using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Venta
    {
        private int idVenta;
        private float impuesto;
        private DateTime fechaVenta;
        private float total;
        private bool estado;
        private byte[] archivoFactura;
        private DateTime fechaEntrega;
        private string fkEmailComprador;
        private long fkCedulaJuridicaVendedor;

        public Venta()
        {

        }
        public Venta(int _idVenta,float _impuesto,DateTime _fechaVenta,float _total,bool _estado,byte[] _archivoFactura
                    ,DateTime _fechaEntrega,string _fkEmailComprador,long _fkCedulaJuridicaVendedor)
        {
            this.idVenta = _idVenta;
            this.impuesto = _impuesto;
            this.fechaVenta = _fechaVenta;
            this.total = _total;
            this.estado = _estado;
            this.archivoFactura = _archivoFactura;
            this.fechaEntrega = _fechaEntrega;
            this.fkEmailComprador = _fkEmailComprador;
            this.fkCedulaJuridicaVendedor = _fkCedulaJuridicaVendedor;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public float Impuesto { get=>impuesto; set=>impuesto=value; }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public float Total { get => total; set => total = value; }
        public bool Estado { get => estado; set => estado = value; }
        public byte[] ArchivoFactura { get => archivoFactura; set => archivoFactura = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public string FkEmailComprador { get => fkEmailComprador; set => fkEmailComprador = value; }
        public long FkCedulaJuridicaVendedor { get => fkCedulaJuridicaVendedor; set => fkCedulaJuridicaVendedor = value; }







    }
}
