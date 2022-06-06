using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Datos
{
     interface DataProvider
    {
        IDbConnection connection(String stringConnection);
        IDbDataAdapter adapter(String commad, IDbConnection connection);
        IDbCommand command(String command);
        IDataParameter parameter(Parameter parameter);
    }
}
