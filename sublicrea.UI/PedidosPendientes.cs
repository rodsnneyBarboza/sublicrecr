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
    public partial class PedidosPendientes : Form
    {

        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        public PedidosPendientes(Usuario _usu)
        {
            this.usuSesion = _usu;

            InitializeComponent();
        }

        private void PedidosPendientes_Load(object sender, EventArgs e)
        {
            List<Empresa> emp = ges.mostrarEmpresaPedidosActivo(usuSesion.FkEmpresa);

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
                btnAgregarEmpresaRedirigir.Visible = true;

                btnMantenimientos.Visible = true;
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
                this.dtgArticulos.Columns["btnRecibido"].Visible = true;
                dtgArticulos.Visible = true;
                lbPedidosPendientes.Visible = true;
                this.dtgArticulos.DataSource = ges.mostrarArticulosPedidosPendientes(this.usuSesion.FkEmpresa);
                this.dtgArticulos.Columns["IdDetalleVenta"].Visible = false;
                this.dtgArticulos.Columns["Descuento"].Visible = false;
                this.dtgArticulos.Columns["FkIdArticulo"].Visible = false;
                this.dtgArticulos.Columns["FkIdVenta"].Visible = false;
                this.dtgArticulos.Columns["btnRecibido"].DisplayIndex = this.dtgArticulos.Columns.Count - 1;

            }
            else if (usuSesion.FkTipoUsuario == 4)
            {
                btnAgregarArticuloRedirigir.Visible = true;
                btnMantenimientos.Visible = true;
                btnCategoriasRedirigir.Visible = true;
                btnAgregarCategoriaRedirigir.Visible = true;
                picCampana.Visible = true;
                pSubMenu.Location = new Point(5, 134);
                this.dtgArticulos.Columns["btnAceptar"].Visible = true;
                this.dtgArticulos.Columns["btnRechazar"].Visible = true;
                cbPedidosClientes.Visible = true;
                lbClientesPedidos.Visible = true;


            }

            lbEmail.Text = usuSesion.Email;

            lbRol.Text = usuSesion.TipoUsuario;
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

            //opcion por defecto combobox proveedores
            cbPedidosClientes.Items.Add("Seleccione");
            cbPedidosClientes.SelectedItem = "Seleccione";

            for (int i = 0; i < emp.Count; i++)
            {
                cbPedidosClientes.Items.Add(emp[i].CedulaJuridica.ToString() + " - " + emp[i].NombreEmpresa.ToString());
            }
        }

        private void cbPedidosClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            Empresa pro = new Empresa();
            DetalleVenta det = new DetalleVenta();
            //si seleciona otro diferente al valor seleccionar me muestra los datagridviews

            if (!cbPedidosClientes.Text.Contains("Seleccione"))
            {
                if (ges.eliminarVentasErroneas())
                {
                    pro.CedulaJuridica = long.Parse(cbPedidosClientes.Text.Split(' ')[0]);

                    this.dtgArticulos.DataSource = ges.mostrarArticulosPedidosPendientes(pro.CedulaJuridica);
                    dtgArticulos.Visible = true;
                    lbPedidosPendientes.Visible = true;
                    this.dtgArticulos.Columns["btnRechazar"].DisplayIndex = this.dtgArticulos.Columns.Count - 1;
                    this.dtgArticulos.Columns["btnAceptar"].DisplayIndex = this.dtgArticulos.Columns.Count - 2;


                }
            }
        }

        private void dtgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DetalleVenta det = new DetalleVenta();
            det.IdDetalleVenta = Int16.Parse(this.dtgArticulos.Rows[dtgArticulos.CurrentRow.Index].Cells["IdDetalleVenta"].Value.ToString());
            
            if (this.dtgArticulos.Columns[e.ColumnIndex].Name == "btnAceptar")
            {
                det.Estado = 1;
                det.FkIdArticulo = Int16.Parse(this.dtgArticulos.Rows[dtgArticulos.CurrentRow.Index].Cells["FkIdArticulo"].Value.ToString());
                det.Cantidad = Int16.Parse(this.dtgArticulos.Rows[dtgArticulos.CurrentRow.Index].Cells["cantidad"].Value.ToString());
                if (ges.actualizarDetalleVentaEstado(det))
                {
                    ges.actualizarInventario(det);
                }
            }
            else if(this.dtgArticulos.Columns[e.ColumnIndex].Name == "btnRechazar")
            {
                det.Estado = 2;
                ges.actualizarDetalleVentaEstado(det);

            }
            else if(this.dtgArticulos.Columns[e.ColumnIndex].Name == "btnRecibido")
            {
                det.Estado = 3;
                ges.actualizarDetalleVentaEstado(det);

            }

        }
    }
}
