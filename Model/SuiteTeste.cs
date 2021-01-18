using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class SuiteTeste : Base
    {
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true, AutoIncremento = true)]
        public int? sts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string sts_descricao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string sts_versao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int? sts_usu_autor { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int sts_prj_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_objetivo { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public DateTime sts_dataCadastro { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public DateTime sts_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public bool sts_Sia { get; set; }

        public new List<SuiteTeste> Todos()
        {
            var suiteTeste = new List<SuiteTeste>();
            foreach (var ibase in base.Todos())
            {
                suiteTeste.Add((SuiteTeste)ibase);
            }

            return suiteTeste;
        }
        public new List<SuiteTeste> Busca()
        {
            var suiteTeste = new List<SuiteTeste>();
            foreach (var ibase in base.Busca())
            {
                suiteTeste.Add((SuiteTeste)ibase);
            }

            return suiteTeste;
        }
    }
}