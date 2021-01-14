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

namespace MyReview.View
{
    public partial class FrmCadRevisao : DevExpress.XtraEditors.XtraForm
    {
        Usuario usuLogado = new Usuario();

        public FrmCadRevisao(int idUsuario)
        {
            InitializeComponent();

            usuLogado.usu_id = idUsuario;
            usuLogado = usuLogado.Busca()[0];

            this.LookAndFeel.SkinName = usuLogado.GetUsu_tema();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}