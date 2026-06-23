// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocaleTH(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "การทำงาน" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "สถานะ" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "เกี่ยวกับ" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "ไปรษณีย์" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "รถส่งไปรษณีย์" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "ศูนย์คัดแยก" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "รีเซ็ต" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "สแกนเมือง" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "อัปเดตล่าสุด" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "ลิงก์" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "แก้จดหมายในพื้นที่ต่ำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "ถ้าเปิดไว้ จะเพิ่มจดหมายในพื้นที่เล็กน้อย\n" +
                    "เมื่อปริมาณเหลือน้อยเกินไป\n" +
                    "ไม่สร้างรถเพิ่ม แค่เหมือนมีเวทมนตร์ :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "เกณฑ์จดหมายในพื้นที่" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "เมื่อจดหมายในพื้นที่ต่ำกว่าระดับนี้ (เป็น % ของความจุอาคาร)\n" +
                    "ไปรษณีย์จะดึงจดหมายเพิ่มเข้ามาให้เอง"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "ปริมาณดึงจดหมายในพื้นที่" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "เปอร์เซ็นต์ที่ใช้เติมจดหมายในพื้นที่แบบเวทมนตร์\n" +
                    "เช่น ถ้าความจุ = 100,000 และตั้งค่า = 10%\n" +
                    "จะเพิ่ม 10,000 ฉบับเมื่อจำเป็น"
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "แก้จดหมายล้นคลัง" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "เมื่อมีจดหมายเกินความจุ อาคารจะทำความสะอาดเล็กน้อย\n" +
                    "ถือว่าจดหมายส่วนเกินถูกส่งแล้วและลบออก\n" +
                    "ช่วยไม่ให้คลังเต็มค้างตลอดเวลา\n" +
                    "ปิดเพื่อใช้พฤติกรรมแบบเกมเดิมล้วน ๆ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "เกณฑ์ล้นคลังของไปรษณีย์" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "เมื่อจดหมายรวมในไปรษณีย์ถึงเปอร์เซ็นต์นี้\n" +
                    "ม็อดจะลบส่วนเกินออกจนกลับลงมาใกล้ระดับนี้"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "เกณฑ์ล้นคลังของศูนย์คัดแยก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "เมื่อจดหมายรวมในศูนย์คัดแยกถึงเปอร์เซ็นต์นี้\n" +
                    "ม็อดจะลบจดหมายส่วนเกินออก"
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "เปลี่ยนความจุ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "เปิดเพื่อปรับความจุของรถส่งไปรษณีย์\n" +
                    "ถ้าปิด สไลเดอร์ทั้งหมดจะซ่อน และใช้ค่าเกมเดิมเสมอ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "จดหมายต่อรถตู้" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "ควบคุมว่ารถตู้แต่ละคันบรรทุกจดหมายได้เท่าไร\n" +
                    "<100% = ค่าเดิมของเกม>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "จำนวนรถตู้" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "ควบคุมจำนวนรถตู้ที่อาคารไปรษณีย์แต่ละแห่งมีและออกวิ่งได้\n" +
                    "<100% = จำนวนเดิมของเกม>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "จำนวนรถบรรทุก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "ควบคุมจำนวนรถบรรทุกจดหมายที่ศูนย์คัดแยก (และอาคารอื่น)\n" +
                    "มีและส่งออกได้\n" +
                    "<100% = จำนวนเดิมของเกม>"
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "ความเร็วคัดแยก" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "ตัวคูณอัตราคัดแยกพื้นฐานของศูนย์คัดแยก\n" +
                    "<100% = ค่าเดิมของเกม>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "ความจุเก็บจดหมาย" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "ควบคุมความจุในการเก็บจดหมายทั้งหมด\n" +
                    "<100% = ค่าเดิมของเกม>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "แก้จดหมายยังไม่คัดต่ำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "เมื่อเปิด ถ้าจดหมายที่ยังไม่คัดเหลือน้อยเกินไป\n" +
                    "ระบบจะเพิ่มจดหมายชนิดนี้เพื่อให้ศูนย์คัดแยกทำงานต่อเนื่อง\n" +
                    "เป็นการแก้บั๊กชั่วคราวเมื่อมีท่าเรือสินค้าทำให้จดหมายเข้าศูนย์ไม่พอ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "เกณฑ์จดหมายยังไม่คัด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "ถ้าจดหมายยังไม่คัดต่ำกว่าสัดส่วนนี้ของความจุทั้งหมด\n" +
                    "จะมีการดึงจดหมายเพิ่ม\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "ปริมาณดึงจดหมายยังไม่คัด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "ปริมาณจดหมายยังไม่คัดที่ใช้เติม (เป็น % ของความจุสูงสุด)\n" +
                    "เช่น ถ้าความจุ = 250,000 และตั้งค่า = 10%\n" +
                    "จะเพิ่ม 25,000 ฉบับ"
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "ค่าเริ่มต้นของเกม" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "คืนค่าทุกอย่างกลับเป็นพฤติกรรมมาตรฐานของเกม (vanilla)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "ค่าที่แนะนำ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**เริ่มแบบเร็ว** – ใช้การตั้งค่าไปรษณีย์ที่แนะนำทั้งหมด\n" +
                    "โหมดง่าย: คลิกครั้งเดียวแล้วจบ!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "สรุปจำนวนไปรษณีย์ รถตู้ ศูนย์คัดแยก และรถบรรทุก\n" +
                    "ที่ถูกประมวลผลในการสแกนรอบล่าสุด"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "จดหมายรายเดือน" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "แสดงการไหลของจดหมายทั้งเมืองช่วงล่าสุด\n\n" +
                    "**สะสม** = จดหมายที่ชาวเมืองสร้างขึ้น\n" +
                    "**ประมวลผล** = จดหมายที่เครือข่ายจัดการได้จริง\n\n" +
                    "- ถ้า \"ประมวลผล\" มักสูงกว่า \"สะสม\" แปลว่าเครือข่ายเพียงพอ\n" +
                    "- ถ้า \"สะสม\" สูงกว่าเป็นเวลานาน แปลว่าจดหมายมากเกินกำลังระบบ\n" +
                    "  ลองเพิ่มอาคารหรือปรับการตั้งค่า"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "กิจกรรม" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "จำนวนครั้งการเติมจดหมายและการล้างคลังล้นในรอบล่าสุด"
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "ยังไม่มีการประมวลผลอาคารไปรษณีย์ เปิดเมืองแล้วปล่อยให้จำลองสักพัก" },

                { "MM_STATUS_NO_ACTIVITY",
                  "ยังไม่มีกิจกรรมที่บันทึกไว้" },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} ไปรษณีย์ | {1} รถตู้ไปรษณีย์ | {2} ศูนย์คัดแยก | {3} รถบรรทุกไปรษณีย์"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} ครั้งดึงจดหมายในพื้นที่ | {1} ครั้งดึงจดหมายยังไม่คัด | {2} ครั้งล้างคลังล้น"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "สถิติไปรษณีย์ของเมืองยังไม่พร้อม ใช้เมืองแล้วปล่อยให้จำลองทำงานสักพัก" },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} สะสม | {1} ประมวลผลแล้ว"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "ม็อด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "ชื่อที่แสดงของม็อดนี้"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "เวอร์ชัน" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "เวอร์ชันปัจจุบันของม็อด"
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "เปิดเว็บ **Paradox** สำหรับ **Magic Mail** และม็อดอื่น ๆ"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "เปิดห้องพูดคุยข้อเสนอแนะบน **Discord** ในเบราว์เซอร์"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
