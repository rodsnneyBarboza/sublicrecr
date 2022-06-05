using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    class DetalleVenta
    {
        private int cantidad;
        private float precio;
        private float descuento;
        private int fkIdArticulo;
        private int fkIdVenta;

        public DetalleVenta(int _cantidad,float _precio,float _descuento,int _fkIdArticulo,int _fkIdVenta)
        {
            this.cantidad = _cantidad;
            this.precio = _precio;
            this.descuento = _descuento;
            this.fkIdArticulo = _fkIdArticulo;
            this.fkIdVenta = _fkIdVenta;
        }

        public int Cantidad { get=>cantidad; set=>cantidad=value; }
        public float Precio { get => precio; set => precio = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public int FkIdArticulo { get => fkIdArticulo; set => fkIdArticulo = value; }
        public int FkIdVenta { get => fkIdVenta; set => fkIdVenta = value; }




    }
}
