// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocaleES(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Estado" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Acerca de" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Asistencia al reparto postal" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Furgonetas y camiones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de clasificación" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Restablecer" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Resumen de la ciudad" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última actualización" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Información" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Enlaces" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corregir correo local bajo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Si está activado, aparece una pequeña cantidad de correo local\n" +
                    "cuando el nivel baja demasiado.\n" +
                    "No genera vehículos extra: es como magia… pero real :)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Umbral de correo local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Si el correo local baja por debajo de este porcentaje,\n" +
                    "la oficina de correos traerá más correo.\n" +
                    "Es un porcentaje de la capacidad máxima del edificio.\n" +
                    "Ej.: <max = 100 000>, <umbral = 5%>,\n" +
                    "si el correo local < <5 000>, se rellena automáticamente."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Cantidad de recarga local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Porcentaje que se añade al rellenar el correo local.\n" +
                    "Si la capacidad vanilla max = <100 000> y se establece en <10%>,\n" +
                    "se añaden <10 000> cuando hace falta."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corregir desbordamiento de correo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Cuando hay demasiado correo almacenado, los edificios realizan\n" +
                    "una pequeña limpieza mágica.\n" +
                    "El exceso se considera entregado y se elimina.\n" +
                    "Evita que las instalaciones queden bloqueadas al 100 %.\n" +
                    "Desactiva esta opción para mantener el comportamiento vanilla."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Umbral de desbordamiento en oficinas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Cuando el correo total de una oficina alcanza este porcentaje,\n" +
                    "la mod borra suficiente correo para volver a ese nivel."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Umbral de desbordamiento en centros" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Cuando el correo total de un centro de clasificación alcanza este porcentaje,\n" +
                    "la mod elimina el exceso."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Cambiar capacidades" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Activa la modificación de las capacidades de furgonetas y camiones.\n" +
                    "Si está desactivado, se usan los valores vanilla\n" +
                    "aunque los deslizadores estén en otro valor."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga de correo por furgoneta" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla cuánto correo puede transportar cada furgoneta postal.\n" +
                    "<100% = valor vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Tamaño de flota de furgonetas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla cuántas furgonetas puede poseer y enviar cada edificio postal.\n" +
                    "<100% = flota vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Tamaño de flota de camiones" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla cuántos camiones postales puede tener cada centro de clasificación\n" +
                    "u otro edificio con camiones postales.\n" +
                    "<100% = flota vanilla>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidad de clasificación" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador para los centros de clasificación. Afecta a la velocidad base.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidad de almacenamiento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla la capacidad de almacenamiento de correo.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corregir correo sin clasificar bajo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Si está activado, aparece correo sin clasificar adicional cuando las reservas\n" +
                    "son demasiado bajas para mantener activos los centros de clasificación.\n" +
                    "Solución temporal a un error donde los centros reciben poco correo\n" +
                    "si hay un puerto de carga."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Umbral de correo sin clasificar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Si el correo sin clasificar cae por debajo de este porcentaje de la capacidad total,\n" +
                    "se añade automáticamente un poco más."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Cantidad de recarga sin clasificar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Cantidad añadida al rellenar correo sin clasificar (porcentaje de la capacidad máxima).\n" +
                    "Ej.: capacidad max <250 000>, valor <10%> → se añaden <25 000>."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valores del juego" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restaura todos los ajustes al comportamiento original del juego (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Inicio rápido**: aplica todos los ajustes postales recomendados.\n" +
                    "Modo fácil: un clic y listo."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Resumen de oficinas, furgonetas, centros de clasificación y camiones\n" +
                    "procesados en el último escaneo en segundo plano."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correo mensual" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Muestra el flujo reciente de correo en toda la ciudad.\n\n" +
                    "**Acumulado** = correo generado por los ciudadanos.\n" +
                    "**Procesado** = correo que la red realmente manejó.\n\n" +
                    "- Si \"Procesado\" suele ser mayor que \"Acumulado\", la red es suficiente.\n" +
                    "- Si \"Acumulado\" se mantiene mucho tiempo por encima de \"Procesado\",\n" +
                    "la ciudad genera más correo del que se puede manejar.\n" +
                    "Añade más edificios o ajusta la configuración."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Actividad" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Número de recargas de correo y limpiezas de desbordamiento realizadas\n" +
                    "en la última actualización."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Aún no se han procesado instalaciones postales. Abre una ciudad y deja correr la simulación." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Todavía no se ha registrado ninguna actividad." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} oficinas de correos | {1} furgonetas postales | {2} centros de clasificación | {3} camiones postales"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} recargas de correo local | {1} recargas de correo sin clasificar | {2} limpiezas de desbordamiento"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Las estadísticas de correo de la ciudad aún no están disponibles. Abre una ciudad y deja correr la simulación." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} acumulado | {1} procesado"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nombre visible de este mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versión" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Versión actual del mod."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Abrir la página de **Paradox** de **Magic Mail** y otros mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abrir el canal de comentarios en **Discord** en el navegador."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
