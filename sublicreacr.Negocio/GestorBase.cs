using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sublicreacr.Datos;

namespace sublicreacr.Negocio
{
    class GestorBase
    {
        public static void agregarCategoria(Categoria cat)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_CATEGORIA(nombre_categoria) VALUES(@nombre_categoria)";
                Parameter[] parametros =
                {
                    new Parameter("@nombre_categoria",cat.NombreCategoria)
                };

                Database.exectuteNonQuery(sentencia, parametros);
                

            }catch(SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
            }

        }
    }
}
