// Settings.cs

namespace PostOfficeTweaks
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;

    [FileLocation("ModsSettings/PostOfficeTweaks/PostOfficeTweaks")]
    [SettingsUIGroupOrder(PostOfficeGroup, PostSortingFacilityGroup, ResetGroup)]
    [SettingsUIShowGroupName(PostOfficeGroup, PostSortingFacilityGroup, ResetGroup)]
    public class Setting : ModSetting
    {
        public const string MainSection = "Main";
        public const string PostOfficeGroup = "Post Office";
        public const string PostSortingFacilityGroup = "Post Sorting Facility";
        public const string ResetGroup = "Reset";

        public Setting(IMod mod)
            : base(mod)
        {
            // Only apply defaults the first time we ever create this settings asset.
            if (!NotFirstTime)
            {
                SetDefaults();
                NotFirstTime = true;
            }
        }

        public override void Apply()
        {
            base.Apply();

            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                return;
            }

            var system = world.GetExistingSystemManaged<PostOfficeSystem>();
            system.Enabled = true;
        }

        #region Post Office

        [SettingsUISection(MainSection, PostOfficeGroup)]
        public bool PO_GetLocalMail
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostOfficeGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_GetLocalMail), true)]
        public int PO_GettingThresholdPercentage
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostOfficeGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_GetLocalMail), true)]
        public int PO_GettingPercentage
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostOfficeGroup)]
        public bool PO_DisposeOverflow
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostOfficeGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PO_DisposeOverflow), true)]
        public int PO_OverflowPercentage
        {
            get; set;
        }

        // NEW: simple top-level “fix it” checkbox
        [SettingsUISection(MainSection, PostOfficeGroup)]
        public bool FixMailOverflow
        {
            get; set;
        }

        #endregion

        #region Post Sorting Facility

        [SettingsUISection(MainSection, PostSortingFacilityGroup)]
        public bool PSF_GetUnsortedMail
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostSortingFacilityGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingThresholdPercentage
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostSortingFacilityGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_GetUnsortedMail), true)]
        public int PSF_GettingPercentage
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostSortingFacilityGroup)]
        public bool PSF_DisposeOverflow
        {
            get; set;
        }

        [SettingsUISection(MainSection, PostSortingFacilityGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(PSF_DisposeOverflow), true)]
        public int PSF_OverflowPercentage
        {
            get; set;
        }

        #endregion

        #region Reset

        [SettingsUISection(MainSection, ResetGroup)]
        [SettingsUIButton]
        public bool ResetToVanilla
        {
            set
            {
                SetToVanilla();
                Apply();
            }
        }

        [SettingsUISection(MainSection, ResetGroup)]
        [SettingsUIButton]
        public bool ResetToRecommend
        {
            set
            {
                SetDefaults();
                Apply();
            }
        }

        #endregion

        #region Others

        [SettingsUIHidden]
        public bool NotFirstTime
        {
            get; set;
        }

        #endregion

        public override void SetDefaults()
        {
            // Recommended defaults (mod behavior)
            PO_GetLocalMail = false;
            PO_GettingThresholdPercentage = 2;
            PO_GettingPercentage = 20;
            PO_DisposeOverflow = true;
            PO_OverflowPercentage = 80;
            FixMailOverflow = true; // default: fix the broken vanilla overflow

            PSF_GetUnsortedMail = true;
            PSF_GettingThresholdPercentage = 2;
            PSF_GettingPercentage = 20;
            PSF_DisposeOverflow = true;
            PSF_OverflowPercentage = 80;
        }

        public void SetToVanilla()
        {
            // Vanillish behavior: no auto get & no overflow disposal & bug not fixed
            PO_GetLocalMail = false;
            PO_GettingThresholdPercentage = 2;
            PO_GettingPercentage = 20;
            PO_DisposeOverflow = false;
            PO_OverflowPercentage = 80;
            FixMailOverflow = false; // vanilla keeps the bug

            PSF_GetUnsortedMail = false;
            PSF_GettingThresholdPercentage = 2;
            PSF_GettingPercentage = 20;
            PSF_DisposeOverflow = false;
            PSF_OverflowPercentage = 80;
        }
    }
}
