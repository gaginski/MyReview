using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Layout;
using MyReview.Controle;
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
        Usuario usuLogado = new Usuario();

        public FrmConfiguracao(int? IdUsuarioLogado)
        {
            InitializeComponent();

            usuLogado.usu_id = IdUsuarioLogado;
            usuLogado = usuLogado.Busca().Count > 0 ? usuLogado.Busca()[0] : new Usuario();

            atualizaGridProjetos();
            atualizaCombos();

            this.LookAndFeel.SkinName = usuLogado.GetUsu_tema();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {
                Projeto pj = new Projeto();
                pj.pjt_nome = txtNome.Text;

                if (pj.Salvar())
                    txtNome.Text = "";

                atualizaGridProjetos();
            }
            else
                new FrmAlerta("Atenção! Informe o nome do projeto!", usuLogado.usu_id).ShowDialog();

        }

        private void atualizaGridProjetos()
        {
            List<Projeto> listaProjetos = new Projeto().Todos();

            gridProjetos.Rows.Clear();

            gridProjetos.ColumnCount = 2;
            gridProjetos.Columns[0].Name = "ID";
            gridProjetos.Columns[1].Name = "Nome";

            gridProjetos.Columns[0].Width = 30;

            foreach (Projeto p in listaProjetos)
                gridProjetos.Rows.Add(p.pjt_id.ToString(), p.pjt_nome);
        }

        private void FrmConfiguracao_Load(object sender, EventArgs e)
        {

        }
        private void atualizaCombos()
        {
            Util u = new Util();

            foreach (String thema in u.GetTheme())
                cmbTema.Properties.Items.Add(thema);

            cmbTema.SelectedItem = usuLogado.GetUsu_tema();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            this.LookAndFeel.SkinName = (string)cmbTema.SelectedItem;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            this.LookAndFeel.SkinName = (string)cmbTema.SelectedItem;

            usuLogado.usu_tema = (string)cmbTema.SelectedItem;
            usuLogado.update();
        }
    }
}