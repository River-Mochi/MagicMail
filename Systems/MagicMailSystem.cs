// <copyright file="MagicMailSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Systems/MagicMailSystem.cs
// Lets vanilla postal logistics run first, then applies low-frequency rescue behavior:
// - persistent Local/Unsorted mail shortages
// - actual storage overflow using Local + Unsorted + Outgoing mail
// - status counters and city-wide mail stats

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal.Entities;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Low-frequency vanilla-assist system for postal facilities.
    /// Vanilla transfer logic gets the first chance to recover low mail.
    /// Magic Mail intervenes only after a persistent shortage or real overflow.
    /// </summary>
    public partial class MagicMailSystem : GameSystemBase
    {
        private enum FacilityRole
        {
            PostOffice,
            SortingPostOffice,
            SortingFacility,
        }

        private EntityQuery m_PostFacilitiesQuery;

        // Consecutive low scans required before a magic top-up is allowed.
        // Magic Mail scans 32/day while vanilla PostFacilityAISystem updates 1024/day,
        // so vanilla gets many chances to solve the shortage first.
        private const int kUpdatesPerDay = 32;
        private const int kRescueLowScanCount = 3;

        private readonly Dictionary<Entity, int> m_PostOfficeLowLocalScans = new();
        private readonly Dictionary<Entity, int> m_SortingLowUnsortedScans = new();

        // ---- CITY-WIDE MAIL STATS (from MailAccumulationSystem) ----

        private MailAccumulationSystem? m_MailAccumulationSystem;

        internal static int s_LastCityAccumulatedMail;
        internal static int s_LastCityProcessedMail;

        // ---- STATUS FIELDS (read by Setting.Status* properties) ----

        internal static int s_LastFacilityCount;
        internal static int s_LastPostOfficeCount;
        internal static int s_LastSortingPostOfficeCount;
        internal static int s_LastSortingFacilityCount;
        internal static int s_LastPostVanCapacityTotal;
        internal static int s_LastPostTruckCapacityTotal;

        // Names retained for settings/diagnostic compatibility.
        // These now count rescue top-ups, not immediate low-mail pulls.
        internal static int s_LastPostOfficeGets;
        internal static int s_LastSortingGets;
        internal static int s_LastOverflowClamps;

        /// <summary>
        /// Controls how often the system updates for each phase.</summary>
        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 262144 / kUpdatesPerDay;
        }

        /// <summary>
        /// Runs shortly after vanilla PostFacilityAISystem's offset (176).
        /// This gives vanilla the first chance on coincident update cycles.</summary>
        public override int GetUpdateOffset(SystemUpdatePhase phase)
        {
            return 224;
        }

        /// <summary>
        /// Creates the system and builds the entity queries.</summary>
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

            TryResolveMailAccumulationSystem();

#if DEBUG
            LogUtils.Info("MagicMailSystem created.");
#endif
        }

        /// <summary>
        /// Clears rescue history when a city is loaded or created.</summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame))
            {
                m_PostOfficeLowLocalScans.Clear();
                m_SortingLowUnsortedScans.Clear();
                ResetStatus();
            }
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

            EntityManager entityManager = EntityManager;
            bool fixOverflow = settings.FixMailOverflow;

            using NativeArray<Entity> postEntities =
                m_PostFacilitiesQuery.ToEntityArray(Allocator.Temp);

            int facilityCount = postEntities.Length;
            int postOfficeCount = 0;
            int sortingPostOfficeCount = 0;
            int sortingFacilityCount = 0;
            int postOfficeGets = 0;
            int sortingGets = 0;
            int overflowClamps = 0;
            int totalPostVanCapacity = 0;
            int totalPostTruckCapacity = 0;

            foreach (Entity postEntity in postEntities)
            {
                if (!entityManager.TryGetComponent(postEntity, out PrefabRef prefabRef))
                {
                    LogUtils.WarnOnce(
                        "MM.MissingPrefabRef",
                        () => $"Failed to retrieve PrefabRef for {postEntity}.");
                    continue;
                }

                Entity prefab = prefabRef.m_Prefab;

                if (!entityManager.TryGetComponent(prefab, out PostFacilityData prefabData))
                {
                    LogUtils.WarnOnce(
                        "MM.MissingPostFacilityData",
                        () => $"Failed to retrieve PostFacilityData for prefab {prefab}.");
                    continue;
                }

                // Match vanilla: use installed upgrades when deciding the facility's
                // effective capacity, sorting capability, vans, and trucks.
                PostFacilityData effectiveData = prefabData;
                if (entityManager.HasBuffer<InstalledUpgrade>(postEntity))
                {
                    DynamicBuffer<InstalledUpgrade> upgrades =
                        entityManager.GetBuffer<InstalledUpgrade>(postEntity, true);

                    UpgradeUtils.CombineStats(
                        entityManager,
                        ref effectiveData,
                        upgrades);
                }

                int mailCapacity = effectiveData.m_MailCapacity;
                if (mailCapacity <= 0)
                {
                    LogUtils.WarnOnce(
                        "MM.InvalidMailCapacity",
                        () => $"Mail capacity is zero or less: {mailCapacity} (entity {postEntity}).");
                    continue;
                }

                if (!entityManager.HasBuffer<Resources>(postEntity))
                {
                    LogUtils.WarnOnce(
                        "MM.MissingResources",
                        () => $"Post facility {postEntity} has no Resources buffer.");
                    continue;
                }

                DynamicBuffer<Resources> resources =
                    entityManager.GetBuffer<Resources>(postEntity);

                FacilityRole role = GetFacilityRole(effectiveData);

                switch (role)
                {
                    case FacilityRole.PostOffice:
                        postOfficeCount++;
                        HandlePostOffice(
                            postEntity,
                            mailCapacity,
                            role,
                            settings,
                            resources,
                            fixOverflow,
                            ref postOfficeGets,
                            ref overflowClamps);
                        break;

                    case FacilityRole.SortingPostOffice:
                        // Example: Westmont Tower with its underground sorting upgrade.
                        // It sorts mail but still has post vans, so it remains in the
                        // post-office family for Magic Mail rescue behavior.
                        sortingPostOfficeCount++;
                        HandlePostOffice(
                            postEntity,
                            mailCapacity,
                            role,
                            settings,
                            resources,
                            fixOverflow,
                            ref postOfficeGets,
                            ref overflowClamps);
                        break;

                    case FacilityRole.SortingFacility:
                        sortingFacilityCount++;
                        HandleSortingFacility(
                            postEntity,
                            mailCapacity,
                            settings,
                            resources,
                            fixOverflow,
                            ref sortingGets,
                            ref overflowClamps);
                        break;
                }

                // Status uses the same effective stats vanilla sees.
                totalPostVanCapacity += effectiveData.m_PostVanCapacity;
                totalPostTruckCapacity += effectiveData.m_PostTruckCapacity;
            }

            s_LastFacilityCount = facilityCount;
            s_LastPostOfficeCount = postOfficeCount;
            s_LastSortingPostOfficeCount = sortingPostOfficeCount;
            s_LastSortingFacilityCount = sortingFacilityCount;
            s_LastPostVanCapacityTotal = totalPostVanCapacity;
            s_LastPostTruckCapacityTotal = totalPostTruckCapacity;
            s_LastPostOfficeGets = postOfficeGets;
            s_LastSortingGets = sortingGets;
            s_LastOverflowClamps = overflowClamps;

            if (m_MailAccumulationSystem == null)
            {
                TryResolveMailAccumulationSystem();
            }

            if (m_MailAccumulationSystem != null)
            {
                s_LastCityAccumulatedMail =
                    m_MailAccumulationSystem.LastAccumulatedMail;
                s_LastCityProcessedMail =
                    m_MailAccumulationSystem.LastProcessedMail;
            }
        }

        /// <summary>
        /// Handles regular post offices and sorting-upgraded post offices.</summary>
        private void HandlePostOffice(
            Entity postEntity,
            int mailCapacity,
            FacilityRole role,
            Setting settings,
            DynamicBuffer<Resources> resources,
            bool fixOverflow,
            ref int rescueCounter,
            ref int overflowCounter)
        {
            // This entity is not a dedicated sorting facility anymore.
            m_SortingLowUnsortedScans.Remove(postEntity);

            string roleName =
                role == FacilityRole.SortingPostOffice
                    ? "POST_OFFICE_SORTING"
                    : "POST_OFFICE";

            // Fix actual overfill first. If cleanup frees room, give vanilla another
            // chance to import Local Mail before considering a magic top-up.
            bool didOverflow = fixOverflow &&
                ApplyOverflowRescue(
                    postEntity,
                    mailCapacity,
                    settings.PO_OverflowPercentage,
                    roleName,
                    "PO_OVERFLOW",
                    resources);

            if (didOverflow)
            {
                overflowCounter++;
                m_PostOfficeLowLocalScans.Remove(postEntity);
                return;
            }

            if (!settings.PO_GetLocalMail)
            {
                m_PostOfficeLowLocalScans.Remove(postEntity);
                return;
            }

            int localMailCount =
                GetResourceAmount(resources, Resource.LocalMail);

            bool isLow = IsAtOrBelowPercent(
                localMailCount,
                mailCapacity,
                settings.PO_GettingThresholdPercentage);

            if (!ShouldRescue(
                    m_PostOfficeLowLocalScans,
                    postEntity,
                    isLow))
            {
                return;
            }

            int addAmount =
                mailCapacity * settings.PO_GettingPercentage / 100;

            // Zero is a valid user choice; do not manufacture an event for it.
            if (addAmount <= 0)
            {
                m_PostOfficeLowLocalScans.Remove(postEntity);
                return;
            }

#if DEBUG
            int beforeTopUpLocal = localMailCount;
#endif

            AddResourceAmount(
                resources,
                Resource.LocalMail,
                addAmount);

            localMailCount =
                GetResourceAmount(resources, Resource.LocalMail);

            m_PostOfficeLowLocalScans.Remove(postEntity);
            rescueCounter++;

#if DEBUG
            int unsortedMailCount =
                GetResourceAmount(resources, Resource.UnsortedMail);
            int outgoingMailCount =
                GetResourceAmount(resources, Resource.OutgoingMail);

            LogUtils.Info(
                $"[MM EVENT PO_LOCAL_RESCUE] entity={postEntity} role={roleName} " +
                $"L={beforeTopUpLocal}->{localMailCount} " +
                $"U={unsortedMailCount} O={outgoingMailCount} cap={mailCapacity}");
#endif
        }

        /// <summary>
        /// Handles a dedicated sorting facility (sorting capability, no post vans).</summary>
        private void HandleSortingFacility(
            Entity postEntity,
            int mailCapacity,
            Setting settings,
            DynamicBuffer<Resources> resources,
            bool fixOverflow,
            ref int rescueCounter,
            ref int overflowCounter)
        {
            // This entity is not in the post-office family anymore.
            m_PostOfficeLowLocalScans.Remove(postEntity);

            // Current 1.6.2 vanilla sorting storage arithmetic omits Outgoing Mail
            // from one occupied-space calculation. Magic Mail uses L + U + O here.
            bool didOverflow = fixOverflow &&
                ApplyOverflowRescue(
                    postEntity,
                    mailCapacity,
                    settings.PSF_OverflowPercentage,
                    "SORTING_FACILITY",
                    "PSF_OVERFLOW",
                    resources);

            if (didOverflow)
            {
                overflowCounter++;
                m_SortingLowUnsortedScans.Remove(postEntity);
                return;
            }

            if (!settings.PSF_GetUnsortedMail)
            {
                m_SortingLowUnsortedScans.Remove(postEntity);
                return;
            }

            int unsortedMailCount =
                GetResourceAmount(resources, Resource.UnsortedMail);

            bool isLow = IsAtOrBelowPercent(
                unsortedMailCount,
                mailCapacity,
                settings.PSF_GettingThresholdPercentage);

            if (!ShouldRescue(
                    m_SortingLowUnsortedScans,
                    postEntity,
                    isLow))
            {
                return;
            }

            int addAmount =
                mailCapacity * settings.PSF_GettingPercentage / 100;

            if (addAmount <= 0)
            {
                m_SortingLowUnsortedScans.Remove(postEntity);
                return;
            }

#if DEBUG
            int beforeTopUpUnsorted = unsortedMailCount;
#endif

            AddResourceAmount(
                resources,
                Resource.UnsortedMail,
                addAmount);

            unsortedMailCount =
                GetResourceAmount(resources, Resource.UnsortedMail);

            m_SortingLowUnsortedScans.Remove(postEntity);
            rescueCounter++;

#if DEBUG
            int localMailCount =
                GetResourceAmount(resources, Resource.LocalMail);
            int outgoingMailCount =
                GetResourceAmount(resources, Resource.OutgoingMail);

            LogUtils.Info(
                $"[MM EVENT PSF_UNSORTED_RESCUE] entity={postEntity} role=SORTING_FACILITY " +
                $"L={localMailCount} U={beforeTopUpUnsorted}->{unsortedMailCount} " +
                $"O={outgoingMailCount} cap={mailCapacity}");
#endif
        }

        /// <summary>
        /// Trims actual stored mail to the configured threshold.
        /// Counts Local + Unsorted + Outgoing mail instead of relying on vanilla's
        /// sorting-facility free-space arithmetic.</summary>
        private static bool ApplyOverflowRescue(
            Entity postEntity,
            int mailCapacity,
            int overflowPercentage,
            string roleName,
            string eventName,
            DynamicBuffer<Resources> resources)
        {
            int localMailCount =
                GetResourceAmount(resources, Resource.LocalMail);
            int outgoingMailCount =
                GetResourceAmount(resources, Resource.OutgoingMail);
            int unsortedMailCount =
                GetResourceAmount(resources, Resource.UnsortedMail);

            int allMailCount =
                localMailCount + outgoingMailCount + unsortedMailCount;

            if (allMailCount <= 0)
            {
                return false;
            }

            int clampedPercentage =
                math.clamp(overflowPercentage, 0, 100);

            int targetTotal =
                (int)math.round(
                    mailCapacity * clampedPercentage / 100.0);

            // Strictly greater avoids repeated no-op cleanups when storage is
            // already exactly at the configured target.
            if (allMailCount <= targetTotal)
            {
                return false;
            }

#if DEBUG
            int beforeOverflowLocal = localMailCount;
            int beforeOverflowOutgoing = outgoingMailCount;
            int beforeOverflowUnsorted = unsortedMailCount;
            int beforeOverflowAll = allMailCount;
#endif

            int targetLocal =
                (int)math.round(
                    (double)localMailCount / allMailCount * targetTotal);

            int targetOutgoing =
                (int)math.round(
                    (double)outgoingMailCount / allMailCount * targetTotal);

            int targetUnsorted =
                targetTotal - targetLocal - targetOutgoing;

            AddResourceAmount(
                resources,
                Resource.LocalMail,
                targetLocal - localMailCount);

            AddResourceAmount(
                resources,
                Resource.OutgoingMail,
                targetOutgoing - outgoingMailCount);

            AddResourceAmount(
                resources,
                Resource.UnsortedMail,
                targetUnsorted - unsortedMailCount);

#if DEBUG
            localMailCount =
                GetResourceAmount(resources, Resource.LocalMail);
            outgoingMailCount =
                GetResourceAmount(resources, Resource.OutgoingMail);
            unsortedMailCount =
                GetResourceAmount(resources, Resource.UnsortedMail);
            allMailCount =
                localMailCount + outgoingMailCount + unsortedMailCount;

            LogUtils.Info(
                $"[MM EVENT {eventName}] entity={postEntity} role={roleName} " +
                $"L={beforeOverflowLocal}->{localMailCount} " +
                $"U={beforeOverflowUnsorted}->{unsortedMailCount} " +
                $"O={beforeOverflowOutgoing}->{outgoingMailCount} " +
                $"total={beforeOverflowAll}->{allMailCount} cap={mailCapacity}");
#endif

            return true;
        }

        /// <summary>
        /// Classifies facilities the same way the 1.6.1+ vanilla logic needs:
        /// normal post office, sorting-capable post office, or dedicated sorter.</summary>
        private static FacilityRole GetFacilityRole(
            PostFacilityData effectiveData)
        {
            bool sortsMail = effectiveData.m_SortingRate > 0;
            bool hasPostVans = effectiveData.m_PostVanCapacity > 0;

            if (!sortsMail)
            {
                return FacilityRole.PostOffice;
            }

            if (hasPostVans)
            {
                return FacilityRole.SortingPostOffice;
            }

            return FacilityRole.SortingFacility;
        }

        /// <summary>
        /// Returns true after the same facility remains low for the configured
        /// number of consecutive Magic Mail scans.</summary>
        private static bool ShouldRescue(
            Dictionary<Entity, int> lowScanCounts,
            Entity entity,
            bool isLow)
        {
            if (!isLow)
            {
                lowScanCounts.Remove(entity);
                return false;
            }

            lowScanCounts.TryGetValue(entity, out int lowScanCount);
            lowScanCount++;
            lowScanCounts[entity] = lowScanCount;

            return lowScanCount >= kRescueLowScanCount;
        }

        private static bool IsAtOrBelowPercent(
            int amount,
            int capacity,
            int percentage)
        {
            if (capacity <= 0)
            {
                return false;
            }

            int clampedPercentage =
                math.clamp(percentage, 0, 100);

            return (long)amount * 100L <=
                (long)capacity * clampedPercentage;
        }

        // --------------------------------------------------------------------
        // Resource buffer helpers (local replacement for EconomyUtils.*)
        // --------------------------------------------------------------------

        private static int GetResourceAmount(
            DynamicBuffer<Resources> resources,
            Resource resource)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                Resources value = resources[i];
                if (value.m_Resource == resource)
                {
                    return value.m_Amount;
                }
            }

            return 0;
        }

        private static int AddResourceAmount(
            DynamicBuffer<Resources> resources,
            Resource resource,
            int amount)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                Resources value = resources[i];
                if (value.m_Resource == resource)
                {
                    long newAmount = (long)value.m_Amount + amount;
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

        private static void ResetStatus()
        {
            s_LastFacilityCount = 0;
            s_LastPostOfficeCount = 0;
            s_LastSortingPostOfficeCount = 0;
            s_LastSortingFacilityCount = 0;
            s_LastPostVanCapacityTotal = 0;
            s_LastPostTruckCapacityTotal = 0;
            s_LastPostOfficeGets = 0;
            s_LastSortingGets = 0;
            s_LastOverflowClamps = 0;
            s_LastCityAccumulatedMail = 0;
            s_LastCityProcessedMail = 0;
        }

        private void TryResolveMailAccumulationSystem()
        {
            try
            {
                m_MailAccumulationSystem =
                    World.GetExistingSystemManaged<MailAccumulationSystem>();
            }
            catch (System.InvalidOperationException)
            {
                if (m_MailAccumulationSystem == null)
                {
                    LogUtils.WarnOnce(
                        "MM.MailAccumulationSystemMissing",
                        () => "MailAccumulationSystem not found; city mail stats unavailable.");
                }
            }
        }
    }
}
