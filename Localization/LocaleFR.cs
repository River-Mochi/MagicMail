// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
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
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "État" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "À propos" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Aide vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Fourgons et camions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centre de tri dédié" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Réinitialiser" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Scan de la ville" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Dernière mise à jour" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Liens" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Secourir le courrier local faible" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Laisse d'abord le jeu essayer les transferts de courrier normaux.\n" +
                    "Si le courrier local reste très bas pendant plusieurs scans, Magic Mail ajoute un petit appoint de secours.\n" +
                    "S'applique aussi aux bureaux de poste avec amélioration de tri."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Seuil de secours du courrier local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Le courrier local est considéré faible à ce pourcentage du stockage maximal du bâtiment.\n" +
                    "Le secours ne se déclenche que s'il reste bas pendant plusieurs scans."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantité de secours du courrier local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Quantité de courrier local ajoutée quand le secours se déclenche.\n" +
                    "C'est un pourcentage du stockage maximal du bâtiment."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corriger le trop-plein de courrier" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Si un bâtiment postal devient trop plein, Magic Mail réduit le courrier stocké au niveau choisi.\n" +
                    "Il compte le courrier local + non trié + sortant pour repérer les trop-pleins que le jeu peut mal calculer.\n" +
                    "Désactivez ceci pour un comportement vanilla pur."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Seuil de trop-plein du bureau de poste" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quand le courrier total stocké dépasse ce niveau, Magic Mail le réduit.\n" +
                    "S'applique aux bureaux de poste normaux et à ceux avec amélioration de tri."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Seuil de trop-plein du centre de tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quand le courrier total d'un centre de tri dédié dépasse ce niveau,\n" +
                    "Magic Mail le réduit."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Modifier les capacités" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Activez ceci pour modifier les capacités des fourgons et camions. Quand c'est désactivé,\n" +
                    "les réglages ci-dessous sont masqués et\n" +
                    "les valeurs vanilla sont utilisées, même si d'autres valeurs sont restées enregistrées."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Charge du fourgon postal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Contrôle la quantité de courrier transportée par chaque fourgon postal.\n" +
                    "<100% = charge vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Taille de la flotte de fourgons" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Contrôle le nombre de fourgons que chaque bâtiment postal peut posséder et envoyer.\n" +
                    "<100% = flotte vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Taille de la flotte de camions" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Contrôle le nombre de camions postaux que chaque bâtiment équipé peut posséder et envoyer.\n" +
                    "<100% = flotte vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Vitesse de tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicateur pour les centres de tri dédiés.\n" +
                    "Ne change pas l'amélioration de tri d'un bureau de poste.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacité de stockage du tri" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Contrôle le stockage du courrier des centres de tri dédiés.\n" +
                    "Ne change pas l'amélioration de tri d'un bureau de poste.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Secourir le courrier non trié faible" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Laisse d'abord le jeu fournir normalement le courrier non trié.\n" +
                    "Si un centre de tri dédié reste très bas pendant plusieurs scans,\n" +
                    "Magic Mail ajoute un petit appoint de secours."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Seuil de secours du courrier non trié" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Le courrier non trié est considéré faible à ce pourcentage du stockage maximal.\n" +
                    "Le secours ne se déclenche que s'il reste bas pendant plusieurs scans."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantité de secours du courrier non trié" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quantité de courrier non trié ajoutée quand le secours se déclenche.\n" +
                    "C'est un pourcentage du stockage maximal."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Restaure tous les réglages au comportement d'origine du jeu (vanilla)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recommandé" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Aide vanilla** - Démarrage rapide.\n" +
                    "Laisse d'abord fonctionner la logistique normale, puis corrige les manques persistants ou les trop-pleins.\n" +
                    "Applique aussi les réglages de capacité recommandés."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Bâtiments postaux trouvés à l'ouverture de la page État.\n" +
                    "\n" +
                    "**Bureaux de poste** = bureaux de poste normaux.\n" +
                    "**Centres de tri** = centres postaux de tri dédiés.\n" +
                    "**Bureaux avec tri** = <Westmont Tower avec amélioration de tri>.\n" +
                    "- Nécessite le **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Capacité des véhicules postaux à l'ouverture de la page État.\n" +
                    "\n" +
                    "**Fourgons postaux** = collecte et livraison locales.\n" +
                    "**Camions postaux** = déplacent le courrier entre les bâtiments."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Courrier mensuel" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Affiche le flux récent du courrier dans toute la ville.\n" +
                    "\n" +
                    "**Accumulated** = quantité de courrier générée par les citoyens.\n" +
                    "**Processed** = quantité réellement traitée par le réseau postal.\n" +
                    "\n" +
                    "- Si Processed est souvent supérieur à Accumulated, le réseau a assez de capacité.\n" +
                    "- Si Accumulated reste supérieur à Processed longtemps,\n" +
                    "la ville génère plus de courrier que le réseau ne peut traiter.\n" +
                    "Ajoutez des bâtiments, des fourgons ou ajustez les réglages."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Activité" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Secours et nettoyages de trop-plein du dernier passage de secours de Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Écrire le rapport" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Lance **une seule fois** un scan postal détaillé pendant que les Options sont ouvertes,\n" +
                    "puis écrit le rapport dans <Logs/MagicMail.log>. Aucun journal en arrière-plan."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre <Logs/MagicMail.log>, ou le dossier Logs si le fichier n'existe pas encore." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Aucun bâtiment postal trouvé. Ouvrez une ville puis rouvrez État." },
                { "MM_STATUS_NO_ACTIVITY", "Aucune activité de secours enregistrée." },
                { "MM_STATUS_SUMMARY", "Bureaux de poste : {0} | Bureaux avec tri : {1} | Centres de tri : {2}" },
                { "MM_STATUS_VEHICLES", "Fourgons postaux : {0} | Camions postaux : {1}" },
                { "MM_STATUS_ACTIVITY", "{0} secours locaux | {1} secours non triés | {2} nettoyages de trop-plein" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "Les statistiques postales de la ville ne sont pas encore disponibles. Ouvrez une ville et laissez tourner la simulation." },
                { "MM_STATUS_CITY_MAIL", "{0} accumulé | {1} traité" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Nom affiché de ce mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Version actuelle du mod et type de build." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mods Paradox de Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page **Paradox** de **Magic Mail** et des autres mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Ouvre le chat de retours **Discord** dans le navigateur." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
