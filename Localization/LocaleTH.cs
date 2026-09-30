// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleTH.cs
// Thai locale th-TH

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Thai localization source for Magic Mail [MM].</summary>
    public sealed class LocaleTH : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Thai locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleTH(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Thai localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "การทำงาน" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "สถานะ" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "เกี่ยวกับ" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "ตัวช่วยวานิลลา" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "รถตู้และรถบรรทุกไปรษณีย์" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "ศูนย์คัดแยกเฉพาะ" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "รีเซ็ต" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "สแกนเมือง" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "อัปเดตล่าสุด" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "ลิงก์" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "ช่วยเมื่อจดหมายท้องถิ่นต่ำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "ให้เกมลองขนส่งจดหมายตามปกติก่อน\n" +
                    "ถ้าจดหมายท้องถิ่นยังต่ำมากต่อเนื่องหลายครั้ง Magic Mail จะเติมเล็กน้อยเพื่อช่วย\n" +
                    "ใช้กับที่ทำการไปรษณีย์ที่มีอัปเกรดคัดแยกด้วย"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "เกณฑ์ช่วยจดหมายท้องถิ่น" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "ถือว่าจดหมายท้องถิ่นต่ำเมื่อถึงเปอร์เซ็นต์นี้ของความจุสูงสุดของอาคาร\n" +
                    "จะช่วยก็ต่อเมื่อระดับต่ำต่อเนื่องหลายครั้ง"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "ปริมาณช่วยจดหมายท้องถิ่น" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "ปริมาณจดหมายท้องถิ่นที่จะเติมเมื่อระบบช่วยทำงาน\n" +
                    "คิดเป็นเปอร์เซ็นต์ของความจุสูงสุดของอาคาร"
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "ช่วยแก้จดหมายล้น" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "ถ้าสถานที่ไปรษณีย์เต็มเกินไป Magic Mail จะลดจดหมายที่เก็บไว้ลงถึงระดับที่เลือก\n" +
                    "นับจดหมายท้องถิ่น + ยังไม่คัด + ส่งออก เพื่อจับกรณีล้นที่เกมอาจคำนวณผิด\n" +
                    "ปิดเพื่อใช้พฤติกรรมวานิลลาล้วน"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "เกณฑ์ล้นของที่ทำการไปรษณีย์" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "เมื่อจดหมายที่เก็บทั้งหมดเกินระดับนี้ Magic Mail จะลดลง\n" +
                    "ใช้กับที่ทำการปกติและที่ทำการที่มีอัปเกรดคัดแยก"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "เกณฑ์ล้นของศูนย์คัดแยก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "เมื่อจดหมายทั้งหมดในศูนย์คัดแยกเฉพาะเกินระดับนี้\n" +
                    "Magic Mail จะลดลง"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "เปลี่ยนความจุ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "เปิดเพื่อปรับความจุรถตู้และรถบรรทุก เมื่อปิด\n" +
                    "ตัวเลื่อนด้านล่างจะถูกซ่อน และ\n" +
                    "เกมจะใช้ค่าปกติแม้จะเคยตั้งค่าอื่นไว้"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "ปริมาณบรรทุกของรถตู้ไปรษณีย์" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "กำหนดว่ารถตู้ไปรษณีย์แต่ละคันบรรทุกจดหมายได้เท่าไร\n" +
                    "<100% = ปริมาณบรรทุกวานิลลา>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "ขนาดกองรถตู้ไปรษณีย์" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "กำหนดจำนวนรถตู้ที่อาคารไปรษณีย์แต่ละแห่งมีและส่งออกได้\n" +
                    "<100% = จำนวนรถวานิลลา>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "ขนาดกองรถบรรทุกไปรษณีย์" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "กำหนดจำนวนรถบรรทุกไปรษณีย์ที่สถานที่ซึ่งมีรถบรรทุกสามารถมีและส่งออกได้\n" +
                    "<100% = จำนวนรถวานิลลา>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "ความเร็วคัดแยก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "ตัวคูณสำหรับศูนย์คัดแยกเฉพาะ\n" +
                    "ไม่เปลี่ยนอัปเกรดคัดแยกของที่ทำการไปรษณีย์\n" +
                    "<100% = วานิลลา>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "ความจุคลังคัดแยก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "กำหนดพื้นที่เก็บจดหมายของศูนย์คัดแยกเฉพาะ\n" +
                    "ไม่เปลี่ยนอัปเกรดคัดแยกของที่ทำการไปรษณีย์\n" +
                    "<100% = วานิลลา>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "ช่วยเมื่อจดหมายยังไม่คัดต่ำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "ให้เกมส่งจดหมายยังไม่คัดตามปกติก่อน\n" +
                    "ถ้าศูนย์คัดแยกเฉพาะยังมีน้อยมากต่อเนื่องหลายครั้ง\n" +
                    "Magic Mail จะเติมเล็กน้อยเพื่อช่วย"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "เกณฑ์ช่วยจดหมายยังไม่คัด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "ถือว่าจดหมายยังไม่คัดต่ำเมื่อถึงเปอร์เซ็นต์นี้ของความจุสูงสุด\n" +
                    "จะช่วยก็ต่อเมื่อระดับต่ำต่อเนื่องหลายครั้ง"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "ปริมาณช่วยจดหมายยังไม่คัด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "ปริมาณจดหมายยังไม่คัดที่จะเติมเมื่อระบบช่วยทำงาน\n" +
                    "คิดเป็นเปอร์เซ็นต์ของความจุสูงสุด"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "ค่าเริ่มต้นของเกม" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "คืนค่าทั้งหมดเป็นพฤติกรรมดั้งเดิมของเกม (วานิลลา)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "แนะนำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**ตัวช่วยวานิลลา** - เริ่มด่วน\n" +
                    "ให้ระบบไปรษณีย์ปกติทำงานก่อน แล้วช่วยเฉพาะปัญหาขาดต่อเนื่องหรือคลังล้น\n" +
                    "ใช้ค่าปรับความจุที่แนะนำด้วย"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "อาคารไปรษณีย์ที่พบเมื่อเปิดหน้าสถานะ\n" +
                    "\n" +
                    "**ที่ทำการไปรษณีย์** = ที่ทำการปกติ\n" +
                    "**ศูนย์คัดแยก** = ศูนย์คัดแยกไปรษณีย์เฉพาะ\n" +
                    "**ที่ทำการพร้อมคัดแยก** = <Westmont Tower ที่มีอัปเกรดคัดแยก>\n" +
                    "- ต้องมี **DLC Skyscrapers**"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "ความจุรถไปรษณีย์เมื่อเปิดหน้าสถานะ\n" +
                    "\n" +
                    "**รถตู้ไปรษณีย์** = รถรับและส่งในพื้นที่\n" +
                    "**รถบรรทุกไปรษณีย์** = ขนจดหมายระหว่างสถานที่"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "จดหมายรายเดือน" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "แสดงการไหลของจดหมายทั้งเมืองช่วงล่าสุด\n" +
                    "\n" +
                    "**สะสม** = จดหมายที่ชาวเมืองสร้างขึ้น\n" +
                    "**ประมวลผล** = จดหมายที่เครือข่ายจัดการได้จริง\n" +
                    "\n" +
                    "- ถ้า ประมวลผล สูงกว่า สะสม บ่อย ๆ แสดงว่าเครือข่ายมีความจุพอ\n" +
                    "- ถ้า สะสม สูงกว่า ประมวลผล เป็นเวลานาน\n" +
                    "เมืองกำลังสร้างจดหมายมากกว่าที่เครือข่ายจะจัดการได้\n" +
                    "เพิ่มสถานที่ รถตู้ หรือปรับการตั้งค่า"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "กิจกรรม" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "การช่วยและการล้างคลังล้นจากรอบช่วยล่าสุดของ Magic Mail" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "เขียนรายงาน" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "สแกนระบบไปรษณีย์แบบละเอียด **ครั้งเดียว** ขณะเปิดตัวเลือก\n" +
                    "แล้วเขียนรายงานลง <Logs/MagicMail.log> ไม่มีการบันทึกเบื้องหลัง"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิดบันทึก" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "เปิด <Logs/MagicMail.log> หรือเปิดโฟลเดอร์ Logs ถ้ายังไม่มีไฟล์" },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "ไม่พบสถานที่ไปรษณีย์ เปิดเมืองแล้วเปิดหน้าสถานะอีกครั้ง" },
                { "MM_STATUS_NO_ACTIVITY", "ยังไม่มีกิจกรรมช่วยเหลือที่บันทึกไว้" },
                { "MM_STATUS_SUMMARY", "ที่ทำการไปรษณีย์: {0} | ที่ทำการพร้อมคัดแยก: {1} | ศูนย์คัดแยก: {2}" },
                { "MM_STATUS_VEHICLES", "รถตู้ไปรษณีย์: {0} | รถบรรทุกไปรษณีย์: {1}" },
                { "MM_STATUS_ACTIVITY", "ช่วยจดหมายท้องถิ่น {0} | ช่วยจดหมายยังไม่คัด {1} | ล้างคลังล้น {2}" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "สถิติจดหมายของเมืองยังไม่พร้อม เปิดเมืองแล้วปล่อยให้ซิมูเลชันทำงานสักพัก" },
                { "MM_STATUS_CITY_MAIL", "สะสม {0} | ประมวลผล {1}" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "ชื่อที่แสดงของม็อดนี้" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "เวอร์ชันปัจจุบันและชนิดบิลด์ของม็อด" },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "ม็อด Paradox ของ Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า **Paradox** ของ **Magic Mail** และม็อดอื่น ๆ" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "เปิดแชตฟีดแบ็ก **Discord** ในเบราว์เซอร์" },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
