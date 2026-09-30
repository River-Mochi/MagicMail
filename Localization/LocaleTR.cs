// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleTR.cs
// Turkish locale tr-TR

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Turkish localization source for Magic Mail [MM].</summary>
    public sealed class LocaleTR : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Turkish locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleTR(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Turkish localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Eylemler" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Durum" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Hakkında" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Vanilla yardımı" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Posta minibüsleri ve kamyonları" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Özel ayırma tesisi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Sıfırla" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Şehir taraması" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Son güncelleme" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Bilgi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Bağlantılar" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Düşük yerel postayı kurtar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Önce oyunun normal posta transferlerini denemesine izin verir.\n" +
                    "Yerel posta birkaç tarama boyunca çok düşük kalırsa Magic Mail küçük bir kurtarma takviyesi ekler.\n" +
                    "Ayırma yükseltmesi olan postanelere de uygulanır."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Yerel posta kurtarma eşiği" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Yerel posta, bina azami deposunun bu yüzdesine geldiğinde düşük sayılır.\n" +
                    "Kurtarma yalnızca birkaç tarama boyunca düşük kalırsa çalışır."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Yerel posta kurtarma miktarı" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Kurtarma çalıştığında eklenecek yerel posta miktarı.\n" +
                    "Bina azami deposunun yüzdesidir."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Posta taşmasını kurtar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Bir posta tesisi fazla dolarsa Magic Mail depolanan postayı seçilen seviyeye indirir.\n" +
                    "Yerel + ayrılmamış + giden postayı birlikte sayar ve oyunun yanlış hesaplayabildiği taşmaları da yakalar.\n" +
                    "Saf vanilla davranışı için kapatın."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Postane taşma eşiği" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Toplam depolanan posta bu seviyeyi aşınca Magic Mail tekrar düşürür.\n" +
                    "Normal postaneler ve ayırma yükseltmeli postaneler için geçerlidir."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Ayırma tesisi taşma eşiği" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Özel ayırma tesisindeki toplam posta bu seviyeyi aşınca\n" +
                    "Magic Mail tekrar düşürür."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Kapasiteleri değiştir" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Minibüs ve kamyon kapasitelerini değiştirmek için açın. Kapalıyken\n" +
                    "aşağıdaki kapasite kaydırıcıları gizlenir ve\n" +
                    "başka değerler kayıtlı olsa bile vanilla değerleri kullanılır."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Posta minibüsü yükü" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Her posta minibüsünün ne kadar posta taşıyabileceğini ayarlar.\n" +
                    "<100% = vanilla yükü.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Posta minibüsü filo büyüklüğü" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Her posta binasının sahip olabileceği ve gönderebileceği minibüs sayısını ayarlar.\n" +
                    "<100% = vanilla filo büyüklüğü.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Posta kamyonu filo büyüklüğü" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Posta kamyonu olan her tesisin sahip olabileceği ve gönderebileceği kamyon sayısını ayarlar.\n" +
                    "<100% = vanilla filo büyüklüğü.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Ayırma hızı" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Özel ayırma tesisleri için çarpan.\n" +
                    "Bir postanenin ayırma yükseltmesini değiştirmez.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Ayırma depolama kapasitesi" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Özel ayırma tesislerinin posta deposunu ayarlar.\n" +
                    "Bir postanenin ayırma yükseltmesini değiştirmez.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Düşük ayrılmamış postayı kurtar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Önce oyunun ayrılmamış postayı normal şekilde sağlamasına izin verir.\n" +
                    "Özel ayırma tesisi birkaç tarama boyunca çok düşük kalırsa\n" +
                    "Magic Mail küçük bir kurtarma takviyesi ekler."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Ayrılmamış posta kurtarma eşiği" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Ayrılmamış posta, azami deponun bu yüzdesine geldiğinde düşük sayılır.\n" +
                    "Kurtarma yalnızca birkaç tarama boyunca düşük kalırsa çalışır."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Ayrılmamış posta kurtarma miktarı" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Kurtarma çalıştığında eklenecek ayrılmamış posta miktarı.\n" +
                    "Azami deponun yüzdesidir."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Oyun varsayılanları" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Tüm ayarları oyunun orijinal varsayılan davranışına (vanilla) döndürür." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Önerilen" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Vanilla yardımı** - Hızlı Başlangıç.\n" +
                    "Önce normal posta lojistiğinin çalışmasına izin verir, sonra yalnızca kalıcı eksikleri veya taşmayı kurtarır.\n" +
                    "Önerilen kapasite ayarlarını da uygular."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Durum sayfası açıldığında bulunan posta binaları.\n" +
                    "\n" +
                    "**Postaneler** = normal postaneler.\n" +
                    "**Ayırma tesisleri** = özel posta ayırma tesisleri.\n" +
                    "**Ayırmalı postaneler** = <Ayırma yükseltmeli Westmont Tower>.\n" +
                    "- **Skyscrapers DLC** gerekir."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Durum sayfası açıldığındaki posta aracı kapasitesi.\n" +
                    "\n" +
                    "**Posta minibüsleri** = yerel toplama ve teslim araçları.\n" +
                    "**Posta kamyonları** = tesisler arasında posta taşır."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Aylık posta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Şehir genelindeki son posta akışını gösterir.\n" +
                    "\n" +
                    "**Birikmiş** = vatandaşların ürettiği posta miktarı.\n" +
                    "**İşlenmiş** = ağın gerçekten işlediği posta miktarı.\n" +
                    "\n" +
                    "- İşlenmiş sık sık Birikmiş'ten yüksekse posta ağınızın kapasitesi yeterlidir.\n" +
                    "- Birikmiş uzun süre İşlenmiş'in üzerinde kalırsa\n" +
                    "şehir ağın taşıyabileceğinden daha fazla posta üretiyor demektir.\n" +
                    "Daha fazla tesis veya minibüs ekleyin ya da ayarları değiştirin."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Etkinlik" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Son Magic Mail kurtarma geçişindeki kurtarmalar ve taşma temizlikleri." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Rapor yaz" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Seçenekler açıkken **tek seferlik** ayrıntılı posta taraması yapar\n" +
                    "ve raporu <Logs/MagicMail.log> dosyasına yazar. Arka planda günlük tutulmaz."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Günlüğü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "<Logs/MagicMail.log> dosyasını veya dosya henüz yoksa Logs klasörünü açar." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Posta tesisi bulunamadı. Bir şehir açın, sonra Durum'u yeniden açın." },
                { "MM_STATUS_NO_ACTIVITY", "Kurtarma etkinliği kaydedilmedi." },
                { "MM_STATUS_SUMMARY", "Postaneler: {0} | Ayırmalı postaneler: {1} | Ayırma tesisleri: {2}" },
                { "MM_STATUS_VEHICLES", "Posta minibüsleri: {0} | Posta kamyonları: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} yerel kurtarma | {1} ayrılmamış kurtarma | {2} taşma temizliği" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Şehir posta istatistikleri henüz hazır değil. Bir şehir açın ve simülasyonu biraz çalıştırın." },
                { "MM_STATUS_CITY_MAIL", "{0} birikmiş | {1} işlenmiş" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Bu modun görünen adı." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Geçerli mod sürümü ve derleme türü." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mochi'nin Paradox modları" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "**Magic Mail** ve diğer modlar için **Paradox** sayfasını açar." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "**Discord** geri bildirim sohbetini tarayıcıda açar." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
