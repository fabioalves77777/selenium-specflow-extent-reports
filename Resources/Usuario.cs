using Selenium.Specflow.Extent.Reports.Utility;

namespace Selenium.Specflow.Extent.Reports.Resources
{
    public class Usuario
    {
        public Usuario()
        {
            Nome = "Fabio Alves";
            Email = "fabioaraujo.alves@email.com";
            EmailCadastro = "fabioaraujo.alves@email.com" + Utilitario.RetornaDataHora();
            Senha = "123456";
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string EmailCadastro { get; set; }
        public string Senha { get; set; }

    }
}
