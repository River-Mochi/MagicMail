// Localization/LocaleKO.cs
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
                { m_Setting.GetSettingsLocaleID(), "매직 메일 [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "상태" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "정보" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "우체국" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "우편 밴 & 트럭" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "분류 시설" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "초기화" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "도시 스캔" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "최근 작업" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "링크" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "로컬 메일 부족 해결" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "활성화되면 창고가 너무 낮아질 때 자동으로 메일이 조금 생겨납니다.\n " +
                    "추가 밴은 생성되지 않습니다. 진짜 마법처럼… 하지만 진짜예요 :)" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "로컬 메일 임계치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "로컬 메일이 이 비율 아래로 내려가면,\n " +
                    "우체국이 자동으로 로컬 메일을 약간 가져옵니다.\n" +
                    "최대 저장량 대비 비율입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "로컬 메일 가져오기 양" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "로컬 메일을 가져올 때 추가되는 비율입니다 (매직 충전).\n" +
                    "예: 기본 최대 10,000에서 20%라면 2,000이 추가됩니다." },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "메일 과부하 해결" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "메일이 너무 많을 때 시설이 작은 '마법 청소'를 수행합니다.\n " +
                    "과도하게 저장된 메일은 배달된 것으로 처리하고 제거됩니다.\n " +
                    "이 기능은 우체국/시설이 꽉 차서 멈추는 문제를 방지합니다.\n " +
                    "비활성으로 하면 완전 바닐라 동작을 유지합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "우체국 과부하 임계치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "우체국의 총 메일이 이 비율을 넘으면,\n" +
                    "모드는 저장된 메일 일부를 삭제하여 수준을 맞춥니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "분류 시설 과부하 임계치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "분류 시설의 메일이 이 비율을 넘으면,\n" +
                   "모드는 저장된 메일 일부를 삭제하여 수준을 맞춥니다." },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "용량 변경" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "활성화 시 밴/트럭 용량을 변경할 수 있습니다.\n" +
                    "비활성화하면 아래의 모든 슬라이더는 숨겨지고,\n" +
                    "게임(바닐라) 기본값을 사용합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "우편 밴 적재량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "각 우편 밴이 운반할 수 있는 메일 양을 조절합니다.\n" +
                    "<100% = 바닐라 용량>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "우편 밴 보유량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "각 우편 건물이 보유하고 출발시킬 수 있는 밴의 수입니다.\n" +
                    "<100% = 바닐라>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "우편 트럭 보유량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "분류 시설(또는 트럭이 있는 시설)이 보유하고 보낼 수 있는 트럭 수입니다.\n " +
                    "<100% = 바닐라>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "분류 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "분류 시설의 기본 분류 속도 배율입니다.\n " +
                    "<100% = 바닐라>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "분류 저장 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "분류 시설의 메일 저장 용량을 조절합니다.\n " +
                    "<100% = 바닐라>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "미분류 메일 부족 해결" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "활성화 시 저장량이 너무 낮으면 미분류 메일이 조금 자동으로 생깁니다.\n " +
                    "도착을 기다릴 필요 없이 시설이 계속 작동하도록 해줍니다.\n" +
                    "현재 화물 항만이 있을 때 분류 시설이 메일을 충분히 받지 못하는 버그 임시 해결입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "미분류 메일 임계치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "미분류 메일이 이 비율 아래로 떨어지면 자동으로 조금 가져옵니다.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "미분류 메일 가져오기 양" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "미분류 메일을 가져올 때 추가되는 양입니다 (매직 충전).\n" +
                    "최대 저장량 대비 비율입니다." },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "모든 설정을 게임 기본(바닐라) 상태로 되돌립니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "추천 설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**빠른 시작** – 추천 우편 설정을 모두 적용합니다.\n" +
                    "이지 모드: 1클릭 끝!" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "최근 게임 업데이트에서 처리된 우체국, 우편 밴, 분류 시설, 트럭 요약입니다 (~인게임 45분마다)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "도시 메일" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "최근 도시 전체 메일 흐름을 보여줍니다.\n\n" +
                     "**발생량** = 시민들이 생성한 메일.\n" +
                     "**처리량** = 우편 네트워크가 실제로 처리한 메일.\n\n" +
                     "- 처리량이 발생량보다 자주 높으면 시설 용량이 충분한 것입니다.\n " +
                     "- 발생량이 처리량보다 계속 높으면 도시가 메일을 감당하지 못하는 상태이므로,\n " +
                     "시설/밴을 더 추가하거나 설정을 조정해야 합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "활동" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "최근 업데이트에서 수행된 메일 가져오기 및 과부하 정리 횟수." },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "이 모드의 표시 이름." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "현재 모드 버전." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "파라독스" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "**Magic Mail** 및 다른 모드의 파라독스 웹페이지 열기." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "디스코드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "브라우저에서 디스코드 피드백 채널 열기." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
