using sublicreacr.Negocio;
using System;
using System.Collections;
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
    public partial class MostrarUsuarios : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        private Bitacora bit = new Bitacora();

        public MostrarUsuarios(Usuario _usu)
        {
            InitializeComponent();
            this.usuSesion = _usu;

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

        private void MostrarUsuarios_Click(object sender, EventArgs e)
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

        private void MostrarUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                lbEmail.Text = usuSesion.Email;
                Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
                picPerfil.Image = img;
                lbRol.Text = usuSesion.TipoUsuario;

                this.dtgUsuarios.DataSource = ges.mostrarUsuarios();

                this.dtgUsuarios.Columns["fotoPerfil"].Visible = false;
                this.dtgUsuarios.Columns["contrasena"].Visible = false;
                this.dtgUsuarios.Columns["verificacionContrasena"].Visible = false;
                this.dtgUsuarios.Columns["FkTipoUsuario"].Visible = false;
                this.dtgUsuarios.Columns["FkEmpresa"].Visible = false;
                this.dtgUsuarios.Columns["TipoUsuario"].Visible = false;
                this.dtgUsuarios.Columns["Estado"].Visible = false;
                this.dtgUsuarios.Columns["EstadoLeyenda"].HeaderText = "Estado";

                bit.FkEmail = this.usuSesion.Email;
                bit.TipoMovimiento = "consultar";
                bit.DetalleMovimiento = "consultar usuarios";
                bit.FechaInicio = DateTime.Now;
                bit.FechaFin = DateTime.Now;

                ges.agregarBitacora(bit);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string emailEmpleado = this.dtgUsuarios.Rows[dtgUsuarios.CurrentRow.Index].Cells[0].Value.ToString();

            AgregarActualizarUsuario usu = new AgregarActualizarUsuario(usuSesion,emailEmpleado);

            usu.Show();
            this.Hide();
        }

        private void btnArticulosRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MostrarArticulos(usuSesion);

            art.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCategoriaRedirigir_Click(object sender, EventArgs e)
        {
            Form arti = new AgregarActualizarCategoria(usuSesion);

            arti.Show();
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
