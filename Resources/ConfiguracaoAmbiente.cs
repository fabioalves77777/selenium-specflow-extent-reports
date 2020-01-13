using Selenium.Specflow.Extent.Reports.Utility;

namespace Selenium.Specflow.Extent.Reports.Resources
{
    public class ConfiguracaoAmbiente
    {
        public ConfiguracaoAmbiente()
        {
            Navegador = EnumNavegador.FIREFOX;
            Ambiente = EnumAmbiente.TST;
        }

        internal EnumNavegador Navegador { get; set; }
        internal EnumAmbiente Ambiente { get; set; }
        public static string UrlTst = "https://seubarriga.wcaquino.me/login";
        public static string UrlHml = "https://seubarriga.wcaquino.me/login";
    }
}
