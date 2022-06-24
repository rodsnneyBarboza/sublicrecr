using sublicreacr.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sublicrea.UI
{
    public partial class ReportesBitacoras : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();


        public ReportesBitacoras(Usuario _usu)
        {
            InitializeComponent();

            this.usuSesion = _usu;
        }

        private void ReportesBitacoras_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
        }
    }
}
