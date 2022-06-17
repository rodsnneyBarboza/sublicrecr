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
    public partial class AgregarActualizarUsuario : Form
    {
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        private Usuario usuSesion = new Usuario();

        public AgregarActualizarUsuario(Usuario _usu,string _email = null)
        {
            InitializeComponent();

            usuSesion = _usu;

            if(!string.IsNullOrEmpty(_email))
            {
                MessageBox.Show(_email);

                txtEmail.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            string img = "";

            try
            {
                OpenFileDialog archivo = new OpenFileDialog();

                archivo.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    img = archivo.FileName;
                    picFoto.ImageLocation = img;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");

        }

        private void txtApellidosUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "n");

        }

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();

            usu.Email = "Rodsnney21@gmail.com";
            usu.Nombre = "Rodsnney";
            usu.Contrasena = "Trew201971!";
            usu.Apellidos = "Barboza Araya";
            usu.Estado = true;
            usu.FkEmpresa = 111111111;
            usu.FkTipoUsuario = 1;
            usu.Telefono = 83094186;
            usu.FotoPerfil = val.convertirImagenesABytes("C:/Users/rodsn/OneDrive/Desktop/angie_foto.JPG");


            ges.agregarUsuario(usu);

        }

        private void AgregarActualizarUsuario_Load(object sender, EventArgs e)
        {
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
            lbEmail.Text = usuSesion.Email;


            List<TipoUsuario> tipUsu = ges.mostrarTipoUsuario();
            List<Empresa> emp = ges.mostrarEmpresa();


            cbTipoUsuario.Items.Add("Seleccione");
            cbEmpresa.Items.Add("Seleccione");
            cbTipoUsuario.SelectedItem = "Seleccione";
            cbEmpresa.SelectedItem = "Seleccione";


            for (int i = 0; i < tipUsu.Count; i++)
            {
                cbTipoUsuario.Items.Add(tipUsu[i].IdTipoUsuario.ToString() + " - " + tipUsu[i].NombreTipoUsuario.ToString());
            }

            for (int i = 0; i < emp.Count; i++)
            {
                cbEmpresa.Items.Add(emp[i].CedulaJuridica.ToString() + " - " + emp[i].NombreEmpresa.ToString());
            }
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
    }
}
