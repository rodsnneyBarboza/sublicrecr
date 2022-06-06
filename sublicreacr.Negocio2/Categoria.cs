using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Categoria
    {
        private string nombreCategoria;

        public Categoria(string _nombreCategoria)
        {
            this.nombreCategoria = _nombreCategoria;
        }

        public string NombreCategoria { get=>nombreCategoria; set=>nombreCategoria=value; }
    }
}
