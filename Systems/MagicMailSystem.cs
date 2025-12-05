// Systems/MagicMailSystem.cs
// Scans postal facilities for magic top-ups + overflow cleanup,
// and exposes city-wide mail stats via MailAccumulationSystem.

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal.Entities;
    using Game;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Simulation system that runs the "magic" mail behaviour:
    /// - Local/unsorted mail top-ups
    /// - Optional overflow cleanup
    /// - Status counters & city-wide mail stats
    /// </summary>
    public partial class MagicMailSystem : GameSystemBase
    {
        private EntityQuery m_PostFacilitiesQuery;

        // ---- CITY-WIDE MAIL STATS (from MailAccumulationSystem) ----

        private MailAccumulationSystem? m_MailAccumulationSystem;

        internal static int s_LastCityAccumulatedMail;
        internal static int s_LastCityProcessedMail;

        // ---- STATUS FIELDS (read by Settings.Status* properties) ----

        internal static int s_LastFacilityCount;
        internal static int s_LastPostOfficeCount;
        internal static int s_LastSortingFacilityCount;
        internal static int s_LastPostVanCapacityTotal;
        internal static int s_LastPostTruckCapacityTotal;
        internal static int s_LastPostOfficeGets;
        internal static int s_LastSortingGets;
        internal static int s_LastOverflowClamps;

        /// <summary>
        /// Returns a short summary of the last facility scan.</summary>
        public static string GetStatusSummary()
        {
            if (s_LastFacilityCount == 0)
            {
                return "No postal facilities processed yet. Open a city and let the simulation run.";
            }

            return
                $"{s_LastPostOfficeCount} post offices | " +
                $"{s_LastPostVanCapacityTotal} post-vans | " +
                $"{s_LastSortingFacilityCount} sort buildings | " +
                $"{s_LastPostTruckCapacityTotal} post trucks";
        }

        /// <summary>
        /// Returns a short summary of the last update activity.</summary>
        public static string GetStatusActivity()
        {
            if (s_LastFacilityCount == 0)
            {
                return "No activity recorded yet.";
            }

            return
                $"{s_LastPostOfficeGets} local-mail pulls | " +
                $"{s_LastSortingGets} unsorted-mail pulls | " +
                $"{s_LastOverflowClamps} overflow cleanups";
        }

        /// <summary>
        /// Returns a summary of city-wide mail accumulation/processing
        /// from the vanilla MailAccumulationSystem.</summary>
        public static string GetStatusCityMail()
        {
            if (s_LastCityAccumulatedMail == 0 && s_LastCityProcessedMail == 0)
            {
                return "City mail stats not available yet. Open a city and let the simulation run.";
            }

            // UI collapses extra spaces; this is just a simple "A | B" display.
            return
                $"  {s_LastCityAccumulatedMail:N0} accumulated  |  " +
                $"{s_LastCityProcessedMail:N0} processed";
        }

        /// <summary>
        /// Controls how often the system updates for each phase.</summary>
        private const int UpdatesPerDay = 64;   // ≈ once per 22.5 in-game minutes.

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
#if DEBUG
            // Matching the vanilla PostFacilityAISystem interval for easier debugging.
            return 256;
#else
            return 262144 / UpdatesPerDay;
#endif
        }

        /// <summary>
        /// Controls when the system runs relative to other systems.</summary>
        public override int GetUpdateOffset(SystemUpdatePhase phase)
        {
            // Keeps this system in a safe slot before the vanilla system.
            return 48;
        }

        /// <summary>
        /// Creates the system and builds the entity queries.</summary>
        protected override void OnCreate()
        {
            base.OnCreate();

            // Query for all operational post facilities with a resource buffer.
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

            // Try to grab the vanilla MailAccumulationSystem so stats can be surfaced.
            TryResolveMailAccumulationSystem();

            Mod.s_Log.Info("MagicMailSystem created.");
        }

        /// <summary>
        /// Per-update simulation logic for all post facilities.</summary>
        protected override void OnUpdate()
        {
            Setting? settings = Mod.Settings;
            if (settings == null)
            {
                return;
            }

            var entityManager = EntityManager;

            bool fixOverflow = settings.FixMailOverflow;

            using NativeArray<Entity> postEntities = m_PostFacilitiesQuery.ToEntityArray(Allocator.Temp);
            var facilityCount = postEntities.Length;
            var postOfficeCount = 0;
            var sortingFacilityCount = 0;
            var postOfficeGets = 0;
            var sortingGets = 0;
            var overflowClamps = 0;
            var totalPostVanCapacity = 0;
            var totalPostTruckCapacity = 0;

#if DEBUG
            Mod.s_Log.Info($"MagicMailSystem.OnUpdate: {facilityCount} post facilities");
#endif

            foreach (var postEntity in postEntities)
            {
                if (!entityManager.TryGetComponent(postEntity, out PrefabRef prefabRef))
                {
                    Mod.s_Log.Warn($"Failed to retrieve PrefabRef for {postEntity}.");
                    continue;
                }

                Entity prefab = prefabRef.m_Prefab;

                if (!entityManager.TryGetComponent(prefab, out PostFacilityData postFacilityData))
                {
                    Mod.s_Log.Warn($"Failed to retrieve PostFacilityData for prefab {prefab}.");
                    continue;
                }

                var mailCapacity = postFacilityData.m_MailCapacity;
                var sortingRate = postFacilityData.m_SortingRate;

                if (!entityManager.HasBuffer<Resources>(postEntity))
                {
                    Mod.s_Log.Warn($"Post facility {postEntity} has no Resources buffer.");
                    continue;
                }

                DynamicBuffer<Resources> resources = entityManager.GetBuffer<Resources>(postEntity);

                if (mailCapacity <= 0)
                {
                    Mod.s_Log.Warn($"Mail capacity is zero or less: {mailCapacity} (entity {postEntity})");
                    continue;
                }

                if (sortingRate == 0)
                {
                    // Post office behavior (no sorting capability).
                    postOfficeCount++;
                    HandlePostOffice(
                        postEntity,
                        mailCapacity,
                        settings,
                        resources,
                        fixOverflow,
                        ref postOfficeGets,
                        ref overflowClamps);
                }
                else
                {
                    // Sorting facility behavior.
                    sortingFacilityCount++;
                    HandleSortingFacility(
                        postEntity,
                        mailCapacity,
                        settings,
                        resources,
                        fixOverflow,
                        ref sortingGets,
                        ref overflowClamps);
                }

                // For status summary, track total capacity after scaling.
                totalPostVanCapacity += postFacilityData.m_PostVanCapacity;
                totalPostTruckCapacity += postFacilityData.m_PostTruckCapacity;
            }

            // Publish status for the Status tab.
            s_LastFacilityCount = facilityCount;
            s_LastPostOfficeCount = postOfficeCount;
            s_LastSortingFacilityCount = sortingFacilityCount;
            s_LastPostVanCapacityTotal = totalPostVanCapacity;
            s_LastPostTruckCapacityTotal = totalPostTruckCapacity;
            s_LastPostOfficeGets = postOfficeGets;
            s_LastSortingGets = sortingGets;
            s_LastOverflowClamps = overflowClamps;

            // Update city-wide mail stats from the vanilla MailAccumulationSystem.
            if (m_MailAccumulationSystem == null)
            {
                TryResolveMailAccumulationSystem();
            }

            if (m_MailAccumulationSystem != null)
            {
                s_LastCityAccumulatedMail = m_MailAccumulationSystem.LastAccumulatedMail;
                s_LastCityProcessedMail = m_MailAccumulationSystem.LastProcessedMail;
            }
        }

        /// <summary>
        /// Handles mail behavior for a pure post office (no sorting).</summary>
        private static void HandlePostOffice(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            DynamicBuffer<Resources> resources,
            bool fixOverflow,
            ref int getCounter,
            ref int overflowCounter)
        {
            var didGet = false;
            var didOverflow = false;

            var localMailCount = GetResourceAmount(resources, Resource.LocalMail);
            var outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
            var unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
            var allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            // 1) Pull local mail if under threshold (magic top-up).
            if (settings.PO_GetLocalMail &&
                mailCapacity > 0 &&
                localMailCount * 100 / mailCapacity <= settings.PO_GettingThresholdPercentage)
            {
                var addAmount = mailCapacity * settings.PO_GettingPercentage / 100;
                var oldLocal = localMailCount;

                AddResourceAmount(resources, Resource.LocalMail, addAmount);

                localMailCount = GetResourceAmount(resources, Resource.LocalMail);
                outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
                unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                didGet = true;
                Mod.s_Log.Info($"[PO Get] {postEntity}.LocalMail: {oldLocal} -> {localMailCount}");
            }

            // 2) Overflow cleanup (global toggle).
            if (!fixOverflow || allMailCount == 0)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            var overflowRatio = settings.PO_OverflowPercentage / 100.0;
            var fillRatio = (double)allMailCount / mailCapacity;

            if (fillRatio < overflowRatio)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            // Clamp each mail type so total storage is near overflowRatio * capacity.
            var targetTotal = (int)math.round(overflowRatio * mailCapacity);
            if (targetTotal < 0)
            {
                targetTotal = 0;
            }

            // Proportional distribution based on current shares.
            if (allMailCount > 0)
            {
                var targetLocal = (int)math.round((double)localMailCount / allMailCount * targetTotal);
                var targetOutgoing = (int)math.round((double)outgoingMailCount / allMailCount * targetTotal);
                var targetUnsorted = targetTotal - targetLocal - targetOutgoing;

                AddResourceAmount(resources, Resource.LocalMail, targetLocal - localMailCount);
                AddResourceAmount(resources, Resource.OutgoingMail, targetOutgoing - outgoingMailCount);
                AddResourceAmount(resources, Resource.UnsortedMail, targetUnsorted - unsortedMailCount);
            }

            var oldAll = allMailCount;
            localMailCount = GetResourceAmount(resources, Resource.LocalMail);
            outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
            unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
            allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            didOverflow = true;
            Mod.s_Log.Info($"[PO Overflow] {postEntity}.All: {oldAll} -> {allMailCount}");

            if (didGet)
            {
                getCounter++;
            }

            if (didOverflow)
            {
                overflowCounter++;
            }
        }

        /// <summary>
        /// Handles mail behavior for a sorting facility.</summary>
        private static void HandleSortingFacility(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            DynamicBuffer<Resources> resources,
            bool fixOverflow,
            ref int getCounter,
            ref int overflowCounter)
        {
            var didGet = false;
            var didOverflow = false;

            var localMailCount = GetResourceAmount(resources, Resource.LocalMail);
            var outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
            var unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
            var allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            // 1) Pull unsorted mail if under threshold (magic top-up).
            if (settings.PSF_GetUnsortedMail &&
                mailCapacity > 0 &&
                unsortedMailCount * 100 / mailCapacity <= settings.PSF_GettingThresholdPercentage)
            {
                var addAmount = mailCapacity * settings.PSF_GettingPercentage / 100;
                var oldUnsorted = unsortedMailCount;

                AddResourceAmount(resources, Resource.UnsortedMail, addAmount);

                localMailCount = GetResourceAmount(resources, Resource.LocalMail);
                outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
                unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                didGet = true;
                Mod.s_Log.Info($"[PSF Get] {postEntity}.UnsortedMail: {oldUnsorted} -> {unsortedMailCount}");
            }

            // 2) Overflow cleanup (global toggle).
            if (!fixOverflow || allMailCount == 0)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            var overflowRatio = settings.PSF_OverflowPercentage / 100.0;
            var fillRatio = (double)allMailCount / mailCapacity;

            if (fillRatio < overflowRatio)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            var targetTotal = (int)math.round(overflowRatio * mailCapacity);
            if (targetTotal < 0)
            {
                targetTotal = 0;
            }

            if (allMailCount > 0)
            {
                var targetLocal = (int)math.round((double)localMailCount / allMailCount * targetTotal);
                var targetOutgoing = (int)math.round((double)outgoingMailCount / allMailCount * targetTotal);
                var targetUnsorted = targetTotal - targetLocal - targetOutgoing;

                AddResourceAmount(resources, Resource.LocalMail, targetLocal - localMailCount);
                AddResourceAmount(resources, Resource.OutgoingMail, targetOutgoing - outgoingMailCount);
                AddResourceAmount(resources, Resource.UnsortedMail, targetUnsorted - unsortedMailCount);
            }

            var oldAll = allMailCount;
            localMailCount = GetResourceAmount(resources, Resource.LocalMail);
            outgoingMailCount = GetResourceAmount(resources, Resource.OutgoingMail);
            unsortedMailCount = GetResourceAmount(resources, Resource.UnsortedMail);
            allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

            didOverflow = true;
            Mod.s_Log.Info($"[PSF Overflow] {postEntity}.All: {oldAll} -> {allMailCount}");

            if (didGet)
            {
                getCounter++;
            }

            if (didOverflow)
            {
                overflowCounter++;
            }
        }

        // --------------------------------------------------------------------
        // Resource buffer helpers (local replacement for EconomyUtils.*)
        // --------------------------------------------------------------------

        private static int GetResourceAmount(DynamicBuffer<Resources> resources, Resource resource)
        {
            for (var i = 0; i < resources.Length; i++)
            {
                var value = resources[i];
                if (value.m_Resource == resource)
                {
                    return value.m_Amount;
                }
            }

            return 0;
        }

        private static int AddResourceAmount(DynamicBuffer<Resources> resources, Resource resource, int amount)
        {
            for (var i = 0; i < resources.Length; i++)
            {
                var value = resources[i];
                if (value.m_Resource == resource)
                {
                    var newAmount = (long)value.m_Amount + amount;
                    if (newAmount < int.MinValue)
                    {
                        newAmount = int.MinValue;
                    }
                    else if (newAmount > int.MaxValue)
                    {
                        newAmount = int.MaxValue;
                    }

                    value.m_Amount = (int)newAmount;
                    resources[i] = value;
                    return value.m_Amount;
                }
            }

            resources.Add(new Resources
            {
                m_Resource = resource,
                m_Amount = amount,
            });

            return amount;
        }

        // --------------------------------------------------------------------
        // Internal helpers
        // --------------------------------------------------------------------

        private void TryResolveMailAccumulationSystem()
        {
            try
            {
                m_MailAccumulationSystem = World.GetExistingSystemManaged<MailAccumulationSystem>();
            }
            catch (System.InvalidOperationException)
            {
                if (m_MailAccumulationSystem == null)
                {
                    Mod.s_Log.Warn("MailAccumulationSystem not found; city mail stats unavailable.");
                }
            }
        }
    }
}
