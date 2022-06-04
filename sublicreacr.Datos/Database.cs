using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Datos
{
    class Database
    {
        private static string strConnection = "Server=MYSQL5044.site4now.net;Database=db_a87eb5_sublicr;Uid=a87eb5_sublicr;Pwd=Admin123!!";

        private static DataProvider dp = new SqlDataProvider();

        private static IDbConnection dbConnection = dp.connection(strConnection);

        public static void connect()
        {
            dbConnection.Open();
        }

        public static void disconnect()
        {
            dbConnection.Close();
        }

        public static DataSet executeDataset(string command, Parameter[] parameters)
        {
            DataSet dts;
            try
            {
                connect();

                IDbDataAdapter adp = dp.adapter(command, dbConnection);

                foreach(Parameter parameter in parameters)
                {
                    adp.SelectCommand.Parameters.Add(dp.parameter(parameter));
                }

                dts = new DataSet();
                adp.Fill(dts);
            }
            finally
            {
                disconnect();
            }

            return dts;
        }       
    }
}
