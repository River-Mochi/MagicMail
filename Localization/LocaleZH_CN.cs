// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleZH_CN.cs
// Simplified Chinese locale zh-HANS

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Simplified Chinese localization source for Magic Mail [MM].</summary>
    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "状态" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "关于" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "邮局" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "邮政车与卡车" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "分拣设施" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "重置" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "城市扫描" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "最近一次更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "链接" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "修复本地邮件过低" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "启用后，当本地邮件太少时会自动补上一点邮件。\n" +
                    "不会生成额外车辆，就像一点小魔法 :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "本地邮件阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "当本地邮件低于此百分比时，\n" +
                    "邮局会自动拉入更多本地邮件。\n" +
                    "此值是建筑最大存储量的百分比。\n" +
                    "例如：最大容量 = 100,000，阈值 = 5%，\n" +
                    "当本地邮件低于 5,000 时会开始补货。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "本地邮件补充量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "补充本地邮件时增加的百分比（魔法补充）。\n" +
                    "例如最大容量 = 100,000，此值 = 10%，\n" +
                    "则会增加 10,000 封邮件。"
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "修复邮件溢出" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "当邮件太多时，设施会进行一次小清理。\n" +
                    "多余的存储邮件会被视为已投递并删除。\n" +
                    "这可以防止设施一直卡在满仓状态。\n" +
                    "关闭此项可保持纯原版行为。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "邮局溢出阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "当邮局中的总邮件量达到此百分比时，\n" +
                    "模组会删除一部分邮件，使其降回该水平。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "分拣设施溢出阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "当分拣设施中的总邮件量达到此百分比时，\n" +
                    "模组会删除多余邮件，使其降回此水平。"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "更改容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "启用后可以修改邮政车和卡车容量。\n" +
                    "关闭时，下方所有容量滑条会隐藏，\n" +
                    "并始终使用游戏原始数值。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "邮政车载量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "控制每辆邮政车可携带多少邮件。\n" +
                    "<100% = 原版载量>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "邮政车车队规模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "控制每个邮政建筑可以拥有和派出的邮政车数量。\n" +
                    "<100% = 原版车队规模>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "邮政卡车车队规模" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "控制每个分拣设施（以及其他带邮政卡车的设施）\n" +
                    "可以拥有和派出的卡车数量。\n" +
                    "<100% = 原版车队规模>。"
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "分拣速度" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "分拣设施基础分拣速率的倍率。\n" +
                    "<100% = 原版>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "分拣存储容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "控制邮件的存储容量。\n" +
                    "<100% = 原版>。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "修复未分拣邮件过低" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "启用后，当未分拣邮件库存太低时，\n" +
                    "会自动补充一些未分拣邮件，让分拣建筑继续工作。\n" +
                    "这是当前存在货运港口时，分拣设施收不到足够邮件的\n" +
                    "临时修复方案。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "未分拣邮件阈值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "如果未分拣邮件低于总存储容量的这一小百分比，\n" +
                    "就会额外获取一些邮件。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "未分拣邮件补充量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "补充未分拣邮件时增加的数量（为最大容量的百分比）。\n" +
                    "例如最大容量 = 250,000，此值 = 10%，\n" +
                    "则会增加 25,000 封邮件。"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "游戏默认" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "将所有设置恢复为游戏原始默认行为（原版）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "推荐设置" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**快速开始** – 应用所有推荐的邮政设置。\n" +
                    "简单模式：一键完成！"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "上一次后台扫描中处理的邮局、邮政车、\n" +
                    "分拣设施和邮政卡车的汇总。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "每月邮件" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "显示最近城市范围内的邮件流量。\n\n" +
                    "**累积** = 市民产生的邮件量。\n" +
                    "**已处理** = 邮政网络实际处理的邮件量。\n\n" +
                    "- 如果“已处理”经常高于“累积”，说明邮政网络容量足够。\n" +
                    "- 如果“累积”长时间高于“已处理”，\n" +
                    "  说明城市产生的邮件超过处理能力，\n" +
                    "  可以考虑增加设施、车辆或调整设置。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "活动" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "上一次更新中进行的邮件补充和溢出清理次数。"
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "尚未处理任何邮政设施。请打开一个城市并让模拟运行一段时间。" },

                { "MM_STATUS_NO_ACTIVITY",
                  "尚未记录任何活动。" },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} 个邮局 | {1} 辆邮政车 | {2} 座分拣建筑 | {3} 辆邮政卡车"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} 次本地邮件补充 | {1} 次未分拣邮件补充 | {2} 次溢出清理"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "城市邮件统计尚不可用。请打开城市并让模拟运行。" },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} 累积 | {1} 已处理"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "模组" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "此模组的显示名称。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "当前模组版本。"
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "打开 **Magic Mail** 和其他模组的 **Paradox** 网页。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开 **Discord** 反馈频道。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
