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
    public partial class AgregarActualizarArticulos : Form
    {
        private Validaciones val= new Validaciones();
        private Gestor ges = new Gestor();
        private Usuario usuSesion = new Usuario();
        private Articulo art = new Articulo();
        private int idArticulo;
        private Bitacora bit = new Bitacora();

        public AgregarActualizarArticulos(Usuario _usu, int _idArticulo=-1)
        {
            InitializeComponent();
            this.usuSesion = _usu;

            this.idArticulo = _idArticulo;



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
                    picArticulo.ImageLocation = img;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void btnAgregarUsuarioRedirigir_Click(object sender, EventArgs e)
        {
            Form usu = new AgregarActualizarUsuario(usuSesion);
        
            usu.Show();
            this.Hide();


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

   

        private void btnAgregarActualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreArticulo.Text) &&
                !string.IsNullOrEmpty(txtPrecioVenta.Text) &&
                !string.IsNullOrEmpty(txtCantidadDisponible.Text))
            {
                if (!string.IsNullOrEmpty(picArticulo.ImageLocation))
                {
                    art.Imagen = val.convertirImagenesABytes(picArticulo.ImageLocation);
                }
                else
                {

                    art.Imagen = val.convertirImagenesABytes(Environment.CurrentDirectory + "/images/imagen-defecto.png");
                    picArticulo.Image = val.convertirBytesAImagenes(art.Imagen);
                }

                    if(Regex.IsMatch(txtNombreArticulo.Text, @"^[a-zA-Z]+$"))
                    {
                        if (Regex.IsMatch(txtCantidadDisponible.Text, "^[0-9]+$")
                            && Regex.IsMatch(txtPrecioVenta.Text, "^[0-9]+$"))
                        {
                        if (Int64.Parse(txtCantidadDisponible.Text) > 0 && Decimal.Parse(txtPrecioVenta.Text) > 0)
                        {
                            if (!cbCategoria.Text.Equals("Seleccione"))
                            {
                                art.Nombre = txtNombreArticulo.Text;
                                art.CantidadDisponible = Int32.Parse(txtCantidadDisponible.Text);
                                art.PrecioVenta = float.Parse(txtPrecioVenta.Text);
                                art.FechaActualizacion = DateTime.Now;
                                art.FkCedulaJuridica = usuSesion.FkEmpresa;
                                art.FkIdCategoria = Int32.Parse(cbCategoria.Text.Substring(0, 1));
                                art.Estado = true;

                                bit.FkEmail = this.usuSesion.Email;
                                bit.FechaInicio = DateTime.Now;
                                bit.FechaFin = DateTime.Now;


                                if (this.idArticulo == -1)
                                {
                                    bit.TipoMovimiento = "agregar";
                                    bit.DetalleMovimiento = "agregar articulo "+art.Nombre;
                                    if (ges.agregarArticulo(art))
                                    {
                                        MessageBox.Show("Artículo Agregado con Éxito");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al Agregar el Artículo");

                                    }
                                    ges.agregarBitacora(bit);

                                }
                                else
                                {
                                    bit.TipoMovimiento = "actualizar";
                                    bit.DetalleMovimiento = "actualizar articulo " + art.Nombre;
                                    art.IdArticulo = Int32.Parse(txtIddArticulo.Text);

                                    if (ges.actualizarArticulo(art))
                                    {
                                        MessageBox.Show("Artículo Actualizado con Éxito");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al Actualizar el Artículo");

                                    }
                                    ges.agregarBitacora(bit);


                                }
                            }
                            else
                            {
                                MessageBox.Show("seleccione una categoria");

                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad del artículo y el precio de venta deben de ser mayor a 0");
                        }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad del articulo y el precio solo debe contener números");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre del artículo no debe contener números");
                    }
                
            }
            else
            {
                MessageBox.Show("Debe completar los campos obligatorios");
            }
        }

     


        private void AgregarActualizarArticulos_Load(object sender, EventArgs e)
        {
            List<Categoria> cat = ges.mostrarCategoria();
            List<Articulo> articulo = ges.mostrarArticulo(this.idArticulo);


            cbCategoria.Items.Add("Seleccione");
            cbCategoria.SelectedItem = "Seleccione";
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


            for (int i=0; i < cat.Count; i++)
            {
                cbCategoria.Items.Add(cat[i].IdCategoria.ToString()+" - "+cat[i].NombreCategoria.ToString());
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

            if (this.idArticulo != -1)
            {
                List<Categoria> categoriaSeleccionada = ges.mostrarCategoria(articulo[0].FkIdCategoria);

                txtIddArticulo.Visible = true;
                txtIddArticulo.Enabled = false;
                lbIdArticulo.Visible = true;
                txtIddArticulo.Text = articulo[0].IdArticulo.ToString();
                txtNombreArticulo.Text = articulo[0].Nombre.ToString();
                txtCantidadDisponible.Text = articulo[0].CantidadDisponible.ToString();
                txtPrecioVenta.Text = articulo[0].PrecioVenta.ToString();
                picArticulo.Image = val.convertirBytesAImagenes(articulo[0].Imagen);
                string cbCategoria2 = categoriaSeleccionada[0].IdCategoria.ToString() + " - " + categoriaSeleccionada[0].NombreCategoria.ToString();

                cbCategoria.Text = cbCategoria2;

                art.Imagen = articulo[0].Imagen;
                lbTitulo.Text = "Actualizar Artículo";
                btnAgregarActualizarArticulo.Text = "Actualizar";
            }
            else
            {
                lbTitulo.Text = "Agregar Artículo";
                btnAgregarActualizarArticulo.Text = "Agregar";
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
            Form bit = new MenuReportes(usuSesion);
            
            bit.Show();
            this.Hide();
        }

        private void btnReportesRedirigr_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form ventana = new LogIn();

            ventana.Show();
            this.Hide();
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {

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
    }
}
