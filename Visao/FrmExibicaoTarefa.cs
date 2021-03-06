﻿using MyReview.Controle;
using MyReview.Modelo;
using System;
using System.Windows.Forms;

namespace MyReview.Visao
{
    public partial class FrmExibicaoTarefa : Form
    {
        ControleTarefas contTar = new ControleTarefas();
        ControleDocumentacao contDoc = new ControleDocumentacao();
        ControleConfig contConfig = new ControleConfig();
        Tarefa tarefa = new Tarefa();
        Usuario usuarioLogado = new Usuario();
        Documentacao doc = new Documentacao();

        public FrmExibicaoTarefa()
        {
            InitializeComponent();
            contConfig.carregaConfig();

            this.Width = contConfig.conf.frmExibicaoTarefa[0];
            this.Height = contConfig.conf.frmExibicaoTarefa[1];
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void atualizaInformacao()
        {

            tarefa = contTar.selecionaTarefaRevaoId(tarefa.idVinculo);
            txtCodigo.Text = tarefa.idVinculo.ToString();
            txtTitulo.Text = tarefa.titulo;
            txtVersao.Text = tarefa.revisao.versao;
            txtDescricaoTarefa.Text = tarefa.descricao;
            
            txtDataInicio.Text = tarefa.dataInicio.ToString() != "31/12/1888 23:59:59" ? tarefa.dataInicio.ToString() : "";
            txtDataFim.Text = tarefa.dataFim.ToString() != "31/12/1888 23:59:59" ? tarefa.dataFim.ToString() : "";

            switch (tarefa.status)
            {
                case ("A"): txtStatusTarefa.Text = "Pendente"; break;
                case ("I"): txtStatusTarefa.Text = "Iniciada"; break;
                case ("C"): txtStatusTarefa.Text = "Concluída"; break;
            }

            txtStatusTarefa.Enabled = false;
            txtCodigo.Enabled = false;
            txtTitulo.Enabled = false;
            txtVersao.Enabled = false;
            txtDataFim.Enabled = false;
            txtDataInicio.Enabled = false;
        }

        private void FrmExibicaoTarefa_Load(object sender, EventArgs e)
        {
            atualizaInformacao();
        }
        public void passaTarefa(int id, int idUsu)
        {
            tarefa = contTar.selecionaTarefaRevaoId(id);
            ControleUsuario contUsu = new ControleUsuario();
            usuarioLogado = contUsu.pegaUsuario(idUsu);
        }

        private void frmExibicaoTarefa_close(object sender, FormClosedEventArgs e)
        {

            contConfig.carregaConfig();

            Config aux = contConfig.conf;
            aux.frmExibicaoTarefa = new int[] { this.Width, this.Height };
            contConfig.salvaConfig(aux);

            FrmMinhasTarefas fmt = new FrmMinhasTarefas();
            fmt.UsuarioLogado(usuarioLogado.id);
            fmt.Show();
            fmt.UsuarioLogado(usuarioLogado.id);
        }

        private void btnInciar_Click(object sender, EventArgs e)
        {
            contTar = new ControleTarefas();
            if (!contTar.verificaVinculoUsuario(tarefa.idVinculo, usuarioLogado)) // confirma no banco se há usuario vinculado
            {
                if (contTar.verificaPendente(tarefa.idVinculo))
                {
                    tarefa.dataInicio = DateTime.Now;
                    tarefa.usuario = usuarioLogado;
                    tarefa.status = "I";
                    contTar.AlteraStatusTarefa(tarefa);
                    atualizaInformacao();
                }
                else
                    MessageBox.Show("Só é possível iniciar tarefas com o status pendente!");
            }
            else
                MessageBox.Show("Tarefa vinculada a outro usuário!");

    }

    private void btnSalvarDocumentacao_Click(object sender, EventArgs e)
    {
        if (txtStatusTarefa.Text == "Iniciada")
        {
            if (txtDocumentacao.Text != "")
            {
                doc.tarefa = tarefa;
                doc.usuario = usuarioLogado;
                doc.documentacao = txtDocumentacao.Text;
                doc.tarefasCriadas = txtTarefasCriadas.Text;

                if (contDoc.SalvaDocumentacao(doc))
                {
                    MessageBox.Show("Documentação salva com sucesso!");
                    txtDocumentacao.Text = "";
                    txtTarefasCriadas.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Deve ser informado o texto de documentação!");
            }
        }
        else
        {
            MessageBox.Show("Só é possivel documentar em tarefas iniciadas!");
        }
    }

    private void btnFinalizar_Click(object sender, EventArgs e)
    {
        if (txtStatusTarefa.Text == "Iniciada")
        {
            if (contDoc.verificaExisteDocumentacao(int.Parse(txtCodigo.Text)))
            {
                tarefa.dataFim = DateTime.Now;
                tarefa.usuario = usuarioLogado;
                tarefa.status = "C";
                contTar.AlteraStatusTarefa(tarefa);
                atualizaInformacao();
            }
            else
                MessageBox.Show("Não é possivel fechar uma tarefa sem documentação!");
        }
        else
        {
            MessageBox.Show("Só é possivel encerrar tarefas com status 'iniciada'!");
        }
    }

    private void frmExibicaoTarefa(object sender, KeyEventArgs e)
    {
        if (e.KeyValue.Equals(27))
        {
            this.Close();
        }
    }

        private void AlteraTamanho(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            txtTarefasCriadas.Text = (txtTarefasCriadas.Text.Equals("") ? txtIncluirTf.Text.Trim() : txtTarefasCriadas.Text + " - " + txtIncluirTf.Text.Trim());
            txtIncluirTf.Text = "";
        }
    }
}
