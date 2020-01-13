using System;

namespace Selenium.Specflow.Extent.Reports.Utility
{
    public class Utilitario
    {
        public static string CaminhoProjeto = AppDomain.CurrentDomain.BaseDirectory.ToString().Remove(AppDomain.CurrentDomain.BaseDirectory.ToString().LastIndexOf("\\") - 10);

        public static string RetornaDataHora()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        public static string RetornaDataHoraFormatado()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public static string RetornaData()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string RetornaDataPtBr()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

    }
}
