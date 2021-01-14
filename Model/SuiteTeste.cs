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

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_descricao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_versao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int? sts_usu_autor { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int sts_prj_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_objetivo { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_dataCadastro { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string sts_status { get; set; }

    }
}