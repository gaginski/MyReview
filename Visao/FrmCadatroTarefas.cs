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
    public partial class FrmCadatroTarefas : Form
    {
        ControleTarefas contTar = new ControleTarefas();
        Tarefa tarefa = new Tarefa();
        public FrmCadatroTarefas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tarefa.descricao = txtCasoTeste.Text;
            tarefa.titulo = txtTitulo.Text;
            tarefa.codigoSia = "";
            if (tarefa.id == 0)
                contTar.salvaTarefa(tarefa);
            else
                contTar.alteraTarefaId(tarefa);

            MessageBox.Show("Salva com sucesso!");

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja sair sem salvar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                this.Close();
        }

        private void FrmCadatroTarefas_Load(object sender, EventArgs e)
        {

        }

        public void edita(int id, string descricao, string titulo)
        {
            tarefa.id = id;
            tarefa.titulo = titulo;
            tarefa.descricao = descricao;

            txtCasoTeste.Text = tarefa.descricao;
            txtTitulo.Text = tarefa.titulo;

        }
    }
}
