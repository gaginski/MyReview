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
    public partial class FrmCadUsuario : DevExpress.XtraEditors.XtraForm
    {
        Usuario usu_editando = new Usuario();
        Usuario usu_logado = new Usuario();
        Usuario novoUsuario = new Usuario();
        private bool editando = false;


        public FrmCadUsuario(bool editando, int? Id_usuLogado, int usu_editar)
        {
            InitializeComponent();

            usu_logado.usu_id = Id_usuLogado;
            usu_logado.Busca();
            this.editando = editando;


            if (editando)
            {
                usu_editando.usu_id = usu_editar;
                loadEditando();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                novoUsuario.usu_nome = txtNome.Text;
                novoUsuario.usu_senha = txtSenha.Text;
                novoUsuario.usu_senha = txtConfirmaSenha.Text;
                novoUsuario.usu_email = txtEmail.Text;
                novoUsuario.usu_login = txtLogin.Text;
                novoUsuario.usu_ativo = chkAtivo.Checked;
                novoUsuario.usu_enviaemail = chkEmail.Checked;
                novoUsuario.CTAdicionar = chkCTAdicionar.Checked;
                novoUsuario.CTAutoriaPropria = chkCTAutoriaPropria.Checked;
                novoUsuario.CTEditar = chkCTEditar.Checked;
                novoUsuario.CTListar = chkCTListar.Checked;
                novoUsuario.CTRemover = chkCTRemover.Checked;
                novoUsuario.ExCTAbrir = chkExCTAbrir.Checked;
                novoUsuario.ExCTIniFim = chkExCTIniFim.Checked;
                novoUsuario.ExCTListar = chkExCTListar.Checked;
                novoUsuario.ExCTOutrosUsu = chkExCTOutrosUsu.Checked;
                novoUsuario.OutrasConfig = chkOutrasConfig.Checked;
                novoUsuario.RevAdicionar = chkRevAdicionar.Checked;
                novoUsuario.RevEditar = chkRevEditar.Checked;
                novoUsuario.RevListar = chkRevListar.Checked;
                novoUsuario.RevRemover = chkRevRemover.Checked;
                novoUsuario.UsuAdicionar = chkUsuAdicionar.Checked;
                novoUsuario.UsuEditar = chkUsuEditar.Checked;
                novoUsuario.UsuListar = chkUsuListar.Checked;
                novoUsuario.UsuPermissoes = chkUsuPermissoes.Checked;
                novoUsuario.UsuRemover = chkUsuRemover.Checked;

                if (!editando)
                {
                    novoUsuario.usu_dataCad = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    novoUsuario.usu_usuario_cad = usu_logado.usu_id;
                }
                novoUsuario.usu_dataAlteracao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                usu_logado.usu_terminal_alteracao = Environment.MachineName.ToString();
 
                if (editando ? novoUsuario.update() : novoUsuario.Salvar())
                {
                    FrmAlerta alerta = new FrmAlerta("Salvo com sucesso!");
                    alerta.ShowDialog();
                    this.Close();
                }
            }
        }
        private bool validaCampos()
        {
            bool _return = true;
            List<String> campos = new List<string>();

            if (txtLogin.Text.Equals("") || txtLogin.Text == null)
                campos.Add("Login");
            if (txtNome.Text.Equals("") || txtNome.Text == null)
                campos.Add("Nome");
            if (txtSenha.Text.Equals("") || txtSenha.Text == null)
                campos.Add("Senha");
            if (txtConfirmaSenha.Text.Equals("") || txtConfirmaSenha.Text == null)
                campos.Add("Confirmação da Senha");
            if ((txtEmail.Text.Equals("") || txtEmail.Text == null) && chkEmail.Checked)
                campos.Add("Email");

            if (campos.Count > 0)
            {
                _return = false;
                FrmAlerta alerta = new FrmAlerta("Atenção! Alguns campos obrigatórios não foram informados: " + string.Join(", ", campos.ToArray()));
                alerta.ShowDialog();
            }

            if (!txtSenha.Text.Equals(txtConfirmaSenha.Text))
            {
                _return = false;
                FrmAlerta alerta = new FrmAlerta("Atenção! O campo senha difere do campo de confirmação de senha!");
                alerta.ShowDialog();
            }

            Usuario aux = new Usuario();

            if (aux.selectGenerico("count(usu_login)", "usu_login = '"+ txtLogin.Text+"'") != "0" && !editando)
			{
                _return = false;
                FrmAlerta alerta = new FrmAlerta("Atenção! Já existe um usuário cadastrado com esse login!");
                alerta.ShowDialog();
            }

            return _return;
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                chkCTAdicionar.Checked = true;
                chkCTAutoriaPropria.Checked = true;
                chkCTEditar.Checked = true;
                chkCTListar.Checked = true;
                chkCTRemover.Checked = true;
                chkExCTAbrir.Checked = true;
                chkExCTIniFim.Checked = true;
                chkExCTListar.Checked = true;
                chkExCTOutrosUsu.Checked = true;
                chkOutrasConfig.Checked = true;
                chkRevAdicionar.Checked = true;
                chkRevEditar.Checked = true;
                chkRevListar.Checked = true;
                chkRevRemover.Checked = true;
                chkUsuAdicionar.Checked = true;
                chkUsuEditar.Checked = true;
                chkUsuListar.Checked = true;
                chkUsuPermissoes.Checked = true;
                chkUsuRemover.Checked = true;
            }
            else
            {
                chkCTAdicionar.Checked = false;
                chkCTAutoriaPropria.Checked = false;
                chkCTEditar.Checked = false;
                chkCTListar.Checked = false;
                chkCTRemover.Checked = false;
                chkExCTAbrir.Checked = false;
                chkExCTIniFim.Checked = false;
                chkExCTListar.Checked = false;
                chkExCTOutrosUsu.Checked = false;
                chkOutrasConfig.Checked = false;
                chkRevAdicionar.Checked = false;
                chkRevEditar.Checked = false;
                chkRevListar.Checked = false;
                chkRevRemover.Checked = false;
                chkUsuAdicionar.Checked = false;
                chkUsuEditar.Checked = false;
                chkUsuListar.Checked = false;
                chkUsuPermissoes.Checked = false;
                chkUsuRemover.Checked = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Deseja sair sem salvar?", "Atenção",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Exclamation);

            if (resposta.ToString().Equals("Yes"))
                this.Close();
        }

        private void loadEditando()
        {
            List<Usuario> aux = usu_editando.Busca();

            usu_editando = aux[0];

            txtNome.Text = usu_editando.usu_nome;
            txtSenha.Text = usu_editando.usu_senha;
            txtConfirmaSenha.Text = usu_editando.usu_senha;
            txtEmail.Text = usu_editando.usu_email;
            txtLogin.Text = usu_editando.usu_login;
            chkAtivo.Checked = usu_editando.usu_ativo;
            chkEmail.Checked = usu_editando.usu_enviaemail;
            chkCTAdicionar.Checked = usu_editando.CTAdicionar;
            chkCTAutoriaPropria.Checked = usu_editando.CTAutoriaPropria;
            chkCTEditar.Checked = usu_editando.CTEditar;
            chkCTListar.Checked = usu_editando.CTListar;
            chkCTRemover.Checked = usu_editando.CTRemover;
            chkExCTAbrir.Checked = usu_editando.ExCTAbrir;
            chkExCTIniFim.Checked = usu_editando.ExCTIniFim;
            chkExCTListar.Checked = usu_editando.ExCTListar;
            chkExCTOutrosUsu.Checked = usu_editando.ExCTOutrosUsu;
            chkOutrasConfig.Checked = usu_editando.OutrasConfig;
            chkRevAdicionar.Checked = usu_editando.RevAdicionar;
            chkRevEditar.Checked = usu_editando.RevEditar;
            chkRevListar.Checked = usu_editando.RevListar;
            chkRevRemover.Checked = usu_editando.RevRemover;
            chkUsuAdicionar.Checked = usu_editando.UsuAdicionar;
            chkUsuEditar.Checked = usu_editando.UsuEditar;
            chkUsuListar.Checked = usu_editando.UsuListar;
            chkUsuPermissoes.Checked = usu_editando.UsuPermissoes;
            chkUsuRemover.Checked = usu_editando.UsuRemover;

            novoUsuario = usu_editando;
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}