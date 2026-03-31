using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class Jogador
    {

        private Peao peao;
        public string Nome {get; private set;}

        public Jogador(string nome)
        {
            Nome = nome;
            peao = new Peao();
        }

        public int Jogada(int movimentacao)
        {
            
            int casa = peao.Mover(movimentacao);

            return casa;
            


        }




    }
}
