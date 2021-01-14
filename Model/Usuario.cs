using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Usuario : Base
    {
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true, AutoIncremento = true)]
        public int? usu_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public string usu_nome { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public string usu_login { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false, Criptografado = true, chaveCripto = "2MilEVin")]
        public string usu_senha { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public string usu_email { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool usu_enviaemail { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool usu_ativo { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool CTAdicionar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool CTAutoriaPropria { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool CTEditar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool CTListar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool CTRemover { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool ExCTAbrir { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool ExCTIniFim { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool ExCTListar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool ExCTOutrosUsu { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool OutrasConfig { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool RevAdicionar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool RevEditar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool RevListar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool RevRemover { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool UsuAdicionar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool UsuEditar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool UsuListar { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool UsuPermissoes { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public bool UsuRemover { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public DateTime usu_dataCad { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public int? usu_usuario_cad { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public DateTime usu_dataAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public string usu_terminal_alteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = false)]
        public string usu_tema { set; private get; }

        public string GetUsu_tema()
        {
            return usu_tema.Length > 2 ? usu_tema : "Basic";
        }

        public new List<Usuario> Todos()
        {
            var usuarios = new List<Usuario>();
            foreach (var ibase in base.Todos())
            {
                usuarios.Add((Usuario)ibase);
            }

            return usuarios;
        }
        public new List<Usuario> Busca()
        {
            var usuarios = new List<Usuario>();
            foreach (var ibase in base.Busca())
            {
                usuarios.Add((Usuario)ibase);
            }

            return usuarios;
        }
    }
}
