using MyReview.Controle;
using MyReview.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.Visao
{
    public partial class FrmListagemRevisao : Form
    {
        ControleRevisao contRev = new ControleRevisao();
        public FrmListagemRevisao()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastroRevisao r = new FrmCadastroRevisao();
            r.ShowDialog();
            atualizaGrid();
        }

        private void FrmListagemRevisao_Load(object sender, EventArgs e)
        {
            btnExcluir.Enabled = false;
            atualizaGrid();
        }
        private void atualizaGrid()
        {
            grid.Rows.Clear();
            grid.ColumnCount = 4;
            grid.Columns[0].Name = "ID";
            grid.Columns[1].Name = "Versão";
            grid.Columns[2].Name = "Status";
            grid.Columns[3].Name = "Detalhes";

            List<Revisao> list = contRev.selecionaRevisoes();
            foreach (Revisao r in list)
            {
                String[] s = new String[] { r.id.ToString(), r.versao, r.status, r.descricao };
                grid.Rows.Add(s);
            }
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].ReadOnly = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow.Cells[0].Value != null)
            {
                FrmCadastroRevisao frm = new FrmCadastroRevisao();
                frm.editar(int.Parse(grid.CurrentRow.Cells[0].Value.ToString()));
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Selecione um registro!");
         }
    }
}
