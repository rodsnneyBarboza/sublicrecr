using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using sublicreacr.Negocio;


namespace sublicrea.UI
{
    public partial class AgregarActualizarEmpresa : Form
    {
        private Validaciones val = new Validaciones();
        private Usuario usuSesion = new Usuario();
        private Empresa emp = new Empresa();
        private long cedulaJuridica;
        private Gestor ges = new Gestor();
        private Bitacora bit = new Bitacora();

        public AgregarActualizarEmpresa(Usuario _usu, long _cedulaJuridica = -1)
        {
            InitializeComponent();
            this.usuSesion = _usu;

            this.cedulaJuridica = _cedulaJuridica;

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

            }
            catch (Exception)
            {
                MessageBox.Show("error");
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

        private void AgregarActualizarEmpresa_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;
            lbRol.Text = usuSesion.TipoUsuario;

            //valida el tipo de usuario para desplegar las diferentes opciones del menú de navegación
            if (usuSesion.FkTipoUsuario == 1 || usuSesion.FkTipoUsuario == 2)
            {
                //btnCatalogoRedirigir.Visible = true;
                btnMantenimientos.Visible = true;
                btnReportesRedirigr.Visible = true;
                btnReportesBitacoraRedirigir.Visible = true;
                btnUsuarioRedirigir.Visible = true;
                btnCategoriasRedirigir.Visible = true;
                btnEmpresasRedirigir.Visible = true;
                btnArticulosRedirigir.Visible = true;
                btnSistema.Visible = true;
                btnMantenimientos.Visible = true;
                btnAgregarUsuarioRedirigir.Visible = true;
                btnAgregarArticuloRedirigir.Visible = true;
                btnAgregarCategoriaRedirigir.Visible = true;
                btnAgregarEmpresaRedirigir.Visible = true;
                submenuSistema.Location = new Point(3, 325);

            }
            else if (usuSesion.FkTipoUsuario == 3)
            {
                picCampana.Visible = true;
                picCarrito.Visible = true;
                btnReportesRedirigr.Visible = true;
                btnSistema.Visible = true;
                submenuSistema.Location = new Point(3, 155);

            }
            else if (usuSesion.FkTipoUsuario == 4)
            {
                picCampana.Visible = true;
                btnArticulosRedirigir.Visible = true;
                btnAgregarArticuloRedirigir.Visible = true;
                btnAgregarCategoriaRedirigir.Visible = true;
                btnCatalogoRedirigir.Visible = true;
                btnReportesRedirigr.Visible = true;
                btnSistema.Visible = true;
                btnMantenimientos.Visible = true;
                submenuSistema.Location = new Point(3, 225);


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
                picLogo2.Image = val.convertirBytesAImagenes(usuSesion.Logo);

            }
            else
            {

                usuSesion.Logo = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                picLogo2.Image = val.convertirBytesAImagenes(usuSesion.Logo);
            }

            List<Empresa> empresa = ges.mostrarEmpresa(this.cedulaJuridica);

            if (this.cedulaJuridica != -1)
            {
                txtCedulaJuridica.Enabled = false;
                txtCedulaJuridica.Text= empresa[0].CedulaJuridica.ToString();
                txtNombreEmpresa.Text = empresa[0].NombreEmpresa.ToString();
                txtTelefono.Text = empresa[0].Telefono.ToString();

                if (empresa[0].Logo != null)
                {
                    emp.Logo = empresa[0].Logo;
                    picLogo.Image = val.convertirBytesAImagenes(empresa[0].Logo);

                }
                else
                {

                    
                    emp.Logo = val.convertirImagenesABytes(Environment.CurrentDirectory+"/images/imagen-defecto.png");
                    picLogo.Image = val.convertirBytesAImagenes(emp.Logo);
                }

                lbTitulo.Text = "Actualizar Empresa";
                btnAgregarActualizarEmpresa.Text = "Actualizar";
            }
            else
            {
                lbTitulo.Text = "Agregar Empresa";
                btnAgregarActualizarEmpresa.Text = "Agregar";
            }

        }

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();

            if (!string.IsNullOrEmpty(txtCedulaJuridica.Text) &&
                !string.IsNullOrEmpty(txtNombreEmpresa.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text))
            {
                if (!string.IsNullOrEmpty(picLogo.ImageLocation))
                {
                    empresa.Logo = val.convertirImagenesABytes(picLogo.ImageLocation);
                }
                else
                {
                    empresa.Logo = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                }
                

                if (Regex.IsMatch(txtCedulaJuridica.Text, "^[0-9]+$") &&
                    Regex.IsMatch(txtTelefono.Text, "^[0-9]+$"))
                {
                    if (txtCedulaJuridica.Text.Length >= 10)
                    {
                        if (txtTelefono.Text.Length == 8)
                        {
                            empresa.CedulaJuridica = Int64.Parse(txtCedulaJuridica.Text);
                            empresa.Estado = true;
                            empresa.NombreEmpresa = txtNombreEmpresa.Text;
                            empresa.Telefono = Int32.Parse(txtTelefono.Text);

                            bit.FkEmail = usuSesion.Email;

                            bit.FechaInicio = DateTime.Now;
                            bit.FechaFin = DateTime.Now;

                            if (this.cedulaJuridica == -1)
                            {
                                bit.TipoMovimiento = "agregar";
                                bit.DetalleMovimiento = "agregar empresa " + empresa.CedulaJuridica;

                                if (ges.agregarEmpresa(empresa))
                                {
                                    MessageBox.Show("Empresa Agregada con Éxito");
                                }
                                else
                                {
                                    MessageBox.Show("Error al Agregar la Empresa");

                                }
                                ges.agregarBitacora(bit);
                            }
                            else
                            {
                                bit.TipoMovimiento = "actualizar";
                                bit.DetalleMovimiento = "actualizar empresa " + empresa.CedulaJuridica;

                                if (ges.actualizarEmpresa(empresa))
                                {
                                    MessageBox.Show("Empresa Actualizada con Éxito");
                                }
                                else
                                {
                                    MessageBox.Show("Error al Actualizar la Empresa");

                                }
                                ges.agregarBitacora(bit);

                            }

                        }
                        else
                        {
                            MessageBox.Show("El teléfono debe contener 8 dígitos");

                        }
                    }
                    else
                    {
                        MessageBox.Show("La cédula jurídica debe contener al menos 10 dígitos");
                    }
                }
                else
                {
                    MessageBox.Show("La cédula jurídica y el teléfono solo debe contener números");

                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos obligatorios");

            }
        }

        private void btnArticulosRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MostrarArticulos(usuSesion);

            art.Show();
            this.Hide();
        }

        private void btnReportesMenuRedirigir_Click(object sender, EventArgs e)
        {
            Form bit = new MenuReportes(usuSesion, "bit");

            bit.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form ventana = new LogIn();

            ventana.Show();
            this.Hide();
        }

        private void btnAcercaDeRedirigir_Click(object sender, EventArgs e)
        {
            Form acerca = new AcercaDe(usuSesion);

            acerca.Show();
            this.Hide();
        }

        private void btnAyudaRedirigir_Click(object sender, EventArgs e)
        {
            Form ayuda = new Ayuda(usuSesion);

            ayuda.Show();
            this.Hide();
        }

        private void picCarrito_Click(object sender, EventArgs e)
        {
            Form cat = new Catalogo(usuSesion);

            cat.Show();
            this.Hide();
        }

        private void picCampana_Click(object sender, EventArgs e)
        {
            Form ped = new PedidosPendientes(usuSesion);

            ped.Show();
            this.Hide();
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            submenuSistema.Visible = !submenuSistema.Visible;
        }

        private void btnReportesRedirigr_Click(object sender, EventArgs e)
        {
            Form men = new MenuReportes(usuSesion, "norm");

            men.Show();
            this.Hide();
        }
    }
}
