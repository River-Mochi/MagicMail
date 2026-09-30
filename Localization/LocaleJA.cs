// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleJA.cs
// Japanese locale ja-JP

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Japanese localization source for Magic Mail [MM].</summary>
    public sealed class LocaleJA : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Japanese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleJA(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Japanese localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.kActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kStatusTab), "ステータス" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kAboutTab), "情報" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "郵便配送アシスト" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "郵便バン＆トラック" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "専用仕分け施設" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "リセット" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "都市スキャン" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "最新の更新" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutInfoGroup), "情報" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutLinksGroup), "リンク" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "ローカル郵便不足を救済" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "まずゲーム本来の郵便輸送に任せます。\n" +
                    "ローカル郵便が数回の確認でずっと少ない場合だけ、Magic Mail が少量を補充します。\n" +
                    "仕分けアップグレード付き郵便局にも適用されます。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "ローカル郵便の救済しきい値" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "建物の最大保管量に対して、この割合以下を不足と判定します。\n" +
                    "数回の確認で不足が続いた場合だけ救済します。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "ローカル郵便の救済量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "救済時に追加するローカル郵便の量です。\n" +
                    "建物の最大保管量に対する割合です。"
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "郵便のあふれを救済" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "郵便施設がいっぱいになりすぎた場合、Magic Mail が保存量を指定レベルまで減らします。\n" +
                    "ローカル＋未仕分け＋発送郵便を合計し、ゲームが見落とすことのある過剰保管も検出します。\n" +
                    "完全なバニラ動作にする場合はオフにしてください。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "郵便局のあふれしきい値" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "保存郵便の合計がこの割合を超えると、Magic Mail が減らします。\n" +
                    "通常の郵便局と仕分けアップグレード付き郵便局に適用されます。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "仕分け施設のあふれしきい値" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "専用仕分け施設の保存郵便合計がこの割合を超えると、\n" +
                    "Magic Mail が減らします。"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "容量を変更" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "郵便バンとトラックの容量を変更する場合にオンにします。オフでは、\n" +
                    "下のスライダーが非表示になり、\n" +
                    "別の値が残っていてもゲーム本来の値を使います。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "郵便バンの積載量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "各郵便バンが運べる郵便量を調整します。\n" +
                    "<100% = バニラの積載量。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "郵便バンの台数" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "各郵便施設が所有・出動できる郵便バン数を調整します。\n" +
                    "<100% = バニラの台数。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "郵便トラックの台数" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "郵便トラックを持つ施設が所有・出動できる台数を調整します。\n" +
                    "<100% = バニラの台数。>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "仕分け速度" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "専用仕分け施設の倍率です。\n" +
                    "郵便局の仕分けアップグレードは変更しません。\n" +
                    "<100% = バニラ>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "仕分け施設の保管容量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "専用仕分け施設の郵便保管量を調整します。\n" +
                    "郵便局の仕分けアップグレードは変更しません。\n" +
                    "<100% = バニラ>。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "未仕分け郵便不足を救済" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "まずゲーム本来の方法で未仕分け郵便を供給させます。\n" +
                    "専用仕分け施設の在庫が数回の確認でずっと少ない場合だけ、\n" +
                    "Magic Mail が少量を補充します。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "未仕分け郵便の救済しきい値" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "最大保管量に対して、この割合以下を不足と判定します。\n" +
                    "数回の確認で不足が続いた場合だけ救済します。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "未仕分け郵便の救済量" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "救済時に追加する未仕分け郵便の量です。\n" +
                    "最大保管量に対する割合です。"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "すべての設定をゲーム本来の標準動作に戻します。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "おすすめ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**郵便配送アシスト** - クイックスタート。\n" +
                    "まず通常の郵便物流に任せ、繰り返す不足やあふれだけを救済します。\n" +
                    "おすすめの容量調整も適用します。"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "ステータス画面を開いた時点の郵便施設です。\n" +
                    "\n" +
                    "**郵便局** = 通常の郵便局。\n" +
                    "**仕分け施設** = 専用の郵便仕分け施設。\n" +
                    "**仕分け付き郵便局** = <仕分けアップグレード付き Westmont Tower>。\n" +
                    "- **Skyscrapers DLC** が必要です。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "ステータス画面を開いた時点の郵便車両容量です。\n" +
                    "\n" +
                    "**郵便バン** = 地域内の集荷・配達車両。\n" +
                    "**郵便トラック** = 施設間で郵便を運ぶトラック。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "月間郵便" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "都市全体の最近の郵便フローを表示します。\n" +
                    "\n" +
                    "**累積** = 市民が生成した郵便量。\n" +
                    "**処理済み** = 郵便ネットワークが実際に処理した量。\n" +
                    "\n" +
                    "- 処理済みが累積より多いことが多ければ、郵便網の能力は十分です。\n" +
                    "- 累積が長時間ずっと処理済みを上回る場合、\n" +
                    "都市が郵便網の処理能力以上の郵便を生成しています。\n" +
                    "施設や郵便バンを増やすか、設定を調整してください。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "アクティビティ" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "直近の Magic Mail 救済処理で行った補充と、あふれ整理の回数です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "レポートを書き出す" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "オプションを開いている間に詳細な郵便スキャンを**1回だけ**実行し、\n" +
                    "<Logs/MagicMail.log> に書き出します。バックグラウンド記録はありません。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "<Logs/MagicMail.log> を開きます。まだ無い場合は Logs フォルダーを開きます。" },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "郵便施設が見つかりません。都市を開いてから、もう一度ステータスを開いてください。" },
                { "MM_STATUS_NO_ACTIVITY", "救済アクティビティは記録されていません。" },
                { "MM_STATUS_SUMMARY", "郵便局: {0} | 仕分け付き郵便局: {1} | 仕分け施設: {2}" },
                { "MM_STATUS_VEHICLES", "郵便バン: {0} | 郵便トラック: {1}" },
                { "MM_STATUS_ACTIVITY", "ローカル救済 {0} | 未仕分け救済 {1} | あふれ整理 {2}" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "都市の郵便統計はまだ利用できません。都市を開いてシミュレーションをしばらく動かしてください。" },
                { "MM_STATUS_CITY_MAIL", "{0} 累積 | {1} 処理済み" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "このModの表示名です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "現在のModバージョンとビルド種別です。" },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Mochi の Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "**Magic Mail** とその他のModの **Paradox** ページを開きます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "ブラウザで **Discord** のフィードバックチャットを開きます。" },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
