using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReview.DataBase
{
    public interface IBase
    {
        int Key { get;  }
        bool Salvar();
        List<IBase> Todos();
        List<IBase> Busca();
    }
}
