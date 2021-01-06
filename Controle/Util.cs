using MyReview.Visao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.Controle
{
    class Util
    {
        public Config config;
        public String stringConexao;
        public String stringConexaoSql;
        public MySqlConnection con { get; set; }
        public MySqlDataReader read { get; set; }
        public MySqlCommand cmd { get; set; }
        public String chave { get; set; }

        public Util(Config _config)
        {
            chave = "SemSalsichaEhRuim_ByMarcosPauloJesus";
           cmd = new MySqlCommand();
            config = _config;
            atualizaStringConexao();
            cmd.Connection = con;
        }

        public Util()
        {
            chave = "SemSalsichaEhRuim_ByMarcosPauloJesus";
            ControleConfig c = new ControleConfig();
            cmd = new MySqlCommand();
            c.carregaConfig();
            config = c.conf;
            atualizaStringConexao();
            cmd.Connection = con;
        }

        public void atualizaStringConexao()
        {
            this.stringConexao = "server=" + config.host + ";port=" + config.porta + ";User Id=" + config.usuario + ";database = " + config.banco + "; password=" + config.senha + ";";
            //stringConexaoSql = "Server= OMNISERVER\\SQL2014; Database= myreview; Uid= sa; Pwd= omni@50ftp4r;";
            stringConexaoSql = "Server= DESKTOP-AVV1N1R; Database= myreview; Uid= sa; Pwd= root;";

            con = new MySqlConnection(stringConexao);
        }
        public Boolean VerificaConexao()
        {
            Boolean _return = true;
             try
            {
                con.Open();
                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                _return = false;
            }
            return _return;
        }

    }
}
