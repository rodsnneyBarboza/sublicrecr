using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sublicreacr.Negocio;

namespace sublicrea.UI
{
    public partial class AgregarActualizarCategoria : Form
    {
        private Validaciones val = new Validaciones();
        public AgregarActualizarCategoria()
        {
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = val.validarSoloNumerosOLetras(e, "l");

        }
    }
}
