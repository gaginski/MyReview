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
    class ControleDocumentacao
    {
        Util ut = new Util();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader read;

        public ControleDocumentacao()
        {
            con = ut.con;
            cmd = ut.cmd;
            read = ut.read;
        }

        public Boolean SalvaDocumentacao(Documentacao doc)
        {
            Boolean _return = false;
            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "INSERT documentacao_tarefa(dta_id, dta_usuario, dta_vinculoTarefa, dta_data, dta_documentacao, dta_tarefas) " +
                                                        "VALUES(NULL, @idUsuario, @idVinculo, NOW(), @documentacao, @tarefas);";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idUsuario", doc.usuario.id.ToString());
                cmd.Parameters.AddWithValue("@idVinculo", doc.tarefa.idVinculo.ToString());
                cmd.Parameters.AddWithValue("@documentacao", doc.documentacao);
                cmd.Parameters.AddWithValue("@tarefas", doc.tarefasCriadas);

                cmd.ExecuteNonQuery();
                con.Close();

                _return = true;
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro ao salvar documentação!\nMenssagem de erro:"+error.Message);
            }
            return _return;
        }
        public Boolean verificaExisteDocumentacao(int idVinculo)
        {
            Boolean _return = false;

            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "SELECT COUNT(*) FROM documentacao_tarefa WHERE dta_VinculoTarefa = @vinculoTarefa;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vinculoTarefa", idVinculo);

                read = cmd.ExecuteReader();
                read.Read();

               if(read.GetInt32(0) > 0)
                    _return = true;

                con.Close();
                read.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao selecionar documentações!\nMensagem de erro:"+error.Message);
            }

            return _return;
        }
    }
}
