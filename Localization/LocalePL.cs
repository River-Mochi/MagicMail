// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocalePL.cs
// Polish locale pl-PL

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Polish localization source for Magic Mail [MM].</summary>
    public class LocalePL : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Polish locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocalePL(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Polish localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.StatusTab), "Stan" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.AboutTab), "Informacje" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "Wsparcie dostaw pocztowych" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "Furgonetki i ciężarówki" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "Dedykowana sortownia" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "Resetuj" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "Skan miasta" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "Ostatnia aktualizacja" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutLinksGroup), "Linki" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "Ratowanie niskiej lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "Najpierw pozwala grze spróbować normalnych transferów poczty.\n" +
                    "Jeśli lokalna poczta pozostaje bardzo niska przez kilka skanów, Magic Mail dodaje małe awaryjne uzupełnienie.\n" +
                    "Dotyczy też urzędów pocztowych z ulepszeniem sortowania."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "Próg ratowania lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "Lokalna poczta jest uznawana za niską przy tym procencie maksymalnego magazynu budynku.\n" +
                    "Ratowanie działa dopiero, gdy niski poziom utrzymuje się przez kilka skanów."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "Ilość ratunkowej lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "Ile lokalnej poczty dodać po uruchomieniu ratowania.\n" +
                    "To procent maksymalnego magazynu budynku."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "Ratowanie przepełnionej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "Jeśli obiekt pocztowy jest zbyt pełny, Magic Mail zmniejsza zapas do wybranego poziomu.\n" +
                    "Liczy pocztę lokalną + niesortowaną + wychodzącą, więc wykrywa też przepełnienie źle liczone przez grę.\n" +
                    "Wyłącz, aby zachować czyste zachowanie vanilla."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "Próg przepełnienia urzędu pocztowego" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "Gdy całkowita ilość poczty przekroczy ten poziom, Magic Mail ją zmniejsza.\n" +
                    "Dotyczy zwykłych urzędów i urzędów z ulepszeniem sortowania."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "Próg przepełnienia sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "Gdy całkowita ilość poczty w dedykowanej sortowni przekroczy ten poziom,\n" +
                    "Magic Mail ją zmniejsza."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "Zmień pojemności" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "Włącz, aby zmieniać pojemności furgonetek i ciężarówek. Po wyłączeniu\n" +
                    "suwaki poniżej są ukryte i\n" +
                    "używane są wartości vanilla gry, nawet jeśli inne wartości pozostały zapisane."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "Ładunek furgonetki pocztowej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "Steruje ilością poczty przewożonej przez każdą furgonetkę.\n" +
                    "<100% = normalny ładunek vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "Wielkość floty furgonetek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "Steruje liczbą furgonetek, które każdy budynek pocztowy może posiadać i wysyłać.\n" +
                    "<100% = normalna flota vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "Wielkość floty ciężarówek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "Steruje liczbą ciężarówek pocztowych, które może posiadać i wysyłać obiekt z ciężarówkami.\n" +
                    "<100% = normalna flota vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "Szybkość sortowania" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "Mnożnik dla dedykowanych sortowni.\n" +
                    "Nie zmienia ulepszenia sortowania w urzędzie pocztowym.\n" +
                    "<100% = normalne vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "Pojemność magazynu sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "Steruje magazynem poczty w dedykowanych sortowniach.\n" +
                    "Nie zmienia ulepszenia sortowania w urzędzie pocztowym.\n" +
                    "<100% = normalne vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "Ratowanie niskiej niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "Najpierw pozwala grze normalnie dostarczać niesortowaną pocztę.\n" +
                    "Jeśli dedykowana sortownia pozostaje bardzo niska przez kilka skanów,\n" +
                    "Magic Mail dodaje małe awaryjne uzupełnienie."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "Próg ratowania niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "Niesortowana poczta jest uznawana za niską przy tym procencie maksymalnego magazynu.\n" +
                    "Ratowanie działa dopiero, gdy niski poziom utrzymuje się przez kilka skanów."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "Ilość ratunkowej niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "Ile niesortowanej poczty dodać po uruchomieniu ratowania.\n" +
                    "To procent maksymalnego magazynu."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "Ustawienia gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "Przywraca wszystkie ustawienia do oryginalnego domyślnego zachowania gry." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "Zalecane" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**Wsparcie dostaw pocztowych** - Szybki start.\n" +
                    "Najpierw pozwala działać normalnej logistyce, a potem ratuje powtarzające się braki lub przepełnienie.\n" +
                    "Stosuje też zalecane ustawienia pojemności."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "Budynki pocztowe znalezione po otwarciu strony Stan.\n" +
                    "\n" +
                    "**Urzędy pocztowe** = zwykłe urzędy.\n" +
                    "**Sortownie** = dedykowane obiekty sortowania poczty.\n" +
                    "**Urzędy z sortowaniem** = <Westmont Tower z ulepszeniem sortowania>.\n" +
                    "- Wymaga **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "Pojemność pojazdów pocztowych po otwarciu strony Stan.\n" +
                    "\n" +
                    "**Furgonetki pocztowe** = lokalny odbiór i dostawa.\n" +
                    "**Ciężarówki pocztowe** = przewożą pocztę między obiektami."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "Miesięczna poczta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "Pokazuje ostatni przepływ poczty w całym mieście.\n" +
                    "\n" +
                    "**Nagromadzona** = poczta wygenerowana przez mieszkańców.\n" +
                    "**Przetworzona** = poczta faktycznie obsłużona przez sieć.\n" +
                    "\n" +
                    "- Jeśli Przetworzona często przewyższa Nagromadzoną, sieć ma wystarczającą wydajność.\n" +
                    "- Jeśli Nagromadzona długo pozostaje wyższa,\n" +
                    "miasto generuje więcej poczty, niż sieć może obsłużyć.\n" +
                    "Dodaj obiekty, furgonetki albo zmień ustawienia."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "Aktywność" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "Ratowania i czyszczenia przepełnienia z ostatniego przebiegu ratunkowego Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "Zapisz raport" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "Wykonuje **jednorazowy** szczegółowy skan poczty przy otwartych Opcjach,\n" +
                    "a potem zapisuje raport do <Logs/MagicMail.log>. Bez logowania w tle."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "Otwiera <Logs/MagicMail.log> albo folder Logs, jeśli plik jeszcze nie istnieje." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Nie znaleziono obiektów pocztowych. Otwórz miasto, a potem ponownie Stan." },
                { "MM_STATUS_NO_ACTIVITY", "Nie zapisano aktywności ratunkowej." },
                { "MM_STATUS_SUMMARY", "Urzędy pocztowe: {0} | Urzędy z sortowaniem: {1} | Sortownie: {2}" },
                { "MM_STATUS_VEHICLES", "Furgonetki pocztowe: {0} | Ciężarówki pocztowe: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} ratowań lokalnej | {1} ratowań niesortowanej | {2} czyszczeń przepełnienia" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Statystyki poczty miasta nie są jeszcze dostępne. Otwórz miasto i uruchom symulację." },
                { "MM_STATUS_CITY_MAIL", "{0} nagromadzona | {1} przetworzona" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "Wyświetlana nazwa tego moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "Aktualna wersja moda i typ kompilacji." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Mody Mochi na Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "Otwiera stronę **Paradox** dla **Magic Mail** i innych modów." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "Otwiera czat opinii **Discord** w przeglądarce." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
