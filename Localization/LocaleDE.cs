// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocaleDE.cs
// German locale de-DE
namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German localization source for Magic Mail [MM].
    /// </summary>
    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

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
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Postversand-Hilfe" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Postwagen & LKW" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Sortieranlage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Zurücksetzen" },

                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Stadtübersicht" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Letzte Aktivität" },

                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Information" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Niedrige lokale Post beheben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Wenn aktiviert, erscheint eine kleine Menge lokaler Post,\n" +
                    "falls der Bestand zu niedrig wird.\n" +
                    "Es werden keine zusätzlichen Fahrzeuge erzeugt – es ist wie Magie… aber echt :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Schwellwert für lokale Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Wenn die lokale Post unter diesen Prozentsatz fällt,\n" +
                    "zieht das Postamt automatisch zusätzliche Post nach.\n" +
                    "Dies ist ein Prozentsatz der maximalen Gebäude-Kapazität.\n" +
                    "Beispiel: <max = 100.000>, <Schwellwert = 5%>,\n" +
                    "wenn lokale Post < <5.000>, wird Post ergänzt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Menge der lokalen Postauffüllung" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Prozentsatz, der beim Auffüllen lokaler Post hinzugefügt wird.\n" +
                    "Wenn vanilla max = <100.000> und dies <10%> ist,\n" +
                    "werden <10.000> ergänzt."
                },

                // Overflow
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Überlauf von Post beheben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Wenn zu viel Post gespeichert ist, entfernt die Mod kleine Mengen,\n" +
                    "um Überfüllung zu verhindern.\n" +
                    "Dies hält Anlagen funktionsfähig.\n" +
                    "Deaktivieren, um reines Vanilla-Verhalten zu erhalten."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Postamt-Überlaufgrenze" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Wenn die Gesamtpost diesen Prozentsatz erreicht,\n" +
                    "wird überschüssige Post gelöscht, um das Level zu halten."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Sortieranlage-Überlaufgrenze" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Wenn eine Sortieranlage diesen Prozentsatz erreicht,\n" +
                    "wird überschüssige Post entfernt."
                },

                // ---- Vans & trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Kapazitäten ändern" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Aktivieren, um Wagen- und LKW-Kapazitäten anzupassen.\n" +
                    "Wenn deaktiviert, werden Vanilla-Werte verwendet."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Postwagen-Ladung" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Steuert die Postmenge pro Wagen.\n" +
                    "<100% = Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Flottengröße (Postwagen)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Steuert die Anzahl der Postwagen pro Gebäude.\n" +
                    "<100% = Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Flottengröße (Post-LKW)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Steuert die Anzahl der Post-LKW.\n" +
                    "<100% = Vanilla>"
                },

                // ---- Sorting ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sortiergeschwindigkeit" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplikator für Sortieranlagen.\n<100% = Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sortier-Speicherkapazität" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Kontrolle der Speichermenge.\n<100% = Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Niedrige unsortierte Post beheben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Wenn aktiviert, erscheint zusätzliche unsortierte Post,\n" +
                    "wenn die Menge zu niedrig wird."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Schwellwert für unsortierte Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Wenn unsortierte Post unter diesen Prozentsatz fällt,\n" +
                    "wird automatisch Post ergänzt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Auffüllmenge für unsortierte Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Prozentsatz der Ergänzung.\n" +
                    "Beispiel: max = <250.000>, <10%> → <25.000> werden ergänzt."
                },

                // ---- Reset ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Spiel-Standard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Alle Einstellungen auf Vanilla zurücksetzen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)), "Schnellstart – empfohlene Einstellungen anwenden." },

                // ---- Status ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Zusammenfassung der verarbeiteten Einrichtungen beim letzten Scan."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Monatliche Post" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Zeigt die jüngste stadtweite Postbewegung."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Aktivität" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Anzahl der Nachfüllungen und Überlaufbehebungen beim letzten Update."
                },

                // ---- Status Templates ----
                { "MM_STATUS_NO_FACILITIES", "Noch keine Postanlagen verarbeitet. Öffne eine Stadt und lasse die Simulation laufen." },
                { "MM_STATUS_NO_ACTIVITY", "Noch keine Aktivität aufgezeichnet." },

                { "MM_STATUS_SUMMARY",
                  "{0} Postämter | {1} Postwagen | {2} Sortieranlagen | {3} Post-LKW" },

                { "MM_STATUS_ACTIVITY",
                  "{0} lokale Nachfüllungen | {1} unsortierte Nachfüllungen | {2} Überlauf-Bereinigungen" },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Stadtpost-Statistiken noch nicht verfügbar. Öffne eine Stadt und warte." },

                { "MM_STATUS_CITY_MAIL",
                  "{0} angesammelt | {1} verarbeitet" },

                // ---- About ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Name der Mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Seite der Mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Öffnet den Discord-Kanal." },
            };
        }

        public void Unload()
        {
        }
    }
}
