// Mod.cs

namespace PostOfficeTweaks
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        // Mod instance and asset
        public static Mod? instance
        {
            get; private set;
        }

        public static ExecutableAsset? modAsset
        {
            get; private set;
        }

        // Logging
        public static readonly ILog log =
            LogManager.GetLogger(nameof(PostOfficeTweaks)).SetShowsErrorsInUI(false);

        // Settings instance
        public static Setting? m_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            instance = this;
            log.Info($"{nameof(OnLoad)} for {nameof(PostOfficeTweaks)}");

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null)
            {
                log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            if (gameManager.modManager.TryGetExecutableAsset(this, out ExecutableAsset asset))
            {
                log.Info($"{asset.name} v{asset.version} mod asset at {asset.path}");
                modAsset = asset;
            }

            Setting setting = new Setting(this);
            m_Setting = setting;

            setting.RegisterInOptionsUI();

            var localizationManager = gameManager.localizationManager;
            if (localizationManager == null)
            {
                log.Warn("LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                localizationManager.AddSource("en-US", new LocaleEN(setting));
                localizationManager.AddSource("ja-JP", new LocaleJA(setting));
            }

            AssetDatabase.global.LoadSettings(nameof(PostOfficeTweaks), setting, new Setting(this));

            // Run the system before simulation phase starts
            updateSystem.UpdateBefore<PostOfficeSystem>(SystemUpdatePhase.GameSimulation);
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
        }
    }
}
