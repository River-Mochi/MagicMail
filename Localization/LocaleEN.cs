// LocaleEN.cs

namespace PostOfficeTweaks
{
    using System.Collections.Generic;
    using Colossal;
    using Colossal.Localization;
    using Game.Settings;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Post Office Tweaks [POT]" },

                // Tabs / groups
                { m_Setting.GetOptionTabLocaleID(Setting.MainSection), "Main" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Post office" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Sorting facility" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Reset" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Get local mail when under threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "When enabled, post offices automatically pull in local mail if storage is below the threshold." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Local mail threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "If local mail is below this percentage of capacity, the post office will pull in more local mail." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Local mail fetch amount" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentage of capacity to add when fetching local mail." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_DisposeOverflow)),
                    "Dispose overflow mail" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_DisposeOverflow)),
                    "When enabled, overflow mail will be removed once storage exceeds the overflow percentage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Overflow threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "When total mail reaches this percentage of capacity, overflow handling is triggered." },

                // NEW: FixMailOverflow
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)),
                    "Fix mail overflow" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "When the post office is full it sometimes stops sending new delivery vans. "
                  + "This option periodically removes some stored mail to keep the facility from stalling." },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Get unsorted mail when under threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "When enabled, sorting facilities automatically pull in unsorted mail if storage is below the threshold." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Unsorted mail threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "If unsorted mail is below this percentage of capacity, the facility will pull in more unsorted mail." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Unsorted mail fetch amount" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Percentage of capacity to add when fetching unsorted mail." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_DisposeOverflow)),
                    "Dispose overflow mail" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_DisposeOverflow)),
                    "When enabled, overflow mail at sorting facilities will be removed once storage exceeds the overflow percentage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Overflow threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "When total mail reaches this percentage of capacity, overflow handling is triggered." },

                // ---- Reset ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)),
                    "Reset to vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restore all postal settings to the game’s original behaviour." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)),
                    "Reset to recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "Apply the mod’s recommended postal settings." },
            };
        }

        public void Unload()
        {
        }
    }
}
