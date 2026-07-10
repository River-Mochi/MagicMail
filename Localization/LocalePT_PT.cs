// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocalePT_PT.cs
// European Portuguese locale pt-PT

namespace MagicMail
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// European Portuguese localization source for Magic Mail [MM].</summary>
    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_PT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.kStatusTab),  "Estado" },
                { m_Setting.GetOptionTabLocaleID(Setting.kAboutTab),   "Sobre" },

                // Groups (Actions tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.PostOfficeGroup),          "Estação de correios" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostVanGroup),             "Carrinhas e camiões postais" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PostSortingFacilityGroup), "Centro de triagem" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup),               "Repor" },

                // Groups (Status tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusSummaryGroup),  "Análise da cidade" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusActivityGroup), "Última atualização" },

                // Groups (About tab)
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutInfoGroup),  "Informação" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAboutLinksGroup), "Ligações" },

                // ---- Post Office ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GetLocalMail)), "Corrigir falta de correio local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GetLocalMail)),
                    "Quando ativado, aparece uma pequena quantidade de correio se o nível ficar demasiado baixo.\n " +
                    "Não cria carrinhas extra; é como magia... mas a sério :)"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingThresholdPercentage)), "Limite de correio local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingThresholdPercentage)),
                    "Se o correio local ficar abaixo desta percentagem, a estação de correios\n " +
                    "recebe automaticamente mais correio local.\n" +
                    "É uma percentagem da capacidade máxima do edifício.\n" +
                    "Ex.: se <armazenamento máximo = 100 000> e <limite = 5%>,\n" +
                    "quando o correio local < <5 000>, é recebido mais correio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_GettingPercentage)), "Quantidade de correio local" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_GettingPercentage)),
                    "Percentagem adicionada ao receber correio local (reposição mágica).\n" +
                    "Se o máximo original = <100 000> e estiver definido para <10%>,\n" +
                    "são adicionados <10 000> quando necessário."
                },

                // Global overflow toggle (PO + PSF)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FixMailOverflow)), "Corrigir excesso de correio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FixMailOverflow)),
                    "Quando há demasiado correio, as instalações fazem uma pequena limpeza mágica.\n " +
                    "O correio armazenado em excesso é considerado entregue e removido.\n " +
                    "Isto evita que as instalações fiquem permanentemente cheias.\n " +
                    "Desative para manter o comportamento original do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PO_OverflowPercentage)), "Limite de excesso da estação de correios" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PO_OverflowPercentage)),
                    "Quando o correio total numa estação de correios atinge esta percentagem,\n" +
                    "o mod remove correio suficiente para o reduzir até este nível."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_OverflowPercentage)), "Limite de excesso do centro de triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_OverflowPercentage)),
                    "Quando o correio total num centro de triagem atinge esta percentagem,\n" +
                    "o mod remove correio suficiente para o reduzir até este nível."
                },

                // ---- Post Vans & Trucks ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChangeCapacity)), "Alterar capacidades" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ChangeCapacity)),
                    "Ative para alterar as capacidades das carrinhas e dos camiões. Quando desativado,\n" +
                    "todos os controlos de capacidade abaixo ficam ocultos e\n" +
                    "são usados os valores originais do jogo, mesmo que os controlos tenham outros valores."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanMailLoadPercentage)), "Carga da carrinha postal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanMailLoadPercentage)),
                    "Controla a quantidade de correio que cada carrinha postal pode transportar.\n" +
                    "<100% = carga original do jogo.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PostVanFleetSizePercentage)), "Frota de carrinhas postais" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PostVanFleetSizePercentage)),
                    "Controla quantas carrinhas cada edifício postal pode ter e enviar.\n" +
                    "<100% = frota original do jogo.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TruckCapacityPercentage)), "Frota de camiões postais" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TruckCapacityPercentage)),
                    "Controla quantos camiões postais cada centro de triagem\n " +
                    "(e qualquer instalação com camiões postais) pode ter e enviar.\n " +
                    "<100% = frota original do jogo.>"
                },

                // ---- Sorting Facility ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)), "Velocidade de triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_SortingSpeedPercentage)),
                    "Multiplicador para os centros de **triagem**. Aplica-se à velocidade base de triagem.\n " +
                    "<100% = valor original do jogo>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)), "Capacidade de armazenamento da triagem" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_StorageCapacityPercentage)),
                    "Controla o **armazenamento de correio**.\n " +
                    "<100% = valor original do jogo>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GetUnsortedMail)), "Corrigir falta de correio por triar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GetUnsortedMail)),
                    "Quando ativado, aparece algum correio por triar se as reservas ficarem demasiado baixas.\n " +
                    "Isto mantém os centros de triagem ativos.\n" +
                    "É uma correção temporária para um erro atual em que os centros de triagem\n" +
                    "não recebem correio suficiente quando existe um porto de carga."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)), "Limite de correio por triar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingThresholdPercentage)),
                    "Se o correio por triar ficar abaixo desta pequena percentagem\n" +
                    "da capacidade total, é recebido algum correio adicional.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PSF_GettingPercentage)), "Quantidade de correio por triar" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PSF_GettingPercentage)),
                    "Quantidade adicional de correio por triar a adicionar (reposição mágica).\n" +
                    "A quantidade é uma percentagem da capacidade máxima.\n" +
                    "Se o <máximo original = 250 000> e estiver definido para <10%>, são adicionados <25 000>."
                },

                // ---- RESET BUTTONS ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Predefinições do jogo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Repõe todas as definições para o comportamento original do jogo (vanilla)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToRecommend)), "Recomendado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToRecommend)),
                    "**Início rápido** – aplica todas as definições postais recomendadas.\n" +
                    "Modo fácil: um clique e está feito!"
                },

                // ---- Status tab ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilitySummary)), string.Empty },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilitySummary)),
                    "Resumo das estações de correios, carrinhas, centros de triagem e camiões\n" +
                    "processados na última análise em segundo plano."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCityMailSummary)), "Correio mensal" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCityMailSummary)),
                    "Mostra o fluxo recente de correio em toda a cidade.\n\n" +
                    "**Acumulado** = quantidade de correio criada pelos cidadãos.\n" +
                    "**Processado** = quantidade de correio realmente tratada pela rede.\n\n" +
                    "- Se Processado for frequentemente superior a Acumulado, a rede postal tem capacidade suficiente.\n " +
                    "- Se Acumulado permanecer acima de Processado durante muito tempo,\n" +
                    "a cidade está a gerar mais correio do que a rede consegue tratar.\n" +
                    "Adicione mais instalações, carrinhas ou ajuste as definições."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastActivity)), "Atividade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastActivity)),
                    "Número de reposições de correio e limpezas de excesso efetuadas na última atualização."
                },

                // ---- Status text templates (for MagicMailSystem) ----
                { "MM_STATUS_NO_FACILITIES",
                  "Ainda não foram processadas instalações postais. Abra uma cidade e deixe a simulação funcionar." },

                { "MM_STATUS_NO_ACTIVITY",
                  "Ainda não foi registada qualquer atividade." },

                {
                    "MM_STATUS_SUMMARY",
                    "{0} estações de correios | {1} carrinhas postais | {2} centros de triagem | {3} camiões postais"
                },

                {
                    "MM_STATUS_ACTIVITY",
                    "{0} reposições de correio local | {1} reposições de correio por triar | {2} limpezas de excesso"
                },

                { "MM_STATUS_CITY_MAIL_NOT_READY",
                  "As estatísticas do correio da cidade ainda não estão disponíveis. Abra uma cidade e deixe a simulação funcionar." },

                {
                    "MM_STATUS_CITY_MAIL",
                    "{0} acumulado | {1} processado"
                },

                // ---- About tab: info ----
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)),
                    "Nome apresentado deste mod."
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
                    "Abre a página da **Paradox** para o **Magic Mail** e outros mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre a conversa de comentários no **Discord** num navegador."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
