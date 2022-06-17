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
        private Gestor ges = new Gestor();
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
                        usu.Contrasena = txtContrasena.Text;
                        usu.Email = txtEmail.Text;
                        DataSet datos = ges.informacionLogin(usu);


                        if (datos.Tables[0].Rows.Count > 0)
                        {
                            usu.Nombre = datos.Tables[0].Rows[0]["nombre"].ToString();
                            usu.FotoPerfil = (byte[])datos.Tables[0].Rows[0]["foto_perfil"];
                            usu.FkTipoUsuario = (int)datos.Tables[0].Rows[0]["fk_tipo_usuario"];
                            usu.Apellidos = datos.Tables[0].Rows[0]["apellidos"].ToString();
                            usu.TipoUsuario = datos.Tables[0].Rows[0]["nombre_tipo_usuario"].ToString();

                            Catalogo cat = new Catalogo(usu);

                            cat.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Correo o Contraseña Incorrecta");

                        }


                        

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
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
