// Systems/GoPostalSystem.cs
// Main ECS system that tweaks postal facility mail buffers and capacities.

namespace GoPostal
{
    using System;
    using System.Collections.Generic;
    using Colossal.Entities;
    using Colossal.Serialization.Entities;      // Purpose
    using Game;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    /// <summary>
    /// Simulation system that adjusts post office and sorting facility mail buffers,
    /// sorting rate, and postal vehicle capacities.
    /// </summary>
    public partial class GoPostalSystem : GameSystemBase
    {
        // ---- QUERIES ----

        private EntityQuery m_PostFacilitiesQuery;
        private EntityQuery m_PostFacilityDataQuery;
        private EntityQuery m_PostVanDataQuery;

        // ---- CACHED VANILLA DATA ----

        private readonly Dictionary<Entity, PostFacilityData> m_BasePostFacilityData = new();
        private readonly Dictionary<Entity, PostVanData> m_BasePostVanData = new();

        // ---- STATUS FIELDS (read by Settings.Status* properties) ----

        internal static int s_LastFacilityCount;
        internal static int s_LastPostOfficeCount;
        internal static int s_LastSortingFacilityCount;
        internal static int s_LastPostOfficeGets;
        internal static int s_LastSortingGets;
        internal static int s_LastOverflowClamps;

        /// <summary>
        /// Returns a short summary of the last facility scan.
        /// </summary>
        public static string GetStatusSummary()
        {
            if (s_LastFacilityCount == 0)
            {
                return "No postal facilities processed yet. Open a city and let the simulation run.";
            }

            return $"{s_LastPostOfficeCount} post offices and "
                 + $"{s_LastSortingFacilityCount} sorting facilities processed in the last update.";
        }

        /// <summary>
        /// Returns a short summary of the last update activity.
        /// </summary>
        public static string GetStatusActivity()
        {
            if (s_LastFacilityCount == 0)
            {
                return "No activity recorded yet.";
            }

            return $"{s_LastPostOfficeGets} local-mail pulls, "
                 + $"{s_LastSortingGets} unsorted-mail pulls, "
                 + $"{s_LastOverflowClamps} overflow cleanups in the last update.";
        }

        /// <summary>
        /// Controls how often the system updates for each phase.
        /// </summary>
        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
#if DEBUG
            // Matching the vanilla PostFacilityAISystem interval for easier debugging.
            return 256;
#else
            // 32 updates per day ≈ once per 45 in-game minutes.
            return 262144 / 32;
#endif
        }

        /// <summary>
        /// Controls when the system runs relative to other systems.
        /// </summary>
        public override int GetUpdateOffset(SystemUpdatePhase phase)
        {
            // Original used 48; keeps this system in a safe slot before the vanilla system.
            return 48;
        }

        /// <summary>
        /// Creates the system and builds the entity queries.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();

            // Instances: operational post facilities with a resources buffer.
            m_PostFacilitiesQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<PrefabRef>(),
                    ComponentType.ReadOnly<Game.Buildings.PostFacility>(),
                    ComponentType.ReadWrite<Resources>()
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Temp>()
                }
            });

            // Prefab-level data for sorting rate + van/truck capacities.
            m_PostFacilityDataQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<PostFacilityData>()
                }
            });

            // Prefab-level data for per-van mail capacity.
            m_PostVanDataQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<PostVanData>()
                }
            });

            RequireForUpdate(m_PostFacilitiesQuery);

            Mod.s_Log.Info("GoPostalSystem created.");
        }

        /// <summary>
        /// Called when a game is fully loaded (new map, load, etc.).
        /// Used here to clear cached vanilla data between worlds.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_BasePostFacilityData.Clear();
            m_BasePostVanData.Clear();

            s_LastFacilityCount = 0;
            s_LastPostOfficeCount = 0;
            s_LastSortingFacilityCount = 0;
            s_LastPostOfficeGets = 0;
            s_LastSortingGets = 0;
            s_LastOverflowClamps = 0;

            Mod.s_Log.Info($"GoPostalSystem game loading complete: {purpose}, {mode} – caches reset.");
        }

        /// <summary>
        /// Per-update simulation logic for all post facilities.
        /// </summary>
        protected override void OnUpdate()
        {
            Setting? settings = Mod.Settings;
            if (settings == null)
            {
                // Settings not ready; skip without affecting simulation.
                return;
            }

            // First, apply tuning for sorting rate and vehicle capacities (relative to vanilla).
            ApplyFacilityAndVehicleTuning(settings);

            EntityManager entityManager = EntityManager;

            using (NativeArray<Entity> postEntities = m_PostFacilitiesQuery.ToEntityArray(Allocator.Temp))
            {
                int facilityCount = postEntities.Length;
                int postOfficeCount = 0;
                int sortingFacilityCount = 0;
                int postOfficeGets = 0;
                int sortingGets = 0;
                int overflowClamps = 0;

#if DEBUG
                Mod.s_Log.Info($"GoPostalSystem.OnUpdate: {facilityCount} post facilities");
#endif

                foreach (Entity postEntity in postEntities)
                {
                    if (!entityManager.TryGetComponent(postEntity, out PrefabRef prefabRef))
                    {
                        Mod.s_Log.Warn($"Failed to retrieve PrefabRef for {postEntity}.");
                        continue;
                    }

                    if (!entityManager.TryGetComponent(prefabRef, out PostFacilityData postFacilityData))
                    {
                        Mod.s_Log.Warn($"Failed to retrieve PostFacilityData for prefab {prefabRef.m_Prefab}.");
                        continue;
                    }

                    if (!entityManager.TryGetBuffer(postEntity, false, out DynamicBuffer<Resources> resourcesBuffer))
                    {
                        Mod.s_Log.Warn($"Failed to retrieve Resources buffer for {postEntity}.");
                        continue;
                    }

                    int sortingRate = postFacilityData.m_SortingRate;
                    int mailCapacity = postFacilityData.m_MailCapacity;

                    int localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
                    int outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
                    int unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
                    int allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                    if (mailCapacity <= 0)
                    {
                        Mod.s_Log.Warn($"Mail capacity is zero or less: {mailCapacity}");
                        continue;
                    }

#if DEBUG
                    Mod.s_Log.Info(
                        $"{postEntity}: SortingRate {sortingRate}, Capacity {mailCapacity}, "
                        + $"TotalMail {allMailCount}, Unsorted {unsortedMailCount}, "
                        + $"Local {localMailCount}, Outgoing {outgoingMailCount}");
#endif

                    if (sortingRate == 0)
                    {
                        // Pure post office behavior (no sorting capability).
                        postOfficeCount++;
                        HandlePostOffice(
                            postEntity,
                            mailCapacity,
                            settings,
                            ref localMailCount,
                            ref outgoingMailCount,
                            ref unsortedMailCount,
                            ref allMailCount,
                            resourcesBuffer,
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
                            ref localMailCount,
                            ref outgoingMailCount,
                            ref unsortedMailCount,
                            ref allMailCount,
                            resourcesBuffer,
                            ref sortingGets,
                            ref overflowClamps);
                    }
                }

                // Publish status for the Status tab.
                s_LastFacilityCount = facilityCount;
                s_LastPostOfficeCount = postOfficeCount;
                s_LastSortingFacilityCount = sortingFacilityCount;
                s_LastPostOfficeGets = postOfficeGets;
                s_LastSortingGets = sortingGets;
                s_LastOverflowClamps = overflowClamps;
            }
        }

        /// <summary>
        /// Applies tuning to PostFacilityData (sorting rate, van/truck capacity)
        /// and PostVanData (per-van mail capacity), always relative to vanilla values.
        /// </summary>
        private void ApplyFacilityAndVehicleTuning(Setting settings)
        {
            EntityManager entityManager = EntityManager;

            float sortingFactor = settings.PSF_SortingSpeedPercentage / 100f;
            float vanCapacityFactor = settings.VanCapacityPercentage / 100f;
            float truckCapacityFactor = settings.TruckCapacityPercentage / 100f;

            // ---- PostFacilityData: sorting rate + van/truck capacities ----
            using (NativeArray<Entity> facilities = m_PostFacilityDataQuery.ToEntityArray(Allocator.Temp))
            {
                foreach (Entity facility in facilities)
                {
                    if (!entityManager.TryGetComponent(facility, out PostFacilityData current))
                    {
                        continue;
                    }

                    if (!m_BasePostFacilityData.TryGetValue(facility, out PostFacilityData original))
                    {
                        // Cache vanilla data on first sight.
                        original = current;
                        m_BasePostFacilityData.Add(facility, original);
                    }

                    PostFacilityData adjusted = original;

                    // Only facilities with sorting capability care about sorting speed.
                    if (original.m_SortingRate > 0)
                    {
                        adjusted.m_SortingRate = (int)Math.Round(original.m_SortingRate * sortingFactor);
                    }

                    // Van capacity (how many vans per facility).
                    if (original.m_PostVanCapacity > 0)
                    {
                        int newVanCapacity = (int)Math.Round(original.m_PostVanCapacity * vanCapacityFactor);
                        adjusted.m_PostVanCapacity = Math.Max(0, newVanCapacity);
                    }

                    // Truck capacity (how many post trucks per facility).
                    if (original.m_PostTruckCapacity > 0)
                    {
                        int newTruckCapacity = (int)Math.Round(original.m_PostTruckCapacity * truckCapacityFactor);
                        adjusted.m_PostTruckCapacity = Math.Max(0, newTruckCapacity);
                    }

                    entityManager.SetComponentData(facility, adjusted);
                }
            }

            // ---- PostVanData: per-van mail capacity ----
            using (NativeArray<Entity> vans = m_PostVanDataQuery.ToEntityArray(Allocator.Temp))
            {
                foreach (Entity van in vans)
                {
                    if (!entityManager.TryGetComponent(van, out PostVanData current))
                    {
                        continue;
                    }

                    if (!m_BasePostVanData.TryGetValue(van, out PostVanData original))
                    {
                        // Cache vanilla data on first sight.
                        original = current;
                        m_BasePostVanData.Add(van, original);
                    }

                    PostVanData adjusted = original;
                    int newMailCapacity = (int)Math.Round(original.m_MailCapacity * vanCapacityFactor);
                    adjusted.m_MailCapacity = Math.Max(1, newMailCapacity);

                    entityManager.SetComponentData(van, adjusted);
                }
            }
        }

        /// <summary>
        /// Handles mail behavior for a pure post office (no sorting).
        /// </summary>
        private static void HandlePostOffice(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            ref int localMailCount,
            ref int outgoingMailCount,
            ref int unsortedMailCount,
            ref int allMailCount,
            DynamicBuffer<Resources> resourcesBuffer,
            ref int getCounter,
            ref int overflowCounter)
        {
            bool didGet = false;
            bool didOverflow = false;

            // 1) Pull local mail if under threshold.
            if (settings.PO_GetLocalMail &&
                localMailCount * 100 / mailCapacity <= settings.PO_GettingThresholdPercentage)
            {
                int addAmount = mailCapacity * settings.PO_GettingPercentage / 100;
                EconomyUtils.AddResources(Resource.LocalMail, addAmount, resourcesBuffer);

                int oldLocal = localMailCount;
                localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                didGet = true;
                Mod.s_Log.Info($"[PO Get] {postEntity}.LocalMail: {oldLocal} -> {localMailCount}");
            }

            // 2) Dispose or clamp overflow mail if above configured ratio.
            double overflowRatio = settings.PO_OverflowPercentage / 100.0;

            // Phase 1:
            // - If FixMailOverflow is ON, always run overflow cleanup at or above threshold.
            // - If FixMailOverflow is OFF, respect the legacy PO_DisposeOverflow toggle.
            if ((!settings.FixMailOverflow && !settings.PO_DisposeOverflow) || allMailCount == 0)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            double fillRatio = (double)allMailCount / mailCapacity;
            if (fillRatio < overflowRatio)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            // Clamp each mail type so total storage is near overflowRatio * capacity.
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

            int oldAll = allMailCount;
            localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
            outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
            unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
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
        /// Handles mail behavior for a sorting facility.
        /// </summary>
        private static void HandleSortingFacility(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            ref int localMailCount,
            ref int outgoingMailCount,
            ref int unsortedMailCount,
            ref int allMailCount,
            DynamicBuffer<Resources> resourcesBuffer,
            ref int getCounter,
            ref int overflowCounter)
        {
            bool didGet = false;
            bool didOverflow = false;

            // 1) Pull unsorted mail if under threshold.
            if (settings.PSF_GetUnsortedMail &&
                unsortedMailCount * 100 / mailCapacity <= settings.PSF_GettingThresholdPercentage)
            {
                int addAmount = mailCapacity * settings.PSF_GettingPercentage / 100;
                EconomyUtils.AddResources(Resource.UnsortedMail, addAmount, resourcesBuffer);

                int oldUnsorted = unsortedMailCount;
                unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
                allMailCount = localMailCount + outgoingMailCount + unsortedMailCount;

                didGet = true;
                Mod.s_Log.Info($"[PSF Get] {postEntity}.UnsortedMail: {oldUnsorted} -> {unsortedMailCount}");
            }

            // 2) Dispose overflow mail if above configured ratio.
            double overflowRatio = settings.PSF_OverflowPercentage / 100.0;

            if (!settings.PSF_DisposeOverflow || allMailCount == 0)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            double fillRatio = (double)allMailCount / mailCapacity;
            if (fillRatio < overflowRatio)
            {
                if (didGet)
                {
                    getCounter++;
                }

                return;
            }

            // Clamp each mail type so total storage is near overflowRatio * capacity.
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

            int oldAll = allMailCount;
            localMailCount = EconomyUtils.GetResources(Resource.LocalMail, resourcesBuffer);
            outgoingMailCount = EconomyUtils.GetResources(Resource.OutgoingMail, resourcesBuffer);
            unsortedMailCount = EconomyUtils.GetResources(Resource.UnsortedMail, resourcesBuffer);
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
    }
}
