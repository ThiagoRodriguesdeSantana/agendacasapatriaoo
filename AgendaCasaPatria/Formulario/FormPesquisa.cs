using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using AgendaCasaPatria.Dados;
using System.Data.SqlClient;
using AgendaCasaPatria.Formulario;

namespace AgendaCasaPatria.Formulario
{
    public partial class FormPesquisa : Form
    {
        public FormPesquisa()
        {
            InitializeComponent();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var comandoSelect = "SET DATEFORMAT YMD; select * from AgendaCasaPatria..AgendaCasaPatria ";

                if (textBoxIntegrante.Text != "")
                {
                    comandoSelect += string.Format("Where Integrante Like '%{0}%' ", textBoxIntegrante.Text);
                }
                else if (textBoxFuncao.Text != "")
                {
                    comandoSelect += string.Format("Where Funcao = '{0}' ", textBoxFuncao.Text);
                }
                else if (textBoxHorario.Text != "")
                {
                    comandoSelect += string.Format("Where HoraInicio = '{0}' ", textBoxHorario.Text);
                }
                else if (textBoxLocal.Text != "")
                {
                    comandoSelect += string.Format("Where Local = '{0}' ", textBoxLocal.Text);
                }
                else if (radioButtonShow.Checked)
                {
                    comandoSelect += "WHere Situacao = 'Show' ";
                }
                else if (radioButtonEnsaio.Checked)
                {
                    comandoSelect += "where Situacao = 'Ensaio' ";
                }
                else if (radioButtonOutros.Checked)
                {
                    comandoSelect += "where Situacao = 'Outros' ";
                }
                else if (dateTimePickerData.Value != DateTime.MinValue)
                {
                    comandoSelect += string.Format("Where Data = '{0}' ", dateTimePickerData.Value.ToString("yyyy-MM-dd"));
                }

                var servicoBanco = new ServicosBancoDados();
                var dataTable = servicoBanco.BuscaNoBanco(comandoSelect);

                dataGridViewPesquisa.DataSource = dataTable;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }


        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                var linhaSelecionada = dataGridViewPesquisa.CurrentRow;
                if (linhaSelecionada == null)
                    return;

                var codigoLinha = dataGridViewPesquisa.Rows[linhaSelecionada.Index].Cells["Id"].Value;
                var comandoSelect = string.Format("Select * from AgendaCasaPatria..AgendaCasaPatria where Id = {0}", codigoLinha);
                var servicoBancoDados = new ServicosBancoDados();
                var dataTable = servicoBancoDados.BuscaNoBanco(comandoSelect);

                var resultadoConsulta = dataTable.Rows[0];

                var agendamento = PreencheComDataRow(resultadoConsulta);

                var formularioNovoEvento = new FormNovoEvenetoAtualizacao(agendamento);

                formularioNovoEvento.Show();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

        private static Agendamento PreencheComDataRow(DataRow resultadoConsulta)
        {
            var agendamento = new Agendamento();

            agendamento.Id = Convert.ToInt32(resultadoConsulta["Id"]);
            agendamento.Integrante = resultadoConsulta["Integrante"].ToString();
            agendamento.Funcao = resultadoConsulta["Funcao"].ToString();
            agendamento.Data = Convert.ToDateTime(resultadoConsulta["Data"]);
            agendamento.HoraInicio = resultadoConsulta["HoraInicio"].ToString();
            agendamento.HoraFim = resultadoConsulta["HoraFim"].ToString();
            agendamento.Local = resultadoConsulta["Local"].ToString();
            agendamento.Observacoes = resultadoConsulta["Observacoes"].ToString();

            return agendamento;
        }
    }
}
