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
        public FrmCadastroCasoTeste()
        {
            InitializeComponent();
            gridPassos.Rows.Add(1, "");
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
        private List<Casos_Passo> montaListaPassos()
        {
            List < Casos_Passo > listaPassos = new List<Casos_Passo>();

            for(int i = 0; i<gridPassos.RowCount; i++)
            {
                if(gridPassos.Rows[i].Cells[0].Value != null && gridPassos.Rows[i].Cells[1].Value != null)
                {
                    Casos_Passo aux = new Casos_Passo();

                    aux.cps_indice = Int32.Parse(gridPassos.Rows[i].Cells[0].Value.ToString());
                    aux.cps_descricao = gridPassos.Rows[i].Cells[1].Value.ToString();
                    aux.cps_cts_id = 1; // ajustar
                    aux.cps_dataInclusao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    aux.cps_ultimaAlteracao = DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                    listaPassos.Add(aux);
                }
            }

            return listaPassos;
        }

        private void btnIncluiCaso_Click(object sender, EventArgs e)
        {
            CasoTeste casoAux = new CasoTeste();
            
            // implementar preenchimento da classe

            List<Casos_Passo> listaPassos = montaListaPassos();
            foreach(Casos_Passo cp in listaPassos)
            {
                cp.Salvar();
            }

        }
    }
    }