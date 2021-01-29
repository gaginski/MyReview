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
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria =true,UsarParaBuscar =true)]
        public int? cps_indice { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public String cps_descricao { get; set; }

        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true)]
        public int? cps_cts_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public  DateTime cps_dataInclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_usu_inclusao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public DateTime cps_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public int cps_usu_ultimaAlteracao { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string cps_terminalUltimaAleracao { get; set; }

        public new List<Casos_Passo> Todos()
        {
            var casos_Passo = new List<Casos_Passo>();
            foreach (var ibase in base.Todos())
            {
                casos_Passo.Add((Casos_Passo)ibase);
            }

            return casos_Passo;
        }
        public new List<Casos_Passo> Busca()
        {
            var casos_Passo = new List<Casos_Passo>();
            foreach (var ibase in base.Busca())
            {
                casos_Passo.Add((Casos_Passo)ibase);
            }

            return casos_Passo;
        }
    }
}
