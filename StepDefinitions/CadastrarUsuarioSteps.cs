using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.Resources;
using Selenium.Specflow.Extent.Reports.PageObjects;
using Selenium.Specflow.Extent.Reports.Utility;
using TechTalk.SpecFlow;

namespace Selenium.Specflow.Extent.Reports.StepDefinitions
{
    [Binding]
    public class CadastrarUsuarioSteps
    {
        public PaginaLogin Login;
        public PaginaCadastro Cadastro;
        Usuario user = new Usuario();

        public CadastrarUsuarioSteps(IWebDriver driver)
        {
            Login = new PaginaLogin(driver);
        }

        [Given(@"Dado que o usuario queira criar uma conta")]
        public void DadoQueOUsuarioQueiraCriarUmaConta()
        {
            Cadastro = Login
                .AcessarPaginaLogin(EnumAmbiente.TST)
                .AcessarCadastroUsuario();
        }

        [Given(@"E que o usuario informe os dados necessarios para cadastro ""(.*)"" ""(.*)"" ""(.*)""")]
        public void DadoQueOUsuarioInformeOsDadosNecessariosParaCadastroE(string nome, string email, string senha)
        {
            Cadastro.CadastrarUsuario(nome, email, senha);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para cadastro")]
        public void DadoQueOUsuarioInformeOsDadosNecessariosParaCadastro(Table table)
        {
                Cadastro.CadastrarUsuario(table.Rows[0]["nome"], table.Rows[0]["email"], table.Rows[0]["senha"]);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para cadastro")]
        public void DadoQueOUsuarioInformeOsDadosNecessariosParaCadastro()
        {            
            Cadastro.CadastrarUsuario(user.Nome, user.EmailCadastro, user.Senha);
        }

        [Then(@"Entao o usuario e informado que campos obrigatorios do cadastro nao foram preenchidos ""(.*)"" ""(.*)"" ""(.*)""")]
        public void EntaoOUsuarioEInformadoQueCamposObrigatoriosNaoForamPreenchidosE(string nome, string email, string senha)
        {
            Cadastro.ValidarCamposObrigatorios(nome, email, senha);
        }
        
        [Then(@"Entao o usuario e informado que ja existe um registro cadastrado para esse e-mail")]
        public void EntaoOUsuarioEInformadoQueJaExisteUmRegistroCadastradoParaEsseE_Mail()
        {
            Cadastro.ValidarRegistroDuplicado();
        }
        
        [Then(@"Entao o usuario e informado que foi realizado o cadastro com sucesso")]
        public void EntaoOUsuarioEInformadoQueFoiRealizadoOCadastroComSucesso()
        {
            Cadastro.VerificarUsuarioCadastradoComSucesso();
        }
    }
}
