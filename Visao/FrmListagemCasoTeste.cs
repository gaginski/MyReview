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
    public partial class FrmListagemCasoTeste : Form
    {
        List<Tarefa> listaTarefas = new List<Tarefa>();
        ControleTarefas contTar = new ControleTarefas();

        public FrmListagemCasoTeste()
        {
            InitializeComponent();
        }

        private void FrmListagemCasoTeste_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }
        public void atualizaGrid()
        {
            if (txtPesquisa.Text == "" || txtPesquisa.Text == null)
                listaTarefas = contTar.retornaTarefas(null);
            else
                listaTarefas = contTar.retornaTarefas(txtPesquisa.Text);

            grid.Rows.Clear();

            grid.ColumnCount = 3;
            grid.Columns[0].Name = "ID";
            grid.Columns[1].Name = "Título";
            grid.Columns[2].Name = "Detalhamento";

            grid.Columns[0].Width = 30;
            grid.Columns[1].Width = 200;
            grid.Columns[2].Width = 220;


            foreach (Tarefa t in listaTarefas)
            {
                String[] aux = { t.id.ToString(), t.titulo, t.descricao };
                grid.Rows.Add(aux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadatroTarefas t = new FrmCadatroTarefas();
            t.ShowDialog();
            atualizaGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmCadatroTarefas frm = new FrmCadatroTarefas();
            if (grid.CurrentRow.Cells[0].Value!= null) {
                if (grid.SelectedRows.ToString() != "")
                {
                    foreach (Tarefa t in listaTarefas)
                    {
                        if (t.id.ToString() == grid.CurrentRow.Cells[0].Value.ToString())
                        {
                            frm.edita(t.id, t.descricao, t.titulo);
                            frm.ShowDialog();
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Selecione um registro!");
            }
            else
                MessageBox.Show("Selecione um registro!");

            atualizaGrid();
        }
    }
}
