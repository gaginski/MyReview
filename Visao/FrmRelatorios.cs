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
    public partial class FrmRelatorios : Form
    {
        Usuario usuarioLogado = new Usuario();
        ControleRelatorio contRel = new ControleRelatorio();
        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {

        }
        public void UsuarioLogado(int idUsuario)
        {
            ControleUsuario contUsu = new ControleUsuario();
            usuarioLogado = contUsu.pegaUsuario(idUsuario);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtRelatorio.Text = contRel.geraRelatorio(usuarioLogado, Convert.ToDateTime(txtInicial.Text), Convert.ToDateTime(txtFinal.Text)).ToUpper();
            validaCampos();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.H):
                    if (txtInicial.Focused)
                    {
                        txtInicial.Text = DateTime.Now.ToString();
                    }
                    if (txtFinal.Focused)
                    {
                        txtFinal.Text = DateTime.Now.ToString();
                    }
                    break;
            }
        }
        private void validaCampos()
        {
            txtInicial.Text = (txtInicial.Text.Contains("  :  ") && !txtInicial.Text.Equals("  /  /       :  ")) ? txtInicial.Text.Replace("  :  ", "00:00") : txtInicial.Text; // tem algo errado, mas não sei o que
            txtFinal.Text = (txtFinal.Text.Contains("  :  ") && !txtFinal.Text.Equals("  /  /       :  ")) ? txtFinal.Text.Replace("  :  ", "23:59") : txtFinal.Text; // || |||||||||||||||||||
        }

    }
}
