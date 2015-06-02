using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengueApp.Model
{
    public interface IQuantidadeListener
    {
        void AlterarQuantidade(int quantidade, int total);
    }
}
