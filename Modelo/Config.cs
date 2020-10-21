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
        public int[] frmExibicaoTarefa { get; set; }
        public int[] frmMinhasTarefas { get; set; }

        public Config()
        {
            this.porta = null;
            this.host = null;
            this.banco = null;
            this.usuario = null;
            this.senha = null;
            this.frmExibicaoTarefa = new int[] { 773, 547 }; 
            this.frmMinhasTarefas = new int[] { 549, 389 };
        }
        public Config(String _porta, String _host, String _banco, String _usuario, String _senha, int[] _frmExibicaoTarefa, int[] _frmMinhasTarefas)
        {
            this.porta = _porta;
            this.host = _host;
            this.banco = _banco;
            this.usuario = _usuario;
            this.senha = _senha;
            this.frmExibicaoTarefa = _frmExibicaoTarefa;
            this.frmMinhasTarefas = _frmMinhasTarefas;
        }
    }
}
