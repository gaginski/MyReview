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
    class ControleRelatorio
    {
        Util ut = new Util();
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader read;

        public ControleRelatorio()
        {
            con = ut.con;
            cmd = ut.cmd;
            read = ut.read;
        }
        public String geraRelatorio(Usuario usuario, DateTime inicio, DateTime fim)
        {
            List<String> tarefas = new List<String>();
            String relatorio = null;
            String itensRevisados = "Realizado revisões com foco em:\n ";
            String detalhamentos = "Testes aplicados:\n ";
            String TarefasCriadas = "Criado Tarefas:\n ";
            try
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "SELECT dta_documentacao, dta_tarefas, tar_id FROM documentacao_tarefa " +
                    "INNER JOIN revisao_tarefa ON rta_id = dta_vinculoTarefa " +
                    "INNER JOIN tarefa ON tar_id = rta_tarefa " +
                    "INNER JOIN revisao ON rev_id = rta_revisao " +
                    "WHERE rta_responsavel = @usuario " +
                    "AND dta_data BETWEEN @data_Inicio " +
                    "AND @dataFim;";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usuario", usuario.id);
                cmd.Parameters.AddWithValue("@data_Inicio", inicio);
                cmd.Parameters.AddWithValue("@dataFim", fim);

                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    detalhamentos = detalhamentos + " - " + read.GetString(0) + "\n";
                    TarefasCriadas = TarefasCriadas + read.GetString(1);
                    tarefas.Add(read.GetString(2));
                }
                cmd.Dispose();
                read.Close();
                int i = 0;
                String comando = "Select tar_titulo from tarefa where tar_id in(";
                foreach (String s in tarefas)
                {
                    if (i != tarefas.Count && i != 0)
                        comando = comando + ", ";

                    comando = comando + " " + s;
                     i++;
                }
                comando = comando + ") group by tar_titulo";

                cmd.CommandText = comando;
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    itensRevisados = itensRevisados + " - " + read.GetString(0) + "\n"; 
                }
                con.Close();
                read.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            relatorio = itensRevisados + "\n" + detalhamentos + "\n" + TarefasCriadas;

            return relatorio;
        }
    }
}
