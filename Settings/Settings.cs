// Settings/Settings.cs
// Options UI and configuration for Go Postal [GP].

namespace GoPostal
{
    using System;                       // Exception handling (try/catch)
    using Colossal.IO.AssetDatabase;    // [FileLocation]
    using Game.Modding;                 // IMod, ModSetting
    using Game.Settings;                // SettingsUI
    using Game.UI;
    using Unity.Entities;
    using UnityEngine;                  // Application.OpenURL

    /// <summary>
    /// Settings definition and UI bindings for Go Postal [GP].
    /// </summary>
    [FileLocation("ModsSettings/GoPostal/GoPostal")]
    [SettingsUITabOrder(
        kActionsTab,
        kStatusTab,
        kAboutTab)]
    [SettingsUIGroupOrder(
        PostOfficeGroup,
        PostSortingFacilityGroup,
        PostVanGroup,
        ResetGroup,
        StatusSummaryGroup,
        StatusActivityGroup,
        kAboutInfoGroup,
        kAboutLinksGroup)]
    [SettingsUIShowGroupName(
        PostOfficeGroup,
        PostSortingFacilityGroup,
        PostVanGroup,
        ResetGroup,
        StatusSummaryGroup,
        StatusActivityGroup,
        kAboutLinksGroup)]
    public sealed class Setting : ModSetting
    {
        // ---- TABS ----

        public const string kActionsTab = "Actions";
        public const string kStatusTab = "Status";
        public const string kAboutTab = "About";

        // ---- ACTION GROUPS (Actions tab) ----

        public const string PostOfficeGroup = "PostOffice";
        public const string PostSortingFacilityGroup = "PostSortingFacility";
        public const string PostVanGroup = "PostVan";
        public const string ResetGroup = "Reset";

        // ---- STATUS GROUPS (Status tab) ----

        public const string StatusSummaryGroup = "StatusSummary";
        public const string StatusActivityGroup = "StatusActivity";

        // ---- ABOUT GROUPS (About tab) ----

        public const string kAboutInfoGroup = "AboutInfo";
        public const string kAboutLinksGroup = "AboutLinks";

        // ---- LINKS ----

        private const string kUrlDiscord = "https://discord.gg/HTav7ARPs2";
        private const string kUrlGithub = "https://github.com/River-Mochi/GoPostal";

        /// <summary>
        /// Internal flag used to avoid resetting options on every load.
        /// </summary>
        [SettingsUIHidden]
        public bool NotFirstTime
        {
            get; set;
        }

        /// <summary>
        /// Constructs the settings object and initializes defaults on first creation.
        /// </summary>
        /// <param name="mod">Mod instance passed by the game.</param>
        public Setting(IMod mod)
            : base(mod)
        {
            // Only apply defaults the first time this settings asset is created.
            if (!NotFirstTime)
            {
                SetDefaults();
                NotFirstTime = true;
            }
        }

        /// <summary>
        /// Applies settings at runtime and ensures the managed system is enabled.
        /// </summary>
        public override void Apply()
        {
            base.Apply();

            World? world = World.DefaultGameObjectInjectionWorld;
            GoPostalSystem? system = world?.GetExistingSystemManaged<GoPostalSystem>();
            if (system != null)
            {
                // Re-enable the system so it reacts to the latest settings.
                system.Enabled = true;
            }
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: POST OFFICE OPTIONS
        // --------------------------------------------------------------------

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        public bool PO_GetLocalMail
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_GetLocalMail), true)]
        public int PO_GettingThresholdPercentage
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_GetLocalMail), true)]
        public int PO_GettingPercentage
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        public bool PO_DisposeOverflow
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_DisposeOverflow), true)]
        public int PO_OverflowPercentage
        {
            get; set;
        }

        /// <summary>
        /// Overflow fix toggle for post offices.
        /// When enabled, overflow cleanup always runs once the threshold is reached.
        /// </summary>
        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        public bool FixMailOverflow
        {
            get; set;
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: POST SORTING FACILITY OPTIONS
        // --------------------------------------------------------------------

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        public bool PSF_GetUnsortedMail
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingThresholdPercentage
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingPercentage
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        public bool PSF_DisposeOverflow
        {
            get; set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 0, max = 100, step = 1,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_DisposeOverflow), true)]
        public int PSF_OverflowPercentage
        {
            get; set;
        }

        /// <summary>
        /// Sorting speed multiplier for sorting facilities (percent).
        /// Applied to PostFacilityData.m_SortingRate (100% = vanilla).
        /// </summary>
        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 50, max = 300, step = 10,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int PSF_SortingSpeedPercentage
        {
            get; set;
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: POST VAN / TRUCK OPTIONS
        // --------------------------------------------------------------------

        /// <summary>
        /// Post van capacity multiplier (percent).
        /// Applied to:
        /// - PostFacilityData.m_PostVanCapacity (vans per facility)
        /// - PostVanData.m_MailCapacity (payload per van)
        /// 100% = vanilla.
        /// </summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        [SettingsUISlider(
            min = 50, max = 300, step = 10,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int VanCapacityPercentage
        {
            get; set;
        }

        /// <summary>
        /// Post truck capacity multiplier (percent).
        /// Applied to PostFacilityData.m_PostTruckCapacity (trucks per facility).
        /// 100% = vanilla.
        /// </summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        [SettingsUISlider(
            min = 50, max = 300, step = 10,
            scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int TruckCapacityPercentage
        {
            get; set;
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: RESET BUTTONS
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(ResetGroup)]
        [SettingsUISection(kActionsTab, ResetGroup)]
        [SettingsUIButton]
        public bool ResetToVanilla
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SetToVanilla();
                Apply();
            }
        }

        [SettingsUIButtonGroup(ResetGroup)]
        [SettingsUISection(kActionsTab, ResetGroup)]
        [SettingsUIButton]
        public bool ResetToRecommend
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SetDefaults();
                Apply();
            }
        }

        // --------------------------------------------------------------------
        // STATUS TAB
        // --------------------------------------------------------------------

        [SettingsUISection(kStatusTab, StatusSummaryGroup)]
        public string StatusFacilitySummary =>
            GoPostalSystem.GetStatusSummary();

        [SettingsUISection(kStatusTab, StatusActivityGroup)]
        public string StatusLastActivity =>
            GoPostalSystem.GetStatusActivity();

        // --------------------------------------------------------------------
        // ABOUT TAB: INFO
        // --------------------------------------------------------------------

        [SettingsUISection(kAboutTab, kAboutInfoGroup)]
        public string ModNameDisplay => $"{Mod.ModName} {Mod.ModTag}";

        [SettingsUISection(kAboutTab, kAboutInfoGroup)]
        public string ModVersionDisplay => Mod.ModVersion;

        // --------------------------------------------------------------------
        // ABOUT TAB: LINKS
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(kAboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(kAboutTab, kAboutLinksGroup)]
        public bool OpenGithub
        {
            set
            {
                if (!value)
                {
                    return;
                }

                TryOpenUrl(kUrlGithub);
            }
        }

        [SettingsUIButtonGroup(kAboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(kAboutTab, kAboutLinksGroup)]
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
        // DEFAULTS
        // --------------------------------------------------------------------

        /// <summary>
        /// Sets recommended default values for mod behavior.
        /// </summary>
        public override void SetDefaults()
        {
            // Recommended defaults (mod behavior).
            PO_GetLocalMail = false;
            PO_GettingThresholdPercentage = 2;
            PO_GettingPercentage = 20;
            PO_DisposeOverflow = true;
            PO_OverflowPercentage = 80;
            FixMailOverflow = true; // Default: fix the overflow behavior.

            PSF_GetUnsortedMail = true;
            PSF_GettingThresholdPercentage = 2;
            PSF_GettingPercentage = 20;
            PSF_DisposeOverflow = true;
            PSF_OverflowPercentage = 80;

            PSF_SortingSpeedPercentage = 100;

            VanCapacityPercentage = 100;
            TruckCapacityPercentage = 100;
        }

        /// <summary>
        /// Restores a configuration similar to vanilla behavior.
        /// </summary>
        public void SetToVanilla()
        {
            // Vanilla-like behavior: no auto get, no overflow disposal, no bug fix.
            PO_GetLocalMail = false;
            PO_GettingThresholdPercentage = 2;
            PO_GettingPercentage = 20;
            PO_DisposeOverflow = false;
            PO_OverflowPercentage = 80;
            FixMailOverflow = false;

            PSF_GetUnsortedMail = false;
            PSF_GettingThresholdPercentage = 2;
            PSF_GettingPercentage = 20;
            PSF_DisposeOverflow = false;
            PSF_OverflowPercentage = 80;

            PSF_SortingSpeedPercentage = 100;
            VanCapacityPercentage = 100;
            TruckCapacityPercentage = 100;
        }

        // --------------------------------------------------------------------
        // HELPERS
        // --------------------------------------------------------------------

        /// <summary>
        /// Opens a URL via Unity’s Application.OpenURL, ignoring failures.
        /// </summary>
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
