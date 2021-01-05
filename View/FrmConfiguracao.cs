using DevExpress.XtraEditors;
using MyReview.Model;
using MyReview.Visao;
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
    public partial class FrmConfiguracao : DevExpress.XtraEditors.XtraForm
    {
        public FrmConfiguracao()
        {
            InitializeComponent();
            atualizaGridProjetos();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtNome.Text != "")
            {
                Projeto pj = new Projeto();
                pj.pjt_nome = txtNome.Text;

                if(pj.Salvar())
                    txtNome.Text = "";

                atualizaGridProjetos();
            }
            else
                new FrmAlerta("Atenção! Informe o nome do projeto!").ShowDialog();
            
        }

        private void atualizaGridProjetos()
        {
            List < Projeto > listaProjetos = new Projeto().Todos();

            gridProjetos.Rows.Clear();

            gridProjetos.ColumnCount = 2;
            gridProjetos.Columns[0].Name = "ID";
            gridProjetos.Columns[1].Name = "Nome";

            gridProjetos.Columns[0].Width = 30;

            foreach (Projeto p in listaProjetos)
                gridProjetos.Rows.Add(p.pjt_id.ToString(), p.pjt_nome) ;
        }
    }
}