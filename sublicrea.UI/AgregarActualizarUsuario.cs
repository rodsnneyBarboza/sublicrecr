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
        public AgregarActualizarUsuario()
        {
            InitializeComponent();
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
    }
}
