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
    class ControleUsuario
    {

        Util ut;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader read;

        public ControleUsuario()
        {
            ut = new Util();
            con = ut.con;
            read = ut.read;
            cmd = ut.cmd;
        }
        public List<Usuario> selecionaUsuarios()
        {
            var usuarios = new List<Usuario>();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select usu_id, usu_usuario, AES_DECRYPT(usu_senha, @chave), usu_tipo, usu_status, usu_email, usu_enviaemail  from usuario;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@chave", ut.chave);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Usuario aux = new Usuario();
                    aux.id = read.GetInt16(0);
                    aux.login = read.GetString(1);
                    aux.senha = read.GetString(2);
                    aux.tipo = read.GetInt16(3);
                    aux.status = read.GetString(4);
                    aux.email = read.GetString(5);
                    aux.enviaEmail = read.GetBoolean(6);

                    usuarios.Add(aux);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao executar a leitura dos Usuarios!\nMenssagem de erro:" + error.Message);
            }
            read.Close();
            con.Close();
            return usuarios;
        }

        public Boolean gravaUsuario(Usuario usu)
        {
            Boolean _return = false;
            usu.id = 0;
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = ("insert into usuario(usu_id, usu_usuario, USU_SENHA, usu_tipo, usu_datacad, usu_status, usu_email, usu_enviaemail) values(null, @usuario, AES_ENCRYPT(@senha, @chave), @tipo, CURDATE( ), @status, @email, @enviaEmail);");
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@chave", ut.chave);
                    cmd.Parameters.AddWithValue("@senha", usu.senha);
                    cmd.Parameters.AddWithValue("@usuario", usu.login);
                    cmd.Parameters.AddWithValue("@tipo", usu.tipo);
                    cmd.Parameters.AddWithValue("@status", usu.status);
                    cmd.Parameters.AddWithValue("@email", usu.email);
                    cmd.Parameters.AddWithValue("@enviaemail", usu.enviaEmail);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    _return = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Erro ao salvar usuário!\nMensagem de erro: " + error.Message);
                }
            
            return _return;
        }
        public Usuario pegaUsuario(int id)
        {
            Usuario aux = new Usuario();
            try
            { 
                con.Open();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Select usu_id, usu_usuario, AES_DECRYPT(usu_senha, @chave), usu_tipo, usu_status, usu_email, usu_enviaemail from usuario where usu_id = @id;";
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.Parameters.AddWithValue("@chave", ut.chave);
                read = cmd.ExecuteReader();
                read.Read();

                aux.id = read.GetInt16(0);
                aux.login = read.GetString(1);
                aux.senha = read.GetString(2);
                aux.tipo = read.GetInt16(3);
                aux.status = read.GetString(4);
                aux.email = read.GetString(5);
                aux.enviaEmail = read.GetBoolean(6);
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return aux;

        }
          public Boolean alteraUsuario(Usuario usu)
        {
            Boolean _return = false;
            try
            {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = ("update usuario set usu_usuario = @usuario, USU_SENHA = AES_ENCRYPT(@senha, @chave), usu_tipo = @tipo, usu_datacad = CURDATE( ), usu_status = @status, usu_email = @email, usu_enviaEmail = @enviaEmail WHERE usu_id = @id;");
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@chave", ut.chave);
                    cmd.Parameters.AddWithValue("@senha", usu.senha);
                    cmd.Parameters.AddWithValue("@usuario", usu.login);
                    cmd.Parameters.AddWithValue("@tipo", usu.tipo);
                    cmd.Parameters.AddWithValue("@id", usu.id);
                    cmd.Parameters.AddWithValue("@status", usu.status);
                    cmd.Parameters.AddWithValue("@email", usu.email);
                    cmd.Parameters.AddWithValue("@enviaemail", usu.enviaEmail);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    _return = true;
                }
            
            catch (Exception error)
            {
                MessageBox.Show("Erro ao salvar usuário!\nMensagem de erro: " + error.Message);
            }
            return _return;
        }
        public Boolean apagaUsuario(int id)
        {
            Boolean _retunr = false;

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ("update usuario set usu_status = 'X' WHERE usu_id = @id;");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                _retunr = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao excluir usuário\n Mensagem de erro: " + error.Message);
            }
            return _retunr;
        }
    }
}
