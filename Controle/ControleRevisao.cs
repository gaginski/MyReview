using MyReview.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.Controle
{
    class ControleRevisao
    {
        Util ut = new Util();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader read;

        public ControleRevisao()
        {
            con = ut.con;
            cmd = ut.cmd;
            read = ut.read;
        }
        public int criaRevisao(Revisao rev)
        {
            int id = 0;
            try
            {
                con.Open();

                cmd.CommandText = "Insert into revisao(rev_id, rev_versao, rev_descricao, rev_status, rev_modelo) values(null, @versao, @descricao, @status, @modelo);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@versao", rev.versao);
                cmd.Parameters.AddWithValue("@descricao", rev.descricao);
                cmd.Parameters.AddWithValue("@status", rev.status);
                cmd.Parameters.AddWithValue("@modelo", rev.modelo);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select max(rev_id) from revisao";
                read = cmd.ExecuteReader();
                read.Read();

                id = int.Parse(read[0].ToString());

                read.Close();
            }catch(Exception error)
            {
                MessageBox.Show("Erro ao criar revisão!\nMensagem do erro: " + error.Message);
            }
            con.Close();
            return id;
        }
        public Boolean alteraRevisao(Revisao rev)
        {
            Boolean _return = false;
            try
            {
                con.Open();

                cmd.CommandText = "update revisao set  rev_versao = @versao, rev_descricao = @descricao, rev_status = @status, rev_modelo = @modelo where rev_id = @id;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@versao", rev.versao);
                cmd.Parameters.AddWithValue("@descricao", rev.descricao);
                cmd.Parameters.AddWithValue("@status", rev.status);
                cmd.Parameters.AddWithValue("@id", rev.id);
                cmd.Parameters.AddWithValue("@modelo", rev.modelo);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select max(rev_id) from revisao";
                read = cmd.ExecuteReader();
                read.Read();

                _return = true;

                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao alterar revisão!\nMensagem do erro: " + error.Message);
            }
            con.Close();
            return _return;
        }

        public List<String> pegaVersoes()
        {
            List<String> versoes = new List<string>();
            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "SELECT DISTINCT (rev_versao) FROM revisao WHERE rev_status <> 'A';";
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    String aux = read.GetString(0);
                    versoes.Add(aux);
                }

                read.Close();
                con.Close();
             }
            catch(Exception error)
            {
                MessageBox.Show("Erro ao selecionar versões!\nMensagem de erro: "+error.Message);
            }
            return versoes;
        }
        public List<Revisao> selecionaRevisoes()
        {
            List<Revisao> lista = new List<Revisao>();

            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "Select rev_id, rev_versao, rev_descricao, rev_status, rev_modelo from revisao where rev_status <> 'A'";
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Revisao aux = new Revisao();
                    aux.id = read.GetInt32(0);
                    aux.versao = read.GetString(1);
                    aux.descricao = read.GetString(2);
                    aux.modelo = read.GetBoolean(4);

                    switch (read.GetString(3))
                    {
                        case ("F"): aux.status = "Gravada"; break;
                        case ("C"): aux.status = "Concluída"; break;
                    }
                    lista.Add(aux);
                }
                con.Close();
                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return lista;
        }

    }
}
