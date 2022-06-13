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
    public partial class LogIn : Form
    {
        private Usuario usu = new Usuario();
        private Validaciones val = new Validaciones();
        public LogIn()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {    

            try
            {
                string validacion = "";
                validacion = val.validarCorreo(txtEmail.Text);

                if (validacion.Equals(string.Empty))
                {
                    validacion = val.validarContrasena(txtContrasena.Text);
                    if (validacion.Equals(string.Empty))
                    {
                        usu.Contrasena = val.MD5Contrasena(txtContrasena.Text);

                        MessageBox.Show("login");
                    }
                    else
                    {
                        MessageBox.Show(validacion);
                    }
                }
                else
                {
                    MessageBox.Show(validacion);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //AgregarActualizarArticulos art = new AgregarActualizarArticulos();

            //art.Show();
            //this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
