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
    public partial class AcercaDe : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();

        public AcercaDe(Usuario _usu)
        {
            this.usuSesion = _usu;

            InitializeComponent();
        }

        private void btnAgregarUsuarioRedirigir_Click(object sender, EventArgs e)
        {
            Form usu = new AgregarActualizarUsuario(usuSesion);

            usu.Show();
            this.Hide();
        }

        private void btnAcercaDeRedirigir_Click(object sender, EventArgs e)
        {
            Form acerca = new AcercaDe(usuSesion);

            acerca.Show();
            this.Hide();
        }

        private void btnAyudaRedirigir_Click(object sender, EventArgs e)
        {
            Form ayuda = new Ayuda(usuSesion);

            ayuda.Show();
            this.Hide();
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;

            lbRol.Text = usuSesion.TipoUsuario;
            if (usuSesion.FotoPerfil != null)
            {
                picPerfil.Image = val.convertirBytesAImagenes(usuSesion.FotoPerfil);

            }
            else
            {
                usuSesion.FotoPerfil = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                picPerfil.Image = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            }

            if (usuSesion.Logo != null)
            {
                picLogo.Image = val.convertirBytesAImagenes(usuSesion.Logo);

            }
            else
            {

                usuSesion.Logo = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                picLogo.Image = val.convertirBytesAImagenes(usuSesion.Logo);
            }
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            pSubMenu.Visible = !pSubMenu.Visible;

        }

        private void btnCatalogoRedirigir_Click(object sender, EventArgs e)
        {
            Catalogo ventana = new Catalogo(usuSesion);


            this.Hide();
            ventana.Show();

        }

        private void btnAgregarArticuloRedirigir_Click(object sender, EventArgs e)
        {
            Form arti = new AgregarActualizarArticulos(usuSesion);

            arti.Show();
            this.Hide();
        }

        private void btnAgregarCategoriaRedirigir_Click(object sender, EventArgs e)
        {
            Form cat = new AgregarActualizarCategoria(usuSesion);

            cat.Show();
            this.Hide();
        }

        private void btnAgregarEmpresaRedirigir_Click(object sender, EventArgs e)
        {
            Form emp = new AgregarActualizarEmpresa(usuSesion);

            emp.Show();
            this.Hide();
        }

        private void btnReportesBitacoraRedirigir_Click(object sender, EventArgs e)
        {
            Form bit = new MenuReportes(usuSesion);

            bit.Show();
            this.Hide();
        }

        private void btnUsuarioRedirigir_Click(object sender, EventArgs e)
        {
            Form usu = new MostrarUsuarios(usuSesion);

            usu.Show();
            this.Hide();
        }

        private void btnCategoriasRedirigir_Click(object sender, EventArgs e)
        {
            Form cat = new MostrarCategorias(usuSesion);

            cat.Show();
            this.Hide();
        }

        private void btnEmpresasRedirigir_Click(object sender, EventArgs e)
        {
            Form emp = new MostrarEmpresas(usuSesion);

            emp.Show();
            this.Hide();
        }

        private void btnArticulosRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MostrarArticulos(usuSesion);

            art.Show();
            this.Hide();
        }

        private void picCarrito_Click(object sender, EventArgs e)
        {
            Form cat = new Catalogo(usuSesion);

            cat.Show();
            this.Hide();
        }

        private void picCampana_Click(object sender, EventArgs e)
        {
            Form ped = new PedidosPendientes(usuSesion);

            ped.Show();
            this.Hide();
        }
    }
}
