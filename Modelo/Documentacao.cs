using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Modelo
{
    class Documentacao
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public Tarefa tarefa { get; set; }
        public DateTime data { get; set; }
        public String documentacao { get; set; }
        public String tarefasCriadas { get; set; }

        public Documentacao()
        {
            id = 0;
            usuario = new Usuario();
            tarefa = new Tarefa();
            data = new DateTime();
            documentacao = null;
            tarefasCriadas = null;
        }
    }
}
