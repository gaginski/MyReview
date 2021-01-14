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

namespace MyReview.Visao
{
    public partial class FrmAlerta : DevExpress.XtraEditors.XtraForm
    {
        Usuario usuLogado = new Usuario();

        public FrmAlerta(String Mensagem, int? usuId)
        {
            InitializeComponent();

            usuLogado.usu_id = usuId;
            usuLogado = usuLogado.Busca().Count > 0 ? usuLogado.Busca()[0] : new Usuario();

            this.lblMensagem.Text = Mensagem;
            this.LookAndFeel.SkinName = usuLogado.GetUsu_tema();
        }


        private void FrmAlerta_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close(object sender, FormClosedEventArgs e)
        {

        }
    }
}