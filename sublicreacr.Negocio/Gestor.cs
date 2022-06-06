using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Gestor
    {
        public static void agregarCategoria(Categoria cat)
        {
            try
            {
                GestorBase.agregarCategoria(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
