using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Factories;
using Selenium.Specflow.Extent.Reports.Resources;

namespace Selenium.Specflow.Extent.Reports.PageObjects
{
    public class PaginaCadastro : DriverFactory
    {
        public PaginaCadastro(IWebDriver driver) : base(driver) { }

        public PaginaCadastro CadastrarUsuario(string nome, string email, string senha)
        {
            InserirTexto(Driver(), By.Id("nome"), nome);
            InserirTexto(Driver(), By.Id("email"), email);
            InserirTexto(Driver(), By.Id("senha"), senha);            
            return this;
        }

        public void VerificarUsuarioCadastradoComSucesso()
        {
            Clicar(Driver(), By.XPath("//input[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.UsuarioCadastrado + "')]"),                
                "Ocorreu um erro ao realizar o cadastro do usuário"
            );
        }

        public void ValidarCamposObrigatorios(string nome, string email, string senha)
        {
            Clicar(Driver(), By.XPath("//input[@class='btn btn-primary']"));
            if(string.IsNullOrEmpty(nome)) {
                ElementoExiste(
                    Driver(),
                    By.XPath("//div[contains(text(),'Nome é um " + Mensagens.CampoObrigorio + "')]"),
                    "Não foi apresentada mensagem de nome obrigatório"
                );
            }
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

        public void ValidarRegistroDuplicado()
        {
            Clicar(Driver(), By.XPath("//input[@class='btn btn-primary']"));
            ElementoExiste(
                Driver(),
                By.XPath("//div[contains(text(),'" + Mensagens.EmailJaUtilizado + "')]"),
                "Não foi apresentada mensagem de registro duplicado"
            );
        }

    }
}
