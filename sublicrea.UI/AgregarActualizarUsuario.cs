using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private Usuario usu = new Usuario();
        private string correo;
        private Bitacora bit = new Bitacora();

        public AgregarActualizarUsuario(Usuario _usu,string _email = "n/a")
        {
            InitializeComponent();

            usuSesion = _usu;
            this.correo = _email;
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

                    usu.FotoPerfil = val.convertirImagenesABytes(picFoto.ImageLocation);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

       

        

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            if (!string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtNombreUsuario.Text) &&
                !string.IsNullOrEmpty(txtApellidosUsuario.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text)
                )
            {
                if(txtEmail.Text.Contains(".") && txtEmail.Text.Contains("@"))
                {
                    if (txtNombreUsuario.Text.IndexOfAny("0123456789".ToCharArray()) == -1 && 
                        txtApellidosUsuario.Text.IndexOfAny("0123456789".ToCharArray())==-1)
                    {
                        if(Regex.IsMatch(txtTelefono.Text, @"[0-9]{1,9}(\.[0-9]{0,2})?$"))
                        {
                            if (!cbEmpresa.Text.Equals("Seleccione") 
                                    && !cbTipoUsuario.Text.Equals("Seleccione"))
                                {
                                    usu.Email = txtEmail.Text;
                                    usu.Nombre = txtNombreUsuario.Text;
                                    usu.Contrasena = txtContrasena.Text;
                                    usu.Apellidos = txtApellidosUsuario.Text;
                                    usu.Estado = true;
                                    usu.FkEmpresa = long.Parse(cbEmpresa.Text.Split(' ')[0]);
                                    usu.FkTipoUsuario = Int32.Parse(cbTipoUsuario.Text.Substring(0, 1)); ;
                                    usu.Telefono = Int32.Parse(txtTelefono.Text);

                                bit.FkEmail = usuSesion.Email;

                                bit.FechaInicio = DateTime.Now;
                                bit.FechaFin = DateTime.Now;

                                if (this.correo.Equals("n/a"))
                                    {
                                        if (txtContrasena.Text.Equals(txtConfirmarContrasena.Text) && !string.IsNullOrEmpty(txtContrasena.Text) &&
                                            !string.IsNullOrEmpty(txtConfirmarContrasena.Text))
                                        {
                                        bit.TipoMovimiento = "agregar";
                                        bit.DetalleMovimiento = "agregar usuario " + usu.Email;
                                        ges.agregarBitacora(bit);

                                        ges.agregarUsuario(usu);

                                        }
                                        else
                                        {
                                            MessageBox.Show("El campo contraseña y verificar contraseña deben de ser iguales");
                                        }
                                    }
                                    else
                                    {
                                        usu.Contrasena = "n/a";
                                    bit.TipoMovimiento = "actualizar";
                                    bit.DetalleMovimiento = "actualizar usuario " + usu.Email;
                                    ges.agregarBitacora(bit);
                                    ges.actualizarUsuario(usu);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("seleccione una empresa y un tipo de usuario ");

                                }
                            
                        }
                        else
                        {
                            MessageBox.Show("El número de teléfono debe contener solo números");

                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre del usuario y sus apellidos no debe contener números");

                    }
                }
                else
                {
                    MessageBox.Show("El correo debe contener el formato correcto");

                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos obligatorios");
            }
        }
        private void AgregarActualizarUsuario_Load(object sender, EventArgs e)
        {
            List<Usuario> usuario = ges.mostrarUsuarios(this.correo);


            lbEmail.Text = usuSesion.Email;
            lbRol.Text = usuSesion.TipoUsuario;

            if (usuSesion.FkTipoUsuario == 1)
            {
                btnCatalogoRedirigir.Visible = true;
                btnReportesBitacoraRedirigir.Visible = true;
                btnReportesRedirigr.Visible = true;
                btnUsuarioRedirigir.Visible = true;
                btnCategoriasRedirigir.Visible = true;
                btnEmpresasRedirigir.Visible = true;
                btnArticulosRedirigir.Visible = true;
                btnAgregarUsuarioRedirigir.Visible = true;
                btnAgregarArticuloRedirigir.Visible = true;
                btnAgregarCategoriaRedirigir.Visible = true;
                btnMantenimientos.Visible = true;

                btnAgregarEmpresaRedirigir.Visible = false;
            }
            else if (usuSesion.FkTipoUsuario == 2)
            {
                btnReportesRedirigr.Visible = true;
                btnAgregarArticuloRedirigir.Visible = true;
                btnArticulosRedirigir.Visible = true;
                btnMantenimientos.Visible = true;
                pSubMenu.Location = new Point(5, 134);


            }
            else if (usuSesion.FkTipoUsuario == 3)
            {
                btnCatalogoRedirigir.Visible = true;
                btnReportesRedirigr.Visible = true;
                picCampana.Visible = true;

            }
            else if (usuSesion.FkTipoUsuario == 4)
            {
                btnAgregarArticuloRedirigir.Visible = true;
                btnMantenimientos.Visible = true;
                btnCategoriasRedirigir.Visible = true;
                btnAgregarCategoriaRedirigir.Visible = true;
                picCampana.Visible = true;
                pSubMenu.Location = new Point(5, 134);

            }
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

            if (!this.correo.Equals("n/a"))
            {
                List<Empresa> empresa = ges.mostrarEmpresa(usuario[0].FkEmpresa);
                List<TipoUsuario> tipoUsuario = ges.mostrarTipoUsuario(usuario[0].FkTipoUsuario);

                txtEmail.Enabled = false;
                txtEmail.Text = usuario[0].Email.ToString();
                txtNombreUsuario.Text = usuario[0].Nombre.ToString();
                txtApellidosUsuario.Text = usuario[0].Apellidos.ToString();
                txtTelefono.Text = usuario[0].Telefono.ToString();

                if (usuario[0].FotoPerfil != null)
                {

                    picFoto.Image = val.convertirBytesAImagenes(usuario[0].FotoPerfil);
                    usu.FotoPerfil = usuario[0].FotoPerfil;
                }
                else
                {                    
                    picFoto.Image = val.convertirBytesAImagenes(val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png"));
                    usu.FotoPerfil = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                }

                string tipoUsuarioSeleccionado = tipoUsuario[0].IdTipoUsuario.ToString() + " - " + tipoUsuario[0].NombreTipoUsuario.ToString();
                string empresaSeleccionada = empresa[0].CedulaJuridica.ToString() + " - " + empresa[0].NombreEmpresa.ToString();

                cbTipoUsuario.Text = tipoUsuarioSeleccionado;
                cbEmpresa.Text = empresaSeleccionada;

                txtContrasena.Visible = false;
                txtConfirmarContrasena.Visible = false;
                lbContrasena.Visible = false;
                lbConfirmarContrasena.Visible = false;

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

        private void btnArticulosRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MostrarArticulos(usuSesion);

            art.Show();
            this.Hide();
        }

        private void btnReportesMenuRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MenuReportes(usuSesion);

            art.Show();
            this.Hide();
        }
    }
}
