// Localization/LocaleFR.cs
// French locale fr-FR

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// French localization source for Magic Mail [MM].</summary>
    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the French locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all French localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail [MM]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Statut" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "À propos" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Bureau de poste" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Fourgons & camions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centre de tri" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Réinitialiser" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Vue d'ensemble de la ville" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Dernière activité" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Liens" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corriger le manque de courrier local" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Quand c'est activé et que le stock devient trop bas, du courrier supplémentaire apparaît.\n " +
                    "Aucun fourgon supplémentaire n’est généré – c’est comme de la magie, mais réelle." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Seuil de courrier local" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Si le courrier local passe en dessous de ce pourcentage choisi,\n " +
                    "le bureau de poste fait venir plus de courrier local.\n" +
                    "C’est un pourcentage de la capacité maximale de stockage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantité de courrier local ajouté" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Pourcentage ajouté lors du remplissage du courrier local (recharge magique).\n" +
                    "Si le maximum vanilla = 10 000 et que tu mets 20 %, alors 2 000 sont ajoutés." },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corriger le débordement de courrier" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Quand il y a trop de courrier, les bâtiments effectuent un petit nettoyage **magique**.\n " +
                    "Le surplus est considéré comme distribué et supprimé.\n " +
                    "Cela évite que les bâtiments restent bloqués en mode « plein » pour toujours.\n " +
                    "Désactive cette option pour garder le comportement vanilla pur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Seuil de débordement (bureau de poste)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quand le total du courrier dans un bureau de poste atteint ce pourcentage,\n" +
                    "le mod supprime assez de courrier pour revenir à ce niveau." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Seuil de débordement (centre de tri)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                   "Quand le total du courrier dans un centre de tri atteint ce pourcentage,\n" +
                   "le mod supprime assez de courrier pour revenir à ce niveau." },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Modifier les capacités" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Active ceci pour modifier les capacités des fourgons et camions. Si c’est désactivé,\n" +
                    "tous les curseurs ci-dessous sont masqués et\n" +
                    "les valeurs vanilla du jeu sont appliquées même si les curseurs affichent autre chose." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Charge des fourgons" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Contrôle la quantité de courrier que chaque fourgon peut transporter.\n" +
                    "<100 % = charge vanilla.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Taille de flotte de fourgons" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Contrôle combien de fourgons chaque bâtiment postal peut posséder et envoyer.\n" +
                    "<100 % = flotte vanilla.>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Taille de flotte de camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Contrôle combien de camions chaque centre de tri (et tout bâtiment avec des camions postaux)\n " +
                    "peut posséder et envoyer.\n " +
                    "<100 % = flotte vanilla.>" },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Vitesse de tri" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicateur pour les centres de **tri**. S’applique à la vitesse de tri de base du bâtiment.\n " +
                    "<100 % = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacité de stockage de tri" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Contrôle la **capacité de stockage du courrier**.\n " +
                    "<100 % = vanilla>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corriger le manque de courrier non trié" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Quand c’est activé, du courrier non trié apparaît magiquement si le stock est trop bas.\n " +
                    "Cela garde les centres de tri actifs sans attendre les livraisons.\n" +
                    "Correctif temporaire pour un bug où les centres de tri reçoivent trop peu de courrier\n " +
                    "lorsqu’un port de fret est présent." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Seuil de courrier non trié" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Si le courrier non trié descend sous ce pourcentage de la capacité,\n " +
                    "une quantité supplémentaire de courrier non trié est ajoutée magiquement.\n" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantité de courrier non trié" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Courrier additionnel ajouté lors du remplissage de courrier non trié (recharge magique).\n" +
                    "Valeur exprimée en pourcentage de la capacité maximale de stockage." },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valeurs par défaut du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restaure toutes les options au comportement par défaut original du jeu (vanilla)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Démarrage rapide** – applique tous les réglages postaux recommandés.\n" +
                    "Mode facile : un clic et c’est fait !" },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Résumé des bureaux de poste, fourgons, centres de tri et camions postaux traités\n " +
                    "lors de la dernière mise à jour du jeu (~toutes les 45 minutes en jeu)." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Courrier de la ville" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Montre le flux récent de courrier dans la ville.\n\n" +
                     "**Accumulé** = quantité de courrier générée par les citoyens.\n" +
                     "**Traité**   = quantité de courrier effectivement prise en charge par le réseau.\n\n" +
                     "- Si « Traité » est souvent supérieur à « Accumulé », le réseau postal a assez de capacité.\n " +
                     "- Si « Accumulé » reste au-dessus de « Traité » pendant longtemps, la ville génère plus de courrier\n " +
                     "que ce que le réseau peut gérer : ajoute des bâtiments, des véhicules ou ajuste les réglages." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activité" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Nombre de compléments de courrier et de nettoyages de débordement effectués lors de la dernière mise à jour." },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Version actuelle du mod." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Ouvre la page **Paradox** pour **Magic Mail** et les autres mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvre le salon **Discord** de retour d’expérience dans un navigateur." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
