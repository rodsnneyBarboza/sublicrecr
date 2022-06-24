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
    public partial class MostrarArticulos : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        private Bitacora bit = new Bitacora();

        public MostrarArticulos(Usuario _usu)
        {
            InitializeComponent();

            this.usuSesion = _usu;

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
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

        private void MostrarArticulos_Click(object sender, EventArgs e)
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

        private void MostrarArticulos_Load(object sender, EventArgs e)
        {
            lbEmail.Text = usuSesion.Email;
            Image img = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            picPerfil.Image = img;
            lbRol.Text = usuSesion.TipoUsuario;

            this.dtgArticulos.DataSource = ges.mostrarArticulo();

            this.dtgArticulos.Columns["Imagen"].Visible = false;
            this.dtgArticulos.Columns["Estado"].Visible = false;
            this.dtgArticulos.Columns["FkIdCategoria"].Visible = false;
            this.dtgArticulos.Columns["FkCedulaJuridica"].HeaderText = "Céd Jurídica";
            this.dtgArticulos.Columns["EstadoLeyenda"].HeaderText = "Estado";

            bit.FkEmail = this.usuSesion.Email;
            bit.TipoMovimiento = "consultar";
            bit.DetalleMovimiento = "consultar artículos";
            bit.FechaInicio = DateTime.Now;
            bit.FechaFin = DateTime.Now;

            ges.agregarBitacora(bit);
        }

        private void btnArticulosRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MostrarArticulos(usuSesion);

            art.Show();
            this.Hide();
        }

        private void dtgArticulos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idArticulo = (int)this.dtgArticulos.Rows[dtgArticulos.CurrentRow.Index].Cells[0].Value;

            AgregarActualizarArticulos art = new AgregarActualizarArticulos(usuSesion, idArticulo);

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
