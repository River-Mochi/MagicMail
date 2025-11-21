// Localization/LocaleZH_CN.cs
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

        /// <summary>
        /// Constructs the Simplified Chinese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleZH_CN(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "状态" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "关于" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "邮局" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "邮车与卡车" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "分拣中心" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "重置" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "城市总览" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "最近更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "链接" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "修复本地邮件不足" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "启用后，如果仓储过低，会“魔法般”出现额外邮件。\n " +
                    "不会生成额外的邮车——像魔法，但是真实生效。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "本地邮件阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "如果本地邮件低于你设定的这个百分比，\n " +
                    "邮局会自动拉入更多本地邮件。\n" +
                    "以最大存储容量为基准的百分比。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "本地邮件补充值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "进行本地邮件“魔法补货”时要添加的百分比。\n" +
                    "如果原版最大值 = 10,000，设置为 20%，则会增加 2,000。" },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "修复邮件溢出" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "当邮件过多时，设施会执行一次小型的 **魔法** 清理。\n " +
                    "多余的邮件会视为已投递并被移除。\n " +
                    "这样可以防止建筑长期卡在“已满”状态。\n " +
                    "关闭此选项可以保持纯原版行为。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "邮局溢出阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "当某个邮局的邮件总量达到该百分比时，\n" +
                    "模组会删除一部分存储邮件，将总量拉回到该水平。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "分拣溢出阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "当分拣中心的邮件总量达到该百分比时，\n" +
                   "模组会删除一部分存储邮件，将总量拉回到该水平。" },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "修改运力" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "启用后可以修改邮车和卡车的容量。若关闭，\n" +
                    "下面所有容量滑块会被隐藏，\n" +
                    "游戏会使用原版数值，即使滑块上显示的是其他数值。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "邮车载重" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "控制每辆邮车可以携带多少邮件。\n" +
                    "<100% = 原版载重。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "邮车车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "控制每个邮政建筑可以拥有并派出的邮车数量。\n" +
                    "<100% = 原版车队规模。>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "邮政卡车车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "控制每个分拣中心（以及任何拥有邮政卡车的建筑）\n " +
                    "可以拥有并派出的卡车数量。\n " +
                    "<100% = 原版车队规模。>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "分拣速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "应用于**分拣**设施的速度倍率。影响建筑的基础分拣速度。\n " +
                    "<100% = 原版>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "分拣存储容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "控制**邮件存储**容量。\n " +
                    "<100% = 原版>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "修复未分拣邮件不足" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "启用后，如果未分拣邮件储量过低，会魔法般补充一些未分拣邮件。\n " +
                    "这样分拣建筑不用等待送货也能持续工作。\n" +
                    "这是当前错误的临时修复：如果有货运港口存在，\n " +
                    "分拣中心往往拿不到足够的邮件。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "未分拣邮件阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "当未分拣邮件低于该容量百分比时，\n " +
                    "会“魔法”拉入额外的未分拣邮件。\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "未分拣邮件补充值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "进行未分拣邮件“魔法补货”时要添加的数量。\n" +
                    "以最大存储容量的百分比表示。" },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "将所有设置恢复为游戏最初的默认行为（原版）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "推荐设置" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**快速开始**：应用所有推荐的邮政设置。\n" +
                    "简单模式：一键完成！" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "显示在上一次游戏更新中处理的邮局、邮车、分拣中心和邮政卡车数量\n " +
                    "（大约每 45 分钟游戏时间更新一次）。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "城市邮件" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "显示最近城市范围内的邮件流量。\n\n" +
                     "**累积量** = 市民在一段时间内产生的邮件总量。\n" +
                     "**处理量**   = 邮政网络实际处理的邮件量。\n\n" +
                     "- 如果“处理量”经常大于“累积量”，说明邮政网络容量充足。\n " +
                     "- 如果“累积量”长时间高于“处理量”，说明城市产生的邮件多于\n " +
                     "系统可以处理的量；可以增加更多设施、车辆，或调整设置。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "最近活动" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "统计在上一次更新中执行的邮件补货和溢出清理次数。" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "当前模组版本。" },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "在浏览器中打开 **Magic Mail** 以及其他模组的 **Paradox** 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开 **Discord** 反馈频道。" },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
