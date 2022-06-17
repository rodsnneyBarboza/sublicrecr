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
    public partial class AgregarActualizarArticulos : Form
    {
        private Validaciones val= new Validaciones();
        private Gestor ges = new Gestor();
        private Usuario usuSesion = new Usuario();
        private Articulo art = new Articulo();

        public AgregarActualizarArticulos(Usuario _usu)
        {
            InitializeComponent();
            this.usuSesion = _usu;

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                    picArticulo.ImageLocation = img;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void btnAgregarUsuarioRedirigir_Click(object sender, EventArgs e)
        {
            Form usu = new AgregarActualizarUsuario(usuSesion);

            usu.Show();
            this.Hide();


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

   

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreArticulo.Text) &&
                !string.IsNullOrEmpty(txtPrecioVenta.Text) &&
                !string.IsNullOrEmpty(txtCantidadDisponible.Text))
            {
                if (!string.IsNullOrEmpty(picArticulo.ImageLocation))
                {
                    art.Imagen = val.convertirImagenesABytes(picArticulo.ImageLocation);
                }
                else
                {

                    art.Imagen = null;
                }

                if (!cbCategoria.Text.Equals("Seleccione"))
                {
                    MessageBox.Show(cbCategoria.Text.Substring(0, 1));

                }
                else
                {
                    MessageBox.Show("seleccione una categoria");

                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos obligatorios");
            }
        }

        private void txtCantidadDisponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "n");

        }

        private void txtNombreArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");


        }


        private void AgregarActualizarArticulos_Load(object sender, EventArgs e)
        {
            List<Categoria> cat = ges.mostrarCategoria();

            cbCategoria.Items.Add("Seleccione");
            cbCategoria.SelectedItem = "Seleccione";

            for(int i=0; i < cat.Count; i++)
            {
                cbCategoria.Items.Add(cat[i].IdCategoria.ToString()+" - "+cat[i].NombreCategoria.ToString());
            }

            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
        }

        private void btnMantenimientos_MouseHover(object sender, EventArgs e)
        {
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
