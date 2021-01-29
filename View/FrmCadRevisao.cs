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
using DevExpress.XtraGrid.Views.Grid;

namespace MyReview.View
{
    public partial class FrmCadRevisao : DevExpress.XtraEditors.XtraForm
    {
        Usuario usuLogado = new Usuario();
        Revisao revAtual = new Revisao();
        bool editando = false;

        public FrmCadRevisao(int idUsuario, bool _editando)
        {
            InitializeComponent();

            usuLogado.usu_id = idUsuario;
            usuLogado = usuLogado.Busca()[0];

            editando = _editando;

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false; //queria utillizar a busca do próprio componente. MAS.... é bugada :(

            this.LookAndFeel.SkinName = usuLogado.GetUsu_tema();
            atualizaCombobox();
            atualizaGrid(true, true);
        }

        private void btnSalvaRevisao_Click(object sender, EventArgs e)
        {
            if (validaCamposRevisao(false))
                if (salvaRevisao(true))
                {
                    new FrmAlerta("Salvo com sucesso!", usuLogado.usu_id).ShowDialog();
                    this.Close();
                }
                else
                    limpaVinculos();

        }

        private void btnAdicionar_TarSia_Click(object sender, EventArgs e)
        {
            if (validaCamposRevisao(true))
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

                if (vincuaTarefaSia(tarefaSia))
                {
                    txtDescricao_TarSia.Text = "";
                    txtObs_TarSia.Text = "";
                    txtTitulo_TarSia.Text = "";
                    atualizaGrid(true, false);
                }
            }
        }

        private void atualizaGrid(bool sia, bool suites)
        {
            // atualiza grid de tarefas do sia
            if (sia && revAtual.rev_suite_Sia != 0)
            {
                DataTable dtSia = new DataTable();
                CasoTeste casoAux = new CasoTeste();
                List<CasoTeste> listaTarefasSia = new List<CasoTeste>();

                dtSia.Columns.AddRange(new DataColumn[]
                            {
                             new DataColumn("ID"),
                             new DataColumn("Título"),
                            });

                if (casoAux.cts_sts_id == null && revAtual.rev_suite_Sia != null)
                {
                    casoAux.cts_sts_id = revAtual.rev_suite_Sia;
                    listaTarefasSia = casoAux.Busca();
                }

                foreach (CasoTeste c in listaTarefasSia)
                    dtSia.Rows.Add(c.cts_id, c.cts_descricao);

                gridSia.DataSource = dtSia;
            }

            // atualiza grid com a suite de testes
            if (suites)
            {
                SuiteTeste suiteAux = new SuiteTeste();
                List<SuiteTeste> listaSuite = new List<SuiteTeste>();

                if (cmbProjeto.EditValue.ToString() != "")
                {
                    suiteAux.sts_prj_id = int.Parse(cmbProjeto.EditValue.ToString());
                    suiteAux.sts_Sia = false;
                    listaSuite = suiteAux.Busca();
                }

                DataTable dtSuite = new DataTable();

                dtSuite.Columns.AddRange(new DataColumn[]
                            {
                             new DataColumn("ID"),
                             new DataColumn("Título"),
                             new DataColumn("Versão")
                            });

                foreach (SuiteTeste s in listaSuite)
                    dtSuite.Rows.Add(s.sts_id, s.sts_descricao, s.sts_versao);

                gridSuite.DataSource = dtSuite;

                gridView2.OptionsSelection.MultiSelect = true;
                gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
        }

        private bool vincuaTarefaSia(CasoTeste tarefaSia)
        {
            if (revAtual.rev_suite_Sia == null || revAtual.rev_suite_Sia == 0)
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
            return tarefaSia.Salvar();
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

        public bool validaCamposRevisao(bool sia)
        {
            List<String> campos = new List<string>();

            if (txtVersao.Text.Equals(""))
                campos.Add("Versão");
            if (txtRevDescricao.Text.Equals(""))
                campos.Add("Descrição");
            if (cmbProjeto.EditValue.ToString() == "")
                campos.Add("Projeto");
            if (!sia && revAtual.rev_suite_Sia == null && gridView2.SelectedRowsCount == 0)
                campos.Add("Suite de Testes");

            if (sia)
            {
                if (txtTitulo_TarSia.Text.Equals(""))
                    campos.Add("Título Sia");
                if (txtDescricao_TarSia.Text.Equals(""))
                    campos.Add("Descrição Sia");
            }

            if (campos.Count > 0)
                new FrmAlerta("Atenção! Alguns campo obrigatórios não foram preenchidos: " + string.Join(", ", campos.ToArray()), usuLogado.usu_id).ShowDialog();

            return campos.Count > 0 ? false : true;
        }

        public bool salvaRevisao(bool finalizado)
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
                if (!revAtual.Salvar())
                    return false;
                revAtual = revAtual.Busca()[0];
            }
            else
                if (!revAtual.update())
                return false;

            if (finalizado)
            {
                if (editando) // deleta caso já exista vinculos. ATENÇÃO!! DEVE SER EDITADO APENAS SE AINDA NÃO TIVER INICIADO
                    if (!limpaVinculos())
                        return false;

                List<SuitesRevisao> listaVinculo = new List<SuitesRevisao>();// vai varrer e criar lista com todos os vinculos selecionados no grid

                for (int i = 0; i < gridView2.RowCount; i++)
                    if (gridView2.IsRowSelected(i))
                    {
                        SuitesRevisao aux = new SuitesRevisao();
                        aux.srv_rev_id = revAtual.rev_id;
                        aux.srv_dataInclusao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        aux.srv_usuarioInclusao = usuLogado.usu_id;
                        aux.srv_sts_id = int.Parse(gridView2.GetRowCellValue(i, "ID").ToString());
                        aux.srv_status = "F";

                        if (!aux.Salvar())
                            return false;

                        aux = aux.Busca()[0];

                        CasoTeste casoAux = new CasoTeste();
                        casoAux.cts_sts_id = int.Parse(gridView2.GetRowCellValue(i, "ID").ToString());

                        foreach (CasoTeste cts in casoAux.Busca()) // cria vinculo no execucao_casos
                        {
                            Execucao_Caso auxExCaso = new Execucao_Caso();

                            auxExCaso.ecs_cst_id = cts.cts_id;
                            auxExCaso.ecs_rev_id = revAtual.rev_id;
                            auxExCaso.ecs_status = "F";
                            auxExCaso.ecs_srv_id = aux.srv_id;
                            auxExCaso.ecs_dataFim = DateTime.Parse("1888-01-01 00:00:01");
                            auxExCaso.ecs_dataInicio = DateTime.Parse("1888-01-01 00:00:01");

                            if (!auxExCaso.Salvar())
                                return false;
                            auxExCaso = auxExCaso.Busca()[0];

                            Casos_Passo passosAux = new Casos_Passo();
                            passosAux.cps_cts_id = auxExCaso.ecs_cst_id;

                            if (auxExCaso.ecs_cst_id == 54)
                                MessageBox.Show("54");

                            foreach (Casos_Passo cps in passosAux.Busca())
                            {
                                Execucao_Passo exePassos = new Execucao_Passo();

                                exePassos.eps_rev_id = revAtual.rev_id;
                                exePassos.eps_status = "F";
                                exePassos.eps_cps_indice = cps.cps_indice;
                                exePassos.eps_ecs_id = auxExCaso.ecs_id;
                                
                                if (!exePassos.Salvar())
                                    return false;
                            }
                        }
                    }

                if (revAtual.rev_suite_Sia != null && revAtual.rev_suite_Sia != 0) // tarefas do sia - vincula a suite
                {
                    SuitesRevisao aux = new SuitesRevisao();
                    aux.srv_rev_id = revAtual.rev_id;
                    aux.srv_dataInclusao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    aux.srv_usuarioInclusao = usuLogado.usu_id;
                    aux.srv_sts_id = revAtual.rev_suite_Sia;
                    aux.srv_status = "F";

                    listaVinculo.Add(aux);

                    if (!aux.Salvar())
                        return false;
                }

                // foreach (SuitesRevisao st in listaVinculo) implementado pra salvar dentro do forech
                //  if (!st.Salvar())
                //   return false;
            }

            return true;
        }

        private void cmbProjeto_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbProjeto.EditValue.ToString() != "")
                atualizaGrid(false, true);
        }

        private bool limpaVinculos()
        {
            SuitesRevisao auxSuite = new SuitesRevisao();
            auxSuite.srv_rev_id = revAtual.rev_id;
            if (!auxSuite.delete())
                return false;

            Execucao_Caso auxExCaso = new Execucao_Caso();
            auxExCaso.ecs_rev_id = revAtual.rev_id;
            if (!auxExCaso.delete())
                return false;

            Execucao_Passo auxExPasso = new Execucao_Passo();
            auxExPasso.eps_rev_id = revAtual.rev_id;
            if (!auxExPasso.delete())
                return false;

            return true;
        }

        private void FrmCadRevisao_Load(object sender, EventArgs e)
        {

        }
    }
}