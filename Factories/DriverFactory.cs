using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Specflow.Extent.Reports.Factories
{
    public class DriverFactory : ActionFactory
    {
        private readonly IWebDriver _driver;

        public DriverFactory() { }

        public DriverFactory(IWebDriver driver)
        {
            _driver = driver;
        }        

        public IWebDriver CreateDriver(string browser = null)
        {
            browser = browser ?? "CHROME";

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver();
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }

        public void Navegar(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebDriver Driver()
        {
            return _driver;
        }

    }
}