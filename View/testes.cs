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
            cmb.Properties.Items.Add("ItemName");
            cmb.Properties.Items.Add("DevExpress Style");
            cmb.Properties.Items.Add("DevExpress Dark Style");
            cmb.Properties.Items.Add("VS2010");
            cmb.Properties.Items.Add("Seven Classic");
            cmb.Properties.Items.Add("Office 2010 Blue");
            cmb.Properties.Items.Add("Office 2010 Black");
            cmb.Properties.Items.Add("Office 2010 Silver");
            cmb.Properties.Items.Add("Office 2013");
            cmb.Properties.Items.Add("Office 2013 Dark Gray");
            cmb.Properties.Items.Add("Office 2013 Light Gray");
            cmb.Properties.Items.Add("Visual Studio 2013 Blue");
            cmb.Properties.Items.Add("Visual Studio 2013 Light");
            cmb.Properties.Items.Add("Visual Studio 2013 Dark");
            cmb.Properties.Items.Add("Office 2016 Colorful");
            cmb.Properties.Items.Add("Office 2016 Dark");
            cmb.Properties.Items.Add("Office 2016 Black");
            cmb.Properties.Items.Add("The Bezier");
            cmb.Properties.Items.Add("Basic");
            cmb.Properties.Items.Add("Office 2019 Colorful");
            cmb.Properties.Items.Add("Office 2019 Black");
            cmb.Properties.Items.Add("Office 2019 White");
            cmb.Properties.Items.Add("Office 2019 Dark Gray");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmCadastroCasoTeste t = new FrmCadastroCasoTeste(false, 10);
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
            FrmCadUsuario usuCad = new FrmCadUsuario(false, 10, 2);
            usuCad.Show();

        }

        private void btnAlerta_Click(object sender, EventArgs e)
        {
            FrmAlerta alerta = new FrmAlerta("Menssagem de Alerta Teste!", null);
            alerta.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            FrmListaUsuarios lu = new FrmListaUsuarios(2);
            lu.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            new FrmExibicaoCasoTeste(1, 10).ShowDialog();
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

                    new FrmAlerta("passou:" + contador, null).Show();
                    passou = true;
                }
                catch (Exception error)
                {

                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.LookAndFeel.SkinName = cmb.SelectedText;

            DataTable dttProdutos;
            dttProdutos = new DataTable();
            dttProdutos.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("CodigoBarras"),
                new DataColumn("Descricao"),
                new DataColumn("UM"),
                new DataColumn("Qtd"),
                new DataColumn("QtdImportar"),
                new DataColumn("ValorUnit"),
                new DataColumn("ValorTotal")
            });
            dttProdutos.Columns["Qtd"].DataType = typeof(decimal);
            dttProdutos.Columns["QtdImportar"].DataType = typeof(decimal);
            dttProdutos.Columns["ValorUnit"].DataType = typeof(decimal);
            dttProdutos.Columns["ValorTotal"].DataType = typeof(decimal);

            for (int i = 0; i < 10; i++)
            {
                dttProdutos.Rows.Add(i, i + 1, i + 2, i + 3
                    , i + 4, i + 5, i + 6);
            }
            gridControl1.DataSource = dttProdutos;

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            new FrmCadRevisao(10, false).Show();
        }
    }
}