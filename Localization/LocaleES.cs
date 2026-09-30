// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleES.cs
// Spanish locale es-ES

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Spanish localization source for Magic Mail [MM].</summary>
    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Spanish locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Spanish localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Estado" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Acerca de" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Ayuda vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Furgonetas y camiones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de clasificación dedicado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Restablecer" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Escaneo de ciudad" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última actualización" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Enlaces" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Rescatar correo local bajo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Deja que el juego intente primero las transferencias normales de correo.\n" +
                    "Si el correo local sigue muy bajo durante varios escaneos, Magic Mail añade una pequeña recarga de rescate.\n" +
                    "También se aplica a oficinas de correos con mejora de clasificación."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Umbral de rescate de correo local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Marca el correo local como bajo al llegar a este porcentaje del almacenamiento máximo del edificio.\n" +
                    "El rescate solo actúa si sigue bajo durante varios escaneos."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Cantidad de rescate de correo local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Cantidad de correo local que se añade cuando actúa el rescate.\n" +
                    "Es un porcentaje del almacenamiento máximo del edificio."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Rescatar desbordamiento de correo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Si una instalación postal se llena demasiado, Magic Mail reduce el correo almacenado al nivel elegido.\n" +
                    "Cuenta correo local + sin clasificar + saliente para detectar sobrecargas que el juego puede calcular mal.\n" +
                    "Desactívalo para comportamiento vanilla puro."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Umbral de desbordamiento de oficina" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Cuando el correo total almacenado supera este nivel, Magic Mail lo reduce.\n" +
                    "Se aplica a oficinas normales y a oficinas con mejora de clasificación."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Umbral de desbordamiento de clasificación" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Cuando el correo total de un centro de clasificación dedicado supera este nivel,\n" +
                    "Magic Mail lo reduce."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Cambiar capacidades" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Activa esto para modificar capacidades de furgonetas y camiones. Si está apagado,\n" +
                    "los controles de abajo se ocultan y\n" +
                    "se usan los valores vanilla aunque hayas dejado otros valores guardados."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga de furgoneta postal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla cuánto correo puede llevar cada furgoneta postal.\n" +
                    "<100% = carga vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Tamaño de flota de furgonetas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla cuántas furgonetas puede tener y despachar cada edificio postal.\n" +
                    "<100% = flota vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Tamaño de flota de camiones" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla cuántos camiones postales puede tener y despachar cada instalación que use camiones.\n" +
                    "<100% = flota vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidad de clasificación" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador para centros de clasificación dedicados.\n" +
                    "No cambia la mejora de clasificación de una oficina de correos.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidad de almacenamiento de clasificación" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla el almacenamiento de correo de centros de clasificación dedicados.\n" +
                    "No cambia la mejora de clasificación de una oficina de correos.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Rescatar correo sin clasificar bajo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Deja que el juego suministre primero el correo sin clasificar de forma normal.\n" +
                    "Si un centro dedicado sigue muy bajo durante varios escaneos,\n" +
                    "Magic Mail añade una pequeña recarga de rescate."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Umbral de rescate sin clasificar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Marca el correo sin clasificar como bajo al llegar a este porcentaje del almacenamiento máximo.\n" +
                    "El rescate solo actúa si sigue bajo durante varios escaneos."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Cantidad de rescate sin clasificar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Cantidad de correo sin clasificar que se añade cuando actúa el rescate.\n" +
                    "Es un porcentaje del almacenamiento máximo."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Restaura todas las opciones al comportamiento original del juego (vanilla)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Ayuda vanilla** - Inicio rápido.\n" +
                    "Deja trabajar primero la logística normal y solo rescata faltas persistentes o desbordamientos.\n" +
                    "También aplica los ajustes de capacidad recomendados."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Edificios postales encontrados al abrir la página Estado.\n" +
                    "\n" +
                    "**Oficinas de correos** = oficinas normales.\n" +
                    "**Centros de clasificación** = centros postales de clasificación dedicados.\n" +
                    "**Oficinas con clasificación** = <Westmont Tower con mejora de clasificación>.\n" +
                    "- Requiere el **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Capacidad de vehículos postales al abrir la página Estado.\n" +
                    "\n" +
                    "**Furgonetas postales** = recogida y reparto local.\n" +
                    "**Camiones postales** = mueven correo entre instalaciones."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correo mensual" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Muestra el flujo reciente de correo de toda la ciudad.\n" +
                    "\n" +
                    "**Acumulado** = correo generado por los ciudadanos.\n" +
                    "**Procesado** = correo que la red realmente gestionó.\n" +
                    "\n" +
                    "- Si Procesado suele ser mayor que Acumulado, tu red postal tiene suficiente capacidad.\n" +
                    "- Si Acumulado se mantiene por encima de Procesado durante mucho tiempo,\n" +
                    "la ciudad genera más correo del que la red puede manejar.\n" +
                    "Añade instalaciones, furgonetas o ajusta las opciones."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Actividad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Rescates y limpiezas de desbordamiento del último ciclo de rescate de Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Escribir informe" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Ejecuta un escaneo postal detallado **una sola vez** mientras Opciones está abierto\n" +
                    "y escribe el informe en <Logs/MagicMail.log>. Sin registro en segundo plano."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir registro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre <Logs/MagicMail.log> o la carpeta Logs si el archivo todavía no existe." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "No se encontraron instalaciones postales. Abre una ciudad y vuelve a abrir Estado." },
                { "MM_STATUS_NO_ACTIVITY", "No se ha registrado actividad de rescate." },
                { "MM_STATUS_SUMMARY", "Oficinas: {0} | Oficinas con clasificación: {1} | Centros de clasificación: {2}" },
                { "MM_STATUS_VEHICLES", "Furgonetas postales: {0} | Camiones postales: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} rescates locales | {1} rescates sin clasificar | {2} limpiezas de desbordamiento" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Las estadísticas postales de la ciudad aún no están disponibles. Abre una ciudad y deja correr la simulación." },
                { "MM_STATUS_CITY_MAIL", "{0} acumulado | {1} procesado" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Nombre mostrado de este mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Versión actual del mod y tipo de compilación." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mods de Mochi en Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página de **Paradox** de **Magic Mail** y otros mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre el chat de comentarios de **Discord** en el navegador." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
