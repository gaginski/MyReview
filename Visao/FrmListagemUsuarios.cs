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
    public partial class FrmListagemUsuarios : Form
    {
        ControleUsuario contUsu = new ControleUsuario();


        public FrmListagemUsuarios()
        {
            InitializeComponent();
        }

        private void FrmListagemUsuarios_Load(object sender, EventArgs e)
        {
            cmbExibir.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbExibir.Items.Add("Todos");
            cmbExibir.Items.Add("Ativos");
            cmbExibir.Items.Add("Inativos");

            cmbExibir.SelectedIndex = 1;

            carregaGrid();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios cad = new FrmCadastroUsuarios();
            cad.ShowDialog();
            carregaGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridUsuarios.CurrentRow.Cells[0].Value != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    contUsu.apagaUsuario(int.Parse(gridUsuarios.CurrentRow.Cells[0].Value.ToString()));
                    carregaGrid();
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridUsuarios.CurrentRow.Cells[0].Value != null)
            {
                FrmCadastroUsuarios cad = new FrmCadastroUsuarios();
                cad.editando(int.Parse(gridUsuarios.CurrentRow.Cells[0].Value.ToString()));
                cad.ShowDialog();
                gridUsuarios.Rows.Clear();
                carregaGrid();
            }
            else
            {
                MessageBox.Show("Selecione um registro!");
            }

        }
        private void carregaGrid()
        {
            ControleUsuario contu = new ControleUsuario();
            var listaUsuario = contu.selecionaUsuarios();

            gridUsuarios.Rows.Clear();

            gridUsuarios.ColumnCount = 3;
            gridUsuarios.Columns[0].Name = "ID";
            gridUsuarios.Columns[1].Name = "Usuário";
            gridUsuarios.Columns[2].Name = "Status";

            var linha = new List<String[]>();

            foreach (Usuario u in listaUsuario)
            {
                String status;
                switch (u.status)
                {
                    case ("F"): status = "Ativo"; break;
                    case ("X"): status = "Inativo"; break;
                    default: status = "Indefinido"; break;
                }
                String[] aux = new String[] { u.id.ToString(), u.login, status };
                linha.Add(aux);
            }
            foreach (String[] a in linha)
            {
                switch (cmbExibir.Text)
                {
                    case ("Ativos"):
                        if (a[2].Equals("Ativo"))
                            gridUsuarios.Rows.Add(a);
                        break;

                    case ("Inativos"):
                        if (a[2].Equals("Inativo"))
                            gridUsuarios.Rows.Add(a);
                        break;

                    default:
                        gridUsuarios.Rows.Add(a);
                        break;
                }
            }
            for (int i = 0; i < gridUsuarios.Columns.Count; i++)
            {
                gridUsuarios.Columns[i].ReadOnly = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaGrid();
        }
    }
}
