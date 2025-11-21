// Localization/LocaleDE.cs
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Info" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Postamt" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Postwagen & LKW" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Sortieranlage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Zurücksetzen" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Stadt-Überblick" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Letzte Aktualisierung" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Niedrige lokale Post beheben" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Wenn aktiviert und der Lagerstand zu niedrig wird, erscheint zusätzliche Post.\n " +
                    "Es werden keine zusätzlichen Lieferwagen gespawnt – fast wie Magie, aber echt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Schwellwert für lokale Post" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Wenn lokale Post unter diesen von dir gewählten Prozentsatz fällt,\n " +
                    "zieht das Postamt automatisch mehr lokale Post nach.\n" +
                    "Bezogen auf den maximalen Speicher." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Menge der nachgezogenen lokalen Post" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Prozentsatz, der beim Nachziehen von lokaler Post hinzugefügt wird (magisches Auffüllen).\n" +
                    "Wenn das Vanilla-Maximum = 10.000 ist und hier 20 % eingestellt sind, werden 2.000 hinzugefügt." },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Postüberlauf beheben" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Wenn es zu viel Post gibt, führen die Anlagen eine kleine **magische** Aufräumaktion durch.\n " +
                    "Überschüssige Post wird als zugestellt behandelt und entfernt.\n " +
                    "So bleiben Anlagen nicht dauerhaft als „voll“ hängen.\n " +
                    "Deaktiviere dies, um das reine Vanilla-Verhalten zu behalten." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Überlauf-Schwellwert (Postamt)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Wenn die Gesamtmenge an Post in einem Postamt diesen Prozentsatz erreicht,\n" +
                    "löscht das Mod genügend gespeicherte Post, um wieder auf dieses Niveau zu kommen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Überlauf-Schwellwert (Sortierung)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "Wenn die Gesamtmenge an Post in einer Sortieranlage diesen Prozentsatz erreicht,\n" +
                   "löscht das Mod genügend gespeicherte Post, um wieder auf dieses Niveau zu kommen." },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Kapazitäten ändern" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Aktiviere dies, um Kapazitäten von Wagen und LKW anzupassen. Wenn deaktiviert,\n" +
                    "werden alle Slider unten ausgeblendet und\n" +
                    "Vanilla-Werte verwendet – selbst wenn die Slider andere Werte anzeigen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Postwagen-Ladung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Steuert, wie viel Post jeder Postwagen transportieren kann.\n" +
                    "<100 % = Vanilla-Nutzlast.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Anzahl der Postwagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Steuert, wie viele Postwagen jedes Postgebäude besitzen und aussenden kann.\n" +
                    "<100 % = Vanilla-Flottengröße.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Anzahl der Post-LKW" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Steuert, wie viele Post-LKW jede Sortieranlage (und andere Gebäude mit Post-LKW)\n " +
                    "besitzen und aussenden kann.\n " +
                    "<100 % = Vanilla-Flottengröße.>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Sortiergeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplikator für **Sortier**anlagen. Wirkt auf die Basis-Sortiergeschwindigkeit der Anlage.\n " +
                    "<100 % = Vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sortierspeicher-Kapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Steuert die **Post-Speicherkapazität**.\n " +
                    "<100 % = Vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Niedrige unsortierte Post beheben" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Wenn aktiviert, erscheint etwas unsortierte Post „magisch“, wenn der Vorrat zu niedrig ist.\n " +
                    "So bleiben Sortiergebäude aktiv, ohne auf Lieferungen warten zu müssen.\n" +
                    "Dies ist ein temporärer Fix für einen Bug, bei dem Sortieranlagen zu wenig Post bekommen,\n " +
                    "wenn ein Frachthafen vorhanden ist." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Schwellwert unsortierte Post" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Wenn unsortierte Post unter diesen Prozentsatz der Kapazität fällt,\n " +
                    "wird magisch zusätzliche unsortierte Post nachgezogen.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Menge der unsortierten Post" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Zusätzliche Post, die beim Nachziehen von unsortierter Post hinzugefügt wird (magisches Auffüllen).\n" +
                    "Wert ist ein Prozentsatz der maximalen Speicherkapazität." },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Spiel-Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Setzt alle Einstellungen auf das ursprüngliche Standardverhalten des Spiels (Vanilla) zurück." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Schnellstart** – wendet alle empfohlenen Post-Einstellungen an.\n" +
                    "Easy-Mode: 1 Klick und fertig!" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Zusammenfassung der Postämter, Postwagen, Sortieranlagen und Post-LKW,\n " +
                    "die im letzten Spiel-Update verarbeitet wurden (~alle 45 In-Game-Minuten)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Stadtpost" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Zeigt den aktuellen Postfluss in der Stadt.\n\n" +
                     "**Gesammelt** = wie viel Post die Bürger erzeugt haben.\n" +
                     "**Verarbeitet**   = wie viel Post das Netzwerk tatsächlich bearbeitet hat.\n\n" +
                     "- Wenn „Verarbeitet“ häufig höher ist als „Gesammelt“, hat dein Postnetz genug Kapazität.\n " +
                     "- Wenn „Gesammelt“ über lange Zeit höher bleibt, produziert die Stadt mehr Post,\n " +
                     "als verarbeitet werden kann; baue weitere Anlagen, mehr Wagen oder passe die Einstellungen an." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Aktivität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Anzahl der Post-Nachzüge und Überlaufbereinigungen im letzten Update." },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Aktuelle Mod-Version." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Öffnet die **Paradox**-Seite für **Magic Mail** und andere Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet den **Discord**-Feedback-Chat im Browser." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
