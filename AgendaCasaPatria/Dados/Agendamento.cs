using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaCasaPatria.Dados
{
   public class Agendamento
    {
        public int Id { get; set; }
        public string Integrante { get; set; }
        public string Funcao { get; set; }
        public string Situacao { get; set; }
        public string Local { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        
    }
}
