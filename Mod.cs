// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Mod.cs
// Entry point for MagicMail [MM].

namespace MagicMail
{
    using System;
    using System.Reflection;

    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;

    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    /// <summary>
    /// Registers Magic Mail settings, localization, and systems.
    /// </summary>
    public sealed class Mod : IMod
    {
        public const string ModId = "MagicMail";
        public const string ModName = "Magic Mail";
        public const string ModTag = "[MM]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Setting? Settings
        {
            get;
            private set;
        }

        private static bool s_BannerLogged;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null)
            {
                s_Log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            Setting setting = new Setting(this);
            Settings = setting;

            LocalizationManager? localizationManager = gameManager.localizationManager;
            if (localizationManager == null)
            {
                s_Log.Warn("LocalizationManager is null; locale sources were not registered.");
            }
            else
            {
                try
                {
                    localizationManager.AddSource("en-US", new LocaleEN(setting));
                    localizationManager.AddSource("de-DE", new LocaleDE(setting));
                    localizationManager.AddSource("fr-FR", new LocaleFR(setting));
                    localizationManager.AddSource("es-ES", new LocaleES(setting));
                    localizationManager.AddSource("it-IT", new LocaleIT(setting));
                    localizationManager.AddSource("ja-JP", new LocaleJA(setting));
                    localizationManager.AddSource("ko-KR", new LocaleKO(setting));
                    localizationManager.AddSource("pl-PL", new LocalePL(setting));
                    localizationManager.AddSource("pt-BR", new LocalePT_BR(setting));
                    localizationManager.AddSource("pt-PT", new LocalePT_PT(setting));
                    localizationManager.AddSource("zh-HANS", new LocaleZH_CN(setting));
                    localizationManager.AddSource("zh-HANT", new LocaleZH_HANT(setting));
                    localizationManager.AddSource("th-TH", new LocaleTH(setting));
                    localizationManager.AddSource("vi-VN", new LocaleVI(setting));
                }
                catch (Exception ex)
                {
                    s_Log.Error(
                        $"Localization registration failed: {ex.GetType().Name}: {ex.Message}");
                }
            }

            AssetDatabase.global.LoadSettings(
                ModId,
                setting,
                new Setting(this));

            setting.RegisterInOptionsUI();

            updateSystem.UpdateBefore<MagicMailSystem>(
                SystemUpdatePhase.GameSimulation);

            updateSystem.UpdateBefore<MailCapacitySystem>(
                SystemUpdatePhase.GameSimulation);
        }

        public void OnDispose()
        {
            Settings?.UnregisterInOptionsUI();
            Settings = null;
        }
    }
}
