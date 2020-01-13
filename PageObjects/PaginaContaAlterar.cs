using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaContaAlterar : TableFactory
    {
        public PaginaContaAlterar(IWebDriver driver) : base(driver) { }

        public void RealizarAlteracaoConta(string conta)
        {
            LimparTexto(Driver(), By.Id("nome"));
            InserirTexto(Driver(), By.Id("nome"), conta);            
        }

        public void VerificarAlteracaoComSucesso(string conta)
        {
            Clicar(Driver(), By.XPath("//button[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaAlteradaComSucesso + "')]"),
                "Não foi apresentada mensagem de conta alterada com sucesso!"
            );
            ValidarAlteracaoConta(conta);
        }

        public void ValidarCamposObrigatorios()
        {
            LimparTexto(Driver(), By.Id("nome"));
            Clicar(Driver(), By.XPath("//button[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaObrigatorio + "')]"),
                "Não foi apresentada mensagem de nome da conta obrigatório"
            );
        }

        public void ValidarRegistroDuplicado()
        {
            Clicar(Driver(), By.XPath("//button[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaJaIncluida + "')]"),
                "Não foi apresentada mensagem de registro duplicado"
            );
        }

        public void ValidarAlteracaoConta(string conta)
        {
            for (int index = 0; index < RetornarTrs().Count; index++)
            {
                string nomeConta = RetornarTd(RetornarTr(index), 0).Text;
                if (nomeConta.Equals(conta)) return;
                VerificarUltimoRegistro(index, "Conta não foi alterada corretamente");
            }
        }

    }
}
