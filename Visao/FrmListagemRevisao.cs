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
            FrmCriaRevisao r = new FrmCriaRevisao();

            r.ShowDialog();
        }

        private void FrmListagemRevisao_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            atualizaGrid();
        }
        private void atualizaGrid()
        {
            grid.Rows.Clear();
            grid.ColumnCount = 3;
            grid.Columns[0].Name = "ID";
            grid.Columns[1].Name = "Versão";
            grid.Columns[2].Name = "Status";

            List < Revisao > list = contRev.selecionaRevisoes();
            foreach(Revisao r in list)
            {
                String[] s = new String[]{ r.id.ToString(), r.versao, r.status};
                grid.Rows.Add(s);
            }
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].ReadOnly = true;
            }
        }
    }
}
