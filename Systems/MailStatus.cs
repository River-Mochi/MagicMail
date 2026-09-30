// <copyright file="MailStatus.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Systems/MailStatus.cs
// Options-only cached status for Magic Mail.
// No recurring simulation work: snapshots are built only when Options reads Status
// or when the player explicitly clicks Write Report.

namespace MagicMail
{
    using System.Text;
    using CS2Shared.RiverMochi;
    using Game.SceneFlow;
    using Unity.Entities;

    internal static class MailStatus
    {
        internal static int s_LastFacilityCount;
        internal static int s_LastPostOfficeCount;
        internal static int s_LastSortingPostOfficeCount;
        internal static int s_LastSortingFacilityCount;
        internal static int s_LastPostVanCapacityTotal;
        internal static int s_LastPostTruckCapacityTotal;
        internal static int s_LastCityAccumulatedMail;
        internal static int s_LastCityProcessedMail;
        internal static int s_LastPostOfficeGets;
        internal static int s_LastSortingGets;
        internal static int s_LastOverflowClamps;

        private static bool s_HasSnapshot;
        private static bool s_Dirty = true;
        private static bool s_WasInGame;
        private static uint s_LastSimulationFrame = uint.MaxValue;

        internal static void MarkDirty()
        {
            s_Dirty = true;
        }

        internal static void RefreshIfNeeded()
        {
            if (!TryGetStatusSystem(out MailStatusSystem system))
            {
                ResetUi();
                return;
            }

            uint simulationFrame = system.GetSimulationFrame();

            // Options pauses the city. All Status rows therefore reuse the same
            // snapshot until the city actually runs and the simulation frame changes.
            if (s_HasSnapshot &&
                !s_Dirty &&
                s_LastSimulationFrame == simulationFrame)
            {
                return;
            }

            MailStatusSystem.Snapshot snapshot =
                system.BuildSnapshot(includeDetails: false);

            ApplySnapshot(snapshot, simulationFrame);
        }

        internal static void RefreshNow(bool writeToLog)
        {
            if (!TryGetStatusSystem(out MailStatusSystem system))
            {
                ResetUi();

                if (writeToLog)
                {
                    LogUtils.Info(
                        $"{Mod.ModTag} Status report unavailable: no city is loaded.");
                }

                return;
            }

            uint simulationFrame = system.GetSimulationFrame();
            MailStatusSystem.Snapshot snapshot =
                system.BuildSnapshot(includeDetails: writeToLog);

            ApplySnapshot(snapshot, simulationFrame);

            if (writeToLog)
            {
                LogUtils.Info(BuildReportText(snapshot));
            }
        }

        private static void ApplySnapshot(
            MailStatusSystem.Snapshot snapshot,
            uint simulationFrame)
        {
            s_LastFacilityCount = snapshot.FacilityCount;
            s_LastPostOfficeCount = snapshot.PostOfficeCount;
            s_LastSortingPostOfficeCount = snapshot.SortingPostOfficeCount;
            s_LastSortingFacilityCount = snapshot.SortingFacilityCount;
            s_LastPostVanCapacityTotal = snapshot.PostVanCapacityTotal;
            s_LastPostTruckCapacityTotal = snapshot.PostTruckCapacityTotal;
            s_LastCityAccumulatedMail = snapshot.CityAccumulatedMail;
            s_LastCityProcessedMail = snapshot.CityProcessedMail;

            // Rescue activity comes from the rescue engine itself. Reading these
            // counters adds no scan or simulation work.
            s_LastPostOfficeGets = MagicMailSystem.s_LastPostOfficeGets;
            s_LastSortingGets = MagicMailSystem.s_LastSortingGets;
            s_LastOverflowClamps = MagicMailSystem.s_LastOverflowClamps;

            s_HasSnapshot = true;
            s_Dirty = false;
            s_LastSimulationFrame = simulationFrame;
        }

        private static string BuildReportText(MailStatusSystem.Snapshot snapshot)
        {
            StringBuilder log = new(6000);

            log.AppendLine($"{Mod.ModTag} Status Report");
            log.AppendLine($"Build: v{Mod.ModVersion} {Mod.BuildDisplayName}");

            Setting? setting = Mod.Settings;
            if (setting != null)
            {
                log.AppendLine(
                    "Settings: " +
                    $"localRescue={setting.PO_GetLocalMail} " +
                    $"localThreshold={setting.PO_GettingThresholdPercentage}% " +
                    $"localAmount={setting.PO_GettingPercentage}% | " +
                    $"overflow={setting.FixMailOverflow} " +
                    $"POoverflow={setting.PO_OverflowPercentage}% " +
                    $"sortingOverflow={setting.PSF_OverflowPercentage}% | " +
                    $"unsortedRescue={setting.PSF_GetUnsortedMail} " +
                    $"unsortedThreshold={setting.PSF_GettingThresholdPercentage}% " +
                    $"unsortedAmount={setting.PSF_GettingPercentage}%");

                log.AppendLine(
                    "Tuning: " +
                    $"sortingSpeed={setting.PSF_SortingSpeedPercentage}% " +
                    $"sortingStorage={setting.PSF_StorageCapacityPercentage}% | " +
                    $"changeCapacity={setting.ChangeCapacity} " +
                    $"vanLoad={setting.PostVanMailLoadPercentage}% " +
                    $"vanFleet={setting.PostVanFleetSizePercentage}% " +
                    $"truckFleet={setting.TruckCapacityPercentage}%");
            }

            log.AppendLine(
                "Status: " +
                $"facilities={snapshot.FacilityCount} " +
                $"postOffices={snapshot.PostOfficeCount} " +
                $"sortingPostOffices={snapshot.SortingPostOfficeCount} " +
                $"sortingFacilities={snapshot.SortingFacilityCount} " +
                $"postVans={snapshot.PostVanCapacityTotal} " +
                $"postTrucks={snapshot.PostTruckCapacityTotal}");

            log.AppendLine(
                "City mail: " +
                $"accumulated={snapshot.CityAccumulatedMail} " +
                $"processed={snapshot.CityProcessedMail}");

            log.AppendLine(
                "Last rescue pass: " +
                $"localRescues={MagicMailSystem.s_LastPostOfficeGets} " +
                $"unsortedRescues={MagicMailSystem.s_LastSortingGets} " +
                $"overflowCleanups={MagicMailSystem.s_LastOverflowClamps}");

            if (snapshot.Facilities.Length == 0)
            {
                log.AppendLine("Facilities: none");
                return log.ToString().TrimEnd();
            }

            log.AppendLine("Facilities:");

            for (int i = 0; i < snapshot.Facilities.Length; i++)
            {
                MailStatusSystem.FacilityEntry f = snapshot.Facilities[i];

                log.AppendLine(
                    $"  [{i + 1}] entity={f.Entity} prefab=\"{f.PrefabName}\" " +
                    $"role={f.Role} upgrades={f.UpgradeCount}[{f.UpgradeNames}]");

                log.AppendLine(
                    "      stats: " +
                    $"capacity={f.MailCapacity} sortingRate={f.SortingRate} " +
                    $"vans={f.PostVanCapacity} trucks={f.PostTruckCapacity} " +
                    $"processing={f.ProcessingFactor:0.000}");

                log.AppendLine(
                    "      storage: " +
                    $"L={f.LocalMail} U={f.UnsortedMail} O={f.OutgoingMail} " +
                    $"total={f.StoredTotal} fill={f.FillPercent:0.0}%");

                log.AppendLine(
                    "      rescueState: " +
                    $"lowLocalScans={f.LowLocalScans} " +
                    $"lowUnsortedScans={f.LowUnsortedScans}");

                log.AppendLine(
                    "      facility: " +
                    $"flags={f.FacilityFlags} " +
                    $"acceptPriority={f.AcceptPriority:0.000} " +
                    $"deliverPriority={f.DeliverPriority:0.000}");

                log.AppendLine(
                    "      traffic: " +
                    $"ownedVans={f.OwnedVans} activeVans={f.ActiveVans} " +
                    $"parkedVans={f.ParkedVans} ownedMailTrucks={f.OwnedMailTrucks} " +
                    $"guestMailTrucks={f.GuestMailTrucks} " +
                    $"ownedTruckLoad={f.OwnedTruckLoad} guestTruckLoad={f.GuestTruckLoad} " +
                    $"dispatchVan={f.VanDispatches} dispatchTruck={f.TruckDispatches} " +
                    $"dispatchOther={f.OtherDispatches}");

                log.AppendLine(
                    "      requests: " +
                    $"deliverToFacility={f.DeliverRequest} " +
                    $"receiveFromFacility={f.ReceiveRequest} " +
                    $"target={f.TargetRequest}");
            }

            return log.ToString().TrimEnd();
        }

        private static bool TryGetStatusSystem(out MailStatusSystem system)
        {
            system = null!;

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                s_WasInGame = false;
                return false;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                s_WasInGame = false;
                return false;
            }

            if (!s_WasInGame)
            {
                s_WasInGame = true;
                s_HasSnapshot = false;
                s_Dirty = true;
                s_LastSimulationFrame = uint.MaxValue;
            }

            system = world.GetOrCreateSystemManaged<MailStatusSystem>();
            return system != null;
        }

        private static void ResetUi()
        {
            s_LastFacilityCount = 0;
            s_LastPostOfficeCount = 0;
            s_LastSortingPostOfficeCount = 0;
            s_LastSortingFacilityCount = 0;
            s_LastPostVanCapacityTotal = 0;
            s_LastPostTruckCapacityTotal = 0;
            s_LastCityAccumulatedMail = 0;
            s_LastCityProcessedMail = 0;
            s_LastPostOfficeGets = 0;
            s_LastSortingGets = 0;
            s_LastOverflowClamps = 0;

            s_HasSnapshot = false;
            s_Dirty = true;
            s_LastSimulationFrame = uint.MaxValue;
        }
    }
}
