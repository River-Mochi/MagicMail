// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleUK.cs
// Ukrainian locale uk-UA

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Ukrainian localization source for Magic Mail [MM].</summary>
    public class LocaleUK : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Ukrainian locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleUK(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Ukrainian localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.ActionsTab), "Дії" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.StatusTab), "Стан" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.AboutTab), "Про мод" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "Допомога поштовій доставці" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "Поштові фургони й вантажівки" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "Окремий сортувальний центр" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "Скидання" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "Сканування міста" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "Останнє оновлення" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutInfoGroup), "Інформація" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutLinksGroup), "Посилання" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "Порятунок при нестачі місцевої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "Спочатку дозволяє грі спробувати звичайні поштові перевезення.\n" +
                    "Якщо місцевої пошти дуже мало протягом кількох перевірок, Magic Mail додає невелике аварійне поповнення.\n" +
                    "Також діє для поштового відділення з покращенням сортування."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "Поріг порятунку місцевої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "Місцева пошта вважається низькою при досягненні цього відсотка від максимального сховища будівлі.\n" +
                    "Порятунок спрацьовує лише якщо рівень залишається низьким кілька перевірок поспіль."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "Обсяг порятунку місцевої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "Скільки місцевої пошти додати, коли спрацьовує порятунок.\n" +
                    "Обсяг задається у відсотках від максимального сховища будівлі."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "Порятунок від переповнення пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "Якщо поштова споруда переповнюється, Magic Mail зменшує запас пошти до вибраного рівня.\n" +
                    "Враховується місцева + несортована + вихідна пошта, що допомагає виявляти переповнення, яке гра може рахувати неправильно.\n" +
                    "Вимкніть для повністю vanilla-поведінки."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "Поріг переповнення поштового відділення" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "Коли загальний запас пошти перевищує цей рівень, Magic Mail зменшує його.\n" +
                    "Діє для звичайних відділень і відділень з покращенням сортування."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "Поріг переповнення сортувального центру" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "Коли загальний запас пошти в окремому сортувальному центрі перевищує цей рівень,\n" +
                    "Magic Mail зменшує його."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "Змінювати місткість" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "Увімкніть, щоб змінювати місткість фургонів і вантажівок. Якщо вимкнено,\n" +
                    "повзунки нижче приховані та\n" +
                    "використовуються звичайні vanilla-значення гри, навіть якщо інші значення залишилися збереженими."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "Завантаження поштового фургона" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "Визначає, скільки пошти може перевозити кожен поштовий фургон.\n" +
                    "<100% = звичайне vanilla-завантаження.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "Розмір парку поштових фургонів" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "Визначає, скільки поштових фургонів може мати й відправляти кожна поштова споруда.\n" +
                    "<100% = звичайний vanilla-розмір парку.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "Розмір парку поштових вантажівок" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "Визначає, скільки поштових вантажівок може мати й відправляти споруда, що їх використовує.\n" +
                    "<100% = звичайний vanilla-розмір парку.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "Швидкість сортування" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "Множник для окремих сортувальних центрів.\n" +
                    "Не змінює покращення сортування поштового відділення.\n" +
                    "<100% = звичайне vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "Місткість сортувального сховища" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "Керує сховищем пошти в окремих сортувальних центрах.\n" +
                    "Не змінює покращення сортування поштового відділення.\n" +
                    "<100% = звичайне vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "Порятунок при нестачі несортованої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "Спочатку дозволяє грі нормально доставляти несортовану пошту.\n" +
                    "Якщо в окремому сортувальному центрі її дуже мало протягом кількох перевірок,\n" +
                    "Magic Mail додає невелике аварійне поповнення."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "Поріг порятунку несортованої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "Несортована пошта вважається низькою при досягненні цього відсотка від максимального сховища.\n" +
                    "Порятунок спрацьовує лише якщо рівень залишається низьким кілька перевірок поспіль."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "Обсяг порятунку несортованої пошти" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "Скільки несортованої пошти додати, коли спрацьовує порятунок.\n" +
                    "Обсяг задається у відсотках від максимального сховища."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "Налаштування гри" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "Повертає всі параметри до оригінальної стандартної поведінки гри." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "Рекомендовано" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**Допомога поштовій доставці** - Швидкий старт.\n" +
                    "Спочатку дає працювати звичайній поштовій логістиці, а потім рятує повторювану нестачу або переповнення.\n" +
                    "Також застосовує рекомендовані налаштування місткості."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "Поштові будівлі, знайдені під час відкриття сторінки «Стан».\n" +
                    "\n" +
                    "**Поштові відділення** = звичайні відділення.\n" +
                    "**Сортувальні центри** = окремі поштові сортувальні центри.\n" +
                    "**Відділення із сортуванням** = <Westmont Tower з покращенням сортування>.\n" +
                    "- Потрібен **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "Місткість поштового транспорту під час відкриття сторінки «Стан».\n" +
                    "\n" +
                    "**Поштові фургони** = місцевий збір і доставка.\n" +
                    "**Поштові вантажівки** = перевозять пошту між спорудами."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "Пошта за місяць" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "Показує останній потік пошти по всьому місту.\n" +
                    "\n" +
                    "**Накопичено** = скільки пошти створили мешканці.\n" +
                    "**Оброблено** = скільки пошти мережа фактично опрацювала.\n" +
                    "\n" +
                    "- Якщо Оброблено часто вище за Накопичено, поштова мережа має достатню пропускну здатність.\n" +
                    "- Якщо Накопичено довго залишається вище за Оброблено,\n" +
                    "місто створює більше пошти, ніж мережа може опрацювати.\n" +
                    "Додайте споруди, фургони або змініть налаштування."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "Активність" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "Порятунки й очищення переповнення з останнього циклу порятунку Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "Записати звіт" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "Виконує **одноразове** детальне сканування пошти, поки відкриті Параметри,\n" +
                    "і записує звіт у <Logs/MagicMail.log>. Без фонових записів."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "Відкрити журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "Відкриває <Logs/MagicMail.log> або папку Logs, якщо файла ще немає." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Поштових споруд не знайдено. Відкрийте місто, потім знову відкрийте «Стан»." },
                { "MM_STATUS_NO_ACTIVITY", "Активність порятунку не зафіксована." },
                { "MM_STATUS_SUMMARY", "Поштові відділення: {0} | Відділення із сортуванням: {1} | Сортувальні центри: {2}" },
                { "MM_STATUS_VEHICLES", "Поштові фургони: {0} | Поштові вантажівки: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} порятунків місцевої | {1} порятунків несортованої | {2} очищень переповнення" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Статистика пошти міста ще недоступна. Відкрийте місто й дайте симуляції трохи попрацювати." },
                { "MM_STATUS_CITY_MAIL", "{0} накопичено | {1} оброблено" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "Відображувана назва цього мода." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "Поточна версія мода та тип збірки." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Моди Mochi на Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "Відкриває сторінку **Paradox** для **Magic Mail** та інших модів." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "Відкриває чат відгуків **Discord** у браузері." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
