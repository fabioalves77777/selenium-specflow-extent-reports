using Selenium.Specflow.Extent.Reports.Utility;

namespace Selenium.Specflow.Extent.Reports.Resources
{
    public class Conta
    {

        public Conta()
        {
            NomeIncluir = "Água " + Utilitario.RetornaDataHora();
            NomeAlterar = "Luz " + Utilitario.RetornaDataHora();
            NomeExcluir = "Conta para alterar";
        }

        public string NomeIncluir { get; set; }
        public string NomeAlterar { get; set; }
        public string NomeExcluir { get; set; }
    }
}
