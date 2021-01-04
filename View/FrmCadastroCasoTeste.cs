using DevExpress.XtraEditors;
using MyReview.Controle;
using MyReview.Model;
using MyReview.Modelo;
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
        private Modelo.Usuario usuarioLogado;
        private SuiteTeste suite;


        public FrmCadastroCasoTeste(bool editando, int idUsuarioLogado)
        {
            InitializeComponent();
            
            gridPassos.Rows.Add(1, "");
            suite = new SuiteTeste();

            this.editando = editando;
            // pega usuario

            if (editando)
                carregaEditando(); 
            else 
                carregaNovaSuite(); // fazer isso na inclusão do caso de teste 
        }
        private void carregaEditando()
        {

        }
        private void carregaNovaSuite()
        {
            suite.Salvar();
            suite.sts_id = Int32.Parse(suite.max("sts_id"));

            txtId.Text = suite.sts_id.ToString();
         }

        private void btnNovoPasso_Click(object sender, EventArgs e)
        {
            /*TODO - Ajustar, algo de erado não está certo*/
            /*bool verificador = true;
            for(int i = 0; i< gridPassos.Rows.Count; i++)
            {
                if(gridPassos.Rows[i].Cells[1].Value != null && verificador)
                {
                    MessageBox.Show("Informe a descrição do passo " + i+1);
                    verificador = false;
                }
            }
            if(verificador)*/
                gridPassos.Rows.Add(gridPassos.Rows.Count, "");
        }
        private List<Casos_Passo> montaListaPassos(int idCasoTeste)
        {
            List < Casos_Passo > listaPassos = new List<Casos_Passo>();

            for(int i = 0; i<gridPassos.RowCount; i++)
            {
                if(gridPassos.Rows[i].Cells[0].Value != null && gridPassos.Rows[i].Cells[1].Value != null)
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

        private void btnIncluiCaso_Click(object sender, EventArgs e)
        {
            // fazer verificar se a suite está salva, caso não esteja, salvar
            #region inclusaoNovo
            CasoTeste casoAux = new CasoTeste();
            
            casoAux.cts_sts_id = suite.sts_id;
            casoAux.cts_indice = (Int32.Parse(casoAux.max("cts_indice")) == 0) ? Int32.Parse(casoAux.max("cts_indice")): Int32.Parse(casoAux.max("cts_indice")) + 1;
            casoAux.cts_dataInclusao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            casoAux.cts_precondicoes = txtPrecondicao.Text;
            casoAux.cts_prioridade = Int32.Parse(cmbPrioridade.Text);
            casoAux.cts_resultadoEsperado = txtResultado.Text;
            casoAux.cts_tempoEstimado = Int32.Parse(sedTempoEstimado.Text);
            casoAux.cts_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            casoAux.cts_terminalUltimaAleracao = Environment.MachineName;

            casoAux.Salvar();
            casoAux.cts_id = Int32.Parse(casoAux.max("cts_id"));

            List<Casos_Passo> listaPassos = montaListaPassos(casoAux.cts_id);

            foreach(Casos_Passo cp in listaPassos)
                cp.Salvar();

            #endregion
        }
    }
    }