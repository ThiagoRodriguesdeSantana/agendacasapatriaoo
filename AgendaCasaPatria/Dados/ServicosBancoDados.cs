using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaCasaPatria.Dados
{
    public class ServicosBancoDados
    {
        public void ExecutaNoBanco(string comandoSql)
        {
            var con = new SqlConnection(Connection.ConnectionString);
            var cmd = new SqlCommand(comandoSql, con);

            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable BuscaNoBanco(string comandoSql)
        {            
            var dataTable = new DataTable();
            var conn = new SqlConnection(Connection.ConnectionString);
            var cmd = new SqlCommand(comandoSql, conn);
            
            cmd.CommandType = CommandType.Text;
            conn.Open();

            var sqlDataAdapter = new SqlDataAdapter(cmd);

            sqlDataAdapter.Fill(dataTable);
            conn.Close();

            return dataTable;
        }
    }
}
