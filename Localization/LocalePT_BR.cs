// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// LocalePT_BR.cs
// Brazilian Portuguese locale pt-BR

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Brazilian Portuguese localization source for Magic Mail [MM].</summary>
    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        /// <summary>
        /// Constructs the Brazilian Portuguese locale generator.</summary>
        /// <param name="setting">Settings object used for locale IDs.</param>
        public LocalePT_BR(Setting setting)
        {
            m_Setting = setting;
        }

        /// <summary>
        /// Generates all Brazilian Portuguese localization entries for this mod.</summary>
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), "Magic Mail + Postal Dispatch" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab), "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab), "Sobre" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup), "Assistência vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup), "Vans e caminhões postais" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de triagem dedicado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup), "Redefinir" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup), "Varredura da cidade" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última atualização" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office / Vanilla Assist ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Resgatar correio local baixo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Deixa o jogo tentar primeiro as transferências normais de correio.\n" +
                    "Se o correio local continuar muito baixo por várias verificações, Magic Mail adiciona uma pequena reposição de emergência.\n" +
                    "Também vale para agências com melhoria de triagem."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Limite de resgate do correio local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "O correio local é considerado baixo ao chegar a esta porcentagem do armazenamento máximo do prédio.\n" +
                    "O resgate só ocorre se continuar baixo por várias verificações."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantidade de resgate do correio local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Quanto correio local adicionar quando o resgate ocorrer.\n" +
                    "É uma porcentagem do armazenamento máximo do prédio."
                },

                // Global overflow toggle (PO + sorting)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Resgatar excesso de correio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Se uma instalação postal ficar cheia demais, Magic Mail reduz o correio armazenado até o nível escolhido.\n" +
                    "Conta correio local + não triado + de saída, ajudando a detectar excesso que o jogo pode calcular errado.\n" +
                    "Desative para comportamento vanilla puro."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Limite de excesso da agência" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quando o total armazenado passa deste nível, Magic Mail reduz novamente.\n" +
                    "Vale para agências comuns e agências com melhoria de triagem."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Limite de excesso da triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quando o total armazenado em um centro de triagem dedicado passa deste nível,\n" +
                    "Magic Mail reduz novamente."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Alterar capacidades" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Ative para modificar capacidades de vans e caminhões. Quando desligado,\n" +
                    "os controles abaixo ficam ocultos e\n" +
                    "os valores vanilla são usados mesmo que outros valores tenham ficado salvos."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga da van postal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla quanto correio cada van postal pode carregar.\n" +
                    "<100% = carga vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Tamanho da frota de vans" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla quantas vans cada prédio postal pode possuir e despachar.\n" +
                    "<100% = frota vanilla.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Tamanho da frota de caminhões" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla quantos caminhões postais cada instalação com caminhões pode possuir e despachar.\n" +
                    "<100% = frota vanilla.>"
                },

                // ---- Dedicated Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidade de triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador para centros de triagem dedicados.\n" +
                    "Não altera a melhoria de triagem de uma agência.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidade de armazenamento da triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla o armazenamento de correio dos centros de triagem dedicados.\n" +
                    "Não altera a melhoria de triagem de uma agência.\n" +
                    "<100% = vanilla>."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Resgatar correio não triado baixo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Deixa o jogo fornecer correio não triado normalmente primeiro.\n" +
                    "Se um centro dedicado continuar muito baixo por várias verificações,\n" +
                    "Magic Mail adiciona uma pequena reposição de emergência."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Limite de resgate do correio não triado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "O correio não triado é considerado baixo ao chegar a esta porcentagem do armazenamento máximo.\n" +
                    "O resgate só ocorre se continuar baixo por várias verificações."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantidade de resgate do correio não triado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quanto correio não triado adicionar quando o resgate ocorrer.\n" +
                    "É uma porcentagem do armazenamento máximo."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Restaura todas as opções para o comportamento original do jogo (vanilla)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Assistência vanilla** - Início rápido.\n" +
                    "Deixa a logística normal trabalhar primeiro e só resgata faltas persistentes ou excesso.\n" +
                    "Também aplica os ajustes de capacidade recomendados."
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Prédios postais encontrados ao abrir a página Status.\n" +
                    "\n" +
                    "**Agências postais** = agências comuns.\n" +
                    "**Centros de triagem** = centros postais dedicados.\n" +
                    "**Agências com triagem** = <Westmont Tower com melhoria de triagem>.\n" +
                    "- Requer o **DLC Skyscrapers**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusVehicleSummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusVehicleSummary)),
                    "Capacidade dos veículos postais ao abrir a página Status.\n" +
                    "\n" +
                    "**Vans postais** = coleta e entrega local.\n" +
                    "**Caminhões postais** = levam correio entre instalações."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correio mensal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Mostra o fluxo recente de correio da cidade toda.\n" +
                    "\n" +
                    "**Acumulado** = correio gerado pelos cidadãos.\n" +
                    "**Processado** = correio realmente tratado pela rede.\n" +
                    "\n" +
                    "- Se Processado costuma ser maior que Acumulado, a rede tem capacidade suficiente.\n" +
                    "- Se Acumulado fica acima de Processado por muito tempo,\n" +
                    "a cidade gera mais correio do que a rede consegue tratar.\n" +
                    "Adicione instalações, vans ou ajuste as opções."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Atividade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)), "Resgates e limpezas de excesso da última passagem de resgate do Magic Mail." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WriteReport)), "Gravar relatório" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WriteReport)),
                    "Executa **uma única vez** uma varredura postal detalhada com as Opções abertas\n" +
                    "e grava o relatório em <Logs/MagicMail.log>. Sem registro em segundo plano."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre <Logs/MagicMail.log> ou a pasta Logs se o arquivo ainda não existir." },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES", "Nenhuma instalação postal encontrada. Abra uma cidade e depois abra Status novamente." },
                { "MM_STATUS_NO_ACTIVITY", "Nenhuma atividade de resgate registrada." },
                { "MM_STATUS_SUMMARY", "Agências postais: {0} | Agências com triagem: {1} | Centros de triagem: {2}" },
                { "MM_STATUS_VEHICLES", "Vans postais: {0} | Caminhões postais: {1}" },
                { "MM_STATUS_ACTIVITY", "{0} resgates locais | {1} resgates não triados | {2} limpezas de excesso" },
                { "MM_STATUS_CITY_MAIL_NOT_READY", "As estatísticas postais da cidade ainda não estão disponíveis. Abra uma cidade e deixe a simulação rodar." },
                { "MM_STATUS_CITY_MAIL", "{0} acumulado | {1} processado" },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Versão atual do mod e tipo de compilação." },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Mods do Mochi no Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página **Paradox** de **Magic Mail** e outros mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre o chat de feedback do **Discord** no navegador." },
            };
        }

        /// <summary>
        /// Called when the localization source is unloaded.</summary>
        public void Unload()
        {
        }
    }
}
