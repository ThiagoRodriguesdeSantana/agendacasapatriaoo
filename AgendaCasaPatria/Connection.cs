using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AgendaCasaPatria
{
    public class Connection
    {
        private static string connectionString = @"Server=DESKTOP-KDDDEK4;Database=AgendaCasaPatria;User Id=sa;
Password = sap@123; ";

        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }   

    }
}
