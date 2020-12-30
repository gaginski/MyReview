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
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true)]
        public int usu_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string usu_login { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int usu_senha { get; set; }
    }
}
