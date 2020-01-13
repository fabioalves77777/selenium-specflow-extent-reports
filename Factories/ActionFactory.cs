using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Selenium.Specflow.Extent.Reports.Factories
{
    public class ActionFactory
    {
        public int TempoLimiteEspera = 3;
        public int ElementoExistente = 1;

        /// <summary>
        /// Método para esperar a página carregar
        /// </summary>
        public void EsperaPaginaCarregar(IWebDriver driver, int timeout = 1)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(wd => ((IJavaScriptExecutor)driver).ExecuteScript("return (window.angular !== undefined) && (angular.element(document).injector() !== undefined) && (angular.element(document).injector().get('$http').pendingRequests.length === 0)").ToString());
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML
        /// </summary>
        public IWebElement EsperaExistencia(IWebDriver driver, By by)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    return driver.FindElement(by);
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
            }                
            throw new Exception("Elemento não encontrado: '" + by + "'");
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML e inserir texto
        /// </summary>
        public void EsperaExistenciaSendKeys(IWebDriver driver, By by, string text)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    driver.FindElement(by).SendKeys(text);
                    return;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser digitado: '" + by);
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML e inserir texto
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="text"></param>
        public void EsperaExistenciaSendKeys(IWebElement element, string text)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    element.SendKeys(text);
                    return;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser digitado: '" + element);
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML e inserir texto
        /// </summary>
        public void EsperaExistenciaSendKeys(IWebDriver driver, string key)
        {            
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    driver.FindElement(By.XPath(".//body"));
                    Actions builder = new Actions(driver);
                    builder.SendKeys(key).Build().Perform();
                }  
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser digitado: '" + key.ToString());
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML e clicar
        /// </summary>
        public void EsperaExistenciaAndClick(IWebDriver driver, By by)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    EsperaExistencia(driver, by).Click();
                    return;
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser clicado: '" + by);
        }

        /// <summary>
        /// Método para esperar a existência do elemento HTML e clicar
        /// </summary>
        public void EsperaExistenciaAndClick(IWebElement element)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    element.Click();
                    return;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser clicado: '" + element);
        }

        /// <summary>
        /// Método para esperar a existência de SelectByText
        /// </summary>
        public void EsperaSelectByVisibleText(IWebDriver driver, By by, string texto)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    new SelectElement(EsperaExistencia(driver, by)).SelectByText(texto);
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser selecionado: '" + by);
        }

        /// <summary>
        /// Método para esperar a existência de SelectByIndex
        /// </summary>
        public void EsperaSelectByIndex(IWebDriver driver, By by, int index)
        {
            for (int i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {
                    new SelectElement(EsperaExistencia(driver, by)).SelectByIndex(index);
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep(500);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep(500);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não pode ser selecionado: '" + by);
        }

        /// <summary>
        /// Método que verifica se elemento existe
        /// </summary>
        public bool ElementoExiste(IWebDriver driver, By by, int index = 0)
        {
            var tmp = 0;
            if (index != 0) tmp = index; else tmp = ElementoExistente;
            for (var i = 0; i < tmp; i++)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
            }
            return false;
        }

        /// <summary>
        /// Método que verifica se elemento existe
        /// </summary>
        public void ElementoExiste(IWebDriver driver, By by, string texto)
        {
            if (!ElementoExiste(driver, by))
            {
                Assert.Fail(texto);
            }
        }

        /// <summary>
        /// Método que retorna coleção de elementos
        /// </summary>
        public ReadOnlyCollection<IWebElement> ColecaoElementos(IWebDriver driver, By by)
        {
            for (var i = 0; i < TempoLimiteEspera; i++)
            {
                try
                {                    
                    return driver.FindElements(by);
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elemento não encontrado: '" + by + "'");
        }

        /// <summary>
        /// Método para limpar um elemento
        /// </summary>
        public void LimparTexto(IWebDriver driver, By by)
        {
            EsperaExistencia(driver, by).Clear();
        }

        /// <summary>
        /// Método para inserir texto em elemento
        /// </summary>
        public void InserirTexto(IWebDriver driver, By by, string texto)
        {
            if (!string.IsNullOrEmpty(texto)) EsperaExistenciaSendKeys(driver, by, texto);
        }

        /// <summary>
        /// Método para inserir texto em elemento
        /// Exemplo: InserirTexto(driver(), Keys.Alt);
        /// </summary>
        public void InserirTexto(IWebDriver driver, string key)
        {
            if (!string.IsNullOrEmpty(key)) EsperaExistenciaSendKeys(driver, key);
        }

        /// <summary>
        /// Método para inserir texto em elemento
        /// </summary>
        public void InserirTexto(IWebElement element, string texto)
        {
            if (!string.IsNullOrEmpty(texto)) EsperaExistenciaSendKeys(element, texto);
        }

        /// <summary>
        /// Método para inserir texto em elemento com foco
        /// </summary>
        public void InserirTextoActions(IWebDriver driver, string texto)
        {
            new Actions(driver).SendKeys(texto).Build().Perform();
        }

        /// <summary>
        /// Método para clicar em um elemento
        /// </summary>
        public void Clicar(IWebDriver driver, By by)
        {
            EsperaExistenciaAndClick(driver, by);
        }

        /// <summary>
        /// Método para clicar em um elemento
        /// </summary>
        public void Clicar(IWebElement element)
        {
            EsperaExistenciaAndClick(element);
        }

        /// <summary>
        /// Método para clicar em um elemento pelo index
        /// </summary>
        public void ClicarByIndex(IWebDriver driver, By by, int index)
        {
            Clicar(ColecaoElementos(driver, by)[index]);
        }

        /// <summary>
        /// Método para selecionar elemento pelo texto
        /// </summary>
        public void Selecionar(IWebDriver driver, By by, string texto)
        {
            EsperaSelectByVisibleText(driver, by, texto);
        }

        /// <summary>
        /// Método para selecionar elemento pelo indice
        /// </summary>
        public void Selecionar(IWebDriver driver, By by, int index)
        {
            EsperaSelectByIndex(driver, by, index);
        }

        /// <summary>
        /// Método para realizar upload de arquivo com selenium
        /// </summary>
        /// <param name="arquivo">Informar o caminho completo e o nome arquivo para upload</param>
        public void UploadArquivo(string arquivo)
        {
            System.Windows.Forms.SendKeys.SendWait(arquivo);
            System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
        }

        /// <summary>
        /// Método que retorna o texto do elemento
        /// </summary>
        public string RetornarTexto(IWebDriver driver, By by)
        {
            return EsperaExistencia(driver, by).Text;
        }

        /// <summary>
        /// Método que retorna o texto de um elemento da index informada
        /// </summary>
        public string RetornarTextoByIndex(IWebDriver driver, By by, int index)
        {
            return ColecaoElementos(driver, by)[index].Text;
        }

        /// <summary>
        /// Método que retorna o texto de um elemento pelo atributo informado
        /// </summary>
        public string RetornarTextoAttr(IWebDriver driver, By by, string attr)
        {
            return EsperaExistencia(driver, by).GetAttribute(attr);
        }

        /// <summary>
        /// Método que verifica se texto atual é igual ao texto esperado
        /// </summary>
        public void VerificarTexto(string msgEsperada, string msgAtual, string msgErro)
        {
            Assert.AreEqual(msgEsperada, msgAtual, msgErro);
        }

        /// <summary>
        /// Método que verifica se texto do elemento contém no texto esperado
        /// </summary>
        public void ContemTexto(string msgEsperada, string msgAtual, string msgErro)
        {
            Assert.IsTrue(msgAtual.Contains(msgEsperada), msgErro);
        }

        /// <summary>
        /// Método que dá um scroll na página caso o elemento não seja visualizado
        /// </summary>
        public IWebElement ScrollPage(IWebDriver driver, IWebElement element)
        {
            new Actions(driver).MoveToElement(element);
            return element;
        }

        /// <summary>
        /// Método que dá um scroll na página caso o elemento não seja visualizado
        /// </summary>
        public IWebElement ScrollElementJs(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", element);
            return element;
        }

        /// <summary>
        /// Método que dá um scroll na página
        /// </summary>
        public void ScrollPageJs(IWebDriver driver, string sobe, string desce)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("scroll(" + sobe + ", " + desce + ")");
        }

        /// <summary>
        /// Método que altera a aba do navegador
        /// </summary>
        public void TrocarAba(IWebDriver driver, string aba = null)
        {
            if (!string.IsNullOrEmpty(aba) && aba.Equals("Last"))
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            else
                driver.SwitchTo().Window(driver.WindowHandles.First());
        }

    }
}