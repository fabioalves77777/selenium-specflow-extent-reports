using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;
using Selenium.Specflow.Extent.Reports.Utility;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaLogin : DriverFactory
    {
        public PaginaLogin(IWebDriver driver) : base(driver) { }

        public PaginaLogin AcessarPaginaLogin(EnumAmbiente ambiente)
        {
            if (ambiente.Equals(EnumAmbiente.TST))
                Navegar(ConfiguracaoAmbiente.UrlTst);
            else if (ambiente.Equals(EnumAmbiente.HML))
                Navegar(ConfiguracaoAmbiente.UrlHml);
            ElementoExiste(Driver(), By.Id("email"), "Erro ao acessar a página de autenticação");
            return this;
        }

        public PaginaCadastro AcessarCadastroUsuario()
        {
            Clicar(Driver(), By.XPath("//a[contains(text(),'Novo usuário?')]"));
            return new PaginaCadastro(Driver());
        }

        public PaginaLogin RealizarLogin(string usuario, string senha)
        {
            InserirTexto(Driver(), By.Id("email"), usuario);
            InserirTexto(Driver(), By.Id("senha"), senha);
            return this;
        }

        public PaginaInicial VerificarUsuarioAutenticadoComSucesso()
        {
            Clicar(Driver(), By.XPath("//button[contains(text(),'Entrar')]"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.LoginRealizadoComSucesso + "')]"),
                "Ocorreu um erro ao realizar o login no sistema"
            );
            return new PaginaInicial(Driver());
        }

        public void ValidarLoginInvalido()
        {
            Clicar(Driver(), By.XPath("//button[contains(text(),'Entrar')]"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.LoginInvalido + "')]"),
                "Não foi apresentada mensagem de login inválido"
            );
        }

        public void ValidarCamposObrigatorios(string email, string senha)
        {
            Clicar(Driver(), By.XPath("//button[contains(text(),'Entrar')]"));
            if (string.IsNullOrEmpty(email))
            {
                ElementoExiste(
                    Driver(),
                    By.XPath("//div[contains(text(),'Email é um " + Mensagens.CampoObrigorio + "')]"),
                    "Não foi apresentada mensagem de email obrigatório"
                );
            }
            if (string.IsNullOrEmpty(senha))
            {
                ElementoExiste(
                    Driver(),
                    By.XPath("//div[contains(text(),'Senha é um " + Mensagens.CampoObrigorio + "')]"),
                    "Não foi apresentada mensagem de senha obrigatória"
                );
            }
        }

    }
}
