// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleDE.cs
// German locale de-DE

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German localization source for Magic Mail [MM].</summary>
    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the German locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all German localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Info" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Vanilla-Hilfe" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Postwagen & LKW" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Eigene Sortieranlage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Zurücksetzen" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Stadt-Scan" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Letztes Update" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Wenig lokale Post retten" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Lässt zuerst die normalen Posttransfers des Spiels arbeiten.\n" +
                    "Bleibt die lokale Post mehrere Prüfungen lang sehr niedrig, fügt Magic Mail eine kleine Rettungsmenge hinzu.\n" +
                    "Gilt auch für Postämter mit Sortier-Upgrade."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Rettungsschwelle für lokale Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Lokale Post gilt ab diesem Anteil des maximalen Gebäudespeichers als niedrig.\n" +
                    "Die Rettung greift nur, wenn der Wert mehrere Prüfungen lang niedrig bleibt."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Rettungsmenge für lokale Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Menge an lokaler Post, die bei einer Rettung hinzugefügt wird.\n" +
                    "Die Menge ist ein Prozentsatz des maximalen Gebäudespeichers."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Post-Überfüllung beheben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Wird eine Posteinrichtung zu voll, reduziert Magic Mail die gespeicherte Post auf den gewählten Wert.\n" +
                    "Gezählt werden lokale, unsortierte und ausgehende Post, damit auch Überfüllungen erfasst werden, die das Spiel falsch berechnen kann.\n" +
                    "Für reines Vanilla-Verhalten deaktivieren."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Überfüllungsschwelle Postamt" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Steigt die gesamte gespeicherte Post über diesen Wert, reduziert Magic Mail sie wieder.\n" +
                    "Gilt für normale Postämter und Postämter mit Sortier-Upgrade."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Überfüllungsschwelle Sortieranlage" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Steigt die gesamte gespeicherte Post in einer eigenen Sortieranlage über diesen Wert,\n" +
                    "reduziert Magic Mail sie wieder."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Kapazitäten ändern" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Aktivieren, um Kapazitäten von Postwagen und LKW zu ändern. Ist dies aus,\n" +
                    "werden die Regler darunter ausgeblendet und\n" +
                    "Vanilla-Werte verwendet, auch wenn andere Reglerwerte gespeichert sind."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Postwagen-Ladung" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Bestimmt, wie viel Post jeder Postwagen transportieren kann.\n" +
                    "<100% = Vanilla-Ladung.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Postwagen-Flottengröße" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Bestimmt, wie viele Postwagen ein Postgebäude besitzen und losschicken kann.\n" +
                    "<100% = Vanilla-Flottengröße.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Post-LKW-Flottengröße" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Bestimmt, wie viele Post-LKW eine Einrichtung mit Post-LKW besitzen und losschicken kann.\n" +
                    "<100% = Vanilla-Flottengröße.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sortiergeschwindigkeit" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplikator für eigene Sortieranlagen.\n" +
                    "Ändert nicht das Sortier-Upgrade eines Postamts.\n" +
                    "<100% = Vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sortier-Speicherkapazität" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Bestimmt den Postspeicher eigener Sortieranlagen.\n" +
                    "Ändert nicht das Sortier-Upgrade eines Postamts.\n" +
                    "<100% = Vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Wenig unsortierte Post retten" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Lässt das Spiel unsortierte Post zuerst normal liefern.\n" +
                    "Bleibt eine eigene Sortieranlage mehrere Prüfungen lang sehr niedrig,\n" +
                    "fügt Magic Mail eine kleine Rettungsmenge hinzu."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Rettungsschwelle für unsortierte Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Unsortierte Post gilt ab diesem Anteil des maximalen Speichers als niedrig.\n" +
                    "Die Rettung greift nur, wenn der Wert mehrere Prüfungen lang niedrig bleibt."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Rettungsmenge für unsortierte Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Menge an unsortierter Post, die bei einer Rettung hinzugefügt wird.\n" +
                    "Die Menge ist ein Prozentsatz des maximalen Speichers."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Spiel-Standards" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Setzt alle Einstellungen auf das ursprüngliche Verhalten des Spiels (Vanilla) zurück." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Empfohlen" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Vanilla-Hilfe** – Schnellstart.\n" +
                    "Lässt zuerst die normale Postlogistik arbeiten und rettet erst anhaltende Engpässe oder Überfüllung.\n" +
                    "Wendet außerdem die empfohlenen Kapazitätswerte an."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Postgebäude, die beim Öffnen der Statusseite gefunden wurden.\n" +
                    "\n" +
                    "**Postämter** = normale Postämter.\n" +
                    "**Sortieranlagen** = eigenständige Post-Sortieranlagen.\n" +
                    "**Postämter mit Sortierung** = <Westmont Tower mit Sortier-Upgrade>.\n" +
                    "- Benötigt den **Skyscrapers-DLC**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Postfahrzeug-Kapazität beim Öffnen der Statusseite.\n" +
                    "\n" +
                    "**Postwagen** = Fahrzeuge für lokale Abholung und Zustellung.\n" +
                    "**Post-LKW** = LKW, die Post zwischen Einrichtungen transportieren."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Monatliche Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Zeigt den aktuellen stadtweiten Postfluss.\n" +
                    "\n" +
                    "**Erzeugt** = wie viel Post die Bürger erstellt haben.\n" +
                    "**Verarbeitet** = wie viel Post das Netzwerk tatsächlich bearbeitet hat.\n" +
                    "\n" +
                    "- Ist Verarbeitet oft höher als Erzeugt, hat dein Postnetz genug Kapazität.\n" +
                    "- Bleibt Erzeugt längere Zeit höher als Verarbeitet,\n" +
                    "erzeugt die Stadt mehr Post als das Netz bewältigen kann.\n" +
                    "Baue mehr Einrichtungen oder Postwagen oder passe die Einstellungen an."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Aktivität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Rettungen und Überfüllungs-Bereinigungen aus dem letzten Magic-Mail-Rettungsdurchlauf." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Bericht schreiben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Führt bei geöffneten Optionen einen **einmaligen** detaillierten Post-Scan aus\n" +
                    "und schreibt den Bericht in <Logs/MagicMail.log>. Keine Hintergrund-Protokollierung."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnet <Logs/MagicMail.log> oder den Logs-Ordner, falls die Datei noch nicht existiert." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Keine Posteinrichtungen gefunden. Öffne eine Stadt und dann erneut Status." },
                { "MM_STATUS_NO_ACTIVITY", "Keine Rettungsaktivität aufgezeichnet." },
                { "MM_STATUS_SUMMARY", "Postämter: {0} | Postämter mit Sortierung: {1} | Sortieranlagen: {2}" },
                { "MM_STATUS_VEHICLES", "Postwagen: {0} | Post-LKW: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} lokale Rettungen | {1} unsortierte Rettungen | {2} Überfüllungs-Bereinigungen" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Stadtweite Poststatistik noch nicht verfügbar. Öffne eine Stadt und lass die Simulation kurz laufen." },
                { "MM_STATUS_CITY_MAIL", "{0} erzeugt | {1} verarbeitet" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Anzeigename dieses Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Aktuelle Mod-Version und Build-Typ." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mochis Paradox-Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die **Paradox**-Seite für **Magic Mail** und weitere Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Öffnet den **Discord**-Feedback-Chat im Browser." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
