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
    public partial class FrmMinhasTarefas : Form
    {
        ControleTarefas contTar = new ControleTarefas();
        ControleRevisao contRev = new ControleRevisao();
        ControleConfig contConfig = new ControleConfig();

        List<Tarefa> listaTar = new List<Tarefa>();
        Usuario usuarioLogado = new Usuario();

        public FrmMinhasTarefas()
        {
            InitializeComponent();

            contConfig.carregaConfig();
            this.Width = contConfig.conf.frmMinhasTarefas[0];
            this.Height = contConfig.conf.frmMinhasTarefas[1];
        }

        private void FrmMinhasTarefas_Load(object sender, EventArgs e)
        {
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVersao.DropDownStyle = ComboBoxStyle.DropDownList;

            DataTable dtVersao = new DataTable();
            DataTable dtStatus = new DataTable();
            List<String> versoes = contRev.pegaVersoes();

            dtVersao.Columns.Add("Versao");

            dtVersao.Rows.Add("Todas");
            foreach (String v in versoes)
            {
                dtVersao.Rows.Add(v);
            }
            cmbVersao.DataSource = dtVersao;
            cmbVersao.DisplayMember = "Versao";
            cmbVersao.ValueMember = "Versao";
            cmbVersao.SelectedIndex = 0;

            dtStatus.Columns.Add("StatusBanco");
            dtStatus.Columns.Add("Status");

            dtStatus.Rows.Add("T", "Todos");
            dtStatus.Rows.Add("A", "Pendente");
            dtStatus.Rows.Add("I", "Iniciada");
            dtStatus.Rows.Add("C", "Concluída");

            cmbStatus.DataSource = dtStatus;
            cmbStatus.DisplayMember = "Status";
            cmbStatus.ValueMember = "StatusBanco";

            cmbStatus.SelectedIndex = 1;
            chkSemVinculo.Checked = true;
        }
        public void UsuarioLogado(int idUsuario)
        {
            ControleUsuario contUsu = new ControleUsuario();
            usuarioLogado = contUsu.pegaUsuario(idUsuario);
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            String versao = null, status_ = null;

            if (cmbStatus.SelectedValue != null)
                if (!cmbStatus.SelectedValue.ToString().Equals("T"))
                    status_ = cmbStatus.SelectedValue.ToString();

            if (!cmbVersao.Text.ToString().Equals("Todas"))
                versao = cmbVersao.Text.ToString();

            listaTar = contTar.selecionaTarefaRevisao(usuarioLogado, status_, versao, chkSemVinculo.Checked);

            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.ColumnCount = 5;

            grid.Columns[0].Name = "Id";
            grid.Columns[1].Name = "Título";
            grid.Columns[2].Name = "Versão";
            grid.Columns[3].Name = "Status";
            grid.Columns[4].Name = "Responsavel";



            foreach (Tarefa t in listaTar)
            {
                String resp = null;
                String status = null;

                if (t.usuario.login == null)
                    resp = "Indefinido";
                else
                    resp = t.usuario.login;

                switch (t.status)
                {
                    case ("A"): status = "Pendente"; break;
                    case ("I"): status = "Iniciada"; break;
                    case ("C"): status = "Concluída"; break;
                }

                String[] aux = new String[] { t.idVinculo.ToString(), t.titulo, t.revisao.versao, status, resp };
                grid.Rows.Add(aux);

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    grid.Columns[i].ReadOnly = true;
                }

            }
        }
        private void cmbVersao_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void chkSemVinculo_CheckedChanged(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void btnDocumentar_Click(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmMinhasTarefas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case (Keys.D):
                        btnDetalhes_Click(sender, e);
                        break;

                }
            }
        }

        private void btnFinalizaTarefa_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (grid.CurrentRow.Cells[0].Value != null)// verifica se existe linha selecionada
                {
                    if (!contTar.verificaVinculoUsuario(int.Parse(grid.CurrentRow.Cells[0].Value.ToString()), usuarioLogado))
                    {
                        FrmExibicaoTarefa et = new FrmExibicaoTarefa();
                        et.passaTarefa(int.Parse(grid.CurrentRow.Cells[0].Value.ToString()), usuarioLogado.id);
                        et.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tarefa vinculada a outro usuário!");
                        atualizaGrid();
                    }
                }
                else
                    MessageBox.Show("Selecione um registro!");
            }
            else
                MessageBox.Show("Selecione um registro!");

        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            contConfig.carregaConfig();

            Config aux = contConfig.conf;
            aux.frmMinhasTarefas = new int[] { this.Width, this.Height };
            contConfig.salvaConfig(aux);
        }
    }
}


