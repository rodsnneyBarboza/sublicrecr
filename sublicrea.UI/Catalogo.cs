using sublicreacr.Negocio;
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

namespace sublicrea.UI
{
    public partial class Catalogo : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        DateTimePicker oDateTimePicker;
        public Catalogo(Usuario _usu)
        {
            InitializeComponent();

            this.usuSesion = _usu;
        }

        public Catalogo()
        {
            InitializeComponent();
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            pSubMenu.Visible = !pSubMenu.Visible;

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

        private void Catalogo_Click(object sender, EventArgs e)
        {
            Form cat = new Catalogo(usuSesion);

            cat.Show();
            this.Hide();
        }

        
        private void btnAgregarEmpresaRedirigir_Click(object sender, EventArgs e)
        {
            Form emp = new AgregarActualizarEmpresa(usuSesion);

            emp.Show();
            this.Hide();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Catalogo ventana = new Catalogo(usuSesion);
            this.Hide();
            ventana.Show();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            //variables
            List<Empresa> emp = ges.mostrarProveedores();

            //muestra toda la información del usuarop en el menú de navegación
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
            //valida si la imagen de perfil es vacía para cargar la imagen por defecto 

            if (usuSesion.FotoPerfil != null)
            {
                picPerfil.Image = val.convertirBytesAImagenes(usuSesion.FotoPerfil);

            }
            else
            {
                usuSesion.FotoPerfil = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                picPerfil.Image = val.convertirBytesAImagenes(usuSesion.FotoPerfil);
            }

            //valida si el logo es vacío para cargar la imagen por defecto 
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
            cbProveedor.Items.Add("Seleccione");
            cbProveedor.SelectedItem = "Seleccione";

            //cargar combobox de proveedores

            for (int i = 0; i < emp.Count; i++)
            {
                cbProveedor.Items.Add(emp[i].CedulaJuridica.ToString() + " - " + emp[i].NombreEmpresa.ToString());
            }
        }

        private void btnUsuariosRedirigir_Click(object sender, EventArgs e)
        {
            MostrarUsuarios usu = new MostrarUsuarios(usuSesion);

            usu.Show();

            this.Hide();
        }

        private void btnCategoriasRedirigir_Click(object sender, EventArgs e)
        {
            MostrarCategorias cat = new MostrarCategorias(usuSesion);

            cat.Show();

            this.Hide();
        }

        private void btnEmpresasRedirigir_Click(object sender, EventArgs e)
        {
            MostrarEmpresas emp = new MostrarEmpresas(usuSesion);

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

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            //si devuelve verdadero al crear el pedido en la bd hace visible lo demás
            lbProveedor.Visible = true;
            cbProveedor.Visible = true;
        }


        private void cbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            Empresa pro = new Empresa();
            Venta ven = new Venta();
            //si seleciona otro diferente al valor seleccionar me muestra los datagridviews

            dtgOrdenarArticulos.Visible = false;
            lbOrdenarArticulos.Visible = false;
            dtgArticulosPedidos.Visible = false;
            lbArticulosPedidos.Visible = false;
            lbArticulosPedidos.Visible = false;

            if (!cbProveedor.Text.Contains("Seleccione"))
            {
                if (ges.eliminarVentasErroneas())
                {
                    pro.CedulaJuridica = long.Parse(cbProveedor.Text.Split(' ')[0]);

                    this.dtgOrdenarArticulos.DataSource = ges.mostrarArticuloProveedor(pro.CedulaJuridica);
                    dtgOrdenarArticulos.Visible = true;
                    lbOrdenarArticulos.Visible = true;
                    dtgArticulosPedidos.Visible = true;
                    lbArticulosPedidos.Visible = true;

                    this.dtgOrdenarArticulos.Columns["Imagen"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["Estado"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["FechaActualizacion"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["FkCedulaJuridica"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["FkIdCategoria"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["EstadoLeyenda"].Visible = false;
                    this.dtgOrdenarArticulos.Columns["CantidadDisponible"].HeaderText = "Cantidad Disponible";
                    this.dtgOrdenarArticulos.Columns["txtCantidad"].DisplayIndex = this.dtgOrdenarArticulos.Columns.Count - 2;
                    this.dtgOrdenarArticulos.Columns["btnAceptar"].DisplayIndex = this.dtgOrdenarArticulos.Columns.Count - 1;


                    ven.Impuesto = 0.14f;
                    ven.FechaVenta = DateTime.Now;
                    ven.Total = 0;
                    ven.Estado = false;
                    ven.FechaEntrega = DateTime.Now;
                    ven.FkEmailComprador = usuSesion.Email;
                    ven.FkCedulaJuridicaVendedor = pro.CedulaJuridica;

                    ges.agregarVenta(ven);
                }
            }
        }

        private void dtgOrdenarArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DetalleVenta det = new DetalleVenta();
            Venta ven = new Venta();

            if (this.dtgOrdenarArticulos.Columns[e.ColumnIndex].Name == "btnAceptar")
            {
                if (this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["txtCantidad"].Value != null)
                {
                    if(Regex.IsMatch(this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["txtCantidad"].Value.ToString(), "^[0-9]+$"))
                    {
                        det.Cantidad = Int16.Parse(this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["txtCantidad"].Value.ToString());

                        if (det.Cantidad > 0 
                            && det.Cantidad <=Int16.Parse(this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["CantidadDisponible"].Value.ToString()))
                        {
                            det.Precio = float.Parse(this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["PrecioVenta"].Value.ToString())*det.Cantidad;
                            det.Descuento = 0;
                            det.FkIdArticulo = Int16.Parse(this.dtgOrdenarArticulos.Rows[dtgOrdenarArticulos.CurrentRow.Index].Cells["IdArticulo"].Value.ToString());
                            det.FkIdVenta = Int16.Parse(ges.mostrarVentaActual()[0].IdVenta.ToString());
                            det.Estado = 0;
                            if (ges.agregarDetalleVenta(det))
                            {

                                ven = ges.mostrarVentas(det.FkIdVenta)[0];
                                ven.Total += det.Precio;

                                ges.actualizarTotalFinal(ven);

                                lbTotal.Text = "Total: " + ven.Total.ToString();
                                dtgArticulosPedidos.DataSource = ges.mostrarArticulosPedidos(det.FkIdVenta);
                                this.dtgArticulosPedidos.Columns["btnEliminar"].DisplayIndex = this.dtgArticulosPedidos.Columns.Count - 1;


                                lbTotal.Visible = true;

                            }

                        }
                        else
                        {
                            MessageBox.Show("La cantidad debe ser mayor a 0 y menor o igual a la cantidad disponible");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no puede contener letras");
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad no puede estar vacía");

                }

            }
        }

        private void dtgArticulosPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DetalleVenta det = new DetalleVenta();

            if (this.dtgArticulosPedidos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                det.IdDetalleVenta = Int16.Parse(this.dtgArticulosPedidos.Rows[dtgArticulosPedidos.CurrentRow.Index].Cells["IdDetalleVenta"].Value.ToString());
                det.FkIdVenta = ges.mostrarVentaActual()[0].IdVenta;

                if (ges.eliminarDetalleVenta(det.IdDetalleVenta))
                {
                    dtgArticulosPedidos.DataSource = ges.mostrarArticulosPedidos(det.FkIdVenta);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el artículo");
                }
            }

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
