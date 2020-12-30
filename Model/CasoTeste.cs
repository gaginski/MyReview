using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class CasoTeste : Base
    {
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true)]
        public int cts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_indice { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_sts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cts_precondicoes { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_prioridade { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_tempoEstimado { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cts_resultadoEsperado { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public String cts_dataInclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_usu_inclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public String cts_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cts_usu_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cts_terminalUltimaAleracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cts_Observacao { get; set; }
    }
}
