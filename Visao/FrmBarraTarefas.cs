using MyReview.Controle;
using MyReview.Modelo;
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

    public partial class FrmBarraTarefas : Form
    {
        Usuario usuarioLogado = new Usuario();

        public void UsuarioLogado(int idUsuario)
        {
            ControleUsuario contUsu = new ControleUsuario();
            usuarioLogado = contUsu.pegaUsuario(idUsuario);
            lblUsuarioLogado.Text = usuarioLogado.login.ToUpper();
        }
        public FrmBarraTarefas()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Top = 0;//(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - 580;
            this.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - 139;

        }

        private void FrmBarraTarefas_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmListagemUsuarios C = new FrmListagemUsuarios();
            C.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListagemRevisao r = new FrmListagemRevisao();
            r.ShowDialog();
        }

        private void lblUsuarioLogado_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMinhasTarefas mf = new FrmMinhasTarefas();
            mf.UsuarioLogado(usuarioLogado.id);
            mf.ShowDialog();
        }

        private void frmBarraTarefas_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmListagemCasoTeste lcs = new FrmListagemCasoTeste();
            lcs.ShowDialog();
        }

        private void btnRelatorio_click(object sender, EventArgs e)
        {
            FrmRelatorios rel = new FrmRelatorios();
            rel.UsuarioLogado(usuarioLogado.id);
            rel.ShowDialog();
        }
    }
}
