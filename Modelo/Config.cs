using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.Visao
{
    class Config
    {
        public String porta{ get; set; }
        public String host { get; set; }
        public String banco{ get; set; }
        public String usuario { get; set; }
        public String senha { get; set; }

        public Config()
        {
            this.porta = null;
            this.host = null;
            this.banco = null;
            this.usuario = null;
            this.senha = null;
        }
        public Config(String _porta, String _host, String _banco, String _usuario, String _senha)
        {
            this.porta = _porta;
            this.host = _host;
            this.banco = _banco;
            this.usuario = _usuario;
            this.senha = _senha;
        }
    }
}
