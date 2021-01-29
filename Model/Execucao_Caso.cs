using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Execucao_Caso : Base
    {
        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true, ChavePrimaria = true, AutoIncremento = true)]
        public int? ecs_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? ecs_cst_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? ecs_srv_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string ecs_status { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? ecs_usu_executando { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public DateTime ecs_dataInicio { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public DateTime ecs_dataFim { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? ecs_rev_id { get; set; }

        public new List<Execucao_Caso> Todos()
        {
            var execucao_Caso = new List<Execucao_Caso>();
            foreach (var ibase in base.Todos())
            {
                execucao_Caso.Add((Execucao_Caso)ibase);
            }

            return execucao_Caso;
        }
        public new List<Execucao_Caso> Busca()
        {
            var execucao_Caso = new List<Execucao_Caso>();
            foreach (var ibase in base.Busca())
            {
                execucao_Caso.Add((Execucao_Caso)ibase);
            }

            return execucao_Caso;
        }
    }
}
