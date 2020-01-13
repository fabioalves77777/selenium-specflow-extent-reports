using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaContaIncluir : TableFactory
    {
        public PaginaContaIncluir(IWebDriver driver) : base(driver) { }

        public PaginaContaListar AcessarListaContas()
        {
            Clicar(Driver(), By.XPath("//a[contains(text(),'Contas')]"));
            Clicar(Driver(), By.XPath("//a[contains(text(),'Listar')]"));
            ElementoExiste(Driver(), By.XPath("//th[contains(text(),'Conta')]"), "Erro ao acessar a página de listar contas");
            return new PaginaContaListar(Driver());
        }

        public void RealizarInclusaoConta(string conta)
        {
            InserirTexto(Driver(), By.Id("nome"), conta);            
        }

        public void VerificarContaAdicionadaComSucesso(string conta)
        {
            Clicar(Driver(), By.XPath("//button[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.ContaAdicionadaComSucesso + "')]"),
                "Não foi apresentada mensagem de conta adicionada com sucesso!"
            );
            ValidarInclusaoConta(conta);
        }

        public void ValidarCamposObrigatorios(string nome)
        {
            Clicar(Driver(), By.XPath("//button[@class='btn btn-primary']"));
            if (string.IsNullOrEmpty(nome))
            {
                ElementoExiste(
                    Driver(),
                    By.XPath("//div[contains(text(),'" + Mensagens.ContaObrigatorio + "')]"),
                    "Não foi apresentada mensagem de nome da conta obrigatório"
                );
            }            
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

        public void ValidarInclusaoConta(string conta)
        {
            int index = 0;
            foreach (IWebElement tr in RetornarTrs())
            {
                string nomeConta = RetornarTd(tr, 0).Text;
                if (nomeConta.Equals(conta)) return;
                VerificarUltimoRegistro(index++, "Conta não foi adicionada corretamente");
            }
        }

    }
}
