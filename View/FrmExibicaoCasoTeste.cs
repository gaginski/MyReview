using DevExpress.XtraEditors;
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

        public FrmExibicaoCasoTeste(int idExecucao, int logadoId)
        {
            InitializeComponent();
            progressBarControl1.PerformStep();
            progressBarControl2.PerformStep();
            progressBarControl2.PerformStep();

            usuarioLogado.usu_id = logadoId;
            usuarioLogado = usuarioLogado.Busca()[0];

            this.LookAndFeel.SkinName = usuarioLogado.GetUsu_tema();
        }

        private void progressBarControl2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}