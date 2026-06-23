// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleVI.cs
// Vietnamese locale vi-VN

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Vietnamese localization source for Magic Mail [MM].</summary>
    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleVI(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Tác vụ" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Trạng thái" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Giới thiệu" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Bưu điện" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Xe bưu phẩm" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Trung tâm phân loại" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Đặt lại" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Quét thành phố" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Lần cập nhật gần nhất" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Liên kết" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Sửa thư nội địa thấp" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Khi bật, một ít thư nội địa sẽ được thêm vào\n" +
                    "khi lượng thư xuống quá thấp.\n" +
                    "Không sinh thêm xe – giống như có phép thuật vậy :)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Ngưỡng thư nội địa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Nếu thư nội địa xuống dưới tỉ lệ này\n" +
                    "(tính theo % sức chứa tối đa của tòa nhà),\n" +
                    "bưu điện sẽ tự động kéo thêm thư về."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Lượng thư nội địa bổ sung" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Phần trăm thêm vào khi mod \"bơm\" thư nội địa.\n" +
                    "Ví dụ: sức chứa = 100.000, giá trị = 10%\n" +
                    "→ thêm 10.000 thư."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Sửa quá tải thư" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Khi kho thư đầy, các cơ sở sẽ thực hiện một lần dọn dẹp nhỏ.\n" +
                    "Thư dư được coi như đã phát và bị xóa.\n" +
                    "Giúp tránh tình trạng kho thư bị kẹt 100% mãi mãi.\n" +
                    "Tắt để giữ đúng hành vi vanilla."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Ngưỡng quá tải bưu điện" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Khi tổng thư tại một bưu điện đạt tỉ lệ này,\n" +
                    "mod sẽ xóa bớt thư để đưa về gần mức đó."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Ngưỡng quá tải trung tâm phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Khi tổng thư tại trung tâm phân loại đạt tỉ lệ này,\n" +
                    "thư dư sẽ bị loại bỏ."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Thay đổi sức chứa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Cho phép chỉnh sức chứa của xe bưu phẩm.\n" +
                    "Khi tắt, các thanh trượt ẩn đi và luôn dùng\n" +
                    "giá trị gốc của game."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Tải thư mỗi xe van" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Điều khiển lượng thư mỗi xe van có thể chở.\n" +
                    "<100% = tải gốc của game>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Quy mô đội xe van" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Điều khiển số lượng xe van mỗi tòa nhà bưu điện có thể sở hữu và xuất phát.\n" +
                    "<100% = đội xe gốc>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Quy mô đội xe tải" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Điều khiển số xe tải bưu chính mà mỗi trung tâm phân loại\n" +
                    "hoặc cơ sở có xe tải có thể sở hữu và xuất phát.\n" +
                    "<100% = đội xe gốc>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Tốc độ phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Hệ số nhân cho tốc độ phân loại cơ bản của trung tâm.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Sức chứa kho thư" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Điều khiển **sức chứa kho thư**.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Sửa thư chưa phân loại thấp" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Khi bật, nếu thư chưa phân loại trong kho xuống quá thấp,\n" +
                    "mod sẽ bổ sung thêm để trung tâm không bị \"chết\".\n" +
                    "Đây là bản vá tạm thời cho lỗi khi cảng hàng hóa\n" +
                    "khiến trung tâm phân loại nhận thư không đủ."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Ngưỡng thư chưa phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Nếu thư chưa phân loại xuống dưới tỉ lệ này\n" +
                    "so với sức chứa tối đa, hệ thống sẽ kéo thêm thư.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Lượng thư chưa phân loại bổ sung" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Lượng thư chưa phân loại được thêm (theo % sức chứa tối đa).\n" +
                    "Ví dụ: max = 250.000, giá trị = 10% → thêm 25.000 thư."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Mặc định game" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Khôi phục mọi lựa chọn về hành vi mặc định ban đầu của game (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Khuyến nghị" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Bắt đầu nhanh** – áp dụng toàn bộ thiết lập bưu chính được khuyến nghị.\n" +
                    "Chế độ dễ: nhấn một lần là xong!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Tóm tắt số bưu điện, xe van, trung tâm phân loại và xe tải\n" +
                    "đã được xử lý trong lần quét nền gần nhất."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Thư hàng tháng" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Hiển thị luồng thư toàn thành phố gần đây.\n\n" +
                    "**Tích lũy** = lượng thư người dân tạo ra.\n" +
                    "**Đã xử lý** = lượng thư mạng bưu chính thực sự xử lý.\n\n" +
                    "- Nếu \"Đã xử lý\" thường cao hơn \"Tích lũy\" → mạng đủ mạnh.\n" +
                    "- Nếu \"Tích lũy\" thường cao hơn trong thời gian dài\n" +
                    "  → thành phố tạo ra nhiều thư hơn khả năng xử lý.\n" +
                    "  Hãy thêm cơ sở mới hoặc chỉnh lại thiết lập."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Hoạt động" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Số lần bổ sung thư và dọn quá tải trong lần cập nhật gần nhất."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Chưa có cơ sở bưu chính nào được xử lý. Mở một thành phố và cho mô phỏng chạy." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Chưa có hoạt động nào được ghi lại." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} bưu điện | {1} xe van | {2} trung tâm phân loại | {3} xe tải bưu chính"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} lần bổ sung thư nội địa | {1} lần bổ sung thư chưa phân loại | {2} lần dọn quá tải"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Thống kê thư của thành phố chưa sẵn sàng. Mở một thành phố và cho mô phỏng chạy." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} tích lũy | {1} đã xử lý"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Tên hiển thị của mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Phiên bản" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Phiên bản hiện tại của mod."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Mở trang **Paradox** cho **Magic Mail** và các mod khác."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Mở kênh phản hồi trên **Discord** trong trình duyệt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
