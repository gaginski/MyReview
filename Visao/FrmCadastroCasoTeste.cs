using DevExpress.XtraEditors;
using MyReview.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void FrmCadastroCasoTeste_Load(object sender, EventArgs e)
        {

        }
        private void keyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnIncluiCaso_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNovoPasso_Click(object sender, EventArgs e)
        {
            gridPassos.Rows.Add(gridPassos.Rows.Count, "");
        }
    }
}