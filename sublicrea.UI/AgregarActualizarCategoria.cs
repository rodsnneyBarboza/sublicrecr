using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sublicreacr.Negocio;

namespace sublicrea.UI
{
    public partial class AgregarActualizarCategoria : Form
    {
        private Validaciones val = new Validaciones();
        private Usuario usuSesion = new Usuario();
        private Gestor ges = new Gestor();

        public AgregarActualizarCategoria(Usuario _usu,int _idCategoria=-1)
        {
            InitializeComponent();
            this.usuSesion = _usu;

            List<Categoria> cat = ges.mostrarCategoria(_idCategoria);

            if (_idCategoria != -1)
            {
                MessageBox.Show(_idCategoria.ToString());
                txtIdCategoria.Visible = true;
                txtIdCategoria.Enabled = false;
                lbIdCategoria.Visible = true;
                txtIdCategoria.Text = _idCategoria.ToString();
                txtIdCategoria.Text = cat[0].IdCategoria.ToString();
                txtNombreCategoria.Text = cat[0].NombreCategoria;
                lbTitulo.Text = "Actualizar Categoría";
                btnAgregarActualizarCategoria.Text = "Actualizar";
            }
            else
            {
                lbTitulo.Text = "Agregar Categoría";
                btnAgregarActualizarCategoria.Text = "Agregar";
            }

        }

        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");

        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            pSubMenu.Visible = !pSubMenu.Visible;
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Catalogo ventana = new Catalogo(usuSesion);
            this.Hide();
            ventana.Show();
        }

        private void btnAgregarUsuarioRedirigir_Click(object sender, EventArgs e)
        {
            AgregarActualizarUsuario ventana = new AgregarActualizarUsuario(usuSesion);
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

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void AgregarActualizarCategoria_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
        }
    }
}
