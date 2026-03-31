using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class Peao
    {
        public int Casa { get; private set; }


        public Peao ()
        {
            Casa = 0;
        }
        
        
        
        public int Mover(int valor)
        {
            Casa += valor;

            return Casa;
        }



    }
}
