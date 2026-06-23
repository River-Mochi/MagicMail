// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Status" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Sobre" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Agência dos correios" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Vans e caminhões" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de triagem" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Redefinir" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Varredura da cidade" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última atualização" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Links" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corrigir pouca correspondência local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Quando ativado, uma pequena quantidade de correspondência local\n" +
                    "é adicionada automaticamente quando o nível fica muito baixo.\n" +
                    "Nenhuma van extra é criada – é tipo mágica… mas de verdade :)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Limite de correspondência local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Se a correspondência local cair abaixo deste percentual,\n" +
                    "a agência puxa mais cartas.\n" +
                    "É um percentual da capacidade máxima do prédio.\n" +
                    "Ex.: <máx = 100.000>, <limite = 5%>,\n" +
                    "quando a correspondência local <5.000> ela é recarregada."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantidade de recarga local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentual adicionado ao fazer o reforço mágico da correspondência local.\n" +
                    "Se o máximo vanilla é <100.000> e o valor for <10%>,\n" +
                    "são adicionadas <10.000> cartas."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corrigir excesso de correspondência" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Quando há correspondência demais armazenada, as instalações fazem\n" +
                    "uma pequena limpeza mágica.\n" +
                    "O excedente é tratado como entregue e removido.\n" +
                    "Isso evita que os prédios fiquem travados com 100% de lotação.\n" +
                    "Desative para manter o comportamento vanilla puro."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Limite de excesso da agência" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quando o total de correspondência em uma agência chega a este percentual,\n" +
                    "o mod remove o excedente até voltar a esse nível."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Limite de excesso do centro de triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quando o total de correspondência em um centro de triagem chega a este percentual,\n" +
                    "o excedente é apagado."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Alterar capacidades" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Ativa a alteração das capacidades das vans e caminhões.\n" +
                    "Quando desativado, todos os controles deslizantes abaixo são ocultados\n" +
                    "e os valores vanilla do jogo são usados, mesmo que você tenha mudado os sliders."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga de cartas por van" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla quantas cartas cada van pode transportar.\n" +
                    "<100% = carga vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Tamanho da frota de vans" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla quantas vans cada prédio postal pode possuir e despachar.\n" +
                    "<100% = frota vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Tamanho da frota de caminhões" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla quantos caminhões postais cada centro de triagem (ou prédio com caminhões)\n" +
                    "pode possuir e despachar.\n" +
                    "<100% = frota vanilla>."
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidade de triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador aplicado à taxa básica de triagem dos centros.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidade de armazenamento" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla a **capacidade de armazenamento** de correspondência.\n" +
                    "<100% = vanilla>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corrigir pouca correspondência não triada" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Quando ativado, um pouco de correspondência não triada é adicionada\n" +
                    "quando o estoque fica muito baixo, mantendo os centros de triagem ativos.\n" +
                    "É uma correção temporária para o bug em que centros de triagem recebem\n" +
                    "correspondência demais de portos de carga."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Limite de não triada" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Se a correspondência não triada cair abaixo deste baixo percentual\n" +
                    "da capacidade total, um pouco mais será puxado automaticamente.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantidade de recarga não triada" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quantidade extra de correspondência não triada a adicionar (percentual da capacidade máxima).\n" +
                    "Ex.: capacidade máx <250.000>, valor <10%> → <25.000> cartas adicionadas."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Padrões do jogo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Restaura todas as opções para o comportamento padrão original do jogo (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Início rápido** – aplica todas as configurações postais recomendadas.\n" +
                    "Modo fácil: um clique e pronto!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Resumo das agências, vans, centros de triagem e caminhões\n" +
                    "processados na última varredura em segundo plano."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correio mensal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Mostra o fluxo recente de correspondência na cidade inteira.\n\n" +
                    "**Acumulado** = quanto correio os cidadãos geraram.\n" +
                    "**Processado** = quanto a rede realmente tratou.\n\n" +
                    "- Se \"Processado\" costuma ser maior que \"Acumulado\", sua rede está dando conta.\n" +
                    "- Se \"Acumulado\" fica acima de \"Processado\" por longos períodos,\n" +
                    "  a cidade está gerando mais correio do que a rede consegue processar.\n" +
                    "  Adicione mais instalações ou ajuste as configurações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Atividade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Contagens de recargas de correio e limpezas de excesso realizadas\n" +
                    "na última atualização."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Nenhuma instalação postal foi processada ainda. Abra uma cidade e deixe a simulação rodar." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Nenhuma atividade registrada ainda." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} agências | {1} vans postais | {2} centros de triagem | {3} caminhões postais"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} recargas de correio local | {1} recargas de correio não triado | {2} limpezas de excesso"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "Estatísticas de correio da cidade ainda não disponíveis. Abra uma cidade e deixe a simulação rodar." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} acumulado | {1} processado"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nome exibido deste mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Versão" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)),
                    "Versão atual do mod."
                },

                // ---- About tab: links ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadox)),
                    "Abre a página da **Paradox** para **Magic Mail** e outros mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre no navegador o canal de feedback no **Discord**."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
