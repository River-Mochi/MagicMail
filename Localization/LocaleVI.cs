// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleVI.cs
// Vietnamese locale vi-VN

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Vietnamese localization source for Magic Mail [MM].</summary>
    public class LocaleVI : IDictionarySource
    {
        private readonly MailSettings m_Setting;

        /// <summary>
        /// Constructs the Vietnamese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleVI(MailSettings setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Vietnamese localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(MailSettings.kActionsTab), "Tác vụ" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kStatusTab), "Trạng thái" },
                { m_Setting.GetOptionTabLocaleID(MailSettings.kAboutTab), "Giới thiệu" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostOfficeGroup), "Hỗ trợ điều phối bưu chính" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostVanGroup), "Xe van & xe tải bưu điện" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.PostSortingFacilityGroup), "Cơ sở phân loại chuyên dụng" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.ResetGroup), "Đặt lại" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusSummaryGroup), "Quét thành phố" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.StatusActivityGroup), "Cập nhật gần nhất" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(MailSettings.kAboutLinksGroup), "Liên kết" },

                // ---- Post Office / Dispatch Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GetLocalMail)), "Cứu khi thư nội địa quá thấp" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GetLocalMail)),
                    "Để game thử vận chuyển thư bình thường trước.\n" +
                    "Nếu thư nội địa vẫn rất thấp qua nhiều lần kiểm tra, Magic Mail sẽ thêm một lượng nhỏ để cứu tình trạng thiếu.\n" +
                    "Cũng áp dụng cho bưu điện có nâng cấp phân loại."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)), "Ngưỡng cứu thư nội địa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingThresholdPercentage)),
                    "Thư nội địa được xem là thấp khi chạm mức phần trăm này của kho tối đa của tòa nhà.\n" +
                    "Chỉ cứu khi mức thấp kéo dài qua nhiều lần kiểm tra."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_GettingPercentage)), "Lượng cứu thư nội địa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_GettingPercentage)),
                    "Lượng thư nội địa được thêm khi cứu.\n" +
                    "Tính theo phần trăm kho tối đa của tòa nhà."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.FixMailOverflow)), "Cứu tình trạng thư bị đầy" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.FixMailOverflow)),
                    "Nếu một cơ sở bưu điện quá đầy, Magic Mail sẽ giảm lượng thư lưu trữ về mức đã chọn.\n" +
                    "Tính cả thư nội địa + chưa phân loại + gửi đi, giúp phát hiện tình trạng đầy mà game có thể tính sai.\n" +
                    "Tắt để giữ hành vi vanilla hoàn toàn."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PO_OverflowPercentage)), "Ngưỡng đầy của bưu điện" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PO_OverflowPercentage)),
                    "Khi tổng thư lưu trữ vượt mức này, Magic Mail sẽ giảm xuống.\n" +
                    "Áp dụng cho bưu điện thường và bưu điện có nâng cấp phân loại."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_OverflowPercentage)), "Ngưỡng đầy của cơ sở phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_OverflowPercentage)),
                    "Khi tổng thư trong cơ sở phân loại chuyên dụng vượt mức này,\n" +
                    "Magic Mail sẽ giảm xuống."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ChangeCapacity)), "Thay đổi sức chứa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ChangeCapacity)),
                    "Bật để thay đổi sức chứa của xe van và xe tải. Khi tắt,\n" +
                    "các thanh chỉnh bên dưới sẽ bị ẩn và\n" +
                    "game dùng giá trị vanilla bình thường dù các giá trị khác vẫn còn được lưu."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)), "Tải thư của xe van" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanMailLoadPercentage)),
                    "Điều chỉnh lượng thư mỗi xe van bưu điện có thể chở.\n" +
                    "<100% = tải vanilla bình thường.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)), "Quy mô đội xe van" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PostVanFleetSizePercentage)),
                    "Điều chỉnh số xe van mỗi tòa nhà bưu điện có thể sở hữu và điều động.\n" +
                    "<100% = quy mô vanilla bình thường.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.TruckCapacityPercentage)), "Quy mô đội xe tải" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.TruckCapacityPercentage)),
                    "Điều chỉnh số xe tải bưu điện mà mỗi cơ sở có xe tải có thể sở hữu và điều động.\n" +
                    "<100% = quy mô vanilla bình thường.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)), "Tốc độ phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_SortingSpeedPercentage)),
                    "Hệ số cho cơ sở phân loại chuyên dụng.\n" +
                    "Không thay đổi nâng cấp phân loại của bưu điện.\n" +
                    "<100% = vanilla bình thường>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)), "Sức chứa kho phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_StorageCapacityPercentage)),
                    "Điều chỉnh kho thư của cơ sở phân loại chuyên dụng.\n" +
                    "Không thay đổi nâng cấp phân loại của bưu điện.\n" +
                    "<100% = vanilla bình thường>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)), "Cứu khi thư chưa phân loại quá thấp" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GetUnsortedMail)),
                    "Để game cung cấp thư chưa phân loại theo cách bình thường trước.\n" +
                    "Nếu cơ sở phân loại chuyên dụng vẫn rất thấp qua nhiều lần kiểm tra,\n" +
                    "Magic Mail sẽ thêm một lượng nhỏ để cứu tình trạng thiếu."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)), "Ngưỡng cứu thư chưa phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingThresholdPercentage)),
                    "Thư chưa phân loại được xem là thấp khi chạm mức phần trăm này của kho tối đa.\n" +
                    "Chỉ cứu khi mức thấp kéo dài qua nhiều lần kiểm tra."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.PSF_GettingPercentage)), "Lượng cứu thư chưa phân loại" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.PSF_GettingPercentage)),
                    "Lượng thư chưa phân loại được thêm khi cứu.\n" +
                    "Tính theo phần trăm kho tối đa."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToVanilla)), "Mặc định của game" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToVanilla)), "Khôi phục mọi cài đặt về hành vi mặc định ban đầu của game." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ResetToRecommend)), "Khuyến nghị" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ResetToRecommend)),
                    "**Hỗ trợ điều phối bưu chính** - Khởi động nhanh.\n" +
                    "Để hệ thống bưu điện bình thường hoạt động trước, rồi cứu các thiếu hụt lặp lại hoặc tình trạng quá đầy.\n" +
                    "Cũng áp dụng các điều chỉnh sức chứa được khuyến nghị."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusFacilitySummary)),
                    "Các tòa nhà bưu điện được tìm thấy khi mở trang Trạng thái.\n" +
                    "\n" +
                    "**Bưu điện** = bưu điện thông thường.\n" +
                    "**Cơ sở phân loại** = cơ sở phân loại bưu điện chuyên dụng.\n" +
                    "**Bưu điện có phân loại** = <Westmont Tower có nâng cấp phân loại>.\n" +
                    "- Cần **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusVehicleSummary)),
                    "Sức chứa xe bưu điện khi mở trang Trạng thái.\n" +
                    "\n" +
                    "**Xe van bưu điện** = xe nhận và giao thư trong khu vực.\n" +
                    "**Xe tải bưu điện** = chở thư giữa các cơ sở."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusCityMailSummary)), "Thư hàng tháng" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusCityMailSummary)),
                    "Hiển thị luồng thư gần đây của toàn thành phố.\n" +
                    "\n" +
                    "**Tích lũy** = lượng thư người dân tạo ra.\n" +
                    "**Đã xử lý** = lượng thư mạng lưới thực sự xử lý.\n" +
                    "\n" +
                    "- Nếu Đã xử lý thường cao hơn Tích lũy, mạng bưu điện có đủ công suất.\n" +
                    "- Nếu Tích lũy cao hơn Đã xử lý trong thời gian dài,\n" +
                    "thành phố đang tạo nhiều thư hơn khả năng xử lý của mạng.\n" +
                    "Hãy thêm cơ sở, xe van hoặc điều chỉnh cài đặt."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.StatusLastActivity)), "Hoạt động" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.StatusLastActivity)), "Các lần cứu và dọn quá đầy trong lượt cứu gần nhất của Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.WriteReport)), "Ghi báo cáo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(MailSettings.WriteReport)),
                    "Chạy **một lần** quét bưu điện chi tiết khi đang mở Tùy chọn,\n" +
                    "sau đó ghi báo cáo vào <Logs/MagicMail.log>. Không ghi log nền."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenLog)), "Mở log" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenLog)), "Mở <Logs/MagicMail.log>, hoặc thư mục Logs nếu tệp chưa tồn tại." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Không tìm thấy cơ sở bưu điện. Mở một thành phố rồi mở lại Trạng thái." },
                { "MM_STATUS_NO_ACTIVITY", "Chưa ghi nhận hoạt động cứu." },
                { "MM_STATUS_SUMMARY", "Bưu điện: {0} | Bưu điện có phân loại: {1} | Cơ sở phân loại: {2}" },
                { "MM_STATUS_VEHICLES", "Xe van bưu điện: {0} | Xe tải bưu điện: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} cứu thư nội địa | {1} cứu thư chưa phân loại | {2} lần dọn quá đầy" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Thống kê thư của thành phố chưa sẵn sàng. Mở một thành phố và cho mô phỏng chạy một lúc." },
                { "MM_STATUS_CITY_MAIL", "{0} tích lũy | {1} đã xử lý" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModNameDisplay)), "Tên hiển thị của mod này." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.ModVersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.ModVersionDisplay)), "Phiên bản mod hiện tại và loại bản dựng." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenParadox)), "Mod Paradox của Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenParadox)), "Mở trang **Paradox** của **Magic Mail** và các mod khác." },
                { m_Setting.GetOptionLabelLocaleID(nameof(MailSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(MailSettings.OpenDiscord)), "Mở kênh phản hồi **Discord** trong trình duyệt." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
