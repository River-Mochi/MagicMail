// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleZH_HANT.cs
// Traditional Chinese locale zh-HANT
namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Traditional Chinese localization source for Magic Mail [MM].</summary>
    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_HANT(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "狀態" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "關於" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "郵局" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "郵務車與卡車" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "分揀設施" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "重設" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "城市掃描" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "最近更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "連結" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "修正本地郵件過低" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "啟用後，當本地郵件太少時會自動補上一點郵件。\n" +
                    "不會產生額外車輛，像是小小的魔法 :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "本地郵件門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "當本地郵件低於此百分比時，\n" +
                    "郵局會自動拉入更多本地郵件。\n" +
                    "此值是建築最大容量的百分比。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "本地郵件補充量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "補充本地郵件時所增加的百分比（魔法補充）。\n" +
                    "例如最大容量 100,000、此值為 10%，\n" +
                    "就會增加 10,000 封郵件。"
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "修正郵件溢出" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "當郵件過多時，設施會進行小規模清理，\n" +
                    "把多餘郵件視為已投遞並移除，\n" +
                    "避免建築永遠維持滿倉狀態。\n" +
                    "若想完全維持原版行為，可將此項關閉。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "郵局溢出門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "當郵局內的總郵件量達到此百分比時，\n" +
                    "模組會刪除部分郵件，讓總量降回此水準附近。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "分揀設施溢出門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "當分揀設施的總郵件量達到此百分比時，\n" +
                    "多出的郵件會被移除。"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "變更容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "啟用後可調整郵務車與卡車的容量。\n" +
                    "關閉時，下方所有滑桿會被隱藏，\n" +
                    "即使滑桿數值不同也會使用原版設定。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "郵務車載量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "控制每輛郵務車可載運多少郵件。\n" +
                    "<100% = 原版載量>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "郵務車隊規模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "控制每座郵政建築可以擁有與派出的郵務車數量。\n" +
                    "<100% = 原版數量>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "郵政卡車隊規模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "控制每座分揀設施（及其他有郵政卡車的建築）\n" +
                    "可擁有與派出的卡車數量。\n" +
                    "<100% = 原版數量>。"
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "分揀速度" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "分揀設施基礎分揀速度的倍率。\n" +
                    "<100% = 原版>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "分揀儲存容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "控制郵件的儲存容量。\n" +
                    "<100% = 原版>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "修正未分揀郵件過低" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "啟用後，當未分揀郵件存量太低時，\n" +
                    "會自動補上一些，讓分揀建築保持運作。\n" +
                    "這是目前貨運港口導致分揀設施郵件不足的\n" +
                    "暫時修正方案。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "未分揀郵件門檻" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "若未分揀郵件低於總容量此低百分比，\n" +
                    "就會額外補充一些郵件。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "未分揀郵件補充量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "補充未分揀郵件的額外數量（以最大容量百分比計算）。\n" +
                    "例如最大值 250,000、此值 10%，則會增加 25,000 封。"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "遊戲預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "將所有設定還原為遊戲原始預設行為（原版）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "推薦設定" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**快速開始** – 套用所有推薦郵政設定。\n" +
                    "簡單模式：一鍵完成！"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "顯示在最近一次背景掃描中處理的郵局、郵務車、\n" +
                    "分揀設施與郵政卡車的總覽。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "每月郵件" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "顯示城市最近的整體郵件流量。\n\n" +
                    "**累積** = 市民產生的郵件量。\n" +
                    "**已處理** = 網路實際處理的郵件量。\n\n" +
                    "- 若「已處理」常高於「累積」，代表郵政網路容量足夠。\n" +
                    "- 若「累積」長時間高於「已處理」，\n" +
                    "  代表城市產生的郵件超過處理能力，\n" +
                    "  可以考慮增加設施或調整設定。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "活動" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "顯示上一輪更新中進行的補充與溢出清理次數。"
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "尚未處理任何郵政設施。請開啟一座城市並讓模擬運行一段時間。" },

                { "MM_STATUS_NO_ACTIVITY",
                  "尚未記錄任何活動。" },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} 間郵局 | {1} 輛郵務車 | {2} 座分揀建築 | {3} 輛郵政卡車"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} 次本地郵件補充 | {1} 次未分揀郵件補充 | {2} 次溢出清理"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "城市郵件統計尚未可用。請開啟城市並讓模擬運行。" },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} 累積 | {1} 已處理"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "模組" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "此模組的顯示名稱。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "目前模組版本。"
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "開啟 **Magic Mail** 以及其他模組的 **Paradox** 網頁。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在瀏覽器中開啟 **Discord** 回饋頻道。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
