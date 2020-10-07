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
       public partial class FrmCadastroUsuarios : Form
    {
        Usuario usu = new Usuario();
        Boolean edit = false;
        ControleUsuario contUsu = new ControleUsuario();

        public FrmCadastroUsuarios()
        {
            InitializeComponent();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Boolean existe = false;
            List<Usuario> listaUsuario = new List<Usuario>();

            listaUsuario = contUsu.selecionaUsuarios();

            if (!txtUsuario.Text.Equals("") && !txtSenha.Text.Equals(""))
            {
                foreach (Usuario u in listaUsuario)
                {
                    if (txtUsuario.Text.ToUpper().Equals(u.login.ToUpper()) && u.id != usu.id)
                        existe = true;
                 }

                if (!existe)
                {
                    usu.login = txtUsuario.Text.ToUpper().Trim();
                    usu.senha = txtSenha.Text;
                    switch (chkAdm.Checked)
                    {
                        case (true):
                            usu.tipo = 1;
                            break;
                        case (false):
                            usu.tipo = 0;
                            break;
                    };

                    switch (chkAtivo.Checked)
                    {
                        case (true):
                            usu.status = "F";
                            break;
                        case (false):
                            usu.status = "X";
                            break;
                    }

                    if (edit)
                    {
                        if (contUsu.alteraUsuario(usu))
                        {
                            MessageBox.Show("Salvo com sucesso!");
                            this.Close();
                        }
                    }
                    else
                    {
                        if (contUsu.gravaUsuario(usu))
                        {
                            MessageBox.Show("Salvo com sucesso!");
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nome de usuário já utilizado!");
                }
            }
            else
            {
                MessageBox.Show("Informe Usuário e Senha!");
            }
          }
        public void editando(int id)
        {
            usu = contUsu.pegaUsuario(id);
            edit = true;

            txtSenha.Text = usu.senha;
            txtUsuario.Text = usu.login;
            
            if(usu.tipo == 1 || usu.tipo == 2)
            {
                chkAdm.Checked = true;
            }
            if(usu.status.Equals("X")){
                chkAtivo.Checked = false;
            }

        }

        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
        }
    }
}
