// <copyright file="MailCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Systems/MailCapacitySystem.cs
// One-shot system: applies van + facility capacity multipliers when settings change.
// Uses PrefabBase authoring values as vanilla baselines so scaling never stacks.

namespace MagicMail
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Updates post van and postal facility capacities when MagicMail sliders change.
    /// Driven by Setting.Apply() and then disables itself again.
    /// </summary>
    public sealed partial class MailCapacitySystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private EntityQuery m_PostFacilitiesQuery;
        private EntityQuery m_PostVansQuery;

        private struct FacilityBaseline
        {
            public int PostVanCapacity;
            public int PostTruckCapacity;
            public int MailCapacity;
            public int SortingRate;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            // Cached prefab query: postal facility prefab entities.
            m_PostFacilitiesQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData>()
                .WithAllRW<PostFacilityData>()
                .Build();

            // Cached prefab query: post van prefab entities.
            m_PostVansQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData>()
                .WithAllRW<PostVanData>()
                .Build();

            RequireForUpdate(m_PostFacilitiesQuery);
            RequireForUpdate(m_PostVansQuery);

            // Run only when settings change or after a city load.
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (isRealGame)
            {
                Enabled = true;
            }
        }

        /// <summary>
        /// Runs immediately once enabled, then disables itself.
        /// </summary>
        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 1;
        }

        protected override void OnUpdate()
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            Setting? settings = Mod.Settings;
            if (settings == null)
            {
                Enabled = false;
                return;
            }

            // ChangeCapacity controls postal vehicle capacity sliders only.
            bool changeVehicleCapacity = settings.ChangeCapacity;

            int vanMailPercent = math.clamp(settings.PostVanMailLoadPercentage, 100, 1000);
            int vanFleetPercent = math.clamp(settings.PostVanFleetSizePercentage, 50, 1000);
            int truckFleetPercent = math.clamp(settings.TruckCapacityPercentage, 50, 1000);

            // Sorting sliders are in the sorting section and should work independently.
            int sortingSpeedPercent = math.clamp(settings.PSF_SortingSpeedPercentage, 50, 500);
            int sortingStoragePercent = math.clamp(settings.PSF_StorageCapacityPercentage, 50, 500);

            if (!changeVehicleCapacity)
            {
                vanMailPercent = 100;
                vanFleetPercent = 100;
                truckFleetPercent = 100;
            }

            ApplyPostVanPayload(vanMailPercent);
            ApplyPostFacilityValues(
                vanFleetPercent,
                truckFleetPercent,
                sortingSpeedPercent,
                sortingStoragePercent);

            // Back to disabled until Setting.Apply() wakes us again.
            Enabled = false;
        }

        private void ApplyPostVanPayload(int vanMailPercent)
        {
            foreach ((RefRW<PostVanData> vanRef, Entity prefabEntity) in SystemAPI
                         .Query<RefRW<PostVanData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref PostVanData vanData = ref vanRef.ValueRW;

                if (!TryGetPostVanBaseMailCapacity(prefabEntity, out int baseMailCapacity))
                {
                    continue;
                }

                int newMailCapacity = ScalePercentMin1(baseMailCapacity, vanMailPercent);
                if (vanData.m_MailCapacity != newMailCapacity)
                {
                    vanData.m_MailCapacity = newMailCapacity;
                }
            }
        }

        private void ApplyPostFacilityValues(
            int vanFleetPercent,
            int truckFleetPercent,
            int sortingSpeedPercent,
            int sortingStoragePercent)
        {
            foreach ((RefRW<PostFacilityData> facilityRef, Entity prefabEntity) in SystemAPI
                         .Query<RefRW<PostFacilityData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref PostFacilityData data = ref facilityRef.ValueRW;

                if (!TryGetPostFacilityBaseline(prefabEntity, out FacilityBaseline baseline))
                {
                    continue;
                }

                bool isSortingFacility = baseline.SortingRate > 0;

                int newPostVanCapacity =
                    ScalePercentKeepZero(baseline.PostVanCapacity, vanFleetPercent);

                int newPostTruckCapacity =
                    ScalePercentKeepZero(baseline.PostTruckCapacity, truckFleetPercent);

                int newSortingRate = isSortingFacility
                    ? ScalePercentMin1(baseline.SortingRate, sortingSpeedPercent)
                    : baseline.SortingRate;

                // Sorting storage slider should only affect sorting facilities.
                // This avoids accidentally scaling normal post office storage.
                int newMailCapacity = isSortingFacility
                    ? ScalePercentMin1(baseline.MailCapacity, sortingStoragePercent)
                    : baseline.MailCapacity;

                if (data.m_PostVanCapacity != newPostVanCapacity)
                {
                    data.m_PostVanCapacity = newPostVanCapacity;
                }

                if (data.m_PostTruckCapacity != newPostTruckCapacity)
                {
                    data.m_PostTruckCapacity = newPostTruckCapacity;
                }

                if (data.m_SortingRate != newSortingRate)
                {
                    data.m_SortingRate = newSortingRate;
                }

                if (data.m_MailCapacity != newMailCapacity)
                {
                    data.m_MailCapacity = newMailCapacity;
                }
            }
        }

        private bool TryGetPostVanBaseMailCapacity(Entity prefabEntity, out int baseMailCapacity)
        {
            baseMailCapacity = 0;

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase))
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.PostVan postVan))
            {
                return false;
            }

            baseMailCapacity = postVan.m_MailCapacity;
            return baseMailCapacity > 0;
        }

       private bool TryGetPostFacilityBaseline(Entity prefabEntity, out FacilityBaseline baseline)
        {
            baseline = default;

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase))
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.PostFacility postFacility))
            {
                return false;
            }

            baseline = new FacilityBaseline
            {
                PostVanCapacity = postFacility.m_PostVanCapacity,
                PostTruckCapacity = postFacility.m_PostTruckCapacity,
                MailCapacity = postFacility.m_MailStorageCapacity,
                SortingRate = postFacility.m_SortingRate,
            };

            return true;
        }

        private static int ScalePercentMin1(int baseValue, int percent)
        {
            if (baseValue <= 0)
            {
                return 0;
            }

            return math.max(1, (int)math.round(baseValue * percent / 100f));
        }

        private static int ScalePercentKeepZero(int baseValue, int percent)
        {
            if (baseValue <= 0)
            {
                return 0;
            }

            return math.max(1, (int)math.round(baseValue * percent / 100f));
        }
    }
}
