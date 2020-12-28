using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Modelo
{
    class Usuario
    {
        public int id { get; set; }
        public String login { get; set; }
        public String senha { get; set; }
        public int tipo { get; set; }
        public String status { get; set; }

        public Usuario()
        {
            this.id = 0;
            this.login = null;
            this.senha = null;
            this.tipo = 0;
            this.status = null;
        }

        public Usuario(int _id, String _login, String _senha, int _tipo, String _status)
        {
            this.id = _id;
            this.login = _login;
            this.senha = _senha;
            this.tipo = _tipo;
            this.status = _status;
        }
}
}
