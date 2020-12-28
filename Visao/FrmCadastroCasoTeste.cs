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
        }

        private void pnlCadatroCasosTeste_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            DataTable dtPassos = new DataTable();
            dtPassos.Columns.Add("#");
            dtPassos.Columns.Add("Passos");

            grid1.DataSource = dtPassos;

            grid1.AddNewRecord();
         }
    }
}