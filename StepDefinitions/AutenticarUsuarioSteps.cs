using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.PageObjects;
using Selenium.Specflow.Extent.Reports.Resources;
using Selenium.Specflow.Extent.Reports.Utility;
using TechTalk.SpecFlow;

namespace Selenium.Specflow.Extent.Reports.StepDefinitions
{
    [Binding]
    public class AutenticarUsuarioSteps
    {
        public PaginaLogin Login;
        public Usuario user = new Usuario();

        public AutenticarUsuarioSteps(IWebDriver driver) => Login = new PaginaLogin(driver);

        [Given(@"Dado que o usuario queira realizar autenticacao")]
        public void DadoDadoQueOUsuarioQueiraRealizarAutenticacao()
        {
            Login.AcessarPaginaLogin(EnumAmbiente.TST);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para autenticacao ""(.*)"" ""(.*)""")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao(string email, string senha)
        {
            Login.RealizarLogin(email, senha);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para autenticacao")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao(Table table)
        {
            Login.RealizarLogin(table.Rows[0]["email"], table.Rows[0]["senha"]);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para autenticacao")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao()
        {
            Login.RealizarLogin(user.Email, user.Senha);
        }
        
        [Then(@"Entao o usuario e informado que campos obrigatorios nao foram preenchidos ""(.*)"" ""(.*)""")]
        public void EntaoEntaoOUsuarioEInformadoQueCamposObrigatoriosNaoForamPreenchidos(string email, string senha)
        {
            Login.ValidarCamposObrigatorios(email, senha);
        }
        
        [Then(@"Entao o usuario e informado que nao foi realizada autenticacao")]
        public void EntaoEntaoOUsuarioEInformadoQueNaoFoiRealizadaAutenticacao()
        {
            Login.ValidarLoginInvalido();
        }
        
        [Then(@"Entao o usuario e informado que foi realizada a autenticacao com sucesso")]
        public void EntaoEntaoOUsuarioEInformadoQueFoiRealizadaAAutenticacaoComSucesso()
        {
            Login.VerificarUsuarioAutenticadoComSucesso();
        }
    }
}
