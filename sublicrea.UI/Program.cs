using sublicreacr.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sublicrea.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Usuario usu = new Usuario();
            //Validaciones val = new Validaciones();

            //usu.Nombre = "Rodsnney";
            //usu.FotoPerfil = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
            //usu.FkTipoUsuario = 1;
            //usu.Apellidos = "Barboza Araya";
            //usu.TipoUsuario = "test";
            //usu.FkEmpresa = 111111111;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
