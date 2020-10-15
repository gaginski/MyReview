using MyReview.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyReview.Controle
{
    class ControleTarefas
    {
        Util ut = new Util();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader read;

        public ControleTarefas()
        {
            con = ut.con;
            cmd = ut.cmd;
            read = ut.read;
        }
        public Tarefa salvaTarefa(Tarefa t)
        {
            con.Open();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tarefa(tar_id, tar_titulo, tar_codigoSia, tar_sia, tar_descricao) " +
                                                        "VALUES(NULL, @titulo, @codigoSia, @sia, @descricao);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@titulo", t.titulo);
                cmd.Parameters.AddWithValue("@codigoSia", t.codigoSia);
                cmd.Parameters.AddWithValue("@sia", t.sia);
                cmd.Parameters.AddWithValue("@descricao", t.descricao);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(tar_id) FROM tarefa;";
                read = cmd.ExecuteReader();
                read.Read();
                t.id = int.Parse(read[0].ToString());

                read.Close();
                cmd.Dispose();

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao incluir tarefa!\nMensagem de erro: " + error.Message);
            }
            con.Close();
            return t;
        }
        public void criaVinculoRevisao(Tarefa t)
        {
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.Clear();

            try
            {

                cmd.CommandText = "SELECT count(*) FROM revisao_tarefa where rta_revisao = @revisao AND rta_tarefa = @tarefa;";
                cmd.Parameters.AddWithValue("@tarefa", t.id.ToString());
                cmd.Parameters.AddWithValue("@revisao", t.idRevisao.ToString());

                read = cmd.ExecuteReader();
                read.Read();
                if (read.GetInt32(0) == 0)
                {
                    read.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO revisao_tarefa(rta_id, rta_tarefa, rta_revisao, rta_responsavel, rta_status, rta_dataInicio, rta_DataFim) " +
                                                "VALUES(NULL, @tarefa, @revisao, @responsavel, @status, '1888-12-31 23:59:59', '1888-12-31 23:59:59')";
                    cmd.Parameters.AddWithValue("@tarefa", t.id);
                    cmd.Parameters.AddWithValue("@revisao", t.idRevisao);
                    cmd.Parameters.AddWithValue("@status", "A");
                    cmd.Parameters.AddWithValue("@responsavel", t.reponsavel);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    read.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE revisao_tarefa SET rta_responsavel = @responsavel WHERE rta_tarefa = @tarefa and rta_revisao = @revisao;";
                    cmd.Parameters.AddWithValue("@tarefa", t.id);
                    cmd.Parameters.AddWithValue("@revisao", t.idRevisao);
                    cmd.Parameters.AddWithValue("@responsavel", t.reponsavel);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao criar vinculo entre a revisão e as tarefas!\nMenssagem de erro:" + error.Message);
            }
            con.Close();

        }
        public List<Tarefa> retornaTarefas(string titulo)
        {
            List<Tarefa> lista = new List<Tarefa>();

            try
            {
                con.Open();

                cmd.Connection = con;
                String comando = "Select tar_id, tar_titulo, tar_codigoSia, tar_sia, tar_descricao from tarefa where tar_sia = 0";
                if (titulo != null)
                {
                    comando = comando + " AND tar_titulo like '%" + titulo + "%'";
                }
                comando = comando + " ;";
                cmd.CommandText = comando;

                read = cmd.ExecuteReader();
                while (read.Read())
                {

                    Tarefa aux = new Tarefa();
                    aux.id = read.GetInt16(0);
                    aux.titulo = read.GetString(1);
                    aux.codigoSia = read.GetString(2);
                    aux.sia = read.GetBoolean(3);
                    aux.descricao = read.GetString(4);

                    lista.Add(aux);
                }
                read.Close();
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao carregar tarefas!\nMensage de erro:" + error.Message);
            }


            return lista;
        }
        public Boolean deletaTarefa(int id)
        {
            Boolean _return = false;

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "Delete from tarefa where tar_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                _return = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao excluir registros!\nMenssagem de erro:" + error.Message);
            }
            return _return;
        }
        public List<Tarefa> selecionaTarefaRevisao(Usuario u, String status, String versao, Boolean semVinculo)
        {
            List<Tarefa> listaTarefa = new List<Tarefa>();
            String comando = null;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();

                comando = "SELECT /*tarefa*/ tar_id, tar_titulo, tar_codigoSia, tar_sia, tar_descricao,"
                                                                    + "/* revisao*/ rev_id, rev_versao, rev_descricao, rev_status,"
                                                                    + "/* usuario*/ rta_responsavel, usu_usuario, usu_tipo,"
                                                                    + "/* revisao_tarefa*/ rta_id, rta_status, rta_dataInicio, rta_dataFim"
                                                                    + " FROM revisao"
                                                                    + " INNER JOIN revisao_tarefa ON rev_id = rta_revisao"
                                                                    + " INNER JOIN tarefa ON rta_tarefa = tar_id"
                                                                    + " LEFT JOIN usuario ON rta_responsavel = usu_id"
                                                                    + " WHERE  rev_status <> 'A' AND rev_modelo = 0 AND";
                if (semVinculo)
                {
                    comando = comando + " (rta_responsavel = @id OR rta_responsavel = 0)";
                }
                else
                {
                    comando = comando + " rta_responsavel = @id";
                }
                if (status != null)
                {
                    comando = comando + " AND rta_status = @status";
                    cmd.Parameters.AddWithValue("@status", status);
                }
                if (versao != null)
                {
                    comando = comando + " AND rev_versao = @versao";
                    cmd.Parameters.AddWithValue("@versao", versao);
                }
                comando = comando + ";";

                cmd.CommandText = comando;
                cmd.Parameters.AddWithValue("@id", u.id);
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    listaTarefa.Add(povoaObjeto());
                }
                read.Close();
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao selecionar tarefas!\nMenssagem de erro:" + error.Message);
            }

            return listaTarefa;
        }
        private Tarefa povoaObjeto()
        {
            Tarefa aux = new Tarefa();

            /*TAREFA*/
            aux.id = read.GetInt32(0);
            aux.titulo = read.GetString(1);
            aux.codigoSia = read.GetString(2);
            aux.sia = read.GetBoolean(3);
            aux.descricao = read.GetString(4);
            /*REVISAO*/
            aux.idRevisao = read.GetInt32(5);
            aux.revisao.id = read.GetInt32(5);
            aux.revisao.versao = read.GetString(6);
            aux.revisao.descricao = read.GetString(7);
            aux.revisao.status = read.GetString(8);
            /*USUARIO*/
            aux.reponsavel = read.GetInt32(9);
            if (read.GetInt32(9) != 0)
            {
                aux.usuario.id = read.GetInt32(9);
                aux.usuario.login = read.GetString(10);
                aux.usuario.tipo = read.GetInt32(11);
            }
            /*REVISAO_TAREFA*/
            aux.idVinculo = read.GetInt32(12);
            aux.status = read.GetString(13);
            aux.dataInicio = read.GetDateTime(14);
            aux.dataFim = read.GetDateTime(15);

            return aux;
        }
        public Boolean verificaVinculoUsuario(int id, Usuario usu)
        {
            Boolean _return = false;

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select rta_responsavel from revisao_tarefa where rta_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                read = cmd.ExecuteReader();
                read.Read();
                if (read.GetInt32(0) != 0 && read.GetInt32(0) != usu.id)
                {
                    _return = true;
                }
                cmd.Dispose();
                con.Close();
                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return _return;
        }
        public Boolean verificaPendente(int id)
        {
            Boolean _return = false;

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select rta_status from revisao_tarefa where rta_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                read = cmd.ExecuteReader();
                read.Read();
                if (read.GetString(0) == "A")
                {
                    _return = true;
                }
                cmd.Dispose();
                con.Close();
                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return _return;
        }
        public Boolean AlteraStatusTarefa(Tarefa tarefa)
        {
            Boolean _return = false;

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update revisao_tarefa set rta_responsavel= @responsavel, rta_dataInicio = @dataInicio, rta_dataFim = @dataFim, rta_status = @status WHERE rta_id = @id;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", tarefa.idVinculo);
                cmd.Parameters.AddWithValue("@status", tarefa.status);
                cmd.Parameters.AddWithValue("@dataInicio", tarefa.dataInicio);
                cmd.Parameters.AddWithValue("@dataFim", tarefa.dataFim);
                cmd.Parameters.AddWithValue("@responsavel", tarefa.usuario.id);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();

                verificaStatusRevisao(tarefa);

                MessageBox.Show("Tarefa " + tarefa.idVinculo + " alterada com sucesso!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return _return;
        }
        public void verificaStatusRevisao(Tarefa tarefa)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from revisao_tarefa where rta_revisao = @revisao and rta_status <> 'C';";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@revisao", tarefa.revisao.id.ToString());
            read = cmd.ExecuteReader();
            read.Read();
            if (read.GetInt32(0) == 0)
            {
                read.Close();
                cmd.Dispose();
                con.Close();

                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = " UPDATE revisao SET rev_status = 'C' WHERE rev_id =@revisao;";
                cmd.Parameters.AddWithValue("@revisao", tarefa.revisao.id.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            else
            {
                read.Close();
                cmd.Dispose();
                con.Close();
            }


        }
        public Tarefa selecionaTarefaRevaoId(int id)
        {
            Tarefa aux = new Tarefa();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();

                cmd.CommandText = "SELECT /*tarefa*/ tar_id, tar_titulo, tar_codigoSia, tar_sia, tar_descricao,"
                                                                    + "/* revisao*/ rev_id, rev_versao, rev_descricao, rev_status,"
                                                                    + "/* usuario*/ rta_responsavel, usu_usuario, usu_tipo,"
                                                                    + "/* revisao_tarefa*/ rta_id, rta_status, rta_dataInicio, rta_dataFim"
                                                                    + " FROM revisao"
                                                                    + " INNER JOIN revisao_tarefa ON rev_id = rta_revisao"
                                                                    + " INNER JOIN tarefa ON rta_tarefa = tar_id"
                                                                    + " LEFT JOIN usuario ON rta_responsavel = usu_id"
                                                                    + " WHERE  rta_id = @id AND rev_modelo = 0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id.ToString());
                read = cmd.ExecuteReader();
                read.Read();
                aux = povoaObjeto();

                read.Close();
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao selecionar tarefa pelo ID\nMensagem de erro:"+error.Message);
            }
            return aux;
        }
        public List<int> retornaClone(int id)
        {
            List<int> clone = new List<int>();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select rta_tarefa from revisao_tarefa where rta_revisao = @revisao";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@revisao", id.ToString());

                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int aux = read.GetInt32(0);
                    clone.Add(aux);
                }

                con.Close();
                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao clonar revisão!\nMensagem de erro:" + error.Message + "Método: retornaClone() - Classe ControleTarefas");
            }

            return clone;
        }
        public void alteraTarefaId(Tarefa t)
        {
            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText  = "UPDATE tarefa SET tar_descricao = @descricao, tar_titulo = @titulo where tar_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", t.id);
                cmd.Parameters.AddWithValue("@descricao", t.descricao);
                cmd.Parameters.AddWithValue("@titulo", t.titulo);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro ao alterar tarefa\nMensagem de erro:"+error.Message);
            }
        }
        public List<Tarefa> selecionaTarefaIdRevisao(int id)
        {
            List<Tarefa> listaT = new List<Tarefa>();
            Tarefa aux = new Tarefa();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();

                cmd.CommandText = "SELECT /*tarefa*/ tar_id, tar_titulo, tar_codigoSia, tar_sia, tar_descricao,"
                                                                    + "/* revisao*/ rev_id, rev_versao, rev_descricao, rev_status,"
                                                                    + "/* usuario*/ rta_responsavel, usu_usuario, usu_tipo,"
                                                                    + "/* revisao_tarefa*/ rta_id, rta_status, rta_dataInicio, rta_dataFim"
                                                                    + " FROM revisao"
                                                                    + " INNER JOIN revisao_tarefa ON rev_id = rta_revisao"
                                                                    + " INNER JOIN tarefa ON rta_tarefa = tar_id"
                                                                    + " LEFT JOIN usuario ON rta_responsavel = usu_id"
                                                                    + " WHERE  rev_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id.ToString());
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    aux = povoaObjeto();
                    listaT.Add(aux);
                }
                
                read.Close();
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao selecionar tarefa pelo ID\nMensagem de erro:" + error.Message);
            }
            return listaT;
        }
    }
}
