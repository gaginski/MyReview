using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.DataBase
{
    class OpcoesBase : Attribute
    {
        public bool UsarNoBanco { get; set; }
        public bool UsarParaBuscar { get; set; }
        public bool ChavePrimaria { get; set; }
        public bool AutoIncremento { get; set; }
    }
}
