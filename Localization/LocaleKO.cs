// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocaleKO(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "상태" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "정보" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "우체국" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "우편 밴 & 트럭" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "분류 시설" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "초기화" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "도시 스캔" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "최근 업데이트" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "링크" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "지역 우편 부족 수정" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "이 옵션을 켜면 지역 우편이 너무 낮아졌을 때\n" +
                    "소량의 지역 우편을 자동으로 채워 줍니다.\n" +
                    "추가 밴을 소환하지는 않습니다. 말 그대로 마법 같은 기능이에요 :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "지역 우편 임계값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "지역 우편이 이 퍼센트 아래로 떨어지면\n" +
                    "우체국이 자동으로 우편을 더 가져옵니다.\n" +
                    "건물 최대 보관량에 대한 비율입니다.\n" +
                    "예: <최대 보관 = 100,000>, <임계값 = 5%> 이면\n" +
                    "지역 우편이 <5,000> 미만일 때 채워집니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "지역 우편 채우기 양" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "지역 우편을 '마법 보충' 할 때 추가되는 비율입니다.\n" +
                    "바닐라 최대치가 <100,000>이고 값이 <10%>라면\n" +
                    "<10,000> 이 추가됩니다."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "우편 초과량 정리" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "우편이 너무 많이 쌓이면 시설이 작은 정리 작업을 수행합니다.\n" +
                    "초과된 우편은 배달 완료로 간주되어 제거됩니다.\n" +
                    "이 기능은 시설이 가득 찬 상태로 영원히 멈추는 것을 막아 줍니다.\n" +
                    "완전한 바닐라 동작을 원하면 끄세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "우체국 초과 임계값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "우체국의 전체 우편량이 이 퍼센트에 도달하면,\n" +
                    "이 수준으로 되돌아가도록 일부 우편을 삭제합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "분류 시설 초과 임계값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "분류 시설의 전체 우편량이 이 퍼센트에 도달하면,\n" +
                    "이 수준으로 줄어들도록 초과분을 정리합니다."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "용량 변경" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "우편 밴과 트럭의 용량을 조정합니다.\n" +
                    "꺼져 있으면 아래의 모든 슬라이더가 숨겨지고,\n" +
                    "값이 다르게 설정되어 있어도 게임 기본 값이 사용됩니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "우편 밴 적재량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "각 우편 밴이 운반할 수 있는 우편량을 조정합니다.\n" +
                    "<100% = 바닐라 적재량>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "우편 밴 보유 대수" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "각 우편 건물이 보유하고 출동시킬 수 있는 우편 밴 대수를 조정합니다.\n" +
                    "<100% = 바닐라 대수>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "우편 트럭 보유 대수" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "각 분류 시설(및 우편 트럭이 있는 시설)이\n" +
                    "보유하고 출동시킬 수 있는 우편 트럭 대수를 조정합니다.\n" +
                    "<100% = 바닐라 대수>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "분류 속도" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "분류 시설의 기본 분류 속도에 곱해지는 배수입니다.\n" +
                    "<100% = 바닐라>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "분류 보관 용량" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "우편 보관 용량을 제어합니다.\n" +
                    "<100% = 바닐라>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "미분류 우편 부족 수정" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "이 옵션을 켜면 미분류 우편 재고가 너무 낮을 때\n" +
                    "추가 미분류 우편을 자동으로 채워 줍니다.\n" +
                    "이렇게 해서 분류 시설이 계속 작동하도록 합니다.\n" +
                    "화물 항구가 있을 때 분류 시설에 우편이 잘 안 들어오는\n" +
                    "현재 버그에 대한 임시 해결책입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "미분류 우편 임계값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "미분류 우편이 총 보관 용량의 이 낮은 퍼센트 아래로 떨어지면\n" +
                    "추가 미분류 우편을 가져옵니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "미분류 우편 채우기 양" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "미분류 우편을 채울 때 추가되는 양입니다 (최대 보관 용량의 퍼센트).\n" +
                    "예: 최대값 <250,000>, 값 <10%> → <25,000> 추가."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "게임 기본값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "모든 설정을 게임의 기본 동작(바닐라)으로 되돌립니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "추천 값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**빠른 시작** – 추천 우편 설정을 한 번에 적용합니다.\n" +
                    "이지 모드: 한 번 클릭하면 끝!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "최근 백그라운드 스캔에서 처리된 우체국, 우편 밴,\n" +
                    "분류 시설, 우편 트럭의 요약을 표시합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "월간 우편" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "최근 도시 전체의 우편 흐름을 보여 줍니다.\n\n" +
                    "**누적** = 시민이 만들어 낸 우편량.\n" +
                    "**처리됨** = 실제로 네트워크가 처리한 우편량.\n\n" +
                    "- \"처리됨\" 값이 자주 \"누적\"보다 크다면 네트워크 용량은 충분합니다.\n" +
                    "- \"누적\"이 오랫동안 \"처리됨\"보다 크다면\n" +
                    "  도시는 처리 능력보다 많은 우편을 발생시키고 있는 것입니다.\n" +
                    "  시설을 늘리거나 설정을 조정해 보세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "활동" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "최근 업데이트에서 수행된 우편 보충과 초과 정리 횟수를 표시합니다."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "아직 처리된 우편 시설이 없습니다. 도시를 열고 시뮬레이션을 잠시 돌려 주세요." },

                { "MM_STATUS_NO_ACTIVITY",
                  "아직 기록된 활동이 없습니다." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0}곳의 우체국 | {1}대의 우편 밴 | {2}곳의 분류 시설 | {3}대의 우편 트럭"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0}회 지역 우편 보충 | {1}회 미분류 우편 보충 | {2}회 초과 정리"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "도시 우편 통계가 아직 준비되지 않았습니다. 도시를 열고 시뮬레이션을 돌려 주세요." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} 누적 | {1} 처리됨"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "이 모드의 표시 이름입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "버전" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "현재 모드 버전입니다."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "**Magic Mail** 및 다른 모드의 **Paradox** 웹 페이지를 엽니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "브라우저에서 **Discord** 피드백 채팅을 엽니다."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
