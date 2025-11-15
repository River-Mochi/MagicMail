// PostOfficeTweaksSystem.cs
// Main ECS system that tweaks postal facility mail buffers.

namespace PostOfficeTweaks
{
    using System;
    using Colossal.Entities;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    // Hook in Mod.OnLoad:
    //   updateSystem.UpdateBefore<PostOfficeTweaksSystem>(SystemUpdatePhase.GameSimulation);
    public partial class PostOfficeSystem : GameSystemBase
    {
        private EntityQuery m_PostFacilitiesQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
#if DEBUG
            // PostFacilityAISystem uses 256 as well.
            return 256;
#else
            // 32 updates per day ≈ once per 45 in-game minutes.
            return 262144 / 32;
#endif
        }

        public override int GetUpdateOffset(SystemUpdatePhase phase)
        {
            // Original used 48; keeps it in a safe slot before vanilla system.
            return 48;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PostFacilitiesQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<PrefabRef>(),
                    ComponentType.ReadOnly<Game.Buildings.PostFacility>(),
                    ComponentType.ReadWrite<Resources>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            RequireForUpdate(m_PostFacilitiesQuery);

            Mod.log.Info("PostOfficeTweaksSystem created.");
        }

        protected override void OnUpdate()
        {
            var settings = Mod.m_Setting;
            if (settings == null)
            {
                // Settings not ready, don't crash simulation.
                return;
            }

            var entityManager = EntityManager;

            using (var postEntities = m_PostFacilitiesQuery.ToEntityArray(Allocator.Temp))
            {
#if DEBUG
                Mod.log.Info($"PostOfficeTweaksSystem.OnUpdate: {postEntities.Length} post facilities");
#endif
                foreach (var postEntity in postEntities)
                {
                    if (!entityManager.TryGetComponent(postEntity, out PrefabRef prefab))
                    {
                        Mod.log.Warn($"Failed to retrieve PrefabRef for {postEntity}.");
                        continue;
                    }

                    if (!entityManager.TryGetComponent(prefab, out PostFacilityData postFacilityData))
                    {
                        Mod.log.Warn($"Failed to retrieve PostFacilityData for {prefab}.");
                        continue;
                    }

                    if (!entityManager.TryGetBuffer(postEntity, false, out DynamicBuffer<Resources> resourcesBuffer))
                    {
                        Mod.log.Warn($"Failed to retrieve Resources buffer for {postEntity}.");
                        continue;
                    }

                    var sortingRate = postFacilityData.m_SortingRate;
                    var mailCapacity = postFacilityData.m_MailCapacity;

                    var localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
                    var outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
                    var unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
                    var allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                    if (mailCapacity <= 0)
                    {
                        Mod.log.Warn($"Mail capacity is zero or less: {mailCapacity}");
                        continue;
                    }

#if DEBUG
                    Mod.log.Info(
                        $"{postEntity}: SortingRate {sortingRate}, Capacity {mailCapacity}, " +
                        $"TotalMail {allMailCount}, Unsorted {unsortedMailCount}, " +
                        $"Local {localMailCount}, Outgoing {outgoingMailCount}");
#endif

                    if (sortingRate == 0)
                    {
                        // Post Office behaviour
                        HandlePostOffice(
                            postEntity,
                            mailCapacity,
                            settings,
                            ref localMailCount,
                            ref outgoingMailCount,
                            ref unsortedMailCount,
                            ref allMailCount,
                            resourcesBuffer);
                    }
                    else
                    {
                        // Sorting Facility behaviour
                        HandleSortingFacility(
                            postEntity,
                            mailCapacity,
                            settings,
                            ref localMailCount,
                            ref outgoingMailCount,
                            ref unsortedMailCount,
                            ref allMailCount,
                            resourcesBuffer);
                    }
                }
            }
        }

        private static void HandlePostOffice(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            ref int localMailCount,
            ref int outgoingMailCount,
            ref int unsortedMailCount,
            ref int allMailCount,
            DynamicBuffer<Resources> resourcesBuffer)
        {
            // 1) Pull local mail if under threshold
            if (settings.PO_GetLocalMail &&
                localMailCount * 100 / mailCapacity <= settings.PO_GettingThresholdPercentage)
            {
                EconomyUtils.AddResources(
                    Resource.LocalMail,
                    mailCapacity * settings.PO_GettingPercentage / 100,
                    resourcesBuffer);

                var oldLocal = localMailCount;
                localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                Mod.log.Info($"[PO Get] {postEntity}.LocalMail: {oldLocal} -> {localMailCount}");
            }

            // 2) Dispose / clamp overflow mail if over configured ratio
            var overflowRatio = settings.PO_OverflowPercentage / 100.0;

            // NEW:
            // - If FixMailOverflow is ON, we always run this overflow cleanup.
            // - If it is OFF, we fall back to the old PO_DisposeOverflow toggle.
            if ((!settings.FixMailOverflow && !settings.PO_DisposeOverflow) || allMailCount == 0)
            {
                return;
            }

            if ((double)allMailCount / mailCapacity < overflowRatio)
            {
                return;
            }

            EconomyUtils.AddResources(
                Resource.LocalMail,
                (int)(overflowRatio * localMailCount / allMailCount * mailCapacity) - localMailCount,
                resourcesBuffer);

            EconomyUtils.AddResources(
                Resource.OutgoingMail,
                (int)(overflowRatio * outgoingMailCount / allMailCount * mailCapacity) - outgoingMailCount,
                resourcesBuffer);

            EconomyUtils.AddResources(
                Resource.UnsortedMail,
                (int)(overflowRatio * unsortedMailCount / allMailCount * mailCapacity) - unsortedMailCount,
                resourcesBuffer);

            var oldAll = allMailCount;
            localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
            outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
            unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
            allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            Mod.log.Info($"[PO Overflow] {postEntity}.All: {oldAll} -> {allMailCount}");
        }

        private static void HandleSortingFacility(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            ref int localMailCount,
            ref int outgoingMailCount,
            ref int unsortedMailCount,
            ref int allMailCount,
            DynamicBuffer<Resources> resourcesBuffer)
        {
            // 1) Pull unsorted mail if under threshold
            if (settings.PSF_GetUnsortedMail &&
                unsortedMailCount * 100 / mailCapacity <= settings.PSF_GettingThresholdPercentage)
            {
                EconomyUtils.AddResources(
                    Resource.UnsortedMail,
                    mailCapacity * settings.PSF_GettingPercentage / 100,
                    resourcesBuffer);

                var oldUnsorted = unsortedMailCount;
                unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                Mod.log.Info($"[PSF Get] {postEntity}.UnsortedMail: {oldUnsorted} -> {unsortedMailCount}");
            }

            // 2) Dispose overflow mail if over configured ratio
            var overflowRatio = settings.PSF_OverflowPercentage / 100.0;

            if (!settings.PSF_DisposeOverflow || allMailCount == 0)
            {
                return;
            }

            if ((double)allMailCount / mailCapacity < overflowRatio)
            {
                return;
            }

            EconomyUtils.AddResources(
                Resource.LocalMail,
                (int)(overflowRatio * localMailCount / allMailCount * mailCapacity) - localMailCount,
                resourcesBuffer);

            EconomyUtils.AddResources(
                Resource.OutgoingMail,
                (int)(overflowRatio * outgoingMailCount / allMailCount * mailCapacity) - outgoingMailCount,
                resourcesBuffer);

            EconomyUtils.AddResources(
                Resource.UnsortedMail,
                (int)(overflowRatio * unsortedMailCount / allMailCount * mailCapacity) - unsortedMailCount,
                resourcesBuffer);

            var oldAll = allMailCount;
            localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
            outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
            unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
            allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            Mod.log.Info($"[PSF Overflow] {postEntity}.All: {oldAll} -> {allMailCount}");
        }
    }
}
