// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocaleIT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Stato" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Informazioni" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Assistenza alla distribuzione postale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Furgoni e camion" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro di smistamento" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Reimposta" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Panoramica città" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Ultimo aggiornamento" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Link" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Correggi posta locale bassa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Se attivato, viene aggiunta una piccola quantità di posta locale\n" +
                    "quando le scorte diventano troppo basse.\n" +
                    "Non genera furgoni extra: è come magia… ma vera :)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Soglia posta locale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Se la posta locale scende sotto questa percentuale,\n" +
                    "l’ufficio postale recupera automaticamente altra posta.\n" +
                    "È una percentuale della capacità massima dell’edificio.\n" +
                    "Es.: <max = 100.000>, <soglia = 5%>,\n" +
                    "se la posta locale < <5.000>, viene aggiunta posta."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantità ricarica locale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentuale da aggiungere quando si ricarica la posta locale.\n" +
                    "Se la capacità vanilla max = <100.000> e il valore è <10%>,\n" +
                    "vengono aggiunti <10.000>."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Correggi sovraccarico di posta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Quando viene accumulata troppa posta, gli edifici eseguono\n" +
                    "una piccola pulizia magica.\n" +
                    "La posta in eccesso viene considerata consegnata e rimossa.\n" +
                    "Evita che le strutture restino bloccate al 100%.\n" +
                    "Disabilita per mantenere il comportamento vanilla."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Soglia sovraccarico ufficio postale" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quando la posta totale dell’ufficio postale raggiunge questa percentuale,\n" +
                    "la mod rimuove quanto basta per riportarla a quel livello."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Soglia sovraccarico centro di smistamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quando la posta totale di un centro di smistamento raggiunge questa percentuale,\n" +
                    "la mod elimina l’eccesso."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Modifica capacità" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Attiva la modifica delle capacità di furgoni e camion.\n" +
                    "Se disattivato, vengono usati i valori vanilla\n" +
                    "anche se i cursori sono altrove."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carico posta per furgone" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controlla quanta posta può trasportare ciascun furgone postale.\n" +
                    "<100% = carico vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Dimensione flotta furgoni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controlla quanti furgoni può possedere e inviare ogni edificio postale.\n" +
                    "<100% = flotta vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Dimensione flotta camion" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controlla quanti camion postali può avere ogni centro di smistamento\n" +
                    "o altra struttura con camion postali.\n" +
                    "<100% = flotta vanilla>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocità di smistamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Moltiplicatore per i centri di smistamento. Si applica alla velocità base.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacità di stoccaggio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controlla la capacità di stoccaggio della posta.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Correggi posta non smistata bassa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Se attivato, viene aggiunta posta non smistata extra quando le scorte\n" +
                    "sono troppo basse, così i centri restano attivi.\n" +
                    "Soluzione temporanea a un bug in cui i centri ricevono poca posta\n" +
                    "se è presente un porto merci."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Soglia posta non smistata" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Se la posta non smistata scende sotto questa bassa percentuale\n" +
                    "della capacità totale, viene aggiunta automaticamente altra posta."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantità ricarica non smistata" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quantità aggiunta quando si ricarica posta non smistata\n" +
                    "(in % della capacità massima).\n" +
                    "Es.: capacità max <250.000>, valore <10%> → <25.000> aggiunti."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valori di gioco" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Ripristina tutte le impostazioni al comportamento predefinito del gioco (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Consigliato" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Avvio rapido** – applica tutte le impostazioni postali consigliate.\n" +
                    "Modalità facile: un clic e hai finito."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Riepilogo di uffici postali, furgoni, centri di smistamento e camion\n" +
                    "elaborati nell’ultima scansione in background."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Posta mensile" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Mostra il flusso di posta recente in tutta la città.\n\n" +
                    "**Accumulata** = posta generata dai cittadini.\n" +
                    "**Gestita**    = posta effettivamente elaborata dalla rete.\n\n" +
                    "- Se \"Gestita\" è spesso maggiore di \"Accumulata\", la rete è sufficiente.\n" +
                    "- Se \"Accumulata\" resta a lungo sopra \"Gestita\",\n" +
                    "la città genera più posta di quanta la rete possa gestire.\n" +
                    "Aggiungi strutture o regola le impostazioni."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Attività" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Conteggi delle ricariche di posta e delle pulizie di sovraccarico\n" +
                    "eseguite nell’ultimo aggiornamento."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Nessuna struttura postale ancora elaborata. Apri una città e lascia girare la simulazione." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Nessuna attività registrata finora." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} uffici postali | {1} furgoni postali | {2} centri di smistamento | {3} camion postali"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} ricariche di posta locale | {1} ricariche di posta non smistata | {2} pulizie di sovraccarico"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Statistiche della posta cittadina non ancora disponibili. Apri una città e lascia girare la simulazione." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} accumulata | {1} gestita"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nome visualizzato di questa mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versione" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Versione attuale della mod."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Apri la pagina **Paradox** di **Magic Mail** e delle altre mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apri il canale **Discord** dei feedback nel browser."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
