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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;

namespace sublicrea.UI
{
    public partial class ReportesBitacoras : Form
    {
        private Usuario usuSesion = new Usuario();
        private Validaciones val = new Validaciones();
        private Gestor ges = new Gestor();
        string tipoReporte;
        private DataGridView exportarBitacora = new DataGridView();


        public ReportesBitacoras(Usuario _usu, string _tipoReporte)
        {
            InitializeComponent();

            this.usuSesion = _usu;
            this.tipoReporte = _tipoReporte;
        }

        private void ReportesBitacoras_Load(object sender, EventArgs e)
        {
            List<Bitacora> bitacora;
            bitacora = ges.mostrarBitacora();

            List<string> movimientos = new List<string>();
            List<string> correos = new List<string>();


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
                btnAgregarEmpresaRedirigir.Visible = true;

                btnMantenimientos.Visible = true;

            }
            else if (usuSesion.FkTipoUsuario == 2)
            {
                btnReportesRedirigr.Visible = true;
                btnAgregarArticuloRedirigir.Visible = true;
                btnArticulosRedirigir.Visible = true;
                btnMantenimientos.Visible = true;
                pSubMenu.Location = new System.Drawing.Point(5, 134);


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
                pSubMenu.Location = new System.Drawing.Point(5, 134);

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

            cbTipoMovimiento.Items.Add("Seleccione");
            cbEmailReporte.Items.Add("Seleccione");


            cbEmailReporte.SelectedItem = "Seleccione";
            cbTipoMovimiento.SelectedItem = "Seleccione";




            for (int i = 0; i < bitacora.Count; i++)
            {
                movimientos.Add(bitacora[i].TipoMovimiento.ToString());
                correos.Add(bitacora[i].FkEmail.ToString());

            }

            //remover los duplicados
            movimientos = movimientos.Distinct().ToList();
            correos = correos.Distinct().ToList();

          

            for (int i = 0; i < correos.Count(); i++)
            {
                cbEmailReporte.Items.Add(correos[i].ToString());
            }

            if (this.tipoReporte.Equals("rms"))
            {
                //llenar el combobox
                for (int i = 0; i < movimientos.Count(); i++)
                {
                    cbTipoMovimiento.Items.Add(movimientos[i].ToString());
                }


                cbTipoMovimiento.Visible = true;
                lbTipoMovimiento.Visible = true;
                lbTituloReportes.Text = "Reporte Movimientos del Sistema";

            }
            else
            {
                lbTituloReportes.Text = "Reporte Entrada y Salida";

            }

        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Catalogo ventana = new Catalogo(usuSesion);
            this.Hide();
            ventana.Show();
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            pSubMenu.Visible = !pSubMenu.Visible;

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

        private void btnReportesMenuRedirigir_Click(object sender, EventArgs e)
        {
            Form art = new MenuReportes(usuSesion);

            art.Show();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Bitacora bitReporte = new Bitacora();

            if (!cbEmailReporte.Equals("Seleccione"))
            {
                bitReporte.FkEmail = cbEmailReporte.Text;
            }
            else
            {
                bitReporte.FkEmail = "n/a";

            }

            if (!cbTipoMovimiento.Equals("Seleccione") && this.tipoReporte.Equals("rms"))
            {
                bitReporte.TipoMovimiento = cbTipoMovimiento.Text;

            }
            else
            {
                bitReporte.TipoMovimiento = "login";

            }

            if (dtpFechaFin.Value.Date >= dtpFechaInicio.Value.Date)
            {
                bitReporte.FechaInicio = dtpFechaInicio.Value.Date;
                bitReporte.FechaFin = dtpFechaFin.Value.Date;

                dtgReportesBitacora.DataSource = ges.mostrarBitacora(bitReporte);
                this.exportarBitacora.DataSource = ges.mostrarBitacora(bitReporte);

                if (ges.mostrarBitacora(bitReporte).Count>0)
                {
                    btnExportarExcel.Visible = true;
                    btnExportarPDF.Visible = true;
                }
                else
                {
                    btnExportarExcel.Visible = false;
                    btnExportarPDF.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio debe ser mayor a la fecha final");
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dtgReportesBitacora.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dtgReportesBitacora.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dtgReportesBitacora.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dtgReportesBitacora.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            XLWorkbook libro = new XLWorkbook();
       
            foreach (DataGridViewColumn column in dtgReportesBitacora.Columns)
            {
                dt.Columns.Add(column.HeaderText);//, column.ValueType
            }
            // storing Each row and column value to excel sheet  
            foreach (DataGridViewRow row in dtgReportesBitacora.Rows)
            {
                if (dtgReportesBitacora.Rows.Count - 1 > row.Index)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }
            // save the application  
            libro.Worksheets.Add(dt,"test1");
            libro.SaveAs(@"C:\Users\rodsn\OneDrive\Desktop\test.xlsx");
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
    }
}
