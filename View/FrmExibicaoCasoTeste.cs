using DevExpress.XtraEditors;
using MyReview.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.View
{
    public partial class FrmExibicaoCasoTeste : DevExpress.XtraEditors.XtraForm
    {
        Usuario usuarioLogado = new Usuario();
        CasoTeste CasoTesteExibindo = new CasoTeste();
        SuiteTeste suiteTesteExibindo = new SuiteTeste();
        Revisao revisaoAtual = new Revisao();

        int idExecucao;

        public FrmExibicaoCasoTeste(int idExecucao_aux, int logadoId)
        {
            InitializeComponent();

            usuarioLogado.usu_id = logadoId;
            usuarioLogado = usuarioLogado.Busca()[0];
            idExecucao = idExecucao_aux;

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false;

            atualizaCampos();

            this.LookAndFeel.SkinName = usuarioLogado.GetUsu_tema();
        }

        public void atualizaCampos()
        {

            SuitesRevisao suiteRev = new SuitesRevisao();
            suiteRev.srv_id = idExecucao;
            suiteRev = suiteRev.Busca()[0];

            #region busca e implementa os objetos

            suiteTesteExibindo.sts_id = suiteRev.srv_sts_id;
            suiteTesteExibindo = suiteTesteExibindo.Busca()[0];

            revisaoAtual.rev_id = suiteRev.srv_rev_id;
            revisaoAtual = revisaoAtual.Busca()[0];

            Usuario usuCriador = new Usuario();
            usuCriador.usu_id = suiteTesteExibindo.sts_usu_autor;
            usuCriador = usuCriador.Busca()[0];

            Projeto projetoAtual = new Projeto();
            projetoAtual.pjt_id = suiteTesteExibindo.sts_prj_id;
            projetoAtual = projetoAtual.Busca()[0];

            #endregion

            #region carrega Informações na tela

            lblVersao.Text = revisaoAtual.rev_versao;
            lblAutor.Text = usuCriador.usu_nome;
            lblDataCriacao.Text = suiteTesteExibindo.sts_dataCadastro.ToString("dd/mm/yy");
            lblTituloSuite.Text = suiteTesteExibindo.sts_descricao;
            lblObjetivo.Text = suiteTesteExibindo.sts_objetivo;
            lblNomeProjeto.Text = projetoAtual.pjt_nome;
            #endregion

            atualizaGridCasosTeste();

        }

        public void atualizaGridCasosTeste()
        {
            Execucao_Caso exeCasos = new Execucao_Caso();
            exeCasos.ecs_rev_id = revisaoAtual.rev_id;

            List<Execucao_Caso> listaExCasosTeste = exeCasos.Busca();

            DataTable DtCasoPassos = new DataTable();

            DtCasoPassos.Columns.Add("Id");
            DtCasoPassos.Columns.Add("Descrição");
            DtCasoPassos.Columns.Add("Status");

            foreach (Execucao_Caso auxExCaso in listaExCasosTeste)
            {
                CasoTeste casoAux = new CasoTeste();
                casoAux.cts_id = auxExCaso.ecs_cst_id;
                casoAux = casoAux.Busca()[0];

                DtCasoPassos.Rows.Add(auxExCaso.ecs_id, casoAux.cts_descricao, (auxExCaso.ecs_status == "P" ? "Pendente" : (auxExCaso.ecs_status == "I" ? "Iniciado" : "Finalizado")));
            }

            gridCasosControl.DataSource = DtCasoPassos;
        }

        private void FrmExibicaoCasoTeste_Load(object sender, EventArgs e)
        {

        }
        public void atualizaBarrasProgresso()
        {
            if (CasoTesteExibindo.cts_id != null)
            {
                Casos_Passo aux = new Casos_Passo();
                aux.cps_cts_id = CasoTesteExibindo.cts_id;

                pbrCasoTeste.EditValue = 0;
                pbrCasoTeste.Properties.Minimum = 0;
                pbrCasoTeste.Properties.Maximum = aux.Busca().Count();
                pbrCasoTeste.EditValue = gridView1.SelectedRowsCount;
            }

        }
    }
}