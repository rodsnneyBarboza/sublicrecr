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
        public AgregarActualizarArticulos()
        {
            InitializeComponent();
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
            Form usu = new AgregarActualizarUsuario();

            usu.Show();
            this.Hide();


        }

        private void btnAgregarArticuloRedirigir_Click(object sender, EventArgs e)
        {
            Form arti = new AgregarActualizarArticulos();

            arti.Show();
            this.Hide();
        }

        private void btnAgregarCategoriaRedirigir_Click(object sender, EventArgs e)
        {
            Form cat = new AgregarActualizarCategoria();

            cat.Show();
            this.Hide();
        }

        private void btnAgregarEmpresaRedirigir_Click(object sender, EventArgs e)
        {
            Form emp = new AgregarActualizarEmpresa();

            emp.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            string validacion = "";


        }

   

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e,"n");

        }

        private void txtCantidadDisponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e,"n");

        }

        private void txtNombreArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");

        }
    }
}
