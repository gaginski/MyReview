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

namespace MyReview.Visao
{
    public partial class FrmAlerta : DevExpress.XtraEditors.XtraForm
    {
        public FrmAlerta(String Mensagem)
        {
            InitializeComponent();

            this.lblMensagem.Text = Mensagem;
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