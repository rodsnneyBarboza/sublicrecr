using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Articulo
    {
        private string nombre;
        private float precioVenta;
        private int cantidadDisponible;
        private byte[] imagen;
        private bool estado;
        private DateTime fechaActualizacion;
        private int fkCedulaJuridica;
        private int fkIdCategoria;

        public Articulo()
        {

        }
        public Articulo(string _nombre,float _precioVenta,int _cantidadDisponible,byte[] _imagen
            ,bool _estado,DateTime _fechaActualizacion,int _fkCedulaJuridica,int _fkIdCategoria)
        {
            this.nombre = _nombre;
            this.precioVenta = _precioVenta;
            this.cantidadDisponible = _cantidadDisponible;
            this.imagen = _imagen;
            this.estado = _estado;
            this.fechaActualizacion = _fechaActualizacion;
            this.fkCedulaJuridica = _fkCedulaJuridica;
            this.fkIdCategoria = _fkIdCategoria;
        }

        public string Nombre { get=>nombre; set=>nombre=value; }
        public float PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        public int FkCedulaJuridica { get => fkCedulaJuridica; set => fkCedulaJuridica = value; }
        public int FkIdCategoria { get => fkIdCategoria; set => fkIdCategoria = value; }







    }
}
