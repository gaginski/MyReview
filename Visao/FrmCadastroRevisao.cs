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
    public partial class FrmCadastroRevisao : Form
    {
        Boolean editando = false;
        Tarefa tarefa = new Tarefa();
        Revisao revisao = new Revisao();
        DataTable dt = new DataTable();
        DataTable modelo = new DataTable();

        ControleTarefas contTar = new ControleTarefas();
        ControleUsuario contUso = new ControleUsuario();
        ControleRevisao contRev = new ControleRevisao();

        List<Usuario> usu = new List<Usuario>();
        List<Tarefa> lista = new List<Tarefa>();
        List<Tarefa> listaAux = new List<Tarefa>();


        public FrmCadastroRevisao()
        {
            InitializeComponent();
            atualizaLista();
            atualizaGrid(true);
            txtCodigoSia.Enabled = false;
            modelo.Columns.Add("Id");
            modelo.Columns.Add("Titulo");
            modelo.Rows.Add(0, "");
            List<Revisao> lr = contRev.selecionaRevisoes();

            foreach (Revisao r in lr)
            {
                if (r.modelo)
                {
                    modelo.Rows.Add(r.id, r.descricao);
                }
            }
            cmbModelos.ValueMember = "Id";
            cmbModelos.DisplayMember = "Titulo";
            cmbModelos.DataSource = modelo;

            cmbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtTituloTarefa.Text.Equals(""))
            {
                if ((chkSia.Checked && txtCodigoSia.Text != "") || (!chkSia.Checked))
                {
                    tarefa = new Tarefa();
                    tarefa.titulo = txtTituloTarefa.Text;
                    tarefa.descricao = txtDescricaoTarefa.Text;
                    tarefa.codigoSia = txtCodigoSia.Text;
                    tarefa.sia = true;
                    tarefa.idRevisao = revisao.id;

                    tarefa = contTar.salvaTarefa(tarefa);

                    txtTituloTarefa.Text = null;
                    txtDescricaoTarefa.Text = null;
                    txtCodigoSia.Text = null;
                    lista.Add(tarefa);
                    atualizaGrid(true);
                }
                else
                    MessageBox.Show("Informe a tarefa do SIA");
            }
            else
                MessageBox.Show("Informe o título da Tarefa");
        }
        public void atualizaVinculadas()
        {
            foreach (Tarefa t in lista)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (grid.Rows[i].Cells[0].Value != null)
                        if (grid.Rows[i].Cells[0].Value.ToString() == t.id.ToString())
                        {
                            if (grid.Rows[i].Cells[3].Value.Equals(true))
                            {
                                t.idRevisao = revisao.id;
                                break;
                            }
                            else
                                t.idRevisao = 0;
                        }
                }
            }
        }
        private void FrmCriaRevisao_Load(object sender, EventArgs e)
        {
            if (editando)
            {

            }
            else
            {
                revisao.status = "A";
                revisao.versao = "0.00.00.0000";
                revisao.id = contRev.criaRevisao(revisao);
            }
        }

        private void atualizaLista()
        {
            atualizaVinculadas();
            atualizaResponsavel();

            /*Cria lista auxiliar para todos os itens dos tipos: sia ou vinculado a revisao*/
            listaAux.Clear();
            foreach (Tarefa aux in lista)
            {
                if (aux.sia || aux.idRevisao == revisao.id)
                {
                    listaAux.Add(aux);
                }
            }

            /*Verifica o tipo do select(com ou sem pesquisa)*/
            if (txtPesquisa.Text != "")
            {
                lista = contTar.retornaTarefas(txtPesquisa.Text);
            }
            else
            {
                lista = contTar.retornaTarefas(null);
            }

            /*Remove da lista principal os itens da lista auxiliar */
            for(int cont = 0; cont < lista.Count; cont++) { 
                for (int i = 0; i < listaAux.Count; i++)
                {
                    if (lista[cont].id == listaAux[i].id)
                    {
                        lista.RemoveAt(cont);
                    }
                }
            }

            /*concatena lista principal com a auxiliar*/
            lista.AddRange(listaAux);

            List<Usuario> ListUsu = contUso.selecionaUsuarios();

            dt.Columns.Clear();
            dt.Rows.Clear();

            dt.Columns.Add("Id");
            dt.Columns.Add("Login");
            dt.Rows.Add(0, "");
            foreach (Usuario u in ListUsu)
            {
                if (u.status.ToUpper() == "F")
                {
                    dt.Rows.Add(u.id, u.login);
                }
            }
            responsavel.ValueMember = "Id";
            responsavel.DisplayMember = "Login";
            responsavel.DataSource = dt;
        }
        private void atualizaGrid(Boolean atuVinculoResponsavel)
        {
            if (atuVinculoResponsavel) {
                atualizaVinculadas();
                atualizaResponsavel();
            }
            grid.Rows.Clear();

            grid.ColumnCount = 4;
            grid.Columns[0].Width = 30;
            grid.Columns[1].Width = 180;

            List<Usuario> listUsu = contUso.selecionaUsuarios();

            int x = 0;
            foreach (Tarefa e in lista)
            {
                String[] aux = new String[] { e.id.ToString(), e.titulo.ToString(), null, null, e.codigoSia.ToString() };
                grid.Rows.Add(aux);

                if (e.idRevisao == revisao.id && e.idRevisao != 0)
                {
                    grid.Rows[x].Cells[3].Value = true;
                }
                else
                {
                    grid.Rows[x].Cells[3].Value = false;
                }
                if (e.reponsavel != 0)
                {
                    foreach (Usuario u in listUsu)
                    {
                        if (e.reponsavel == u.id && u.status.ToUpper() == "F")
                            grid.Rows[x].Cells[2].Value = u.id.ToString();
                    }
                }
                x++;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (grid.CurrentRow.Cells[0].Value != null)
                {
                    if (contTar.deletaTarefa(int.Parse(grid.CurrentRow.Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Exclusão realizada com sucesso!");
                        atualizaGrid(true);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um registro!");
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro!");
            }
        }
        private void atualizaResponsavel()
        {
            foreach (Tarefa t in lista)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (grid.Rows[i].Cells[0].Value != null && grid.Rows[i].Cells[2].Value != null)
                        if (grid.Rows[i].Cells[0].Value.ToString() == t.id.ToString())
                        {
                            t.reponsavel = int.Parse(grid.Rows[i].Cells[2].Value.ToString());
                        }
                }
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtVersao.Text != "")
            {
                revisao.versao = txtVersao.Text;
                revisao.descricao = txtDescricaoRevisao.Text;
                revisao.modelo = chkModelo.Checked;

                revisao.status = "F";

                atualizaGrid(true);

                foreach (Tarefa t in lista)
                {
                    if (t.idRevisao.ToString() == revisao.id.ToString())
                    {
                        contTar.criaVinculoRevisao(t);
                    }
                }
                if (contRev.alteraRevisao(revisao))
                {
                    MessageBox.Show("Salvo com sucesso!");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Informe a versão da revisão!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            atualizaLista();
            atualizaGrid(true);
        }

        private void chkModelo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModelo.Checked)
            {
                lblCampoRevisao.Text = "Título do modelo:";
            }
            else
            {
                lblCampoRevisao.Text = "Descrição:";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbModelos.Text != "" || cmbModelos.Text != null)
            {
                txtPesquisa.Text = "";

                atualizaLista();

                List<int> clone = contTar.retornaClone(int.Parse(cmbModelos.SelectedValue.ToString()));

                foreach (Tarefa tar in lista)
                {
                    for(int i = 0; i < clone.Count; i++)
                    {
                        if (tar.id == clone[i]) 
                        {
                            tar.idRevisao = revisao.id;
                        }
                    }
                }
                atualizaGrid(false);
            }
            else
            {
                MessageBox.Show("Selecione um modelo para clonar.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSia.Checked)
            {
                txtCodigoSia.Enabled = true;
            }
            else
            {
                txtCodigoSia.Enabled = false;
            }
        }

        private void txtCodigoTarefa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void editar(int id)
        {
            editando = true;
            revisao = contRev.pegaRevisaoId(id);

            txtVersao.Text = revisao.versao;
            txtDescricaoRevisao.Text = revisao.descricao;
            chkModelo.Checked = revisao.modelo;

            List<Tarefa> auxiliar = contTar.selecionaTarefaIdRevisao(id);

            atualizaLista();
            listaAux.Clear();

            foreach (Tarefa tar in auxiliar)
            {
                if (tar.sia)
                {
                    listaAux.Add(tar);
                }
                else
                {
                    foreach(Tarefa t in lista)
                    {
                        if(t.id == tar.id)
                        {
                            t.idRevisao = id;
                        }
                    }
                }
            }
            lista.AddRange(listaAux);
            listaAux.Clear();

            atualizaGrid(false);
         }

        private void txtCodigoSia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cadRevisaoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtPesquisa.Focused)
                {
                    atualizaLista();
                    atualizaGrid(true);
                }
        }

        private void btnPesquisa_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
