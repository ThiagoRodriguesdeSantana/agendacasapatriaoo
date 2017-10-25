using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaCasaPatria.Dados;
using System.Data.SqlClient;


namespace AgendaCasaPatria.Formulario
{
    public partial class FormNovoEvento : Form
    {
        public FormNovoEvento()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var agendamento = PreencheClasseAgenda();
                var servicosAgenda = new ServicosAgenda();

                servicosAgenda.Addcontato(agendamento);

                LimpaTela();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }

        public Agendamento PreencheClasseAgenda()
        {
            var agendamento = new Agendamento();
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


            agendamento.Integrante = textBoxIntegrante.Text;
            agendamento.Funcao = textBoxFuncao.Text;
            agendamento.Situacao = Situacao;
            agendamento.Local = textBoxLocal.Text;
            agendamento.HoraInicio = textBoxHoraInicio.Text;
            agendamento.HoraFim = textBoxHorafim.Text;
            agendamento.Data = dateTimePickerData.Value;
            agendamento.Observacoes = textBoxObservacoes.Text;

            return agendamento;
        }
        
        public void LimpaTela()
        {
            textBoxIntegrante.Text = "";
            textBoxFuncao.Text = "";
            textBoxLocal.Text = "";
            textBoxHoraInicio.Text = "";
            textBoxHorafim.Text = "";
            dateTimePickerData.Value = DateTime.Now;
            textBoxObservacoes.Text = "";
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            var FormPesquisa = new FormPesquisa();

            FormPesquisa.Show();
  
        }
    }
}
