using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Execucao_Passo : Base
    {
        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true, ChavePrimaria = true, AutoIncremento = true)]
        public int? eps_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? eps_ecs_id { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? eps_cps_indice { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public string eps_status { get; set; }

        [OpcoesBase(UsarNoBanco = true, UsarParaBuscar = true)]
        public int? eps_rev_id { get; set; }

        public new List<Execucao_Passo> Todos()
        {
            var execucao_Passo = new List<Execucao_Passo>();
            foreach (var ibase in base.Todos())
            {
                execucao_Passo.Add((Execucao_Passo)ibase);
            }

            return execucao_Passo;
        }
        public new List<Execucao_Passo> Busca()
        {
            var execucao_Passo = new List<Execucao_Passo>();
            foreach (var ibase in base.Busca())
            {
                execucao_Passo.Add((Execucao_Passo)ibase);
            }

            return execucao_Passo;
        }
    }
}
