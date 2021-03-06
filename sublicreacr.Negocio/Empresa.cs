using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    class Empresa
    {
        private int cedulaJuridica;
        private string nombreEmpresa;
        private int telefono;
        private byte[] logo;
        private bool estado;

        public Empresa(int _cedulaJuridica,string _nombreEmpresa,int _telefono,byte[] _logo, bool _estado)
        {
            this.cedulaJuridica = _cedulaJuridica;
            this.nombreEmpresa = _nombreEmpresa;
            this.telefono = _telefono;
            this.logo = _logo;
            this.estado = _estado;
        }
        public int CedulaJuridica { get=>cedulaJuridica; set=>cedulaJuridica=value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public byte[] Logo { get => logo; set => logo = value; }
        public bool Estado { get => estado; set => estado = value; }




    }
}
