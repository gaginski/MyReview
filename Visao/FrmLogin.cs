using MyReview.Modelo;
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

namespace MyReview.Controle
{
    public partial class FrmLogin : Form
    {
        private ControleConfig controleConfig = new ControleConfig();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmAtualizaBanco atuBanco = new FrmAtualizaBanco();
            atuBanco.ShowDialog();
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Util ut = new Util();

            lblVersao.Text = "1.1.5.0";

            if (!ut.VerificaConexao())
            {
                MessageBox.Show("Sem Conexão!\nVerifique as configurações!");
                FrmAtualizaBanco atuBanco = new FrmAtualizaBanco();
                atuBanco.ShowDialog();
                this.Close();
            }
            else
            {
                lblConexao.Text = ut.config.banco.ToLower()+" "+ ut.config.host.ToLower();
            }
        }

        private void lblVersao_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            /*Combinações com o alt*/
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case (Keys.E):
                        btnEntra_Click(sender, e);
                        break;
                    case (Keys.T):
                        testes t = new testes();
                        t.Show();
                        break;
                }

            }
            /*Tecla entrer*/
            else if (e.KeyCode == Keys.Enter) 
            {
                if (txtSenha.Focused)
                    entrar();
                else if (txtUsuario.Focused)
                    txtSenha.Focus();
            } else if(e.KeyValue.Equals(27))
            {
                Application.Exit();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
        private void entrar()
        {
            ControleUsuario contUsu = new ControleUsuario();
            List<Usuario> usuarios = contUsu.selecionaUsuarios();
            Usuario usuLogin = new Usuario();
            Boolean valido = false;

            foreach (Usuario u in usuarios)
            {
                if (u.login.Trim().ToUpper().Equals(txtUsuario.Text.ToUpper()) && u.senha.Equals(txtSenha.Text))
                {
                    if (u.status.Equals("F"))
                    {
                        valido = true;
                        usuLogin = u;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Usuário inativo!");
                    }
                }
            }
            if (valido)
            {
                FrmBarraTarefas f = new FrmBarraTarefas(1);
                f.UsuarioLogado(usuLogin.id);
                f.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Invalido!");
            }
        }

        private void chkViewSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
            }
        }
    }
}
