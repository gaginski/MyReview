using DevExpress.XtraEditors;
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
    public partial class testes : DevExpress.XtraEditors.XtraForm
    {
        public testes()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmCadastroCasoTeste t = new FrmCadastroCasoTeste(false, 2);
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
			FrmCadUsuario usuCad = new FrmCadUsuario(false, 0, 0);
               usuCad.Show();


		}


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmCadUsuario usuCad = new FrmCadUsuario(false, 2, 2);
               usuCad.Show();

        }
           
        private void btnAlerta_Click(object sender, EventArgs e)
        {
            FrmAlerta alerta = new FrmAlerta("Menssagem de Alerta Teste!");
            alerta.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            FrmListaUsuarios lu = new FrmListaUsuarios(2);
            lu.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            new FrmExibicaoCasoTeste(1).ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            bool passou = false;
            Util u = new Util();
            String chave = "";
            int contador = 0;
            while (!passou)
            {
                chave += "a";
                contador++;

                try
                {
                    u.criptografa("teste", chave);

                    new FrmAlerta("passou:" + contador).Show();
                    passou = true;
                }
                catch (Exception error)
                {

                }
            }
        }
    }
}