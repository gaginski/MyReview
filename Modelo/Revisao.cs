using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Modelo
{
    class Revisao
    {
        public int id { get; set; }
        public String versao { get; set; }
        public String descricao { get; set; }
        public String status { get; set; }
        public Boolean modelo { get; set; }
        public Revisao()
        {
            modelo = false;
            id = 0;
            descricao = null;
            versao = null;
            status = "A";
        }
    }
}
