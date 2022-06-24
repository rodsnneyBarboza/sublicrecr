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
    public partial class AgregarActualizarCategoria : Form
    {
        private Validaciones val = new Validaciones();
        private Usuario usuSesion = new Usuario();
        private Gestor ges = new Gestor();
        private int idCategoria;
        private Bitacora bit = new Bitacora();

        public AgregarActualizarCategoria(Usuario _usu,int _idCategoria=-1)
        {
            InitializeComponent();
            this.usuSesion = _usu;
            this.idCategoria = _idCategoria;
           

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

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreCategoria.Text))
            {
                if (Regex.IsMatch(txtNombreCategoria.Text, @"^[a-zA-Z]+$"))
                {
                    Categoria cat = new Categoria();

                    cat.NombreCategoria = txtNombreCategoria.Text;


                    bit.FkEmail = usuSesion.Email;
                   
                    bit.FechaInicio = DateTime.Now;
                    bit.FechaFin = DateTime.Now;


                    if (this.idCategoria == -1)
                    {
                        bit.TipoMovimiento = "agregar";
                        bit.DetalleMovimiento = "agregar categoría " + cat.NombreCategoria;
                        ges.agregarBitacora(bit);

                        ges.agregarCategoria(cat);
                    }
                    else
                    {
                        cat.IdCategoria = Int32.Parse(txtIdCategoria.Text);
                        bit.TipoMovimiento = "actualizar";
                        bit.DetalleMovimiento = "actualizar categoría " + cat.NombreCategoria;
                        ges.agregarBitacora(bit);

                        ges.actualizarCategoria(cat);

                    }

                }
                else
                {
                    MessageBox.Show("El nombre de la categoría no debe contener números");

                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos obligatorios");

            }
        }

        private void AgregarActualizarCategoria_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;
            List<Categoria> cat = ges.mostrarCategoria(this.idCategoria);

            if (this.idCategoria != -1)
            {
                txtIdCategoria.Visible = true;
                txtIdCategoria.Enabled = false;
                lbIdCategoria.Visible = true;
                txtIdCategoria.Text = cat[0].IdCategoria.ToString();
                txtNombreCategoria.Text = cat[0].NombreCategoria;
                lbTitulo.Text = "Actualizar Categoría";
                btnAgregarActualizarCategoria.Text = "Actualizar";
            }
            else
            {
                lbTitulo.Text = "Agregar Categoría";
                btnAgregarActualizarCategoria.Text = "Agregar";
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
            Form art = new MenuReportes(usuSesion);

            art.Show();
            this.Hide();
        }
    }
}
