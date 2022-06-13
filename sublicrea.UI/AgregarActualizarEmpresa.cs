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
    public partial class AgregarActualizarEmpresa : Form
    {
        private Validaciones val = new Validaciones();
        public AgregarActualizarEmpresa()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string img = "";

            try
            {
                OpenFileDialog archivo = new OpenFileDialog();

                archivo.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    img = archivo.FileName;
                    picLogo.ImageLocation = img;
                }

            }catch(Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCedulaJuridica_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "n");

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "n");

        }
    }
}
