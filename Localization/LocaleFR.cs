// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleFR.cs
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

        public LocaleFR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Statut" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "À propos" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Bureau de poste" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Fourgons & camions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centre de tri" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Réinitialiser" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Vue d’ensemble de la ville" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Dernière mise à jour" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Liens" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corriger le faible courrier local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Si cette option est activée, une petite quantité de courrier local est ajoutée\n" +
                    "lorsque le stock devient trop bas.\n" +
                    "Aucun véhicule supplémentaire n’est créé – c’est magique… mais réel :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Seuil de courrier local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Si le courrier local descend en dessous de ce pourcentage,\n" +
                    "le bureau de poste récupère automatiquement plus de courrier.\n" +
                    "C’est un pourcentage de la capacité maximale du bâtiment.\n" +
                    "Ex. : <max = 100 000>, <seuil = 5%>,\n" +
                    "si le courrier local < <5 000>, du courrier est ajouté."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Montant de l’appoint local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Pourcentage ajouté lors du remplissage magique du courrier local.\n" +
                    "Si la capacité max vanilla = <100 000> et que cette valeur est <10%>,\n" +
                    "alors <10 000> sont ajoutés."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corriger le débordement de courrier" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Lorsque trop de courrier est stocké, les installations effectuent un petit nettoyage magique.\n" +
                    "L’excès de courrier est traité comme \"distribué\" et supprimé.\n" +
                    "Cela évite que les bâtiments restent bloqués à 100 %.\n" +
                    "Désactivez pour conserver le comportement vanilla pur."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Seuil de débordement du bureau de poste" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Lorsque le courrier total d’un bureau de poste atteint ce pourcentage,\n" +
                    "la mod supprime assez de courrier pour revenir à ce niveau."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Seuil de débordement du centre de tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Lorsque le courrier total d’un centre de tri atteint ce pourcentage,\n" +
                    "la mod supprime l’excès pour le ramener à ce niveau."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Modifier les capacités" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Active l’ajustement des capacités des fourgons et camions.\n" +
                    "Lorsque désactivé, toutes les valeurs restent vanilla\n" +
                    "même si les curseurs sont positionnés ailleurs."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Charge de courrier par fourgon" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Contrôle la quantité de courrier transportée par chaque fourgon postal.\n" +
                    "<100% = charge vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Taille de flotte des fourgons" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Contrôle combien de fourgons un bâtiment postal peut posséder et envoyer.\n" +
                    "<100% = flotte vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Taille de flotte des camions" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Contrôle combien de camions postaux chaque centre de tri (ou autre bâtiment concerné)\n" +
                    "peut posséder et envoyer.\n" +
                    "<100% = flotte vanilla>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Vitesse de tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicateur pour les centres de tri. S’applique au taux de tri de base.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacité de stockage de tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Contrôle la capacité de stockage du courrier.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corriger le faible courrier non trié" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Si activé, du courrier non trié est ajouté lorsque les réserves\n" +
                    "deviennent trop faibles, afin que le centre de tri continue de fonctionner.\n" +
                    "Solution temporaire à un bug actuel où les centres de tri ne reçoivent\n" +
                    "pas assez de courrier si un port de fret est présent."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Seuil de courrier non trié" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Si le courrier non trié passe en dessous de ce faible pourcentage de la capacité totale,\n" +
                    "un complément de courrier est automatiquement ajouté."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Montant de l’appoint non trié" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Montant ajouté lors du remplissage de courrier non trié (en % de la capacité max).\n" +
                    "Exemple : capacité max <250 000>, valeur <10%> → <25 000> ajoutés."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valeurs du jeu" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restaure tous les paramètres au comportement par défaut du jeu (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommandé" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Démarrage rapide** – applique tous les réglages postaux recommandés.\n" +
                    "Mode facile : un clic et c’est prêt."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Résumé des bureaux de poste, fourgons, centres de tri et camions traités\n" +
                    "lors du dernier scan en arrière-plan."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Courrier mensuel" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Affiche le flux de courrier récent dans toute la ville.\n\n" +
                    "**Accumulation** = quantité de courrier générée par les citoyens.\n" +
                    "**Traité**       = quantité que le réseau postal a réellement gérée.\n\n" +
                    "- Si \"Traité\" est souvent supérieur à \"Accumulation\", votre réseau est suffisant.\n" +
                    "- Si \"Accumulation\" reste longtemps au-dessus de \"Traité\",\n" +
                    "la ville génère plus de courrier que le réseau ne peut en gérer.\n" +
                    "Ajoutez des bâtiments ou ajustez vos paramètres."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activité" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Nombre de compléments et de nettoyages de débordement effectués lors de la dernière mise à jour."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Aucune installation postale encore traitée. Ouvrez une ville et laissez la simulation tourner." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Aucune activité enregistrée pour le moment." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} bureaux de poste | {1} fourgons postaux | {2} centres de tri | {3} camions postaux"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} compléments de courrier local | {1} compléments de courrier non trié | {2} nettoyages de débordement"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Statistiques de courrier de la ville non encore disponibles. Ouvrez une ville et laissez la simulation tourner." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} accumulé | {1} traité"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nom d’affichage de cette mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Version actuelle de la mod."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Ouvrir la page **Paradox** de **Magic Mail** et des autres mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvrir le salon **Discord** pour les retours dans un navigateur."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
