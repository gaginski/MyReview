using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Modelo
{
    class Tarefa
    {
        public int id { get; set; }
        public String titulo { get; set; }
        public String codigoSia { get; set; }
        public Boolean sia { get; set; }
        public String descricao { get; set; }
        public int idRevisao { get; set; }
        public int reponsavel { get; set; }
        public String status { get; set; }
        public Revisao revisao { get; set; }
        public Usuario usuario { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int idVinculo { get; set; }

        public Tarefa()
        {
            id = 0;
            titulo = null;
            codigoSia = null;
            sia = false;
            descricao = null;
            reponsavel = 0;
            status = null;
            revisao = new Revisao();
            usuario = new Usuario();
            dataInicio = new DateTime();
            dataFim = new DateTime();
            idVinculo = 0;
        }
    }
}
