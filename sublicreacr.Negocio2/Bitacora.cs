using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    class Bitacora
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string tipoMovimiento;
        private string detalleMovimiento;
        private string fkEmail;

        public Bitacora(DateTime _fechaInicio, DateTime _fechaFin,string _tipoMovimiento, 
            string _detalleMovimiento, string _fkEmail)
        {
            this.fechaInicio = _fechaInicio;
            this.fechaFin = _fechaFin;
            this.tipoMovimiento = _tipoMovimiento;
            this.detalleMovimiento = _detalleMovimiento;
            this.fkEmail = _fkEmail;
        }

        public DateTime FechaInicio { get=>fechaInicio; set=>fechaInicio=value; }
        public DateTime FechaFin{ get => fechaFin; set => fechaFin = value; }
        public string TipoMovimiento { get => tipoMovimiento; set => tipoMovimiento = value; }
        public string DetalleMovimiento { get => detalleMovimiento; set => detalleMovimiento = value; }
        public string FkEmail { get => fkEmail; set => fkEmail = value; }





    }
}
