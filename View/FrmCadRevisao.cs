using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyReview.Model;
using MyReview.Visao;
using System.Globalization;

namespace MyReview.View
{
    public partial class FrmCadRevisao : DevExpress.XtraEditors.XtraForm
    {
        Usuario usuLogado = new Usuario();
        Revisao revAtual = new Revisao();

        public FrmCadRevisao(int idUsuario)
        {
            InitializeComponent();

            usuLogado.usu_id = idUsuario;
            usuLogado = usuLogado.Busca()[0];

            this.LookAndFeel.SkinName = usuLogado.GetUsu_tema();
            atualizaCombobox();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            atualizaGrid(false, false);
        }

        private void btnAdicionar_TarSia_Click(object sender, EventArgs e)
        {
            if (validaCamposRevisao())
            {
                if (revAtual.rev_id == 0 || revAtual.rev_id == null)
                    salvaRevisao(false);

                CasoTeste tarefaSia = new CasoTeste();

                tarefaSia.cts_descricao = txtTitulo_TarSia.Text;
                tarefaSia.cts_Observacao = txtObs_TarSia.Text;
                tarefaSia.cts_precondicoes = txtRevDescricao.Text;
                tarefaSia.cts_ultimaAlteracao = DateTime.Parse((DateTime.Now).ToString("yyyyy-MM-dd HH:mm:ss"));
                tarefaSia.cts_dataInclusao = DateTime.Parse((DateTime.Now).ToString("yyyyy-MM-dd HH:mm:ss"));
                
                tarefaSia.cts_terminalUltimaAleracao = Environment.MachineName;
                tarefaSia.cts_usu_inclusao = usuLogado.usu_id;

                vincuaTarefaSia(tarefaSia);

                atualizaGrid(true, false);

            }
        }

        private void atualizaGrid(bool sia, bool suites)
        {
            // atualiza grid de tarefas do sia
            if (sia && revAtual.rev_suite_Sia != 0)
            {
                DataTable dtSia = new DataTable();
                CasoTeste casoAux = new CasoTeste();

                dtSia.Columns.AddRange(new DataColumn[]
                            {
                             new DataColumn("ID"),
                             new DataColumn("Título"),
                            });

                casoAux.cts_sts_id = revAtual.rev_suite_Sia;
                List<CasoTeste> listaTarefasSia = casoAux.Busca();

                foreach (CasoTeste c in listaTarefasSia)
                    dtSia.Rows.Add(c.cts_id, c.cts_descricao);

                gridSia.DataSource = dtSia;
            }

            // atualiza grid com a suite de testes
            if (suites)
            {
                // atualizar apenas as do projeto selecionado
            }
        }
        private void vincuaTarefaSia(CasoTeste tarefaSia)
        {
            if (revAtual.rev_suite_Sia == null)
            {
                SuiteTeste suiteSia = new SuiteTeste();

                suiteSia.sts_descricao = "Tarefas do Sia - " + cmbProjeto.Text + "- Revisão N° " + revAtual.rev_id;
                suiteSia.sts_Sia = true;
                suiteSia.sts_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                suiteSia.sts_dataCadastro = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                suiteSia.sts_versao = txtVersao.Text;
                suiteSia.sts_prj_id = int.Parse(cmbProjeto.EditValue.ToString());
                suiteSia.sts_usu_autor = usuLogado.usu_id;

                suiteSia.Salvar();
                suiteSia = suiteSia.Busca()[0];

                revAtual.rev_suite_Sia = suiteSia.sts_id;
            }
            tarefaSia.cts_sts_id = revAtual.rev_suite_Sia;
            tarefaSia.Salvar();
        }
        private void atualizaCombobox()
        {
            DataTable DtProjeto = new DataTable();

            DtProjeto.Columns.Add("Id");
            DtProjeto.Columns.Add("Projeto");

            Projeto ProjetoAux = new Projeto();
            List<Projeto> ListaProjeto = ProjetoAux.Todos();

            foreach (Projeto p in ListaProjeto)
                DtProjeto.Rows.Add(p.pjt_id, p.pjt_nome);

            cmbProjeto.Properties.DataSource = DtProjeto;
            cmbProjeto.Properties.DisplayMember = DtProjeto.Columns[1].Caption;
            cmbProjeto.Properties.ValueMember = DtProjeto.Columns[0].Caption;

            if (cmbProjeto.SelectionLength > 0)
                cmbProjeto.SelectionStart = 0;
        }

        public bool validaCamposRevisao()
        {
            List<String> campos = new List<string>();

            if (txtVersao.Text.Equals(""))
                campos.Add("Versão");
            if (txtRevDescricao.Text.Equals(""))
                campos.Add("Descrição");
            if (cmbProjeto.SelectedText == cmbProjeto.Properties.NullText)
                campos.Add("Projeto");

            if (campos.Count > 0)
                new FrmAlerta("Atenção! Alguns campo obrigatórios não foram preenchidos: " + string.Join(", ", campos.ToArray()), usuLogado.usu_id).ShowDialog();

            return campos.Count > 0 ? false : true;
        }
        public void salvaRevisao(bool finalizado)
        {
            revAtual.rev_status = finalizado ? "F" : "A";
            revAtual.rev_descricao = txtRevDescricao.Text;
            revAtual.rev_modelo = checkEdit1.Checked;
            revAtual.rev_versao = txtVersao.Text;
            revAtual.rev_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            revAtual.rev_dataCad = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            revAtual.rev_pjt_id = int.Parse(cmbProjeto.EditValue.ToString());
            revAtual.rev_terminalUltimaAlteracao = Environment.MachineName;
            revAtual.rev_usu_cadastro = usuLogado.usu_id;

            if (revAtual.rev_id == 0 || revAtual.rev_id == null)
            {
                revAtual.Salvar();
                revAtual = revAtual.Busca()[0];
            }
            else
                revAtual.update();

        }
    }
}