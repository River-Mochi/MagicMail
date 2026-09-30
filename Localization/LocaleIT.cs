// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleIT.cs
// Italian locale it-IT

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Italian localization source for Magic Mail [MM].</summary>
    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Italian locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleIT(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Italian localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Stato" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Info" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Assistenza alla distribuzione postale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Furgoni e camion postali" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro di smistamento dedicato" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Ripristina" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Scansione città" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Ultimo aggiornamento" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Link" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Soccorri posta locale bassa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Lascia prima al gioco il tentativo con i normali trasferimenti di posta.\n" +
                    "Se la posta locale resta molto bassa per diverse scansioni, Magic Mail aggiunge un piccolo rifornimento di soccorso.\n" +
                    "Vale anche per gli uffici postali con miglioramento di smistamento."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Soglia soccorso posta locale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "La posta locale è considerata bassa a questa percentuale dello spazio massimo dell'edificio.\n" +
                    "Il soccorso parte solo se resta bassa per diverse scansioni."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantità soccorso posta locale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Quanta posta locale aggiungere quando scatta il soccorso.\n" +
                    "È una percentuale dello spazio massimo dell'edificio."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Correggi posta in eccesso" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Se una struttura postale si riempie troppo, Magic Mail riduce la posta accumulata al livello scelto.\n" +
                    "Conta posta locale + non smistata + in uscita, così può rilevare eccessi che il gioco può calcolare male.\n" +
                    "Disattiva per il comportamento vanilla puro."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Soglia eccesso ufficio postale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quando la posta totale supera questo livello, Magic Mail la riduce.\n" +
                    "Vale per uffici normali e uffici con miglioramento di smistamento."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Soglia eccesso centro di smistamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quando la posta totale in un centro di smistamento dedicato supera questo livello,\n" +
                    "Magic Mail la riduce."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Modifica capacità" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Attiva per modificare le capacità di furgoni e camion. Se è disattivato,\n" +
                    "i cursori sotto vengono nascosti e\n" +
                    "si usano i valori vanilla anche se erano rimasti impostati valori diversi."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carico furgone postale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controlla quanta posta può trasportare ogni furgone postale.\n" +
                    "<100% = carico vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Dimensione flotta furgoni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controlla quanti furgoni ogni edificio postale può possedere e inviare.\n" +
                    "<100% = flotta vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Dimensione flotta camion" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controlla quanti camion postali ogni struttura che li usa può possedere e inviare.\n" +
                    "<100% = flotta vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocità di smistamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Moltiplicatore per i centri di smistamento dedicati.\n" +
                    "Non cambia il miglioramento di smistamento di un ufficio postale.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacità deposito smistamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controlla lo spazio posta dei centri di smistamento dedicati.\n" +
                    "Non cambia il miglioramento di smistamento di un ufficio postale.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Soccorri posta non smistata bassa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Lascia prima al gioco la normale fornitura di posta non smistata.\n" +
                    "Se un centro dedicato resta molto basso per diverse scansioni,\n" +
                    "Magic Mail aggiunge un piccolo rifornimento di soccorso."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Soglia soccorso posta non smistata" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "La posta non smistata è considerata bassa a questa percentuale dello spazio massimo.\n" +
                    "Il soccorso parte solo se resta bassa per diverse scansioni."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantità soccorso posta non smistata" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quanta posta non smistata aggiungere quando scatta il soccorso.\n" +
                    "È una percentuale dello spazio massimo."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valori del gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Ripristina tutte le impostazioni al comportamento predefinito originale del gioco." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Consigliato" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Assistenza alla distribuzione postale** - Avvio rapido.\n" +
                    "Lascia lavorare prima la logistica normale, poi interviene su carenze ripetute o eccessi.\n" +
                    "Applica anche le regolazioni di capacità consigliate."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Edifici postali trovati quando si apre la pagina Stato.\n" +
                    "\n" +
                    "**Uffici postali** = uffici normali.\n" +
                    "**Centri di smistamento** = centri postali dedicati.\n" +
                    "**Uffici con smistamento** = <Westmont Tower con miglioramento di smistamento>.\n" +
                    "- Richiede il **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Capacità dei veicoli postali quando si apre la pagina Stato.\n" +
                    "\n" +
                    "**Furgoni postali** = ritiro e consegna locale.\n" +
                    "**Camion postali** = spostano la posta tra le strutture."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Posta mensile" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Mostra il flusso recente della posta in tutta la città.\n" +
                    "\n" +
                    "**Accumulated** = quanta posta hanno generato i cittadini.\n" +
                    "**Processed** = quanta posta la rete ha davvero gestito.\n" +
                    "\n" +
                    "- Se Processed è spesso superiore ad Accumulated, la rete postale ha abbastanza capacità.\n" +
                    "- Se Accumulated resta sopra Processed a lungo,\n" +
                    "la città genera più posta di quanta la rete riesca a gestire.\n" +
                    "Aggiungi strutture, furgoni o modifica le impostazioni."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Attività" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Interventi di soccorso e pulizie per eccesso dell'ultimo passaggio di Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Scrivi rapporto" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Esegue **una sola volta** una scansione postale dettagliata mentre le Opzioni sono aperte,\n" +
                    "poi scrive il rapporto in <Logs/MagicMail.log>. Nessun log in background."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apre <Logs/MagicMail.log> oppure la cartella Logs se il file non esiste ancora." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Nessuna struttura postale trovata. Apri una città, poi riapri Stato." },
                { "MM_STATUS_NO_ACTIVITY", "Nessuna attività di soccorso registrata." },
                { "MM_STATUS_SUMMARY", "Uffici postali: {0} | Uffici con smistamento: {1} | Centri di smistamento: {2}" },
                { "MM_STATUS_VEHICLES", "Furgoni postali: {0} | Camion postali: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} soccorsi locali | {1} soccorsi non smistati | {2} pulizie eccesso" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Statistiche postali della città non ancora disponibili. Apri una città e lascia andare la simulazione." },
                { "MM_STATUS_CITY_MAIL", "{0} accumulata | {1} elaborata" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Nome visualizzato di questo mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Versione attuale del mod e tipo di build." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mod Paradox di Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina **Paradox** di **Magic Mail** e degli altri mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apre nel browser la chat **Discord** per feedback." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
