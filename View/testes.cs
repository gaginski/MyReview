using DevExpress.XtraEditors;
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
    public partial class testes : DevExpress.XtraEditors.XtraForm
    {
        public testes()
        {
            InitializeComponent();
            //panel1.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmCadastroCasoTeste t = new FrmCadastroCasoTeste(false, 1);
            t.Show();
        }

        private void testes_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("12062019"))
            {
                panel1.Enabled = true;
            }
        }

        private void textSenhaTeste_keyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Equals("12062019"))
            {
                panel1.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Equals("12062019"))
            {
                panel1.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmCadUsuario usuCad = new FrmCadUsuario(false, 0, 0);
               usuCad.Show();

        }

        private void btnAlerta_Click(object sender, EventArgs e)
        {
            FrmAlerta alerta = new FrmAlerta("Menssagem de Alerta Teste!");
            alerta.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmListaUsuarios lu = new FrmListaUsuarios(7);
            lu.Show();
        }
    }
}