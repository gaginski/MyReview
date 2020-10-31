using MyReview.Controle;
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

namespace MyReview
{
    public partial class FrmAtualizaBanco : Form
    {
        ControleConfig contConfig = new ControleConfig();
        public FrmAtualizaBanco()
        {
            InitializeComponent();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Util ut = new Util();
            ControleAtualizacao atu = new ControleAtualizacao();

            if (!ut.VerificaConexao())
                MessageBox.Show("Impossivel conectar!");
            else
            {
                atu.atualizaBanco();
            }
        }

        private void FrmAtualizaBanco_Load(object sender, EventArgs e)
        {
            contConfig.carregaConfig();

            txtBanco.Text = contConfig.conf.banco;
            txtServidor.Text = contConfig.conf.host;
            txtPorta.Text = contConfig.conf.porta;
            txtSenha.Text = contConfig.conf.senha;
            txtUsuario.Text = contConfig.conf.usuario;
        }
        private Config montaConfig()
        {
            Config config = new Config();
            config.banco = txtBanco.Text;
            config.host = txtServidor.Text;
            config.porta = txtPorta.Text;
            config.senha = txtSenha.Text;
            config.usuario = txtUsuario.Text;
            return config;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Config conf = montaConfig();
            if (contConfig.salvaConfig(conf))
            {
                MessageBox.Show("Salvo com sucesso!\n Por favor, reinicie a aplicação!");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config conf = montaConfig();
            Util ut = new Util(conf);

            if (!ut.VerificaConexao())
                MessageBox.Show("Impossivel conectar!");
            else
            {
                MessageBox.Show("Conexão disponível!");
            }
        }
    }
}
