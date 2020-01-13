using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaContaListar : TableFactory
    {
        public PaginaContaListar(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Método para acessar a tela de alteração da conta com o nome "Conta para alterar"
        /// </summary>
        public PaginaContaAlterar AcessarAlteracaoConta()
        {
            int index = 0;
            foreach (IWebElement tr in RetornarTrs())
            {
                if (RetornarTd(tr, 0).Text.Contains("Conta para alterar"))
                {
                    Clicar(RetornarButtonLink(RetornarTd(tr, 1), 0));
                    break;
                }
                VerificarUltimoRegistro(index++, "Não foi encontrada a conta com o nome 'Conta para alterar'");
            }
            return new PaginaContaAlterar(Driver());
        }

        /// <summary>
        /// Método para solicitar exclusão de conta em uso com o nome "Conta com movimentacao"
        /// </summary>
        public void RealizarExclusaoContaComMovimentacao()
        {
            int index = 0;
            foreach (IWebElement tr in RetornarTrs())
            {
                if (RetornarTd(tr, 0).Text.Contains("Conta com movimentacao"))
                {
                    Clicar(RetornarButtonLink(RetornarTd(tr, 1), 1));
                    break;
                }
                VerificarUltimoRegistro(index++, "Não foi encontrada a conta com o nome 'Conta com movimentacao'");
            }
        }

        /// <summary>
        /// Método para validar exclusão de conta em uso da conta com o nome "Conta com movimentacao"
        /// </summary>
        public void ValidarExclusaoContaComMovimentacao()
        {
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaComMovimentacoes + "')]"),
                "Não foi apresentada mensagem de exclusão de conta não permitida!"
            );
        }

        /// <summary>
        /// Método para excluir conta
        /// </summary>
        public void RealizarExclusaoConta(string conta)
        {
            for (int i = 0; i < RetornarTrs().Count; i++)
            {
                if (RetornarTd(RetornarTr(i), 0).Text.Equals(conta))
                {
                    Clicar(RetornarButtonLink(RetornarTd(RetornarTr(i), 1), 1));
                    return;
                }
            }
            
        }

        /// <summary>
        /// Método para verificar exclusão de conta
        /// </summary>
        public void VerificarContaExcluidaComSucesso()
        {
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaRemovidaComSucesso + "')]"),
                "Não foi apresentada mensagem de exclusão realizada com sucesso!"
            );
        }

    }
}
