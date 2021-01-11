using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Revisao : Base
    {
        [OpcoesBase(UsarNoBanco =true, UsarParaBuscar =true, ChavePrimaria =true, AutoIncremento = true)]
        public int rev_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string rev_versao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string rev_descricao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public char rev_status { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public bool rev_modelo { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int rev_usu_cadastro { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public DateTime rev_dataCad { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public DateTime rev_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string rev_terminalUltimaAlteracao { get; set; }

        public new List<Revisao> Todos()
        {
            var revisao = new List<Revisao>();
            foreach (var ibase in base.Todos())
                revisao.Add((Revisao)ibase);

            return revisao;
        }
        public new List<Revisao> Busca()
        {
            var revisao = new List<Revisao>();
            foreach (var ibase in base.Busca())
                revisao.Add((Revisao)ibase);

            return revisao;
        }

    }
}
