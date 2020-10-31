using System;

namespace MyReview.Modelo
{
    class Usuario
    {
        public int id { get; set; }
        public String login { get; set; }
        public String senha { get; set; }
        public int tipo { get; set; }
        public String status { get; set; }
        public String email { get; set; }
        public Boolean enviaEmail { get; set; }
        public Usuario()
        {
            this.id = 0;
            this.login = null;
            this.senha = null;
            this.tipo = 0;
            this.status = null;
            this.email = null;
            this.enviaEmail = false;
        }

        public Usuario(int _id, String _login, String _senha, int _tipo, String _status, String _email, Boolean _enviaEmail)
        {
            this.id = _id;
            this.login = _login;
            this.senha = _senha;
            this.tipo = _tipo;
            this.status = _status;
            this.email = _email;
            this.enviaEmail = _enviaEmail;
        }
    }
}
