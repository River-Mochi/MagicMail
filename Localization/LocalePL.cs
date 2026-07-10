// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocalePL(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "O modzie" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Wsparcie dostarczania poczty" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Furgonetki i ciężarówki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Sortownia" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Reset" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Skan miasta" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Ostatnia aktualizacja" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Linki" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Napraw niski poziom poczty lokalnej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Gdy jest włączone, niewielka ilość poczty lokalnej\n" +
                    "zostanie dodana, gdy zapasy spadną zbyt nisko.\n" +
                    "Nie tworzy dodatkowych pojazdów – po prostu mała magia :)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Próg poczty lokalnej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Jeśli poczta lokalna spadnie poniżej tego procentu,\n" +
                    "urząd pocztowy pobierze więcej poczty.\n" +
                    "To procent maksymalnej pojemności budynku.\n" +
                    "Przykład: <max = 100 000>, <próg = 5%>,\n" +
                    "gdy poczta lokalna spadnie poniżej <5 000>, nastąpi uzupełnienie."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Wielkość uzupełnienia lokalnego" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Procent dodawany podczas magicznego uzupełniania poczty lokalnej.\n" +
                    "Jeśli maksymalna wartość wynosi <100 000>, a tu ustawiono <10%>,\n" +
                    "dodane zostanie <10 000>."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Napraw przepełnienie poczty" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Gdy w magazynach jest zbyt dużo poczty, budynki wykonują małe\n" +
                    "„magiczne czyszczenie”. Nadmiar poczty jest traktowany jako doręczony\n" +
                    "i usuwany z magazynów. Zapobiega to blokowaniu się budynków na 100%.\n" +
                    "Wyłącz tę opcję, aby zachować czysty tryb vanilla."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Próg przepełnienia urzędu" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Gdy całkowita ilość poczty w urzędzie pocztowym osiągnie ten procent,\n" +
                    "mod usunie nadmiar, aby wrócić do tego poziomu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Próg przepełnienia sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Gdy całkowita ilość poczty w sortowni osiągnie ten procent,\n" +
                    "nadmiar zostanie usunięty."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Zmień pojemności" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Włącza modyfikowanie pojemności furgonetek i ciężarówek.\n" +
                    "Gdy jest wyłączone, wszystkie suwaki są ukryte,\n" +
                    "a używane są wartości vanilla, niezależnie od ustawień suwaków."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Ładunek poczty na furgonetkę" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Określa, ile poczty może przewozić każda furgonetka.\n" +
                    "<100% = ładunek vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Wielkość floty furgonetek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Określa, ile furgonetek może posiadać i wysyłać dany budynek pocztowy.\n" +
                    "<100% = flota vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Wielkość floty ciężarówek" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Określa, ile ciężarówek pocztowych może posiadać każda sortownia\n" +
                    "lub inne budynki z ciężarówkami pocztowymi.\n" +
                    "<100% = flota vanilla>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Prędkość sortowania" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Mnożnik prędkości sortowania dla sortowni. Działa na bazową wartość.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Pojemność magazynu sortowni" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Kontroluje pojemność magazynową na pocztę.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Napraw niski poziom poczty niesortowanej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Gdy jest włączone, dodatkowa poczta niesortowana pojawi się,\n" +
                    "gdy zapasy spadną zbyt nisko, aby utrzymać sortownię w ruchu.\n" +
                    "To tymczasowe obejście błędu, w którym sortownie dostają za mało poczty,\n" +
                    "jeśli w mieście jest port towarowy."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Próg poczty niesortowanej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Jeśli poczta niesortowana spadnie poniżej tego niskiego procentu\n" +
                    "całkowitej pojemności magazynu, zostanie pobrana dodatkowa ilość.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Wielkość uzupełnienia niesortowanej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Ilość dodawanej poczty niesortowanej (procent maksymalnej pojemności).\n" +
                    "Przykład: max <250 000>, wartość <10%> → dodane zostanie <25 000>."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Domyślne gry" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Przywraca wszystkie ustawienia do oryginalnego zachowania gry (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Zalecane" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Szybki start** – stosuje wszystkie zalecane ustawienia poczty.\n" +
                    "Tryb łatwy: jedno kliknięcie i gotowe."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Podsumowanie urzędów pocztowych, furgonetek, sortowni i ciężarówek\n" +
                    "przetworzonych podczas ostatniego skanowania w tle."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Miesięczna poczta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Pokazuje ostatni przepływ poczty w całym mieście.\n\n" +
                    "**Zgromadzona** = ile poczty wygenerowali mieszkańcy.\n" +
                    "**Przetworzona** = ile poczty faktycznie obsłużyła sieć.\n\n" +
                    "- Jeśli \"Przetworzona\" często jest większa niż \"Zgromadzona\",\n" +
                    "  sieć ma wystarczającą wydajność.\n" +
                    "- Jeśli \"Zgromadzona\" przez dłuższy czas przewyższa \"Przetworzoną\",\n" +
                    "  miasto generuje więcej poczty, niż sieć jest w stanie obsłużyć.\n" +
                    "  Dodaj budynki lub zmień ustawienia."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Aktywność" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Liczba uzupełnień poczty i czyszczeń przepełnienia z ostatniej aktualizacji."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Nie przetworzono jeszcze żadnych obiektów pocztowych. Otwórz miasto i pozwól symulacji chwilę działać." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Brak zarejestrowanej aktywności." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} urzędów pocztowych | {1} furgonetek | {2} sortowni | {3} ciężarówek pocztowych"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} uzupełnień poczty lokalnej | {1} uzupełnień poczty niesortowanej | {2} czyszczeń przepełnienia"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Statystyki poczty miejskiej nie są jeszcze dostępne. Otwórz miasto i pozwól symulacji działać." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} zgromadzona | {1} przetworzona"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Wyświetlana nazwa tego modu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Wersja" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Aktualna wersja modu."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Otwiera stronę **Paradox** z **Magic Mail** i innymi modami."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Otwiera w przeglądarce kanał opinii na **Discordzie**."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
