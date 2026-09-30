// <copyright file="MailSettings.Status.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Settings/MailSettings.Status.cs
// Status and About UI for MagicMail [MM].

namespace MagicMail
{
    using System;
    using Colossal.Localization;
    using CS2Shared.RiverMochi;
    using Game.SceneFlow;
    using Game.Settings;
    using UnityEngine;

    /// <summary>
    /// Status and About UI bindings for MagicMail [MM].</summary>
    public partial class MailSettings
    {
        // ---- LINKS ----

        private const string kUrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";
        private const string kUrlDiscord =
            "https://discord.gg/gwXgvtyhjc";

        // ---- Localization keys for Status text ----
        private const string kStatusNoFacilitiesKey = "MM_STATUS_NO_FACILITIES";
        private const string kStatusNoActivityKey = "MM_STATUS_NO_ACTIVITY";
        private const string kStatusSummaryKey = "MM_STATUS_SUMMARY";
        private const string kStatusVehiclesKey = "MM_STATUS_VEHICLES";
        private const string kStatusActivityKey = "MM_STATUS_ACTIVITY";
        private const string kStatusCityMailNotReadyKey = "MM_STATUS_CITY_MAIL_NOT_READY";
        private const string kStatusCityMailKey = "MM_STATUS_CITY_MAIL";

        // --------------------------------------------------------------------
        // STATUS TAB (localized with keys, data from MagicMailSystem)
        // --------------------------------------------------------------------

        [SettingsUISection(StatusTab, StatusSummaryGroup)]
        public string StatusFacilitySummary
        {
            get
            {
                MailStatus.RefreshIfNeeded();

                if (MailStatus.s_LastFacilityCount == 0)
                {
                    return L(
                        kStatusNoFacilitiesKey,
                        "No postal facilities found. Open a city, then open Status again.");
                }

                return string.Format(
                    L(
                        kStatusSummaryKey,
                        "Post offices: {0} | Sorting post offices: {1} | Sorting facilities: {2}"),
                    MailStatus.s_LastPostOfficeCount,
                    MailStatus.s_LastSortingPostOfficeCount,
                    MailStatus.s_LastSortingFacilityCount);
            }
        }

        [SettingsUISection(StatusTab, StatusSummaryGroup)]
        public string StatusVehicleSummary
        {
            get
            {
                MailStatus.RefreshIfNeeded();

                if (MailStatus.s_LastFacilityCount == 0)
                {
                    return string.Empty;
                }

                return string.Format(
                    L(
                        kStatusVehiclesKey,
                        "Post-vans: {0} | Post trucks: {1}"),
                    MailStatus.s_LastPostVanCapacityTotal,
                    MailStatus.s_LastPostTruckCapacityTotal);
            }
        }

        [SettingsUISection(StatusTab, StatusSummaryGroup)]
        public string StatusCityMailSummary
        {
            get
            {
                MailStatus.RefreshIfNeeded();

                if (MailStatus.s_LastCityAccumulatedMail == 0 &&
                    MailStatus.s_LastCityProcessedMail == 0)
                {
                    return L(
                        kStatusCityMailNotReadyKey,
                        "City mail stats not available yet. Open a city and let the simulation run.");
                }

                return string.Format(
                    L(
                        kStatusCityMailKey,
                        "{0} accumulated | {1} processed"),
                    MailStatus.s_LastCityAccumulatedMail.ToString("N0"),
                    MailStatus.s_LastCityProcessedMail.ToString("N0"));
            }
        }

        [SettingsUISection(StatusTab, StatusActivityGroup)]
        public string StatusLastActivity
        {
            get
            {
                MailStatus.RefreshIfNeeded();

                if (MailStatus.s_LastFacilityCount == 0)
                {
                    return L(
                        kStatusNoActivityKey,
                        "No activity recorded yet.");
                }

                return string.Format(
                    L(
                        kStatusActivityKey,
                        "{0} local rescues | {1} unsorted rescues | {2} overflow cleanups"),
                    MailStatus.s_LastPostOfficeGets,
                    MailStatus.s_LastSortingGets,
                    MailStatus.s_LastOverflowClamps);
            }
        }

        [SettingsUIButtonGroup(StatusActivityGroup)]
        [SettingsUIButton]
        [SettingsUISection(StatusTab, StatusActivityGroup)]
        public bool WriteReport
        {
            set
            {
                if (!value)
                {
                    return;
                }

                // One-time detailed scan while Options is open/paused.
                // No recurring Release logging is enabled by this button.
                MailStatus.RefreshNow(writeToLog: true);
            }
        }

        [SettingsUIButtonGroup(StatusActivityGroup)]
        [SettingsUIButton]
        [SettingsUISection(StatusTab, StatusActivityGroup)]
        public bool OpenLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ShellOpen.OpenModLogOrLogsFolder();
            }
        }

        // --------------------------------------------------------------------
        // ABOUT TAB: INFO
        // --------------------------------------------------------------------

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModNameDisplay => $"{Mod.ModName} {Mod.ModTag}";

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModVersionDisplay => $"{Mod.ModVersion} {Mod.BuildDisplayName}";

        // --------------------------------------------------------------------
        // ABOUT TAB: LINKS
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenParadox
        {
            set
            {
                if (!value)
                {
                    return;
                }

                TryOpenUrl(kUrlParadox);
            }
        }

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenDiscord
        {
            set
            {
                if (!value)
                {
                    return;
                }

                TryOpenUrl(kUrlDiscord);
            }
        }


        // --------------------------------------------------------------------
        // HELPERS
        // --------------------------------------------------------------------

        /// <summary>
        /// Looks up a localized string by key, falling back to English text if missing.</summary>
        private static string L(string key, string fallback)
        {
            LocalizationDictionary? dict = GameManager.instance?.localizationManager?.activeDictionary;
            if (dict != null &&
                dict.TryGetValue(key, out string? value) &&
                !string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return fallback;
        }

        /// <summary>
        /// Opens a URL via Unity’s Application.OpenURL, ignoring failures.</summary>
        private static void TryOpenUrl(string url)
        {
            try
            {
                Application.OpenURL(url);
            }
            catch (Exception)
            {
                // Silent failure to avoid disrupting the Options UI.
            }
        }
    }
}
