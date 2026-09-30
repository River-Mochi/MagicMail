// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleEN.cs
// English locale en-US

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// English localization source for Magic Mail [MM].</summary>
    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the English locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all English localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "About" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Vanilla Assist" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Post vans & trucks" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Dedicated sorting facility" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Reset" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "City scan" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Last update" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Rescue low local mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Lets the game try normal mail transfers first.\n" +
                    "If local mail stays very low for several scans, Magic Mail adds a small rescue top-up.\n" +
                    "Also applies to a post office with a sorting upgrade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Local mail rescue threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Marks local mail as low when it reaches this percentage of the building's max storage.\n" +
                    "The rescue only runs if it stays low across several scans."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Local mail rescue amount" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "How much local mail to add when the rescue finally runs.\n" +
                    "Amount is a percentage of the building's max storage."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Rescue mail overflow" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "If a postal facility gets too full, Magic Mail trims stored mail back to the chosen level.\n" +
                    "It counts local + unsorted + outgoing mail, helping catch overfill the game can miscount.\n" +
                    "Disable this for pure vanilla behavior."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Post office overflow threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "When total stored mail goes above this level, Magic Mail trims it back down.\n" +
                    "Applies to regular and sorting-upgraded post offices."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Sorting overflow threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "When total stored mail at a dedicated sorting facility goes above this level,\n" +
                    "Magic Mail trims it back down."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Change capacities" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Enable this to modify van and truck capacities. When off,\n" +
                    "all capacity sliders below are hidden and\n" +
                    "vanilla (game) values are used even if you left the sliders at different amounts."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Post van mail load" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controls how much mail each post van can carry.\n" +
                    "<100% = vanilla payload.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Post van fleet size" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controls how many post vans each postal building can own and dispatch.\n" +
                    "<100% = vanilla fleet size.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Post truck fleet size" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controls how many post trucks each facility with post trucks can own and dispatch.\n" +
                    "<100% = vanilla fleet size.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sorting speed" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplier for dedicated sorting facilities.\n" +
                    "Does not change a post office's sorting upgrade.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sorting storage capacity" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controls mail storage for dedicated sorting facilities.\n" +
                    "Does not change a post office's sorting upgrade.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Rescue low unsorted mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Lets the game supply unsorted mail normally first.\n" +
                    "If a dedicated sorting facility stays very low for several scans,\n" +
                    "Magic Mail adds a small rescue top-up."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Unsorted mail rescue threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Marks unsorted mail as low when it reaches this percentage of max storage.\n" +
                    "The rescue only runs if it stays low across several scans."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Unsorted mail rescue amount" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "How much unsorted mail to add when the rescue finally runs.\n" +
                    "Amount is a percentage of max storage."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Game defaults" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restore all settings to the game's original default behavior (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommended" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Vanilla Assist** - Quick Start.\n" +
                    "Lets vanilla mail logistics work first, then rescues persistent shortages or overflow.\n" +
                    "Also applies the recommended capacity tuning."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Postal buildings found when the Status page is opened.\n\n" +
                    "**Post offices** = regular post offices (PO).\n" +
                    "**Sorting facilities** = dedicated Post Sorting Facilities.\n" +
                    "**Sorting post offices** = <Westmont Tower with Sorting Upgrade>.\n" +
                    "- Requires **Skyscrapers DLC**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Postal vehicle capacity when the Status page is opened.\n\n" +
                    "**Post-vans** = local pickup and delivery vehicles.\n" +
                    "**Post trucks** = trucks that move mail between facilities."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Monthly mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Shows recent city-wide mail flow.\n\n" +
                    "**Accumulated** = how much mail citizens generated.\n" +
                    "**Processed**   = how much mail the network actually handled.\n\n" +
                    "- If Processed is often higher than Accumulated, then your postal network has enough capacity.\n" +
                    "- If Accumulated stays above Processed for long periods,\n" +
                    "then the city is generating more mail than it can handle.\n" +
                    "Add more facilities, vans, or tweak your settings."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activity" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Rescues and overflow cleanups from the last Magic Mail rescue pass."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Write Report" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Runs a **one-time** detailed postal scan while Options is open,\n" +
                    "then writes the report to <Logs/MagicMail.log>. No background logging."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Open <Logs/MagicMail.log>, or the Logs folder if the file does not exist yet."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "No postal facilities found. Open a city, then open Status again." },

                { "MM_STATUS_NO_ACTIVITY",
                  "No rescue activity recorded." },

                {
                    "MM_STATUS_SUMMARY", 
                    "Post offices: {0} | Sorting post offices: {1} | Sorting facilities: {2}"
                },

                {
                    "MM_STATUS_VEHICLES",
                    "Post-vans: {0} | Post trucks: {1}"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} local rescues | {1} unsorted rescues | {2} overflow cleanups"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "City mail stats not available yet. Open a city and let the simulation run." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} accumulated | {1} processed"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Display name of this mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Current mod version and build type."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mochi's Paradox mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Open the **Paradox** webpage for **Magic Mail** and other mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Open the **Discord** feedback chat in a browser."
                },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
