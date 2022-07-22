﻿using sublicreacr.Negocio;
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
    public partial class MostrarCategorias : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        private Bitacora bit = new Bitacora();

        public MostrarCategorias(Usuario _usu)
        {
            InitializeComponent();

            this.usuSesion = _usu;

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
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

        private void MostrarCategorias_Click(object sender, EventArgs e)
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

        private void MostrarCategorias_Load(object sender, EventArgs e)
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
                picLogo.Image = val.convertirBytesAImagenes(usuSesion.Logo);

            }
            else
            {

                usuSesion.Logo = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                picLogo.Image = val.convertirBytesAImagenes(usuSesion.Logo);
            }

            this.dtgCategorias.DataSource = ges.mostrarCategoria();

            bit.FkEmail = this.usuSesion.Email;
            bit.TipoMovimiento = "consultar";
            bit.DetalleMovimiento = "consultar categorías";
            bit.FechaInicio = DateTime.Now;
            bit.FechaFin = DateTime.Now;

            ges.agregarBitacora(bit);


        }

        private void dtgCategorias_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idCategoria = (int)this.dtgCategorias.Rows[dtgCategorias.CurrentRow.Index].Cells[0].Value;

            AgregarActualizarCategoria cat = new AgregarActualizarCategoria(usuSesion, idCategoria);

            cat.Show();
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
