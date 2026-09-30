// <copyright file="MailStatusSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Systems/MailStatusSystem.cs
// One-shot status snapshot builder used only by the Options UI / Write Report button.
// This system is disabled and never performs recurring simulation updates.

namespace MagicMail
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Economy;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    internal sealed partial class MailStatusSystem : GameSystemBase
    {
        internal readonly struct FacilityEntry
        {
            public readonly Entity Entity;
            public readonly string PrefabName;
            public readonly string Role;
            public readonly int UpgradeCount;
            public readonly string UpgradeNames;
            public readonly int MailCapacity;
            public readonly int SortingRate;
            public readonly int PostVanCapacity;
            public readonly int PostTruckCapacity;
            public readonly int LocalMail;
            public readonly int UnsortedMail;
            public readonly int OutgoingMail;
            public readonly int StoredTotal;
            public readonly double FillPercent;
            public readonly int LowLocalScans;
            public readonly int LowUnsortedScans;
            public readonly float ProcessingFactor;
            public readonly string FacilityFlags;
            public readonly float AcceptPriority;
            public readonly float DeliverPriority;
            public readonly int OwnedVans;
            public readonly int ActiveVans;
            public readonly int ParkedVans;
            public readonly int OwnedMailTrucks;
            public readonly int GuestMailTrucks;
            public readonly long OwnedTruckLoad;
            public readonly long GuestTruckLoad;
            public readonly int VanDispatches;
            public readonly int TruckDispatches;
            public readonly int OtherDispatches;
            public readonly string DeliverRequest;
            public readonly string ReceiveRequest;
            public readonly string TargetRequest;

            public FacilityEntry(
                Entity entity,
                string prefabName,
                string role,
                int upgradeCount,
                string upgradeNames,
                int mailCapacity,
                int sortingRate,
                int postVanCapacity,
                int postTruckCapacity,
                int localMail,
                int unsortedMail,
                int outgoingMail,
                int storedTotal,
                double fillPercent,
                int lowLocalScans,
                int lowUnsortedScans,
                float processingFactor,
                string facilityFlags,
                float acceptPriority,
                float deliverPriority,
                int ownedVans,
                int activeVans,
                int parkedVans,
                int ownedMailTrucks,
                int guestMailTrucks,
                long ownedTruckLoad,
                long guestTruckLoad,
                int vanDispatches,
                int truckDispatches,
                int otherDispatches,
                string deliverRequest,
                string receiveRequest,
                string targetRequest)
            {
                Entity = entity;
                PrefabName = prefabName;
                Role = role;
                UpgradeCount = upgradeCount;
                UpgradeNames = upgradeNames;
                MailCapacity = mailCapacity;
                SortingRate = sortingRate;
                PostVanCapacity = postVanCapacity;
                PostTruckCapacity = postTruckCapacity;
                LocalMail = localMail;
                UnsortedMail = unsortedMail;
                OutgoingMail = outgoingMail;
                StoredTotal = storedTotal;
                FillPercent = fillPercent;
                LowLocalScans = lowLocalScans;
                LowUnsortedScans = lowUnsortedScans;
                ProcessingFactor = processingFactor;
                FacilityFlags = facilityFlags;
                AcceptPriority = acceptPriority;
                DeliverPriority = deliverPriority;
                OwnedVans = ownedVans;
                ActiveVans = activeVans;
                ParkedVans = parkedVans;
                OwnedMailTrucks = ownedMailTrucks;
                GuestMailTrucks = guestMailTrucks;
                OwnedTruckLoad = ownedTruckLoad;
                GuestTruckLoad = guestTruckLoad;
                VanDispatches = vanDispatches;
                TruckDispatches = truckDispatches;
                OtherDispatches = otherDispatches;
                DeliverRequest = deliverRequest;
                ReceiveRequest = receiveRequest;
                TargetRequest = targetRequest;
            }
        }

        internal readonly struct Snapshot
        {
            public readonly int FacilityCount;
            public readonly int PostOfficeCount;
            public readonly int SortingPostOfficeCount;
            public readonly int SortingFacilityCount;
            public readonly int PostVanCapacityTotal;
            public readonly int PostTruckCapacityTotal;
            public readonly int CityAccumulatedMail;
            public readonly int CityProcessedMail;
            public readonly FacilityEntry[] Facilities;

            public Snapshot(
                int facilityCount,
                int postOfficeCount,
                int sortingPostOfficeCount,
                int sortingFacilityCount,
                int postVanCapacityTotal,
                int postTruckCapacityTotal,
                int cityAccumulatedMail,
                int cityProcessedMail,
                FacilityEntry[] facilities)
            {
                FacilityCount = facilityCount;
                PostOfficeCount = postOfficeCount;
                SortingPostOfficeCount = sortingPostOfficeCount;
                SortingFacilityCount = sortingFacilityCount;
                PostVanCapacityTotal = postVanCapacityTotal;
                PostTruckCapacityTotal = postTruckCapacityTotal;
                CityAccumulatedMail = cityAccumulatedMail;
                CityProcessedMail = cityProcessedMail;
                Facilities = facilities;
            }
        }

        private struct FacilityTraffic
        {
            public int OwnedVans;
            public int ParkedVans;
            public int OwnedMailTrucks;
            public int GuestMailTrucks;
            public long OwnedTruckLoad;
            public long GuestTruckLoad;
            public int VanDispatches;
            public int TruckDispatches;
            public int OtherDispatches;
        }

        private PrefabSystem m_PrefabSystem = null!;
        private SimulationSystem m_SimulationSystem = null!;
        private MailAccumulationSystem? m_MailAccumulationSystem;
        private EntityQuery m_FacilityQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_SimulationSystem = World.GetOrCreateSystemManaged<SimulationSystem>();
            m_MailAccumulationSystem =
                World.GetExistingSystemManaged<MailAccumulationSystem>();

            m_FacilityQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<Game.Prefabs.PrefabRef>(),
                    ComponentType.ReadOnly<Game.Buildings.PostFacility>(),
                    ComponentType.ReadOnly<Resources>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            // BuildSnapshot() is called manually from the Options UI.
            Enabled = false;
        }

        protected override void OnUpdate()
        {
        }

        internal uint GetSimulationFrame()
        {
            return m_SimulationSystem.frameIndex;
        }

        internal Snapshot BuildSnapshot(bool includeDetails)
        {
            using NativeArray<Entity> entities =
                m_FacilityQuery.ToEntityArray(Allocator.Temp);

            int postOfficeCount = 0;
            int sortingPostOfficeCount = 0;
            int sortingFacilityCount = 0;
            int postVanCapacityTotal = 0;
            int postTruckCapacityTotal = 0;

            List<FacilityEntry>? details = includeDetails
                ? new List<FacilityEntry>(entities.Length)
                : null;

            MagicMailSystem? magicSystem =
                World.GetExistingSystemManaged<MagicMailSystem>();

            foreach (Entity entity in entities)
            {
                if (!EntityManager.HasComponent<Game.Prefabs.PrefabRef>(entity))
                {
                    continue;
                }

                Game.Prefabs.PrefabRef prefabRef =
                    EntityManager.GetComponentData<Game.Prefabs.PrefabRef>(entity);

                if (!EntityManager.HasComponent<Game.Prefabs.PostFacilityData>(prefabRef.m_Prefab))
                {
                    continue;
                }

                Game.Prefabs.PostFacilityData prefabData =
                    EntityManager.GetComponentData<Game.Prefabs.PostFacilityData>(prefabRef.m_Prefab);

                Game.Prefabs.PostFacilityData effectiveData = prefabData;
                int upgradeCount = 0;
                string upgradeNames = "none";

                if (EntityManager.HasBuffer<InstalledUpgrade>(entity))
                {
                    DynamicBuffer<InstalledUpgrade> upgrades =
                        EntityManager.GetBuffer<InstalledUpgrade>(entity, true);

                    upgradeCount = upgrades.Length;
                    if (includeDetails)
                    {
                        upgradeNames = GetUpgradeNames(upgrades);
                    }

                    UpgradeUtils.CombineStats(
                        EntityManager,
                        ref effectiveData,
                        upgrades);
                }

                string role = GetRole(effectiveData);
                switch (role)
                {
                    case "POST_OFFICE":
                        postOfficeCount++;
                        break;
                    case "POST_OFFICE_SORTING":
                        sortingPostOfficeCount++;
                        break;
                    default:
                        sortingFacilityCount++;
                        break;
                }

                postVanCapacityTotal += effectiveData.m_PostVanCapacity;
                postTruckCapacityTotal += effectiveData.m_PostTruckCapacity;

                if (!includeDetails || details == null)
                {
                    continue;
                }

                DynamicBuffer<Resources> resources =
                    EntityManager.GetBuffer<Resources>(entity, true);

                int local = EconomyUtils.GetResources(Resource.LocalMail, resources);
                int unsorted = EconomyUtils.GetResources(Resource.UnsortedMail, resources);
                int outgoing = EconomyUtils.GetResources(Resource.OutgoingMail, resources);
                int storedTotal = local + unsorted + outgoing;
                double fillPercent = effectiveData.m_MailCapacity > 0
                    ? storedTotal * 100.0 / effectiveData.m_MailCapacity
                    : 0.0;

                Game.Buildings.PostFacility facility =
                    EntityManager.GetComponentData<Game.Buildings.PostFacility>(entity);

                FacilityTraffic traffic = GetFacilityTraffic(entity);

                int lowLocalScans =
                    magicSystem?.GetPostOfficeLowLocalScanCount(entity) ?? 0;
                int lowUnsortedScans =
                    magicSystem?.GetSortingLowUnsortedScanCount(entity) ?? 0;

                details.Add(new FacilityEntry(
                    entity,
                    GetPrefabName(prefabRef.m_Prefab),
                    role,
                    upgradeCount,
                    upgradeNames,
                    effectiveData.m_MailCapacity,
                    effectiveData.m_SortingRate,
                    effectiveData.m_PostVanCapacity,
                    effectiveData.m_PostTruckCapacity,
                    local,
                    unsorted,
                    outgoing,
                    storedTotal,
                    fillPercent,
                    lowLocalScans,
                    lowUnsortedScans,
                    facility.m_ProcessingFactor,
                    facility.m_Flags.ToString(),
                    facility.m_AcceptMailPriority,
                    facility.m_DeliverMailPriority,
                    traffic.OwnedVans,
                    traffic.OwnedVans - traffic.ParkedVans,
                    traffic.ParkedVans,
                    traffic.OwnedMailTrucks,
                    traffic.GuestMailTrucks,
                    traffic.OwnedTruckLoad,
                    traffic.GuestTruckLoad,
                    traffic.VanDispatches,
                    traffic.TruckDispatches,
                    traffic.OtherDispatches,
                    FormatTransferRequest(facility.m_MailDeliverRequest),
                    FormatTransferRequest(facility.m_MailReceiveRequest),
                    FormatAnyRequest(facility.m_TargetRequest)));
            }

            int accumulated = 0;
            int processed = 0;

            if (m_MailAccumulationSystem == null)
            {
                m_MailAccumulationSystem =
                    World.GetExistingSystemManaged<MailAccumulationSystem>();
            }

            if (m_MailAccumulationSystem != null)
            {
                accumulated = m_MailAccumulationSystem.LastAccumulatedMail;
                processed = m_MailAccumulationSystem.LastProcessedMail;
            }

            return new Snapshot(
                entities.Length,
                postOfficeCount,
                sortingPostOfficeCount,
                sortingFacilityCount,
                postVanCapacityTotal,
                postTruckCapacityTotal,
                accumulated,
                processed,
                details?.ToArray() ?? Array.Empty<FacilityEntry>());
        }

        private FacilityTraffic GetFacilityTraffic(Entity facility)
        {
            FacilityTraffic result = default;

            if (EntityManager.HasBuffer<Game.Vehicles.OwnedVehicle>(facility))
            {
                DynamicBuffer<Game.Vehicles.OwnedVehicle> ownedVehicles =
                    EntityManager.GetBuffer<Game.Vehicles.OwnedVehicle>(facility, true);

                foreach (Game.Vehicles.OwnedVehicle ownedVehicle in ownedVehicles)
                {
                    Entity vehicle = ownedVehicle.m_Vehicle;
                    if (EntityManager.HasComponent<Game.Vehicles.PostVan>(vehicle))
                    {
                        result.OwnedVans++;
                        if (EntityManager.HasComponent<Game.Vehicles.ParkedCar>(vehicle))
                        {
                            result.ParkedVans++;
                        }
                    }
                    else if (EntityManager.HasComponent<Game.Vehicles.DeliveryTruck>(vehicle))
                    {
                        Game.Vehicles.DeliveryTruck truck =
                            EntityManager.GetComponentData<Game.Vehicles.DeliveryTruck>(vehicle);
                        if (IsMailResource(truck.m_Resource))
                        {
                            result.OwnedMailTrucks++;
                            result.OwnedTruckLoad += truck.m_Amount;
                        }
                    }
                }
            }

            if (EntityManager.HasBuffer<Game.Vehicles.GuestVehicle>(facility))
            {
                DynamicBuffer<Game.Vehicles.GuestVehicle> guestVehicles =
                    EntityManager.GetBuffer<Game.Vehicles.GuestVehicle>(facility, true);

                foreach (Game.Vehicles.GuestVehicle guestVehicle in guestVehicles)
                {
                    if (EntityManager.HasComponent<Game.Vehicles.DeliveryTruck>(guestVehicle.m_Vehicle))
                    {
                        Game.Vehicles.DeliveryTruck truck =
                            EntityManager.GetComponentData<Game.Vehicles.DeliveryTruck>(
                                guestVehicle.m_Vehicle);
                        if (IsMailResource(truck.m_Resource))
                        {
                            result.GuestMailTrucks++;
                            result.GuestTruckLoad += truck.m_Amount;
                        }
                    }
                }
            }

            if (EntityManager.HasBuffer<ServiceDispatch>(facility))
            {
                DynamicBuffer<ServiceDispatch> dispatches =
                    EntityManager.GetBuffer<ServiceDispatch>(facility, true);

                foreach (ServiceDispatch dispatch in dispatches)
                {
                    if (EntityManager.HasComponent<PostVanRequest>(dispatch.m_Request))
                    {
                        result.VanDispatches++;
                    }
                    else if (EntityManager.HasComponent<MailTransferRequest>(dispatch.m_Request))
                    {
                        result.TruckDispatches++;
                    }
                    else
                    {
                        result.OtherDispatches++;
                    }
                }
            }

            return result;
        }

        private string FormatTransferRequest(Entity requestEntity)
        {
            if (requestEntity == Entity.Null)
            {
                return "none";
            }

            if (!EntityManager.Exists(requestEntity))
            {
                return $"{requestEntity}:missing";
            }

            if (!EntityManager.HasComponent<MailTransferRequest>(requestEntity))
            {
                return $"{requestEntity}:not-transfer";
            }

            MailTransferRequest request =
                EntityManager.GetComponentData<MailTransferRequest>(requestEntity);

            return $"{requestEntity}:{request.m_Flags}:amount={request.m_Amount}:" +
                   $"priority={request.m_Priority:0.000}:{FormatRequestState(requestEntity)}";
        }

        private string FormatAnyRequest(Entity requestEntity)
        {
            if (requestEntity == Entity.Null)
            {
                return "none";
            }

            if (!EntityManager.Exists(requestEntity))
            {
                return $"{requestEntity}:missing";
            }

            if (EntityManager.HasComponent<PostVanRequest>(requestEntity))
            {
                PostVanRequest vanRequest =
                    EntityManager.GetComponentData<PostVanRequest>(requestEntity);
                return $"{requestEntity}:VAN:{vanRequest.m_Flags}:" +
                       $"priority={vanRequest.m_Priority}:{FormatRequestState(requestEntity)}";
            }

            if (EntityManager.HasComponent<MailTransferRequest>(requestEntity))
            {
                return FormatTransferRequest(requestEntity);
            }

            return $"{requestEntity}:other";
        }

        private string FormatRequestState(Entity requestEntity)
        {
            string state =
                EntityManager.HasComponent<Dispatched>(requestEntity)
                    ? "dispatched"
                    : "waiting";

            if (EntityManager.HasComponent<Game.Pathfind.PathInformation>(requestEntity))
            {
                state += "+path";
            }

            if (EntityManager.HasComponent<ServiceRequest>(requestEntity))
            {
                ServiceRequest serviceRequest =
                    EntityManager.GetComponentData<ServiceRequest>(requestEntity);
                state += $"+fail={serviceRequest.m_FailCount}+cooldown={serviceRequest.m_Cooldown}";
            }

            return state;
        }

        private string GetUpgradeNames(DynamicBuffer<InstalledUpgrade> upgrades)
        {
            if (upgrades.Length == 0)
            {
                return "none";
            }

            StringBuilder names = new();
            for (int i = 0; i < upgrades.Length; i++)
            {
                if (i != 0)
                {
                    names.Append(',');
                }

                Entity upgrade = upgrades[i].m_Upgrade;
                if (EntityManager.HasComponent<Game.Prefabs.PrefabRef>(upgrade))
                {
                    Game.Prefabs.PrefabRef prefabRef =
                        EntityManager.GetComponentData<Game.Prefabs.PrefabRef>(upgrade);
                    names.Append(GetPrefabName(prefabRef.m_Prefab));
                }
                else
                {
                    names.Append(upgrade);
                }
            }

            return names.ToString();
        }

        private string GetPrefabName(Entity prefabEntity)
        {
            return m_PrefabSystem.TryGetPrefab(
                prefabEntity,
                out Game.Prefabs.PrefabBase prefabBase)
                ? prefabBase.name
                : prefabEntity.ToString();
        }

        private static string GetRole(Game.Prefabs.PostFacilityData effectiveData)
        {
            if (effectiveData.m_SortingRate <= 0)
            {
                return "POST_OFFICE";
            }

            if (effectiveData.m_PostVanCapacity > 0)
            {
                return "POST_OFFICE_SORTING";
            }

            return "SORTING_FACILITY";
        }

        private static bool IsMailResource(Resource resource)
        {
            const Resource mailResources =
                Resource.LocalMail | Resource.UnsortedMail | Resource.OutgoingMail;

            return (resource & mailResources) != Resource.NoResource;
        }
    }
}
