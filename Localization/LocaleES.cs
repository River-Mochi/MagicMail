// Localization/LocaleES.cs
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Estado" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Acerca de" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Oficina de correos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Furgonetas y camiones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de clasificación" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Restablecer" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Resumen de la ciudad" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última actividad" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Enlaces" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corregir poco correo local" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Cuando está activado y el almacén baja demasiado, aparece correo extra.\n " +
                    "No se generan furgonetas adicionales: es como magia, pero de verdad." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Umbral de correo local" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Si el correo local baja por debajo de este porcentaje que eliges,\n " +
                    "la oficina de correos obtiene más correo local.\n" +
                    "Es un porcentaje de la capacidad máxima de almacenamiento." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Cantidad de correo local" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Porcentaje que se añade al rellenar el correo local (recarga mágica).\n" +
                    "Si el máximo vanilla = 10 000 y aquí pones 20 %, se añaden 2 000." },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corregir desbordamiento de correo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Cuando hay demasiado correo, los edificios hacen una pequeña limpieza **mágica**.\n " +
                    "El correo sobrante se considera entregado y se elimina.\n " +
                    "Esto evita que los edificios se queden bloqueados como \"llenos\" para siempre.\n " +
                    "Desactiva esta opción para mantener el comportamiento vanilla puro." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Umbral de desbordamiento (oficina)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Cuando el correo total en una oficina de correos llega a este porcentaje,\n" +
                    "el mod borra suficiente correo almacenado para volver a este nivel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Umbral de desbordamiento (clasificación)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "Cuando el correo total en un centro de clasificación llega a este porcentaje,\n" +
                   "el mod borra suficiente correo almacenado para volver a este nivel." },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Cambiar capacidades" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Activa esto para modificar las capacidades de furgonetas y camiones. Si está desactivado,\n" +
                    "todos los deslizadores de abajo se ocultan y\n" +
                    "se usan los valores vanilla del juego incluso si dejaste otros valores en los deslizadores." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga de las furgonetas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla cuánto correo puede transportar cada furgoneta de correos.\n" +
                    "<100 % = carga vanilla.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Tamaño de la flota de furgonetas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla cuántas furgonetas puede tener y enviar cada edificio postal.\n" +
                    "<100 % = flota vanilla.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Tamaño de la flota de camiones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla cuántos camiones de correos puede tener y enviar cada centro de clasificación\n " +
                    " (y cualquier edificio con camiones postales).\n " +
                    "<100 % = flota vanilla.>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidad de clasificación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador para los centros de **clasificación**. Se aplica a la velocidad base de clasificación.\n " +
                    "<100 % = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidad de almacenamiento de clasificación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla la **capacidad de almacenamiento de correo**.\n " +
                    "<100 % = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corregir poco correo sin clasificar" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Cuando está activado, aparece correo sin clasificar de forma mágica si las reservas son muy bajas.\n " +
                    "Así los centros de clasificación siguen activos sin esperar a las entregas.\n" +
                    "Arreglo temporal para un error actual en el que los centros de clasificación reciben poco correo\n " +
                    "si hay un puerto de carga." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Umbral de correo sin clasificar" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Si el correo sin clasificar baja por debajo de este porcentaje de la capacidad,\n " +
                    "se obtiene mágicamente un poco de correo sin clasificar extra.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Cantidad de correo sin clasificar" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Correo adicional que se añade al rellenar correo sin clasificar (recarga mágica).\n" +
                    "La cantidad es un porcentaje de la capacidad máxima de almacenamiento." },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valores por defecto del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restaura todos los ajustes al comportamiento original por defecto del juego (vanilla)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Inicio rápido**: aplica todos los ajustes postales recomendados.\n" +
                    "Modo fácil: ¡un clic y listo!" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Resumen de oficinas de correos, furgonetas, centros de clasificación y camiones procesados\n " +
                    "en la última actualización del juego (~cada 45 minutos en el juego)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correo de la ciudad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Muestra el flujo reciente de correo en la ciudad.\n\n" +
                     "**Acumulado** = cuánto correo han generado los ciudadanos.\n" +
                     "**Procesado**   = cuánto correo ha manejado realmente la red.\n\n" +
                     "- Si «Procesado» suele ser mayor que «Acumulado», la red postal tiene capacidad suficiente.\n " +
                     "- Si «Acumulado» se mantiene por encima de «Procesado» durante mucho tiempo,\n " +
                     "la ciudad genera más correo del que se puede manejar; añade más edificios,\n " +
                     "más vehículos o ajusta la configuración." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Actividad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Número de recargas de correo y limpiezas de desbordamiento realizadas en la última actualización." },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Versión actual del mod." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Abre la página de **Paradox** para **Magic Mail** y otros mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre el chat de comentarios en **Discord** en el navegador." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
