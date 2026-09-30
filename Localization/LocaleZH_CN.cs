// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleZH_CN.cs
// Simplified Chinese locale zh-HANS

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Simplified Chinese localization source for Magic Mail [MM].</summary>
    public class LocaleZH_CN : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Simplified Chinese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleZH_CN(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Simplified Chinese localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.StatusTab), "状态" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.AboutTab), "关于" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "邮政调度辅助" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "邮政面包车和卡车" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "专用分拣设施" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "重置" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "城市扫描" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "最近更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.AboutLinksGroup), "链接" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "救援本地邮件不足" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "先让游戏尝试正常的邮件运输。\n" +
                    "如果本地邮件连续多次检查都很低，Magic Mail 才会补充少量邮件。\n" +
                    "也适用于带分拣升级的邮局。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "本地邮件救援阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "当本地邮件达到建筑最大存储量的这个百分比时，会被视为过低。\n" +
                    "只有连续多次检查都很低时才会触发救援。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "本地邮件救援量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "救援触发时补充多少本地邮件。\n" +
                    "按建筑最大存储量的百分比计算。"
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "救援邮件溢出" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "如果邮政设施过满，Magic Mail 会把存储邮件减少到所选水平。\n" +
                    "会统计本地 + 未分拣 + 发出邮件，帮助发现游戏可能计算不正确的过量存储。\n" +
                    "关闭此项可保持纯原版行为。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "邮局溢出阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "当存储邮件总量超过此水平时，Magic Mail 会将其降低。\n" +
                    "适用于普通邮局和带分拣升级的邮局。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "分拣设施溢出阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "当专用分拣设施中的邮件总量超过此水平时，\n" +
                    "Magic Mail 会将其降低。"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "修改容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "启用后可修改面包车和卡车容量。关闭时，\n" +
                    "下方容量滑块会隐藏，并且\n" +
                    "即使之前保存了其他数值，也会使用游戏正常的原版数值。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "邮政面包车载量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "控制每辆邮政面包车可携带多少邮件。\n" +
                    "<100% = 正常原版载量。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "邮政面包车车队规模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "控制每个邮政建筑可拥有和派出多少辆邮政面包车。\n" +
                    "<100% = 正常原版车队规模。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "邮政卡车车队规模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "控制拥有邮政卡车的设施可拥有和派出多少辆邮政卡车。\n" +
                    "<100% = 正常原版车队规模。>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "分拣速度" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "专用于分拣设施的倍率。\n" +
                    "不会改变邮局的分拣升级。\n" +
                    "<100% = 正常原版>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "分拣存储容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "控制专用分拣设施的邮件存储容量。\n" +
                    "不会改变邮局的分拣升级。\n" +
                    "<100% = 正常原版>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "救援未分拣邮件不足" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "先让游戏按正常方式供应未分拣邮件。\n" +
                    "如果专用分拣设施连续多次检查都很低，\n" +
                    "Magic Mail 才会补充少量邮件。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "未分拣邮件救援阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "当未分拣邮件达到最大存储量的这个百分比时，会被视为过低。\n" +
                    "只有连续多次检查都很低时才会触发救援。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "未分拣邮件救援量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "救援触发时补充多少未分拣邮件。\n" +
                    "按最大存储量的百分比计算。"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "将所有设置恢复为游戏原本的默认行为。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "推荐" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**邮政调度辅助** - 快速开始。\n" +
                    "先让正常邮件物流工作，然后仅在反复缺货或溢出时介入。\n" +
                    "同时应用推荐的容量调整。"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "打开状态页面时找到的邮政建筑。\n" +
                    "\n" +
                    "**邮局** = 普通邮局。\n" +
                    "**分拣设施** = 专用邮政分拣设施。\n" +
                    "**带分拣的邮局** = <带分拣升级的 Westmont Tower>。\n" +
                    "- 需要 **Skyscrapers DLC**。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "打开状态页面时的邮政车辆容量。\n" +
                    "\n" +
                    "**邮政面包车** = 本地收取和投递车辆。\n" +
                    "**邮政卡车** = 在设施之间运输邮件的卡车。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "每月邮件" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "显示最近的全市邮件流量。\n" +
                    "\n" +
                    "**累计** = 市民生成的邮件量。\n" +
                    "**已处理** = 邮政网络实际处理的邮件量。\n" +
                    "\n" +
                    "- 如果已处理经常高于累计，说明邮政网络容量足够。\n" +
                    "- 如果累计长期高于已处理，\n" +
                    "说明城市产生的邮件超过网络处理能力。\n" +
                    "请增加设施、面包车或调整设置。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "活动" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "Magic Mail 最近一次救援检查中的救援和溢出清理。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "写入报告" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "在打开选项时执行**一次性**详细邮政扫描，\n" +
                    "然后把报告写入 <Logs/MagicMail.log>。不会在后台持续记录。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "打开 <Logs/MagicMail.log>；如果文件还不存在，则打开 Logs 文件夹。" },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "未找到邮政设施。打开一座城市，然后重新打开状态页面。" },
                { "MM_STATUS_NO_ACTIVITY", "未记录救援活动。" },
                { "MM_STATUS_SUMMARY", "邮局：{0} | 带分拣的邮局：{1} | 分拣设施：{2}" },
                { "MM_STATUS_VEHICLES", "邮政面包车：{0} | 邮政卡车：{1}" },
                { "MM_STATUS_ACTIVITY", "本地邮件救援 {0} | 未分拣邮件救援 {1} | 溢出清理 {2}" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "城市邮件统计尚不可用。打开一座城市并让模拟运行一会儿。" },
                { "MM_STATUS_CITY_MAIL", "{0} 累计 | {1} 已处理" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "此模组的显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "当前模组版本和构建类型。" },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Mochi 的 Paradox 模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "打开 **Magic Mail** 和其他模组的 **Paradox** 页面。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "在浏览器中打开 **Discord** 反馈聊天。" },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
