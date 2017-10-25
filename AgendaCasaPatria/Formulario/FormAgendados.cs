using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AgendaCasaPatria.Dados;

namespace AgendaCasaPatria.Formulario
{
    public partial class FormAgendados : Form
    {
        public FormAgendados()
        {
            InitializeComponent();
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            ListaTodos();

        }

        private void ListaTodos()
        {
            var servicoAgenda = new ServicosAgenda();

            var todasAgendas = servicoAgenda.ListaTodos();

            dataGridViewLista.DataSource = todasAgendas;
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            var FormNovoEvento = new FormNovoEvento();

            FormNovoEvento.Show();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            try
            {
                var SelecaoLinhas = dataGridViewLista.CurrentRow;
                var linhaSelecionada = dataGridViewLista.Rows[SelecaoLinhas.Index].Cells["Id"].Value;

                var Codigo = Convert.ToInt32(linhaSelecionada);
                var servicoAgenda = new ServicosAgenda();
                servicoAgenda.DeletaContato(Codigo);
                ListaTodos();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }


    }
}
