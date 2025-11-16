// Mod.cs
// Entry point for Go Postal [GP].

namespace GoPostal
{
    using System.Reflection;                   // AssemblyVersion
    using Colossal;                            // IDictionarySource
    using Colossal.IO.AssetDatabase;           // AssetDatabase
    using Colossal.Logging;                    // ILog, LogManager
    using Game;                                // UpdateSystem, SystemUpdatePhase
    using Game.Modding;                        // IMod
    using Game.SceneFlow;                      // GameManager

    /// <summary>
    /// Mod entry point for Go Postal [GP].
    /// Registers settings, locales, and the ECS system.
    /// </summary>
    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----

        public const string ModId = "GoPostal";
        public const string ModName = "Go Postal";
        public const string ModTag = "[GP]";

        // ---- PRIVATE STATE ----

        private static bool s_BannerLogged;
        private static bool s_ReapplyingLocale;

        /// <summary>
        /// Read &lt;Version&gt; from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        /// <summary>
        /// Logger for this mod.
        /// </summary>
        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        /// <summary>
        /// Global settings instance.
        /// </summary>
        public static Setting? Settings
        {
            get; private set;
        }

        /// <summary>
        /// Called by the game during world initialization.
        /// </summary>
        /// <param name="updateSystem">Update system scheduler.</param>
        public void OnLoad(UpdateSystem updateSystem)
        {
            // Metadata banner (once per session).
            s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
            }

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null)
            {
                s_Log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            // Settings must exist before locales so labels resolve correctly.
            Setting setting = new Setting(this);
            Settings = setting;

            // Register locales via helper
            AddLocale("en-US", new LocaleEN(setting));

            // Future locales – uncomment when you add LocaleXX classes:
            // AddLocale("fr-FR", new LocaleFR(setting));
            // AddLocale("de-DE", new LocaleDE(setting));
            // AddLocale("es-ES", new LocaleES(setting));
            // AddLocale("it-IT", new LocaleIT(setting));
            // AddLocale("ja-JP", new LocaleJA(setting));
            // AddLocale("ko-KR", new LocaleKO(setting));
            // AddLocale("vi-VN", new LocaleVI(setting));
            // AddLocale("pl-PL", new LocalePL(setting));
            // AddLocale("pt-BR", new LocalePT_BR(setting));
            // AddLocale("zh-HANS", new LocaleZH_CN(setting));
            // AddLocale("zh-HANT", new LocaleZH_HANT(setting));

            // Load persisted settings or create defaults on first run.
            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            // Register in Options UI once we have locales.
            setting.RegisterInOptionsUI();

            // Hook locale-change event so the Options UI remains consistent
            // when the active language changes at runtime.
            var localizationManager = gameManager.localizationManager;
            if (localizationManager != null)
            {
                localizationManager.onActiveDictionaryChanged -= OnLocaleChanged;
                localizationManager.onActiveDictionaryChanged += OnLocaleChanged;
            }

            // Schedule the system before the vanilla postal system in the GameSimulation phase.
            updateSystem.UpdateBefore<GoPostalSystem>(SystemUpdatePhase.GameSimulation);
        }

        /// <summary>
        /// Called by the game when the mod is unloaded.
        /// </summary>
        public void OnDispose()
        {
            var gameManager = GameManager.instance;
            var localizationManager = gameManager?.localizationManager;
            if (localizationManager != null)
            {
                localizationManager.onActiveDictionaryChanged -= OnLocaleChanged;
            }

            s_Log.Info(nameof(OnDispose));

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }

        // --------------------------------------------------------------------
        // Localization helpers
        // --------------------------------------------------------------------

        /// <summary>
        /// Adds a locale source in a safe way.
        /// </summary>
        private static void AddLocale(string localeId, IDictionarySource source)
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                s_Log.Warn("No LocalizationManager; cannot add locale source.");
                return;
            }

            lm.AddSource(localeId, source);
        }

        /// <summary>
        /// Re-registers the Options UI when the active locale changes,
        /// so all labels/descriptions stay in sync.
        /// </summary>
        private void OnLocaleChanged()
        {
            if (s_ReapplyingLocale)
            {
                return; // debounce re-entry
            }

            s_ReapplyingLocale = true;
            try
            {
                Settings?.RegisterInOptionsUI();
            }
            finally
            {
                s_ReapplyingLocale = false;
            }
        }
    }
}
