using AgendaADONET.Classes;
using AgendaADONET.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaADONET
{
    public partial class frnAgenda : Form
    {
        public frnAgenda()
        {
            InitializeComponent();
        }

        private void frnAgenda_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmIncluirAlterarContato form = new frmIncluirAlterarContato();
            form.ShowDialog();
            CarregarDataGridView();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAgenda.CurrentRow.Cells[0].Value;
            ContatoDAO contatoDao = new ContatoDAO();
            contatoDao.Excluir(id);
            CarregarDataGridView();
        }

        private void CarregarDataGridView()
        {
            ContatoDAO contatoDao = new ContatoDAO();
            DataTable dataTable = contatoDao.GetContatos();
            dgvAgenda.DataSource = dataTable;
            dgvAgenda.Refresh();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Id = (int)dgvAgenda.CurrentRow.Cells[0].Value,
                Nome = dgvAgenda.CurrentRow.Cells[1].Value.ToString(),
                Email = dgvAgenda.CurrentRow.Cells[2].Value.ToString(),
                Telefone = (int)dgvAgenda.CurrentRow.Cells[3].Value
            };
            frmIncluirAlterarContato form = new frmIncluirAlterarContato(contato);
            form.ShowDialog();
            CarregarDataGridView();
        }
    }
}
