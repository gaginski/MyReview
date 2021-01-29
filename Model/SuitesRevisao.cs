using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class SuitesRevisao : Base
    {
        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true, ChavePrimaria = true, AutoIncremento = true)]
        public int? srv_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? srv_sts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? srv_rev_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string srv_status { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public DateTime srv_dataInclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? srv_usuarioInclusao { get; set; }

        public new List<SuitesRevisao> Todos()
        {
            var suitesRevisao = new List<SuitesRevisao>();
            foreach (var ibase in base.Todos())
                suitesRevisao.Add((SuitesRevisao)ibase);

            return suitesRevisao;
        }
        public new List<SuitesRevisao> Busca()
        {
            var suitesRevisao = new List<SuitesRevisao>();
            foreach (var ibase in base.Busca())
                suitesRevisao.Add((SuitesRevisao)ibase);

            return suitesRevisao;
        }
    }
}
