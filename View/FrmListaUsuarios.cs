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
using MyReview.DataBase;
using System.Reflection;
using MyReview.Visao;

namespace MyReview.View
{
    public partial class FrmListaUsuarios : DevExpress.XtraEditors.XtraForm
    {
        Usuario logado = new Usuario();

        public FrmListaUsuarios(int? usuarioLogado)
        {
            InitializeComponent();
            logado.usu_id = usuarioLogado;

            List<Usuario> listUsu = logado.Busca();

            if (listUsu.Count > 0)
                logado = listUsu[0];

            this.LookAndFeel.SkinName = logado.GetUsu_tema();
        }

        private void carregaGrid()
        {
            List<Usuario> listaUsuarios = new Usuario().Todos();

            dtgListaUsuarios.Rows.Clear();

            dtgListaUsuarios.ColumnCount = 5;
            dtgListaUsuarios.Columns[0].Name = "ID";
            dtgListaUsuarios.Columns[1].Name = "Nome";
            dtgListaUsuarios.Columns[2].Name = "Login";
            dtgListaUsuarios.Columns[3].Name = "Email";
            dtgListaUsuarios.Columns[4].Name = "Status";

            dtgListaUsuarios.Columns[0].Width = 30;
            dtgListaUsuarios.Columns[1].Width = 150;

            PropertyInfo pripriedadeBusca = null;

            foreach (PropertyInfo pi in new Usuario().GetType().GetProperties())
                if (pi.Name.ToString() == cmbBusca.SelectedValue.ToString())
                    pripriedadeBusca = pi;

            foreach (Usuario u in listaUsuarios)
            {
                if (pripriedadeBusca == null || pripriedadeBusca.GetValue(u).ToString().Contains(scsBusca.Text) || scsBusca.Text.Equals(""))
                {
                    String[] auxiliar = { u.usu_id.ToString(), u.usu_nome, u.usu_login, u.usu_email, (u.usu_ativo ? "Ativo" : "Inativo") };
                    dtgListaUsuarios.Rows.Add(auxiliar);
                }
            }
        }
        private void carregaCombos()
        {
            DataTable parametrosBusca = new DataTable();

            parametrosBusca.Columns.Add("Campos");
            parametrosBusca.Columns.Add("Id");

            parametrosBusca.Rows.Add("Id", "usu_id");
            parametrosBusca.Rows.Add("Nome", "usu_nome");
            parametrosBusca.Rows.Add("Login", "usu_login");
            parametrosBusca.Rows.Add("Email", "usu_email");

            cmbBusca.DataSource = parametrosBusca;
            cmbBusca.DisplayMember = "Campos";
            cmbBusca.ValueMember = "Id";
            cmbBusca.SelectedIndex = 1;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                carregaGrid();
        }

        private void enter_srcBusca(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void verificaPermissao()
        {
            btnCadastrar.Enabled = logado.UsuAdicionar;
            btnEditar.Enabled = logado.UsuEditar;
            btnExcluir.Enabled = logado.UsuRemover;
            dtgListaUsuarios.Enabled = logado.UsuListar;
            scsBusca.Enabled = logado.UsuListar;
        }

        private void FrmListaUsuarios_Load(object sender, EventArgs e)
        {
            carregaCombos();
            carregaGrid();
            verificaPermissao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new FrmCadUsuario(false, logado.usu_id, 0).ShowDialog();
            carregaGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (validaSelecao())
                new FrmCadUsuario(true, logado.usu_id, Int32.Parse(dtgListaUsuarios.CurrentRow.Cells[0].Value.ToString())).ShowDialog();
            carregaGrid();
        }
        private bool validaSelecao()
        {
            bool confirmacao = false;

            if (dtgListaUsuarios.CurrentRow.Cells[0].Value != null && dtgListaUsuarios.CurrentRow.Cells[0].Value.ToString() != "")
                confirmacao = true;
            else
                new FrmAlerta("Atenção! A linha selecionada é invalida!", logado.usu_id).ShowDialog();

            return confirmacao;
        }
    }
}