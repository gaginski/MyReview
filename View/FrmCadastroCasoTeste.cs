using DevExpress.XtraEditors;
using MyReview.Controle;
using MyReview.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.Visao
{
    public partial class FrmCadastroCasoTeste : DevExpress.XtraEditors.XtraForm
    {
        private bool editando;
        private Usuario usuarioLogado = new Usuario();
        private SuiteTeste suite;


        public FrmCadastroCasoTeste(bool editando, int idUsuarioLogado)
        {
            InitializeComponent();

            gridPassos.Rows.Add(1, "");
            suite = new SuiteTeste();

            this.editando = editando;
            usuarioLogado.usu_id = idUsuarioLogado;

            if (editando)
                carregaEditando();

            carregaCombos();


        }
        private void carregaEditando()
        {

        }
        private void carregaNovaSuite()
        {
            suite.sts_descricao = txtTituloSuite.Text;
            suite.sts_versao = txtVersao.Text;
            suite.sts_usu_autor = usuarioLogado.usu_id;
            suite.sts_prj_id = Int32.Parse(cmbProjeto.SelectedValue.ToString());
            suite.sts_objetivo = txtObjetivo.Text;

            suite.Salvar();
            suite.sts_id = Int32.Parse(suite.max("sts_id"));

            txtId.Text = suite.sts_id.ToString();
        }

        private void btnNovoPasso_Click(object sender, EventArgs e)
        {
            bool verificador = true;
            for (int i = 0; i < gridPassos.Rows.Count; i++)
            {
                if (gridPassos.Rows[i].Cells[1].Value == "" && gridPassos.Rows[i].Cells[0].Value != "" && verificador)
                {
                    new FrmAlerta("Atenção! Informe a descrição de todos os passos antes de inserir um novo!").ShowDialog();
                    verificador = false;
                }
            }
            if (verificador)
                gridPassos.Rows.Add(gridPassos.Rows.Count, "");

            MessageBox.Show(gridPassos.Rows.Count.ToString());
        }

        private void carregaCombos()
        {
            DataTable prioridades = new DataTable();

            prioridades.Columns.Add("Descricao");
            prioridades.Columns.Add("valor");

            prioridades.Rows.Add("Baixa", "1");
            prioridades.Rows.Add("Normal", "2");
            prioridades.Rows.Add("Alta", "3");
            prioridades.Rows.Add("Urgente", "4");

            cmbPrioridade.DataSource = prioridades;
            cmbPrioridade.DisplayMember = "Descricao";
            cmbPrioridade.ValueMember = "valor";
            cmbPrioridade.SelectedIndex = 0;

            List<Projeto> listaProjeto = new Projeto().Todos();
            DataTable projeto = new DataTable();

            projeto.Columns.Add("Projeto");
            projeto.Columns.Add("id");

            foreach (Projeto p in listaProjeto)
                projeto.Rows.Add(p.pjt_nome, p.pjt_id);

            cmbProjeto.DataSource = projeto;
            cmbProjeto.DisplayMember = "Projeto";
            cmbProjeto.ValueMember = "id";

            if (listaProjeto.Count > 0)
                cmbProjeto.SelectedIndex = 0;
        }
        private void btnIncluiCaso_Click(object sender, EventArgs e)
        {
            if (validaCamposCT())
            {
                bool valida = true;

                if (suite.sts_id == null)
                    carregaNovaSuite();

                #region inclusaoNovo
                CasoTeste casoAux = new CasoTeste();

                casoAux.cts_sts_id = suite.sts_id;
                casoAux.cts_indice = (Int32.Parse(casoAux.max("cts_indice")) == 0) ? Int32.Parse(casoAux.max("cts_indice")) : Int32.Parse(casoAux.max("cts_indice")) + 1;
                casoAux.cts_dataInclusao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                casoAux.cts_precondicoes = txtPrecondicao.Text;
                casoAux.cts_prioridade = Int32.Parse(cmbPrioridade.SelectedValue.ToString());
                casoAux.cts_resultadoEsperado = txtResultado.Text;
                casoAux.cts_tempoEstimado = Int32.Parse(sedTempoEstimado.Text);
                casoAux.cts_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                casoAux.cts_Observacao = txtObs.Text;
                casoAux.cts_terminalUltimaAleracao = Environment.MachineName;

                if (valida)
                    valida = casoAux.Salvar();

                casoAux.cts_id = Int32.Parse(casoAux.max("cts_id"));

                List<Casos_Passo> listaPassos = montaListaPassos(casoAux.cts_id);

                foreach (Casos_Passo cp in listaPassos)
                    if (valida)
                        cp.Salvar();

                if (valida)
                {
                    gridPassos.Rows.Clear();
                    txtDescricaoCaso.Text = "";
                    txtPrecondicao.Text = "";
                    txtResultado.Text = "";
                    txtObs.Text = "";
                    sedTempoEstimado.Text = "0";
                    cmbPrioridade.SelectedIndex = 0;
                    new FrmAlerta("Salvo com Sucesso!");
                }
                    
            }
            #endregion
        }

        private List<Casos_Passo> montaListaPassos(int idCasoTeste)
        {
            List<Casos_Passo> listaPassos = new List<Casos_Passo>();

            for (int i = 0; i < gridPassos.RowCount; i++)
            {
                if (gridPassos.Rows[i].Cells[0].Value != null && gridPassos.Rows[i].Cells[1].Value != null)
                {
                    Casos_Passo aux = new Casos_Passo();

                    aux.cps_indice = Int32.Parse(gridPassos.Rows[i].Cells[0].Value.ToString());
                    aux.cps_descricao = gridPassos.Rows[i].Cells[1].Value.ToString();
                    aux.cps_cts_id = idCasoTeste;
                    aux.cps_dataInclusao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    aux.cps_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    aux.cps_terminalUltimaAleracao = Environment.MachineName;

                    listaPassos.Add(aux);
                }
            }
            return listaPassos;
        }
        private bool validaCamposCT()
        {
            List<String> campos = new List<string>();
            bool valida = false;

            if (txtDescricaoCaso.Text == "")
                campos.Add("Descrição do caso de teste");
            if (txtPrecondicao.Text == "")
                campos.Add("Pré-condições");
            if (txtResultado.Text == "")
                campos.Add("Resultado Esperado");
            if (sedTempoEstimado.Text == "" || sedTempoEstimado.Text == "0")
                campos.Add("Tempo estimado");

            if (campos.Count > 0)
            {
                valida = false;
                new FrmAlerta("Atenção! Alguns campos obrigatórios não foram preenchidos: " + string.Join(", ", campos.ToArray()) + ".");
            }

            if (gridPassos.Rows.Count == 2 && gridPassos.Rows[0].Cells[1].Value == "" && valida)
            {
                valida = false;
                new FrmAlerta("Atenção! Um caso de teste precisa ter ao menos um passo!");
            }

            return valida;
        }

        private void gridPassos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}