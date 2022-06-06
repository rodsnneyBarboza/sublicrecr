using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    class TipoUsuario
    {
        private string nombreTipoUsuario;

        public TipoUsuario(string _nombreTipoUsuario)
        {
            this.nombreTipoUsuario = _nombreTipoUsuario;
        }

        public string NombreTipoUsuario { get=>nombreTipoUsuario; set=>nombreTipoUsuario=value; }
    }
}
