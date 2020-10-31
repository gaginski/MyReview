using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyReview.Controle
{
    class ControleAtualizacao
    {
        Util ut = new Util();


        public void atualizaBanco()
        {
            try
            {
                MySqlConnection con = ut.con;
                MySqlCommand cmd = ut.cmd;
                MySqlDataReader read = ut.read;

                con.Open();

                #region Cria tabela de usuarios e adiciona usuário padrao

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS usuario("
                                                     + "USU_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                                                     + "USU_USUARIO VARCHAR(15) NOT NULL,"
                                                     + "USU_SENHA VARBINARY(255)NOT NULL,"
                                                     + "USU_TIPO INT NOT NULL,"
                                                     + "USU_DATACAD DATE,"
                                                     + "USU_STATUS CHAR);";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.CommandText = "ALTER TABLE usuario ADD COLUMN IF NOT EXISTS usu_email VARCHAR(50) default '';";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.CommandText = "ALTER TABLE usuario ADD COLUMN IF NOT EXISTS usu_enviaEmail BOOLEAN default '0';";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.Parameters.Clear();
                cmd.CommandText = ("Select count(*) from usuario where usu_tipo = 2 and usu_usuario = 'visual'");
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                read.Read();
                if (read.GetInt64(0) == 0)
                {
                    read.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandText = ("insert into usuario(usu_id, usu_usuario, USU_SENHA, usu_tipo, usu_datacad, usu_status) values(null, 'VISUAL', AES_ENCRYPT('vssql', @chave), 2, null, 'F');");
                    cmd.Parameters.AddWithValue("@chave", ut.chave);
                    cmd.ExecuteNonQuery();
                }
                else
                    read.Close();

                #endregion
                #region atualiza tarefa 
                cmd.CommandText = ("CREATE TABLE IF NOT EXISTS tarefa("
                                                      + "tar_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                                                      + "tar_titulo VARCHAR(100),"
                                                      + "tar_codigoSia VARCHAR(10),"
                                                      + "tar_sia BOOLEAN,"
                                                      + "tar_descricao VARCHAR(5000));");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                #endregion
                #region atualiza revisões
                cmd.CommandText = ("CREATE TABLE  IF NOT EXISTS revisao("
                                                        + "rev_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                                                        + "rev_versao VARCHAR(20) NOT NULL,"
                                                        + "rev_descricao VARCHAR(500),"
                                                        + "rev_status CHAR, " 
                                                        +"rev_modelo BOOLEAN"
                                                        + "); ");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                #endregion

                #region Atualiza revisao x tarefas
                cmd.CommandText = ("CREATE TABLE  IF NOT EXISTS revisao_tarefa("
                                                       + "rta_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                                                        + "rta_tarefa INT NOT NULL,"
                                                        + "rta_revisao INT NOT NULL,"
                                                        + "rta_responsavel INT,"
                                                        + "rta_status CHAR NOT NULL,"
                                                        + "rta_dataInicio DATETIME,"
                                                        + "rta_dataFim DATETIME );");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                #endregion

                #region Atualiza documentação
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS documentacao_tarefa("
                                                      + "dta_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                                                      + "dta_usuario INT NOT NULL,"
                                                      + "dta_vinculoTarefa INT NOT NULL,"
                                                      + "dta_data DATETIME NOT NULL,"
                                                      + "dta_documentacao VARCHAR(1000) NOT NULL,"
                                                      + "dta_tarefas VARCHAR(500));";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                #endregion

                con.Close();

                MessageBox.Show("Atualização concluida!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro na atualização do banco!\n Mensagem de erro:" + error.Message);
            }
        }
    }
}
