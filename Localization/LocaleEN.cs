// Localization/LocaleEN.cs
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

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
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "City scan" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Last update" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Fix Low Local mail" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "When enabled and if the storage gets too low, extra mail appears.\n " +
                    "Does not spawn extra vans; it's like magic...but real :)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Local mail threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "If local mail goes below this percentage that you choose, then,\n " +
                    "the post office pulls in more local mail.\n" +
                    "It is the percentage of max storage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Local mail fetch amount" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentage to add when fetching local mail (magic top-up).\n" +
                    "if vanilla max = 10,000, and this is set to 20%, then 2000 is added. "},

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Fix mail overflow" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "When there is too much mail, the facilities perform a small magic cleanup.\n " +
                    "Excess stored mail is treated as delivered and removed.\n " +
                    "This fix prevents facilities from getting stuck full forever.\n " +
                    "Disable this to keep pure vanilla behavior." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Post office overflow threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "When the total mail at a post office reaches this percentage, the mod\n" +
                    "deletes enough stored mail to bring it back down to this level." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Sorting overflow threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "When the total mail at sorting facility reaches this percentage, the mod\n" +
                   "deletes enough stored mail to bring it back down to this level." },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Change capacities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Enable this to modify van and truck capacities. When off," +
                    "all capacity sliders below are hidden and\n" +
                    "vanilla (game) values are used even if you left the sliders at different amounts." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Post van mail load" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controls how much mail each post van can carry.\n" +
                    "<100% = vanilla payload.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Post van fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controls how many post vans each postal building can own and dispatch.\n" +
                    "<100% = vanilla fleet size.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Post truck fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controls how many post trucks each sorting facility (and any facility with Post-trucks)\n " +
                    "can own and dispatch.\n " +
                    "<100% = vanilla fleet size.>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sorting speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplier for **Sorting** facilities. Applies to the facility's base sorting rate\n " +
                    "<100% = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sorting storage capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controls **mail storage**\n " +
                    "<100% = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Fix low unsorted mail" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "When enabled, some unsorted mail magically appears if storage supplies get too low.\n " +
                    "This keeps sorting buildings active without waiting for deliveries.\n" +
                    "This is a temp fix for a current bug where Sorting facilities don't get enough mail if a Cargo harbor is present." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Unsorted mail threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "If unsorted mail goes below this percentage of capacity, some extra unsorted mail is magically fetched. \n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Unsorted mail fetch amount" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "The additional mail to add when fetching unsorted mail (magic top-up).\n" +
                    "Amout is a percentage of max storage capacity." },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Game defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restore all settings to the game’s original default behaviour (vanilla)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Quick Start** - apply all recommended postal settings.\n" +
                    "Easy-Mode: 1-Click and DONE!" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Summary of post offices, post vans, sorting facilities, and post trucks processed in the last game update (~every 45 min in-game)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "City mail" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Shows recent city-wide mail flow.\n\n" +
                     "**Accumulated** = how much mail citizens generated.\n" +
                     "**Processed**   = how much mail the network actually handled.\n\n" +
                     "- If Processed is often higher than Accumulated, then your postal network has enough capacity.\n " +
                     "- If Accumulated stays above Processed for long periods, then the city is generating more mail\n " +
                     "than it can handle; add more facilities, vans or tweak your settings." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Counts of mail pulls and overflow cleanups performed in the last update." },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Current mod version." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Open **Paradox** webpage for **Magic Mail** and other mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Open **Discord** feedback chat in a browser." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
