using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class TipoUsuario
    {
        private int idTipoUsuario;
        private string nombreTipoUsuario;

        public TipoUsuario(int _idTipoUsuario,string _nombreTipoUsuario)
        {
            this.idTipoUsuario = _idTipoUsuario;
            this.nombreTipoUsuario = _nombreTipoUsuario;
        }
        public int IdTipoUsuario { get => idTipoUsuario; set => idTipoUsuario = value; }

        public string NombreTipoUsuario { get=>nombreTipoUsuario; set=>nombreTipoUsuario=value; }
    }
}
