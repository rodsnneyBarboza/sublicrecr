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
    public partial class Catalogo : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        public Catalogo(Usuario _usu)
        {
            InitializeComponent();

            this.usuSesion = _usu;
        }

        public Catalogo()
        {
            InitializeComponent();
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            pSubMenu.Visible = !pSubMenu.Visible;

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

        private void Catalogo_Click(object sender, EventArgs e)
        {
            Form cat = new Catalogo(usuSesion);

            cat.Show();
            this.Hide();
        }

        
        private void btnAgregarEmpresaRedirigir_Click(object sender, EventArgs e)
        {
            Form emp = new AgregarActualizarEmpresa(usuSesion);

            emp.Show();
            this.Hide();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Catalogo ventana = new Catalogo(usuSesion);
            this.Hide();
            ventana.Show();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            //if (usuSesion.Email == null)
            //{

            //    LogIn ventana = new LogIn();                
            //    ventana.Show();
            //    this.Hide();
            //}

            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
            
        }

        private void btnUsuariosRedirigir_Click(object sender, EventArgs e)
        {
            MostrarUsuarios usu = new MostrarUsuarios(usuSesion);

            usu.Show();

            this.Hide();
        }

        private void btnCategoriasRedirigir_Click(object sender, EventArgs e)
        {
            MostrarCategorias cat = new MostrarCategorias(usuSesion);

            cat.Show();

            this.Hide();
        }

        private void btnEmpresasRedirigir_Click(object sender, EventArgs e)
        {
            MostrarEmpresas emp = new MostrarEmpresas(usuSesion);

            emp.Show();

            this.Hide();
        }
    }
}
