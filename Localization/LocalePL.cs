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
    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Polish locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocalePL(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Stan" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Informacje" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Pomoc vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Furgonetki i ciężarówki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Dedykowana sortownia" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Resetuj" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Skan miasta" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Ostatnia aktualizacja" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Linki" },

                // ---- Post Office / Postal Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Ratowanie niskiej lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Najpierw pozwala grze spróbować normalnych transferów poczty.\n" +
                    "Jeśli lokalna poczta pozostaje bardzo niska przez kilka skanów, Magic Mail dodaje małe awaryjne uzupełnienie.\n" +
                    "Dotyczy też urzędów pocztowych z ulepszeniem sortowania."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Próg ratowania lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Lokalna poczta jest uznawana za niską przy tym procencie maksymalnego magazynu budynku.\n" +
                    "Ratowanie działa dopiero, gdy niski poziom utrzymuje się przez kilka skanów."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Ilość ratunkowej lokalnej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Ile lokalnej poczty dodać po uruchomieniu ratowania.\n" +
                    "To procent maksymalnego magazynu budynku."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Ratowanie przepełnionej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Jeśli obiekt pocztowy jest zbyt pełny, Magic Mail zmniejsza zapas do wybranego poziomu.\n" +
                    "Liczy pocztę lokalną + niesortowaną + wychodzącą, więc wykrywa też przepełnienie źle liczone przez grę.\n" +
                    "Wyłącz, aby zachować czyste zachowanie vanilla."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Próg przepełnienia urzędu pocztowego" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Gdy całkowita ilość poczty przekroczy ten poziom, Magic Mail ją zmniejsza.\n" +
                    "Dotyczy zwykłych urzędów i urzędów z ulepszeniem sortowania."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Próg przepełnienia sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Gdy całkowita ilość poczty w dedykowanej sortowni przekroczy ten poziom,\n" +
                    "Magic Mail ją zmniejsza."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Zmień pojemności" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Włącz, aby zmieniać pojemności furgonetek i ciężarówek. Po wyłączeniu\n" +
                    "suwaki poniżej są ukryte i\n" +
                    "używane są wartości vanilla, nawet jeśli inne wartości pozostały zapisane."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Ładunek furgonetki pocztowej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Steruje ilością poczty przewożonej przez każdą furgonetkę.\n" +
                    "<100% = ładunek vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Wielkość floty furgonetek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Steruje liczbą furgonetek, które każdy budynek pocztowy może posiadać i wysyłać.\n" +
                    "<100% = flota vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Wielkość floty ciężarówek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Steruje liczbą ciężarówek pocztowych, które może posiadać i wysyłać obiekt z ciężarówkami.\n" +
                    "<100% = flota vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Szybkość sortowania" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Mnożnik dla dedykowanych sortowni.\n" +
                    "Nie zmienia ulepszenia sortowania w urzędzie pocztowym.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Pojemność magazynu sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Steruje magazynem poczty w dedykowanych sortowniach.\n" +
                    "Nie zmienia ulepszenia sortowania w urzędzie pocztowym.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Ratowanie niskiej niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Najpierw pozwala grze normalnie dostarczać niesortowaną pocztę.\n" +
                    "Jeśli dedykowana sortownia pozostaje bardzo niska przez kilka skanów,\n" +
                    "Magic Mail dodaje małe awaryjne uzupełnienie."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Próg ratowania niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Niesortowana poczta jest uznawana za niską przy tym procencie maksymalnego magazynu.\n" +
                    "Ratowanie działa dopiero, gdy niski poziom utrzymuje się przez kilka skanów."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Ilość ratunkowej niesortowanej poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Ile niesortowanej poczty dodać po uruchomieniu ratowania.\n" +
                    "To procent maksymalnego magazynu."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Ustawienia gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Przywraca wszystkie ustawienia do oryginalnego zachowania gry (vanilla)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Zalecane" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Pomoc vanilla** - Szybki start.\n" +
                    "Najpierw pozwala działać normalnej logistyce, a potem ratuje tylko trwałe braki lub przepełnienie.\n" +
                    "Stosuje też zalecane ustawienia pojemności."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Budynki pocztowe znalezione po otwarciu strony Stan.\n" +
                    "\n" +
                    "**Urzędy pocztowe** = zwykłe urzędy.\n" +
                    "**Sortownie** = dedykowane obiekty sortowania poczty.\n" +
                    "**Urzędy z sortowaniem** = <Westmont Tower z ulepszeniem sortowania>.\n" +
                    "- Wymaga **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Pojemność pojazdów pocztowych po otwarciu strony Stan.\n" +
                    "\n" +
                    "**Furgonetki pocztowe** = lokalny odbiór i dostawa.\n" +
                    "**Ciężarówki pocztowe** = przewożą pocztę między obiektami."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Miesięczna poczta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Aktywność" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Ratowania i czyszczenia przepełnienia z ostatniego przebiegu ratunkowego Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Zapisz raport" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Wykonuje **jednorazowy** szczegółowy skan poczty przy otwartych Opcjach,\n" +
                    "a potem zapisuje raport do <Logs/MagicMail.log>. Bez logowania w tle."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwiera <Logs/MagicMail.log> albo folder Logs, jeśli plik jeszcze nie istnieje." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Nie znaleziono obiektów pocztowych. Otwórz miasto, a potem ponownie Stan." },
                { "MM_STATUS_NO_ACTIVITY", "Nie zapisano aktywności ratunkowej." },
                { "MM_STATUS_SUMMARY", "Urzędy pocztowe: {0} | Urzędy z sortowaniem: {1} | Sortownie: {2}" },
                { "MM_STATUS_VEHICLES", "Furgonetki pocztowe: {0} | Ciężarówki pocztowe: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} ratowań lokalnej | {1} ratowań niesortowanej | {2} czyszczeń przepełnienia" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Statystyki poczty miasta nie są jeszcze dostępne. Otwórz miasto i uruchom symulację." },
                { "MM_STATUS_CITY_MAIL", "{0} nagromadzona | {1} przetworzona" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Wyświetlana nazwa tego moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Aktualna wersja moda i typ kompilacji." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mody Mochi na Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę **Paradox** dla **Magic Mail** i innych modów." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Otwiera czat opinii **Discord** w przeglądarce." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
