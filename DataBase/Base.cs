﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Reflection;
using MyReview.DataBase;
using MyReview.Visao;
using MyReview.Controle;
using System.Windows.Forms;
using MyReview.Model;

namespace Database
{
    public class Base : IBase
    {
        Util util = new Util();

        [OpcoesBase(UsarNoBanco = false)]
        public int Key
        {
            get
            {
                foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (pOpcoesBase != null && pOpcoesBase.ChavePrimaria)
                    {
                        return Convert.ToInt32(pi.GetValue(this));
                    }
                }
                return 0;
            }
        }

        public virtual bool Salvar()
        {
            bool confirmacao = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(
                  util.stringConexaoSql))
                {
                    List<string> campos = new List<string>();
                    List<string> valores = new List<string>();


                    foreach (PropertyInfo pi in this.GetType().GetProperties()) //GetProperties(/*BindingFlags.Public*/) não consegui fazer pegar apenas as publics
                    {
                        OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                        if (pOpcoesBase != null && pOpcoesBase.UsarNoBanco && !pOpcoesBase.AutoIncremento)
                        {
                            campos.Add(pi.Name);
                            if (!pOpcoesBase.Criptografado)
                            {
                                if (pi.PropertyType.Name.ToString().Equals("DateTime"))
                                    valores.Add("'" + DateTime.Parse(pi.GetValue(this).ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
                                else
                                    valores.Add("'" + pi.GetValue(this) + "'");
                            }
                            else
                                valores.Add("'" + util.criptografa(pi.GetValue(this).ToString(), pOpcoesBase.chaveCripto) + "'");
                        }
                    }

                    string queryString = "insert into " + this.GetType().Name + "s (" + string.Join(", ", campos.ToArray()) + ")values(" + string.Join(", ", valores.ToArray()) + ");";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();

                    command.ExecuteNonQuery();

                    confirmacao = true;
                }
            }
            catch (Exception error)
            {
                FrmAlerta alerta = new FrmAlerta("Ocorreu um erro ao salvar " + this.GetType().Name + ". Mensagem de erro:" + error.Message, null);
                alerta.ShowDialog();
                confirmacao = false;
            }
            return confirmacao;
        }

        public virtual bool delete()
        {
            bool confirmacao = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(
                  util.stringConexaoSql))
                {
                    List<string> campos = new List<string>();
                    List<string> where = new List<string>();

                    foreach (PropertyInfo pi in this.GetType().GetProperties())
                    {
                        OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                        if (pOpcoesBase != null && pOpcoesBase.UsarNoBanco && !pOpcoesBase.UsarParaBuscar)
                        {
                            if (pOpcoesBase.UsarNoBanco && pOpcoesBase.UsarParaBuscar)
                                if (pi.GetValue(this) != null)
                                    where.Add(pi.Name + " = '" + pi.GetValue(this) + "'");

                            string queryString = "DELETE FROM " + this.GetType().Name + "s";
                            if (where.Count > 0)
                                queryString += " where " + string.Join(" and ", where.ToArray());

                            SqlCommand command = new SqlCommand(queryString, connection);
                            command.Connection.Open();
                            command.ExecuteNonQuery();

                            confirmacao = true;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                FrmAlerta alerta = new FrmAlerta("Ocorreu um erro ao salvar " + this.GetType().Name + ". Mensagem de erro:" + error.Message, null);
                alerta.ShowDialog();
                confirmacao = false;
            }
            return confirmacao;
        }

        public virtual List<IBase> Todos()
        {
            var list = new List<IBase>();
            using (SqlConnection connection = new SqlConnection(
               util.stringConexaoSql))
            {
                string queryString = "select * from " + this.GetType().Name + "s";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, reader);
                    list.Add(obj);
                }
            }
            return list;
        }

        public virtual List<IBase> Busca()
        {
            var list = new List<IBase>();
            using (SqlConnection connection = new SqlConnection(
               util.stringConexaoSql))
            {
                List<string> where = new List<string>();
                string chavePrimaria = string.Empty;
                foreach (PropertyInfo pi in this.GetType().GetProperties())
                {
                    OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (pOpcoesBase != null || pOpcoesBase.ChavePrimaria)
                    {
                        if (pOpcoesBase.ChavePrimaria)
                            chavePrimaria = pi.Name;

                        if (pOpcoesBase.UsarNoBanco && pOpcoesBase.UsarParaBuscar)
                            if (pi.PropertyType.Name.ToString().Equals("DateTime"))
                                where.Add(pi.Name + " = '" + DateTime.Parse(pi.GetValue(this).ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
                            else if (pi.GetValue(this) != null)
                                where.Add(pi.Name + " = '" + pi.GetValue(this) + "'");

                    }
                }

                string queryString = "select * from " + this.GetType().Name + "s";
                if (where.Count > 0)
                {
                    queryString += " where " + string.Join(" and ", where.ToArray());
                }

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, reader);
                    list.Add(obj);
                }
            }
            return list;
        }

        public virtual string max(String campo)
        {
            String _return = null;
            using (SqlConnection connection = new SqlConnection(util.stringConexaoSql))
            {
                List<string> where = new List<string>();
                foreach (PropertyInfo pi in this.GetType().GetProperties())
                {
                    OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                    if (pOpcoesBase != null)
                        if (pOpcoesBase.UsarNoBanco && pOpcoesBase.UsarParaBuscar)
                        {
                            var valor = pi.GetValue(this);
                            if (valor != null && !pOpcoesBase.ChavePrimaria)
                                where.Add(pi.Name + " = '" + valor + "'");
                        }
                }

                string queryString = "select isnull(max(" + campo + "),0) from " + this.GetType().Name + "s where " + campo + " is not null";
                if (where.Count > 0)
                {
                    queryString += " and " + string.Join(" and ", where.ToArray());
                }

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() && reader.GetValue(0) != null)
                    _return = reader.GetInt32(0).ToString();

            }
            return _return != null ? _return : "0";
        }
        public virtual string selectGenerico(String campo, String where)
        {
            String _return = null;
            using (SqlConnection connection = new SqlConnection(util.stringConexaoSql))
            {

                string queryString = "select " + campo + " from " + this.GetType().Name + "s where " + where;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() && reader.GetValue(0) != null)
                    _return = reader.GetInt32(0).ToString();

            }
            return _return != null ? _return : "0";
        }

        private void setProperty(ref IBase obj, SqlDataReader reader)
        {
            Util u = new Util();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                if (pOpcoesBase != null && pOpcoesBase.UsarNoBanco && reader[pi.Name].ToString() != null)
                {
                    if (!pOpcoesBase.Criptografado)
                        pi.SetValue(obj, reader[pi.Name]);
                    else
                        pi.SetValue(obj, u.descriptografa(reader[pi.Name].ToString(), pOpcoesBase.chaveCripto));
                }
            }
        }

        public virtual bool update()
        {
            bool confirmacao = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(
                  util.stringConexaoSql))
                {
                    List<string> campos = new List<string>();
                    List<string> where = new List<string>();

                    foreach (PropertyInfo pi in this.GetType().GetProperties())
                    {
                        OpcoesBase pOpcoesBase = (OpcoesBase)pi.GetCustomAttribute(typeof(OpcoesBase));
                        if (pOpcoesBase != null && pOpcoesBase.UsarNoBanco && !pOpcoesBase.UsarParaBuscar)
                        {
                            if (!pOpcoesBase.Criptografado)
                            {
                                if (pi.PropertyType.Name.ToString().Equals("DateTime"))
                                    campos.Add(pi.Name + " = '" + DateTime.Parse(pi.GetValue(this).ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
                                else
                                    campos.Add(pi.Name + " = '" + pi.GetValue(this) + "'");
                            }
                            else
                                campos.Add(pi.Name + " = '" + util.criptografa(pi.GetValue(this).ToString(), pOpcoesBase.chaveCripto) + "'");
                        }

                        if (pOpcoesBase.UsarNoBanco && pOpcoesBase.UsarParaBuscar)
                        {
                            var valor = pi.GetValue(this);
                            if (valor != null)
                                where.Add(pi.Name + " = '" + valor + "'");
                        }
                    }

                    string queryString = "update " + this.GetType().Name + "s set " + string.Join(", ", campos.ToArray());
                    if (where.Count > 0)
                    {
                        queryString += " where " + string.Join(" and ", where.ToArray());
                    }
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    confirmacao = true;
                }
            }
            catch (Exception error)
            {
                FrmAlerta alerta = new FrmAlerta("Ocorreu um erro ao salvar " + this.GetType().Name + ". Mensagem de erro:" + error.Message, null);
                alerta.ShowDialog();
                confirmacao = false;
            }
            return confirmacao;
        }

    }
}