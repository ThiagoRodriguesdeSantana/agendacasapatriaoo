using AgendaCasaPatria.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AgendaCasaPatria.Formulario
{
    public partial class FormNovoEvenetoAtualizacao : Form
    {
        Agendamento _agendamento = new Agendamento();

        public FormNovoEvenetoAtualizacao()
        {
            InitializeComponent();
        }


        public FormNovoEvenetoAtualizacao(Agendamento pAgendamento)
            : this()
        {
            _agendamento = pAgendamento;
            PreecheTela(_agendamento);

          
        }

        private void PreecheTela(Agendamento agendamento)
        {
            textBoxId.Text = Convert.ToString(agendamento.Id); ;
            textBoxIntegrante.Text = agendamento.Integrante;
            textBoxFuncao.Text = agendamento.Funcao;
            dateTimePickerData.MinDate = Convert.ToDateTime(agendamento.Data); ;
            textBoxHoraInicio.Text = agendamento.HoraInicio;
            textBoxHorafim.Text = agendamento.HoraInicio;
            textBoxLocal.Text = agendamento.Local;
            textBoxObservacoes.Text = agendamento.Observacoes;

        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            PreencheClasseAgendamento();

            var comandoUpdate = string.Format(@"SET DATEFORMAT YMD UPDATE [dbo].[AgendaCasaPatria]
                                                SET [Integrante] = '{0}'
                                                   ,[Funcao] = '{1}'
                                                   ,[Situacao] ='{2}'
                                                   ,[Local] = '{3}'
	                                               ,[HoraInicio] = '{4}'
                                                   ,[HoraFim] = '{5}'
                                                   ,[Data] = '{6}'
                                                   ,[Observacoes] = '{7}'
                                                WHERE 
                                                id={8}", _agendamento.Integrante,
                                                   _agendamento.Funcao, _agendamento.Situacao,
                                                   _agendamento.Local, _agendamento.HoraInicio,
                                                  _agendamento.HoraFim, _agendamento.Data.ToString("yyyy-MM-dd"),
                                                  _agendamento.Observacoes, _agendamento.Id);

            var servicoBancoDados = new ServicosBancoDados();
            servicoBancoDados.ExecutaNoBanco(comandoUpdate);          
            LimpaTela();

        }

        private void PreencheClasseAgendamento()
        {
            string Situacao;

            if (radioButtonEnsaio.Checked)
            {
                Situacao = "Ensaio";
            }
            else
            {
                Situacao = "Show";
            }
            if (radioButtonOutros.Checked)
            {
                Situacao = "Outros";
            }

            _agendamento.Integrante = textBoxIntegrante.Text;
            _agendamento.Funcao = textBoxFuncao.Text;
            _agendamento.Situacao = Situacao;
            _agendamento.Local = textBoxLocal.Text;
            _agendamento.HoraInicio = textBoxHoraInicio.Text;
            _agendamento.HoraFim = textBoxHorafim.Text;
            _agendamento.Data = dateTimePickerData.Value;
            _agendamento.Observacoes = textBoxObservacoes.Text;
        }

        public void LimpaTela()
        {
            textBoxIntegrante.Text = "";
            textBoxFuncao.Text = "";
            textBoxLocal.Text = "";
            textBoxHoraInicio.Text = "";
            textBoxHorafim.Text = "";
            dateTimePickerData.MinDate = DateTime.Now;
            textBoxObservacoes.Text = "";

        }

    }
}
