// <copyright file="MailSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Settings/MailSettings.cs
// Options UI and configuration for MagicMail [MM].

namespace MagicMail
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;

    /// <summary>
    /// Settings definition and UI bindings for MagicMail [MM].</summary>
    [FileLocation("ModsSettings/MagicMail/MagicMail")]
    [SettingsUITabOrder(
        kActionsTab, kStatusTab, kAboutTab)]
    [SettingsUIGroupOrder(
        ResetGroup,
        PostVanGroup,
        PostOfficeGroup,
        PostSortingFacilityGroup,
        StatusSummaryGroup, StatusActivityGroup,
        kAboutInfoGroup, kAboutLinksGroup)]
    [SettingsUIShowGroupName(
        ResetGroup,
        PostVanGroup,
        PostOfficeGroup,
        PostSortingFacilityGroup,
        StatusSummaryGroup, StatusActivityGroup,
        kAboutLinksGroup)]
    public partial class MailSettings : ModSetting
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


        /// <summary>
        /// Constructs the settings object with game-default values.
        /// Saved values are overlaid by LoadSettings().
        /// </summary>
        /// <param name="mod">Mod instance passed by the game.</param>
        public MailSettings(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        public MailSettings(IMod mod)
            : base(mod)
        {
            // First run: start from pure game defaults (vanilla).
            if (!NotFirstTime)
            {
                SetDefaults();    // SetDefaults => vanilla now.
                NotFirstTime = true;
            }
        }

        /// <summary>
        /// Applies settings at runtime and ensures the managed systems are enabled.</summary>
        public override void Apply()
        {
            base.Apply();

            // Status is built only when the Options UI reads it. Mark the cached
            // snapshot dirty so changed capacities/settings can refresh immediately.
            MailStatus.MarkDirty();

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return;
            }

            // The rescue system should run only when at least one rescue feature
            // is enabled. Capacity-only users get no recurring MagicMail scan.
            MagicMailSystem? magicSystem =
                world.GetExistingSystemManaged<MagicMailSystem>();
            if (magicSystem != null)
            {
                magicSystem.SetRescueEnabled(
                    MagicMailSystem.NeedsRescue(this));
            }

            // One-shot capacity updater – gives "instant" slider changes.
            MailCapacitySystem? capacitySystem =
                world.GetExistingSystemManaged<MailCapacitySystem>();
            if (capacitySystem != null)
            {
                capacitySystem.Enabled = true;
            }
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: RESET BUTTONS (top)
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
                ApplyAndSave();
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

                SetRecommended();
                ApplyAndSave();
            }
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: POST VAN OPTIONS (second)
        // --------------------------------------------------------------------

        /// <summary>
        /// Master toggle for changing postal capacities (vans, trucks, payload).</summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        public bool ChangeCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Post van mail load multiplier (percent).
        /// Applied to PostVanData.m_MailCapacity (payload per van).
        /// 100% = vanilla; higher values let each van carry more mail.</summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        [SettingsUISlider(
            min = 100,
            max = 1000,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(ChangeCapacity), true)]
        public int PostVanMailLoadPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Post van fleet size multiplier (percent).
        /// Applied to PostFacilityData.m_PostVanCapacity (vans per facility).</summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        [SettingsUISlider(
            min = 50,
            max = 1000,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(ChangeCapacity), true)]
        public int PostVanFleetSizePercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Post truck fleet size multiplier (percent).
        /// Applied to PostFacilityData.m_PostTruckCapacity (trucks per facility).</summary>
        [SettingsUISection(kActionsTab, PostVanGroup)]
        [SettingsUISlider(
            min = 50,
            max = 1000,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(ChangeCapacity), true)]
        public int TruckCapacityPercentage
        {
            get;
            set;
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB: POST OFFICE OPTIONS
        // --------------------------------------------------------------------

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        public bool PO_GetLocalMail
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(PO_GetLocalMail), true)]
        public int PO_GettingThresholdPercentage
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(PO_GetLocalMail), true)]
        public int PO_GettingPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Global overflow fix toggle (post offices + sorting facilities).</summary>
        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        public bool FixMailOverflow
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(FixMailOverflow), true)]
        public int PO_OverflowPercentage
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostOfficeGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(FixMailOverflow), true)]
        public int PSF_OverflowPercentage
        {
            get;
            set;
        }



        // --------------------------------------------------------------------
        // ACTIONS TAB: POST SORTING FACILITY OPTIONS (last)
        // --------------------------------------------------------------------

        /// <summary>
        /// Sorting speed multiplier for sorting facilities (percent).</summary>
        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        public int PSF_SortingSpeedPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Storage capacity multiplier for sorting facilities (percent).
        /// Scales PostFacilityData.m_MailCapacity only for facilities that sort mail.</summary>
        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        public int PSF_StorageCapacityPercentage
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        public bool PSF_GetUnsortedMail
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingThresholdPercentage
        {
            get;
            set;
        }

        [SettingsUISection(kActionsTab, PostSortingFacilityGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUIHideByCondition(typeof(MailSettings), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingPercentage
        {
            get;
            set;
        }


        // --------------------------------------------------------------------
        // DEFAULTS
        // --------------------------------------------------------------------

        /// <summary>
        /// Sets vanilla-like defaults (pure game defaults) for first run.</summary>
        public override void SetDefaults()
        {
            SetToVanilla();
        }

        /// <summary>
        /// Vanilla / game-default behaviour: no magic, 100% capacities.</summary>
        public void SetToVanilla()
        {
            // Vanilla-like behavior: no auto gets, no overflow cleanup, vanilla capacities.
            PO_GetLocalMail = false;
            PO_GettingThresholdPercentage = 2;
            PO_GettingPercentage = 15;

            FixMailOverflow = false;
            PO_OverflowPercentage = 80;
            PSF_OverflowPercentage = 80;

            PSF_GetUnsortedMail = false;
            PSF_GettingThresholdPercentage = 2;
            PSF_GettingPercentage = 15;

            PSF_SortingSpeedPercentage = 100;
            PSF_StorageCapacityPercentage = 100;

            ChangeCapacity = false;
            PostVanMailLoadPercentage = 100;
            PostVanFleetSizePercentage = 100;
            TruckCapacityPercentage = 100;
        }

        /// <summary>
        /// Recommended MagicMail tuning preset.</summary>
        private void SetRecommended()
        {
            // Post offices: rescue Local Mail only after it stays low across several scans.
            PO_GetLocalMail = true;
            PO_GettingThresholdPercentage = 5;
            PO_GettingPercentage = 10;

            // Postal facilities: rescue actual overfill using Local + Unsorted + Outgoing mail.
            FixMailOverflow = true;
            PO_OverflowPercentage = 85;
            PSF_OverflowPercentage = 85;

            // Dedicated sorting facilities: rescue Unsorted Mail only after it stays low across several scans.
            PSF_GetUnsortedMail = true;
            PSF_GettingThresholdPercentage = 5;
            PSF_GettingPercentage = 10;

            PSF_SortingSpeedPercentage = 150;
            PSF_StorageCapacityPercentage = 100;

            // Recommended vehicle tuning.
            ChangeCapacity = true;
            PostVanMailLoadPercentage = 200;
            PostVanFleetSizePercentage = 100;
            TruckCapacityPercentage = 100;
        }

    }
}
