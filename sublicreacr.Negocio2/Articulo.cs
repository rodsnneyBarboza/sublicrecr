using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Articulo
    {
        private int idArticulo;
        private string nombre;
        private float precioVenta;
        private int cantidadDisponible;
        private byte[] imagen;
        private bool estado;
        private string estadoLeyenda;
        private DateTime fechaActualizacion;
        private long fkCedulaJuridica;
        private int fkIdCategoria;
        public Articulo()
        {

        }
        public Articulo(int _idArticulo,string _nombre,float _precioVenta,int _cantidadDisponible,byte[] _imagen
            ,bool _estado,DateTime _fechaActualizacion,long _fkCedulaJuridica,int _fkIdCategoria
            ,string _estadoLeyenda)
        {
            this.idArticulo = _idArticulo;
            this.nombre = _nombre;
            this.precioVenta = _precioVenta;
            this.cantidadDisponible = _cantidadDisponible;
            this.imagen = _imagen;
            this.estado = _estado;
            this.fechaActualizacion = _fechaActualizacion;
            this.fkCedulaJuridica = _fkCedulaJuridica;
            this.fkIdCategoria = _fkIdCategoria;
            this.estadoLeyenda = _estadoLeyenda;

        }

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }

        public string Nombre { get=>nombre; set=>nombre=value; }
        public float PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        public long FkCedulaJuridica { get => fkCedulaJuridica; set => fkCedulaJuridica = value; }
        public int FkIdCategoria { get => fkIdCategoria; set => fkIdCategoria = value; }
        public string EstadoLeyenda { get => estadoLeyenda; set => estadoLeyenda = value; }







    }
}
