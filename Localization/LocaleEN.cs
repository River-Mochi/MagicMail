// Localization/LocaleEN.cs
// English locale for Go Postal [GP].

namespace GoPostal
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// English localization source for Go Postal [GP].
    /// </summary>
    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the English locale generator.
        /// </summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all English localization entries for this mod.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Go Postal [GP]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "About" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),
                    "Post office" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup),
                    "Sorting facility" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),
                    "Post vans & trucks" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),
                    "Reset" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),
                    "City scan" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup),
                    "Last update" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),
                    "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup),
                    "Links" },

                // ---- Post Office ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Get local mail when under threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "When enabled, post offices automatically pull in local mail "
                    + "if storage is below the threshold."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Local mail threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "If local mail is below this percentage of capacity, the post office "
                    + "pulls in more local mail."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Local mail fetch amount"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentage of capacity to add when fetching local mail."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_DisposeOverflow)),
                    "Dispose overflow mail"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_DisposeOverflow)),
                    "When enabled, overflow mail is removed once storage exceeds "
                    + "the overflow percentage."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Overflow threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "When total mail reaches this percentage of capacity, "
                    + "overflow handling is triggered."
                },

                // FixMailOverflow
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)),
                    "Fix mail overflow"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Post facilities sometimes stall when storage is nearly full. "
                    + "This option clamps stored mail when over the threshold to keep "
                    + "the facility from stalling."
                },

                // ---- Sorting Facility ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Get unsorted mail when under threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "When enabled, sorting facilities automatically pull in unsorted mail "
                    + "if storage is below the threshold."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Unsorted mail threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "If unsorted mail is below this percentage of capacity, "
                    + "the facility pulls in more unsorted mail."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Unsorted mail fetch amount"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Percentage of capacity to add when fetching unsorted mail."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_DisposeOverflow)),
                    "Dispose overflow mail"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_DisposeOverflow)),
                    "When enabled, overflow mail at sorting facilities is removed "
                    + "once storage exceeds the overflow percentage."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Overflow threshold"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "When total mail reaches this percentage of capacity, "
                    + "overflow handling is triggered."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Sorting speed"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Sorting speed multiplier for postal sorting facilities. "
                    + "Applies to the facility's base sorting rate (100% = vanilla)."
                },

                // ---- Post Vans & Trucks ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VanCapacityPercentage)),
                    "Post van capacity"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VanCapacityPercentage)),
                    "Controls how many vans each postal building can dispatch and how much "
                    + "mail each van can carry. 100% = vanilla."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Post truck capacity"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controls how many post trucks each facility can dispatch. "
                    + "100% = vanilla."
                },

                // ---- Reset ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)),
                    "Reset to vanilla"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restore all postal settings to the game’s original behaviour."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)),
                    "Reset to recommended"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "Apply Go Postal’s recommended postal settings."
                },

                // ---- Status tab ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Facilities"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Summary of post offices and sorting facilities processed "
                    + "in the last update."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)),
                    "Activity"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Counts of mail pulls and overflow cleanups performed in the last update."
                },

                // ---- About tab: info ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Display name of this mod."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Current mod version."
                },

                // ---- About tab: links ----
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenGithub)),
                    "GitHub"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenGithub)),
                    "Open the Go Postal GitHub page in a browser."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Open the community Discord in a browser."
                },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.
        /// </summary>
        public void Unload()
        {
        }
    }
}
