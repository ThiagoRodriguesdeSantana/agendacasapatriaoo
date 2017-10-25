using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaCasaPatria.Dados
{
    public class ServicosAgenda
    {
        public void Addcontato(Agendamento agendamento)
        {
            var comandoInsert = string.Format(@"set dateformat YMD; INSERT INTO [dbo].[AgendaCasaPatria]
                                              ([Integrante]
                                              ,[Funcao]
                                              ,[Situacao]
                                              ,[Local]
                                              ,[HoraInicio]
                                              ,[HoraFim]    
                                              ,[Data]   
                                              ,[Observacoes])
                                               Values
                                               ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", agendamento.Integrante,
                                              agendamento.Funcao, agendamento.Situacao,
                                              agendamento.Local, agendamento.HoraInicio,
                                              agendamento.HoraFim, agendamento.Data.ToString("yyyy-MM-dd"),
                                              agendamento.Observacoes);

            var servicoBancoDados = new ServicosBancoDados();

            servicoBancoDados.ExecutaNoBanco(comandoInsert);

        }



        public void DeletaContato(int id)
        {
            var comandoDelete = string.Format(@"Delete from AgendaCasaPatria..AgendaCasaPatria where Id = {0}", id);

            var servicoBancoDados = new ServicosBancoDados();
            servicoBancoDados.ExecutaNoBanco(comandoDelete);

        }

        public DataTable ListaTodos()
        {
            var comandoSelect = @"select * from AgendaCasaPatria..AgendaCasaPatria";
            var servicoBancoDados = new ServicosBancoDados();
            var dataTable = servicoBancoDados.BuscaNoBanco(comandoSelect);

            return dataTable;
        }


    }
}
