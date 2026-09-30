// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleZH_HANT.cs
// Traditional Chinese locale zh-HANT

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Traditional Chinese localization source for Magic Mail [MM].</summary>
    public class LocaleZH_HANT : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Traditional Chinese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleZH_HANT(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Traditional Chinese localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.kActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kStatusTab), "狀態" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kAboutTab), "關於" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "郵政調度輔助" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "郵政廂型車和卡車" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "專用分揀設施" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "重設" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "城市掃描" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "最近更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutLinksGroup), "連結" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "救援本地郵件不足" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "先讓遊戲嘗試正常的郵件運輸。\n" +
                    "如果本地郵件連續多次檢查都很低，Magic Mail 才會補充少量郵件。\n" +
                    "也適用於有分揀升級的郵局。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "本地郵件救援門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "當本地郵件達到建築最大儲存量的這個百分比時，會被視為過低。\n" +
                    "只有連續多次檢查都很低時才會觸發救援。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "本地郵件救援量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "救援觸發時補充多少本地郵件。\n" +
                    "按建築最大儲存量的百分比計算。"
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "救援郵件溢出" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "如果郵政設施過滿，Magic Mail 會把儲存郵件減少到所選水平。\n" +
                    "會統計本地 + 未分揀 + 寄出郵件，幫助發現遊戲可能計算不正確的過量儲存。\n" +
                    "關閉此項可保持純原版行為。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "郵局溢出門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "當儲存郵件總量超過此水平時，Magic Mail 會將其降低。\n" +
                    "適用於普通郵局和有分揀升級的郵局。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "分揀設施溢出門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "當專用分揀設施中的郵件總量超過此水平時，\n" +
                    "Magic Mail 會將其降低。"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "修改容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "啟用後可修改廂型車和卡車容量。關閉時，\n" +
                    "下方容量滑桿會隱藏，而且\n" +
                    "即使之前儲存了其他數值，也會使用遊戲正常的原版數值。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "郵政廂型車載量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "控制每輛郵政廂型車可攜帶多少郵件。\n" +
                    "<100% = 正常原版載量。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "郵政廂型車車隊規模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "控制每個郵政建築可擁有和派出多少輛郵政廂型車。\n" +
                    "<100% = 正常原版車隊規模。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "郵政卡車車隊規模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "控制有郵政卡車的設施可擁有和派出多少輛郵政卡車。\n" +
                    "<100% = 正常原版車隊規模。>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "分揀速度" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "專用分揀設施的倍率。\n" +
                    "不會改變郵局的分揀升級。\n" +
                    "<100% = 正常原版>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "分揀儲存容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "控制專用分揀設施的郵件儲存容量。\n" +
                    "不會改變郵局的分揀升級。\n" +
                    "<100% = 正常原版>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "救援未分揀郵件不足" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "先讓遊戲按正常方式供應未分揀郵件。\n" +
                    "如果專用分揀設施連續多次檢查都很低，\n" +
                    "Magic Mail 才會補充少量郵件。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "未分揀郵件救援門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "當未分揀郵件達到最大儲存量的這個百分比時，會被視為過低。\n" +
                    "只有連續多次檢查都很低時才會觸發救援。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "未分揀郵件救援量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "救援觸發時補充多少未分揀郵件。\n" +
                    "按最大儲存量的百分比計算。"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "將所有設定恢復為遊戲原本的預設行為。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "推薦" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**郵政調度輔助** - 快速開始。\n" +
                    "先讓正常郵件物流工作，然後只在反覆缺貨或溢出時介入。\n" +
                    "同時套用推薦的容量調整。"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "開啟狀態頁面時找到的郵政建築。\n" +
                    "\n" +
                    "**郵局** = 普通郵局。\n" +
                    "**分揀設施** = 專用郵政分揀設施。\n" +
                    "**有分揀的郵局** = <有分揀升級的 Westmont Tower>。\n" +
                    "- 需要 **Skyscrapers DLC**。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "開啟狀態頁面時的郵政車輛容量。\n" +
                    "\n" +
                    "**郵政廂型車** = 本地收取和投遞車輛。\n" +
                    "**郵政卡車** = 在設施之間運送郵件的卡車。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "每月郵件" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "顯示最近的全市郵件流量。\n" +
                    "\n" +
                    "**累積** = 市民產生的郵件量。\n" +
                    "**已處理** = 郵政網路實際處理的郵件量。\n" +
                    "\n" +
                    "- 如果已處理經常高於累積，表示郵政網路容量足夠。\n" +
                    "- 如果累積長期高於已處理，\n" +
                    "表示城市產生的郵件超過網路處理能力。\n" +
                    "請增加設施、廂型車或調整設定。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "活動" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "Magic Mail 最近一次救援檢查中的救援和溢出清理。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "寫入報告" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "在開啟選項時執行**一次性**詳細郵政掃描，\n" +
                    "然後把報告寫入 <Logs/MagicMail.log>。不會在背景持續記錄。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "開啟 <Logs/MagicMail.log>；如果檔案還不存在，則開啟 Logs 資料夾。" },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "找不到郵政設施。開啟一座城市，然後重新開啟狀態頁面。" },
                { "MM_STATUS_NO_ACTIVITY", "未記錄救援活動。" },
                { "MM_STATUS_SUMMARY", "郵局：{0} | 有分揀的郵局：{1} | 分揀設施：{2}" },
                { "MM_STATUS_VEHICLES", "郵政廂型車：{0} | 郵政卡車：{1}" },
                { "MM_STATUS_ACTIVITY", "本地郵件救援 {0} | 未分揀郵件救援 {1} | 溢出清理 {2}" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "城市郵件統計尚不可用。開啟一座城市並讓模擬運行一會兒。" },
                { "MM_STATUS_CITY_MAIL", "{0} 累積 | {1} 已處理" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "此模組的顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "目前模組版本和建置類型。" },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Mochi 的 Paradox 模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "開啟 **Magic Mail** 和其他模組的 **Paradox** 頁面。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "在瀏覽器中開啟 **Discord** 意見回饋聊天。" },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
