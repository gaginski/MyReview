using MyReview.Controle;
using MyReview.Model;
using MyReview.View;
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
            /*ControleUsuario contUsu = new ControleUsuario();
            usuarioLogado = contUsu.pegaUsuario(idUsuario);
            lblUsuarioLogado.Text = usuarioLogado.login.ToUpper();*/
        }
        public FrmBarraTarefas(int idUsuario)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Top = 0;
            this.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - 139;

            usuarioLogado.usu_id = idUsuario;
            List<Usuario> list = usuarioLogado.Busca();

            usuarioLogado = list[0];
            validaPermicao();

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FrmListaUsuarios(usuarioLogado.usu_id).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListagemRevisao r = new FrmListagemRevisao();
            r.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMinhasTarefas mf = new FrmMinhasTarefas();
            mf.UsuarioLogado(usuarioLogado.usu_id);
            mf.ShowDialog();
        }

        private void frmBarraTarefas_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            FrmListagemCasoTeste lcs = new FrmListagemCasoTeste();
            lcs.ShowDialog();
        }

        private void btnRelatorio_click(object sender, EventArgs e)
        {
            FrmRelatorios rel = new FrmRelatorios();
            rel.UsuarioLogado((int)usuarioLogado.usu_id);
            rel.ShowDialog();
        }

        private void validaPermicao()
        {
            btnUsuario.Enabled = usuarioLogado.UsuListar;
            btnRevisao.Enabled = usuarioLogado.RevListar;
            btnCasoTeste.Enabled = usuarioLogado.CTListar;
            btnMinhasTarefas.Enabled = usuarioLogado.ExCTListar;
            btnConfig.Enabled = usuarioLogado.OutrasConfig;
        }
        }
}
