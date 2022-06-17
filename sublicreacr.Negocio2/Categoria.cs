using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Categoria
    {
        private int idCategoria;
        private string nombreCategoria;


        public Categoria(int _idCategoria,string _nombreCategoria)
        {
            this.nombreCategoria = _nombreCategoria;
            this.idCategoria = _idCategoria;
        }

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }

        public string NombreCategoria { get=>nombreCategoria; set=>nombreCategoria=value; }
    }
}
