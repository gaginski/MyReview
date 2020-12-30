using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Casos_Passo : Base
    {
        [OpcoesBase(UsarNoBanco= true, ChavePrimaria = true, UsarParaBuscar =true)]
        public int? cps_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_indice { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public String cps_descricao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_cts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cps_dataInclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_usu_inclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cps_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_usu_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cps_terminalUltimaAleracao { get; set; }
    }
}
