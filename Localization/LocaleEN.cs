// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Post office" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Post vans & trucks" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Sorting facility" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Reset" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "City scan" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Last update" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Fix low local mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "If enabled, then a small amount of mail appears if the mail ever gets too low.\n " +
                    "Does not spawn extra vans; it's like magic...but real :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Local mail threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "If local mail goes below this percentage (that you choose), it\n " +
                    "triggers the post office to pull in more local mail.\n" +
                    "This is a percentage of the building max storage.\n" +
                    "E.g., if <max storage = 100,000> and <threshold = 5%>,\n" +
                    "when local mail < <5,000> then more mail is fetched."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Local mail fetch amount" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentage to add when fetching local mail (magic top-up).\n" +
                    "If vanilla max = <100,000> and this is set to <10%>\n" +
                    "then <10,000> is added when needed."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Fix mail overflow" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "When there is too much mail, the facilities perform a small magic cleanup.\n " +
                    "Excess stored mail is treated as delivered and removed.\n " +
                    "This fix prevents facilities from getting stuck full forever.\n " +
                    "Disable this to keep pure vanilla behavior."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Post office overflow threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "When the total mail at a post office reaches this percentage, the mod\n" +
                    "deletes enough stored mail to bring it back down to this level."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Sorting overflow threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "When the total mail at a sorting facility reaches this percentage, the mod\n" +
                    "deletes enough stored mail to bring it back down to this level."
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
                    "Controls how many post trucks each sorting facility (and any facility with Post-trucks)\n " +
                    "can own and dispatch.\n " +
                    "<100% = vanilla fleet size.>"
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sorting speed" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplier for **Sorting** facilities. Applies to the facility's base sorting rate.\n " +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sorting storage capacity" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controls **mail storage**.\n " +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Fix low unsorted mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "When enabled, some unsorted mail magically appears if storage supplies get too low.\n " +
                    "This keeps sorting buildings active.\n" +
                    "It is a temp fix for a current bug where sorting facilities don't get enough mail if a cargo harbor is present."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Unsorted mail threshold" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "If unsorted mail goes below this low percentage of total storage capacity,\n" +
                    "then some extra unsorted mail is fetched.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Unsorted mail fetch amount" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "The additional mail to add when fetching unsorted mail (magic top-up).\n" +
                    "Amount is a percentage of max storage capacity.\n" +
                    "If vanilla <max = 250,000> and this is set to <10%>, then <25,000> is added."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Game defaults" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restore all settings to the game’s original default behaviour (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommended" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Quick Start** – apply all recommended postal settings.\n" +
                    "Easy mode: 1 click and done!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Summary of post offices, post vans, sorting facilities, and post trucks processed in the last background scan."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Monthly mail" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Shows recent city-wide mail flow.\n\n" +
                    "**Accumulated** = how much mail citizens generated.\n" +
                    "**Processed**   = how much mail the network actually handled.\n\n" +
                    "- If Processed is often higher than Accumulated, then your postal network has enough capacity.\n " +
                    "- If Accumulated stays above Processed for long periods,\n" +
                    "then the city is generating more mail than it can handle.\n" +
                    "Add more facilities, vans, or tweak your settings."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activity" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Counts of mail pulls and overflow cleanups performed in the last update."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "No postal facilities processed yet. Open a city and let the simulation run." },

                { "MM_STATUS_NO_ACTIVITY",
                  "No activity recorded yet." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} post offices | {1} post-vans | {2} sorting buildings | {3} post trucks"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} local-mail pulls | {1} unsorted-mail pulls | {2} overflow cleanups"
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
                    "Current mod version."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
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
