﻿using DevExpress.XtraEditors;
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

        public FrmExibicaoCasoTeste(int idExecucao, int logadoId)
        {
            InitializeComponent();

            usuarioLogado.usu_id = logadoId;
            usuarioLogado = usuarioLogado.Busca()[0];

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false;

            this.LookAndFeel.SkinName = usuarioLogado.GetUsu_tema();
        }

        private void progressBarControl2_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void FrmExibicaoCasoTeste_Load(object sender, EventArgs e)
        {
            
        }
        public void atualizaBarrasProgresso()
        {
            if(CasoTesteExibindo.cts_id != null)
            {
                Casos_Passo aux = new Casos_Passo();
                aux.cps_cts_id = CasoTesteExibindo.cts_id;

                pbrCasoTeste.EditValue = 0;
                pbrCasoTeste.Properties.Minimum = 0;
                pbrCasoTeste.Properties.Maximum = aux.Busca().Count();
              //  pbrCasoTeste.EditValue = 
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            atualizaBarrasProgresso();
        }
    }
}