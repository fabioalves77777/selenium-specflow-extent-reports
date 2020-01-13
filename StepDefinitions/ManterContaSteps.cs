using OpenQA.Selenium;
using Selenium.Specflow.Extent.Reports.PageObjects;
using Selenium.Specflow.Extent.Reports.Resources;
using Selenium.Specflow.Extent.Reports.Utility;
using TechTalk.SpecFlow;

namespace Selenium.Specflow.Extent.Reports.StepDefinitions
{
    [Binding]
    public class ManterContaSteps
    {
        public PaginaLogin Login;
        public PaginaInicial Home;
        public PaginaContaIncluir Incluir;
        public PaginaContaAlterar Alterar;
        public PaginaContaListar Listar;
        public Usuario user = new Usuario();
        public Conta conta = new Conta();
        public string nome;

        public ManterContaSteps(IWebDriver driver) => Login = new PaginaLogin(driver);


        [Given(@"Dado que o usuario realize a autenticacao no sistema")]
        public void DadoDadoQueOUsuarioRealizeAAutenticacaoNoSistema()
        {
            Home = Login
                .AcessarPaginaLogin(EnumAmbiente.TST)
                .RealizarLogin(user.Email, user.Senha)
                .VerificarUsuarioAutenticadoComSucesso();
        }
        
        [Given(@"E que o usuario acesse a tela de adicionar conta")]
        public void DadoEQueOUsuarioAcesseATelaDeAdicionarConta()
        {
            Incluir = Home.ResetarMovimentacoes().AcessarAdicionarConta();
        }
        
        [Given(@"E que o usuario informe os dados necessarios para criacao da conta")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaCriacaoDaConta()
        {
            Incluir.RealizarInclusaoConta(conta.NomeIncluir);
        }

        [Given(@"E que o usuario informe os dados necessarios para criacao da conta")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaCriacaoDaConta(Table table)
        {
            nome = table.Rows[0]["nome"];
            Incluir.RealizarInclusaoConta(nome);
        }
        
        [Given(@"E que o usuario acesse a tela de listar conta")]
        public void DadoEQueOUsuarioAcesseATelaDeListarConta()
        {
            Listar = Home.ResetarMovimentacoes().AcessarListaContas();
        }
        
        [Given(@"E que o usuario acesse a tela de alterar conta")]
        public void DadoEQueOUsuarioAcesseATelaDeAlterarConta()
        {
            Alterar = Listar.AcessarAlteracaoConta();
        }
        
        [Given(@"E que o usuario informe os dados necessarios para alteracao da conta")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAlteracaoDaConta()
        {
            Alterar.RealizarAlteracaoConta(conta.NomeAlterar);
        }
        
        [Given(@"E que o usuario informe os dados necessarios para alteracao da conta")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAlteracaoDaConta(Table table)
        {
            nome = table.Rows[0]["nome"];
            Alterar.RealizarAlteracaoConta(nome);
        }
        
        [Given(@"E que o usuario solicite a exclusao da conta")]
        public void DadoEQueOUsuarioSoliciteAExclusaoDaConta()
        {
            Listar.RealizarExclusaoConta(conta.NomeExcluir);
        }

        [Given(@"E que o usuario solicite a exclusao da conta com movimentacao")]
        public void DadoEQueOUsuarioSoliciteAExclusaoDaContaComMovimentacao()
        {
            Listar.RealizarExclusaoContaComMovimentacao();
        }


        [Then(@"Entao o usuario e informado que campos obrigatorios nao foram preenchidos na inclusao")]
        public void EntaoEntaoOUsuarioEInformadoQueCamposObrigatoriosNaoForamPreenchidosNaInclusao()
        {
            Incluir.ValidarCamposObrigatorios(nome);
        }

        [Then(@"Entao o usuario e informado que campos obrigatorios nao foram preenchidos na alteracao")]
        public void EntaoEntaoOUsuarioEInformadoQueCamposObrigatoriosNaoForamPreenchidosNaAlteracao()
        {
            Alterar.ValidarCamposObrigatorios();
        }

        [Then(@"Entao o usuario e informado que ja existe uma conta cadastrada com o mesmo nome na inclusao")]
        public void EntaoEntaoOUsuarioEInformadoQueJaExisteUmaContaCadastradaComOMesmoNomeNaInclusao()
        {
            Incluir.ValidarRegistroDuplicado();
        }

        [Then(@"Entao o usuario e informado que ja existe uma conta cadastrada com o mesmo nome na alteracao")]
        public void EntaoEntaoOUsuarioEInformadoQueJaExisteUmaContaCadastradaComOMesmoNomeNaAlteracao()
        {
            Alterar.ValidarRegistroDuplicado();
        }

        [Then(@"Entao o usuario e informado que foi realizada a inclusao da conta com sucesso")]
        public void EntaoEntaoOUsuarioEInformadoQueFoiRealizadaAInclusaoDaContaComSucesso()
        {
            Incluir.VerificarContaAdicionadaComSucesso(conta.NomeIncluir);
        }
        
        [Then(@"Entao o usuario e informado que foi realizada a alteracao da conta com sucesso")]
        public void EntaoEntaoOUsuarioEInformadoQueFoiRealizadaAAlteracaoDaContaComSucesso()
        {
            Alterar.VerificarAlteracaoComSucesso(conta.NomeAlterar);
        }
        
        [Then(@"Entao o usuario e informado que nao pode excluir conta com movimentacao")]
        public void EntaoEntaoOUsuarioEInformadoQueNaoPodeExcluirContaComMovimentacao()
        {
            Listar.ValidarExclusaoContaComMovimentacao();
        }
        
        [Then(@"Entao o usuario e informado que foi realizada a exclusao da conta com sucesso")]
        public void EntaoEntaoOUsuarioEInformadoQueFoiRealizadaAExclusaoDaContaComSucesso()
        {
            Listar.VerificarContaExcluidaComSucesso();
        }
    }
}
