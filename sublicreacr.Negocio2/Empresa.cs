using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Empresa
    {
        private long cedulaJuridica;
        private string nombreEmpresa;
        private long telefono;
        private byte[] logo;
        private bool estado;
        private string estadoLeyenda;

        public Empresa(long _cedulaJuridica,string _nombreEmpresa,long _telefono,byte[] _logo
            , bool _estado, string _estadoLeyenda)
        {
            this.cedulaJuridica = _cedulaJuridica;
            this.nombreEmpresa = _nombreEmpresa;
            this.telefono = _telefono;
            this.logo = _logo;
            this.estado = _estado;
            this.estadoLeyenda = _estadoLeyenda;
        }

        public Empresa() 
        { 
        }
        public long CedulaJuridica { get=>cedulaJuridica; set=>cedulaJuridica=value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public byte[] Logo { get => logo; set => logo = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string EstadoLeyenda { get => estadoLeyenda; set => estadoLeyenda = value; }





    }
}
