// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleKO.cs
// Korean locale ko-KR

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Korean localization source for Magic Mail [MM].</summary>
    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Korean locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleKO(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Korean localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "상태" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "정보" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "우편 배송 지원" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "우편 밴 & 트럭" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "전용 우편 분류 시설" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "초기화" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "도시 스캔" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "최근 업데이트" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "링크" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "로컬 우편 부족 구조" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "먼저 게임의 일반 우편 운송을 시도합니다.\n" +
                    "로컬 우편이 여러 번 확인해도 매우 낮게 유지되면 Magic Mail이 소량을 보충합니다.\n" +
                    "분류 업그레이드가 있는 우체국에도 적용됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "로컬 우편 구조 기준" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "로컬 우편이 건물 최대 저장량의 이 비율에 도달하면 부족으로 봅니다.\n" +
                    "여러 번 확인해도 낮게 유지될 때만 구조가 실행됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "로컬 우편 구조량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "구조가 실행될 때 추가할 로컬 우편의 양입니다.\n" +
                    "건물 최대 저장량의 비율입니다."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "우편 과적 구조" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "우편 시설이 너무 가득 차면 Magic Mail이 저장 우편을 선택한 수준까지 줄입니다.\n" +
                    "로컬 + 미분류 + 발송 우편을 모두 계산해 게임이 잘못 계산할 수 있는 과적도 잡아냅니다.\n" +
                    "완전한 바닐라 동작을 원하면 끄세요."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "우체국 과적 기준" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "저장된 전체 우편이 이 수준을 넘으면 Magic Mail이 다시 줄입니다.\n" +
                    "일반 우체국과 분류 업그레이드 우체국에 적용됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "분류 시설 과적 기준" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "전용 우편 분류 시설의 전체 저장 우편이 이 수준을 넘으면\n" +
                    "Magic Mail이 다시 줄입니다."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "용량 변경" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "밴과 트럭 용량을 바꾸려면 켜세요. 끄면\n" +
                    "아래 용량 슬라이더가 숨겨지고\n" +
                    "다른 값이 남아 있어도 게임 기본값을 사용합니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "우편 밴 적재량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "각 우편 밴이 실을 수 있는 우편량을 조절합니다.\n" +
                    "<100% = 바닐라 적재량.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "우편 밴 보유량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "각 우편 건물이 보유하고 출동시킬 수 있는 우편 밴 수를 조절합니다.\n" +
                    "<100% = 바닐라 보유량.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "우편 트럭 보유량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "우편 트럭이 있는 시설이 보유하고 출동시킬 수 있는 우편 트럭 수를 조절합니다.\n" +
                    "<100% = 바닐라 보유량.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "분류 속도" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "전용 우편 분류 시설의 배율입니다.\n" +
                    "우체국의 분류 업그레이드는 변경하지 않습니다.\n" +
                    "<100% = 바닐라>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "분류 시설 저장 용량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "전용 우편 분류 시설의 우편 저장량을 조절합니다.\n" +
                    "우체국의 분류 업그레이드는 변경하지 않습니다.\n" +
                    "<100% = 바닐라>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "미분류 우편 부족 구조" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "먼저 게임이 미분류 우편을 정상적으로 공급하게 둡니다.\n" +
                    "전용 분류 시설의 재고가 여러 번 확인해도 매우 낮게 유지되면\n" +
                    "Magic Mail이 소량을 보충합니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "미분류 우편 구조 기준" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "미분류 우편이 최대 저장량의 이 비율에 도달하면 부족으로 봅니다.\n" +
                    "여러 번 확인해도 낮게 유지될 때만 구조가 실행됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "미분류 우편 구조량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "구조가 실행될 때 추가할 미분류 우편의 양입니다.\n" +
                    "최대 저장량의 비율입니다."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "모든 설정을 게임의 원래 기본 동작으로 되돌립니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "권장" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**우편 배송 지원** - 빠른 시작.\n" +
                    "먼저 기본 우편 물류가 작동하게 하고, 반복되는 부족이나 과적만 구조합니다.\n" +
                    "권장 용량 조정도 함께 적용합니다."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "상태 페이지를 열 때 확인된 우편 건물입니다.\n" +
                    "\n" +
                    "**우체국** = 일반 우체국.\n" +
                    "**분류 시설** = 전용 우편 분류 시설.\n" +
                    "**분류 우체국** = <분류 업그레이드가 있는 Westmont Tower>.\n" +
                    "- **Skyscrapers DLC**가 필요합니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "상태 페이지를 열 때의 우편 차량 용량입니다.\n" +
                    "\n" +
                    "**우편 밴** = 지역 수거·배달 차량.\n" +
                    "**우편 트럭** = 시설 사이에서 우편을 운반하는 트럭."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "월간 우편" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "최근 도시 전체 우편 흐름을 보여줍니다.\n" +
                    "\n" +
                    "**누적** = 시민이 만든 우편량.\n" +
                    "**처리** = 우편망이 실제로 처리한 양.\n" +
                    "\n" +
                    "- 처리가 누적보다 자주 높으면 우편망 용량이 충분합니다.\n" +
                    "- 누적이 오랫동안 처리보다 높으면\n" +
                    "도시가 우편망이 감당할 수 있는 양보다 더 많이 만들고 있습니다.\n" +
                    "시설이나 밴을 늘리거나 설정을 조정하세요."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "활동" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "마지막 Magic Mail 구조 처리에서 발생한 구조와 과적 정리입니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "보고서 기록" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "옵션이 열린 동안 상세 우편 스캔을 **한 번만** 실행하고\n" +
                    "<Logs/MagicMail.log>에 기록합니다. 백그라운드 기록은 없습니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "<Logs/MagicMail.log>를 열거나, 아직 파일이 없으면 Logs 폴더를 엽니다." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "우편 시설을 찾지 못했습니다. 도시를 연 뒤 상태 페이지를 다시 여세요." },
                { "MM_STATUS_NO_ACTIVITY", "기록된 구조 활동이 없습니다." },
                { "MM_STATUS_SUMMARY", "우체국: {0} | 분류 우체국: {1} | 분류 시설: {2}" },
                { "MM_STATUS_VEHICLES", "우편 밴: {0} | 우편 트럭: {1}" },
                { "MM_STATUS_ACTIVITY", "로컬 구조 {0} | 미분류 구조 {1} | 과적 정리 {2}" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "도시 우편 통계를 아직 사용할 수 없습니다. 도시를 열고 시뮬레이션을 잠시 실행하세요." },
                { "MM_STATUS_CITY_MAIL", "누적 {0} | 처리 {1}" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "이 모드의 표시 이름입니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "현재 모드 버전과 빌드 종류입니다." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mochi의 Paradox 모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "**Magic Mail** 및 다른 모드의 **Paradox** 페이지를 엽니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 **Discord** 피드백 채팅을 엽니다." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
