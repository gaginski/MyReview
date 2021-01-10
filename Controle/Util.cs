using MyReview.Visao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        public string criptografa(string dado, string chave)
        {
            byte[] key = { }; 
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(chave);
                
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(dado);
                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                return Convert.ToBase64String(Objmst.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string descriptografa(string dado, string chave)
        {
            byte[] key = { };// chave   
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[dado.Length];

           try
            {
                key = Encoding.UTF8.GetBytes(chave);
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(dado);

                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(Objmst.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
