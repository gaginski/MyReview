using Database;
using MyReview.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Model
{
    class Projeto : Base
    {
        [OpcoesBase(UsarNoBanco = true, ChavePrimaria = true, UsarParaBuscar = true, AutoIncremento =true)]
        public int pjt_id { get; set; }

        [OpcoesBase(UsarNoBanco = true)]
        public string pjt_nome { get; set; }

        public new List<Projeto> Todos()
        {
            var projetos = new List<Projeto>();
            foreach (var ibase in base.Todos())
            {
                projetos.Add((Projeto)ibase);
            }

            return projetos;
        }
        public new List<Projeto> Busca()
        {
            var projetos = new List<Projeto>();
            foreach (var ibase in base.Busca())
            {
                projetos.Add((Projeto)ibase);
            }

            return projetos;
        }
    }
}
