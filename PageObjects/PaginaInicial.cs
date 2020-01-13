using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaInicial : DriverFactory
    {
        public PaginaInicial(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Método para voltar as movimentações padrão
        /// </summary>
        public PaginaInicial ResetarMovimentacoes()
        {
            Clicar(Driver(), By.XPath("//a[contains(text(),'reset')]"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ResetarComSucesso + "')]"),
                "Erro ao resetar as movimentações!"
            );
            return this;
        }

        /// <summary>
        /// Método para acessar a tela de adicionar conta
        /// </summary>
        public PaginaContaIncluir AcessarAdicionarConta()
        {
            Clicar(Driver(), By.XPath("//a[contains(text(),'Contas')]"));
            Clicar(Driver(), By.XPath("//a[contains(text(),'Adicionar')]"));
            ElementoExiste(Driver(), By.Id("nome"), "Erro ao acessar a página de adicionar conta");
            return new PaginaContaIncluir(Driver());
        }

        /// <summary>
        /// Método para acessar a tela de listar contas
        /// </summary>
        public PaginaContaListar AcessarListaContas()
        {
            Clicar(Driver(), By.XPath("//a[contains(text(),'Contas')]"));
            Clicar(Driver(), By.XPath("//a[contains(text(),'Listar')]"));
            ElementoExiste(Driver(), By.XPath("//th[contains(text(),'Conta')]"), "Erro ao acessar a página de listar contas");
            return new PaginaContaListar(Driver());
        }

    }
}
