using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class DetalleVenta
    {
        private int idDetalleVenta;
        private string nombre;
        private int cantidad;
        private float precio;
        private float descuento;
        private int fkIdArticulo;
        private int fkIdVenta;
        private int estado;

        public DetalleVenta()
        {

        }
        public DetalleVenta(int _idDetalleVenta,string _nombre,int _cantidad,float _precio,float _descuento,int _fkIdArticulo,int _fkIdVenta,int _estado)
        {
            this.idDetalleVenta = _idDetalleVenta;
            this.nombre = _nombre;
            this.cantidad = _cantidad;
            this.precio = _precio;
            this.descuento = _descuento;
            this.fkIdArticulo = _fkIdArticulo;
            this.fkIdVenta = _fkIdVenta;
            this.estado = _estado;
        }

        public int IdDetalleVenta { get => idDetalleVenta; set => idDetalleVenta = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public int Cantidad { get=>cantidad; set=>cantidad=value; }
        public float Precio { get => precio; set => precio = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public int FkIdArticulo { get => fkIdArticulo; set => fkIdArticulo = value; }
        public int FkIdVenta { get => fkIdVenta; set => fkIdVenta = value; }
        public int Estado { get => estado; set => estado = value; }


    }
}
