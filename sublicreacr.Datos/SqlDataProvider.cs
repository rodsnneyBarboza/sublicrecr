using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Datos
{
    class SqlDataProvider:DataProvider
    {
        public System.Data.IDbConnection connection(String stringConnection)
        {
            return new SqlConnection(stringConnection);
        }

        public System.Data.IDbDataAdapter adapter(String commad, System.Data.IDbConnection connection)
        {
            return new SqlDataAdapter(commad, (SqlConnection)connection);
        }

        public System.Data.IDbCommand command(String command)
        {
            return new SqlCommand(command);
        }

        public System.Data.IDataParameter parameter(Parameter parameter)
        {
            return new SqlParameter(parameter.Name, parameter.Value);
        }
    }
}
