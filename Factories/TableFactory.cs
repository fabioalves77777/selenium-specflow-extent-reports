using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium.Specflow.Extent.Reports.Factories
{
    public class TableFactory : DriverFactory
    {
        public TableFactory(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Método para atualizar a table após realizar uma operação de inativação, ativação ou exclusão de um registro
        /// </summary>
        public TableFactory AtualizarTable()
        {
            return new TableFactory(Driver());
        }

        /// <summary>
        /// Método que retorna todos os registros <tr> da tabela 
        /// </summary>
        /// <param name="tableIndex">Campo opcional caso tenha mais de uma table na tela</param>
        public ReadOnlyCollection<IWebElement> RetornarTrs(int tableIndex = 0)
        {
            return ColecaoElementos(Driver(), By.TagName("tbody"))[tableIndex].FindElements(By.TagName("tr"));
        }

        /// <summary>
        /// Método que retorna apenas um registro <tr> conforme index informada
        /// </summary>
        /// <param name="tableIndex">Campo opcional caso tenha mais de uma table na tela</param>
        public IWebElement RetornarTr(int index, int tableIndex = 0)
        {
            return RetornarTrs(tableIndex)[index];
        }

        /// <summary>
        /// Método que retorna a coluna <td> da <tr> conforme index informada 
        /// </summary>
        public IWebElement RetornarTd(IWebElement tr, int index)
        {
            return tr.FindElements(By.TagName("td"))[index];
        }

        /// <summary>
        /// Método que retorna o botão <button> da <td> conforme index informada 
        /// </summary>
        public IWebElement RetornarButton(IWebElement coluna, int index)
        {
            return coluna.FindElements(By.TagName("button"))[index];
        }

        /// <summary>
        /// Método que retorna o span <span> da <td> conforme index informada 
        /// </summary>
        public IWebElement RetornarSpan(IWebElement coluna, int index)
        {
            return coluna.FindElements(By.TagName("span"))[index];
        }

        /// <summary>
        /// Método que retorna o link <a> da <td> conforme index informada 
        /// </summary>
        public IWebElement RetornarButtonLink(IWebElement coluna, int index)
        {
            return coluna.FindElements(By.TagName("a"))[index];
        }

        /// <summary>
        /// Método que verifica se já foram vistos todos os registros e apresenta a mensagem de erro
        /// </summary>
        public void VerificarUltimoRegistro(int index, string msgErro)
        {
            if (RetornarTrs().Count == (index + 1))
            {
                Assert.Fail(msgErro);
            }
        }

    }
}
