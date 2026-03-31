using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{


    public class Tabuleiro
    {
        public char[] arrayTabuleiro { get; private set; }



        public Tabuleiro()
        {

            arrayTabuleiro = new char[]{
            'c', 'c', 'c', 'c', 'c', 's', 'c', 'c', 'a', 'c',  // 0-9
    'c', 'c', 's', 'c', 'c', 'a', 'c', 'c', 's', 'c',  // 10-19
    'c', 'c', 'a', 'c', 'c', 's', 'c', 'c', 'a', 'c',  // 20-29
    'c', 's', 'c', 'c', 'c', 'a', 'c', 'c', 's', 'c',  // 30-39
    'a', 'c', 's', 'c', 'a', 'c', 'a', 'c', 's', 'f'   // 40-49
};


        }

    }
}
