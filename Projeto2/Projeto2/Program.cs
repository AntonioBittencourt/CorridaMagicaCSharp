using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Projeto2
{
    class Program
    {


         static void Main(string[] args)
        {


            string nome1 = "";
            string nome2 = "";
            while (string.IsNullOrWhiteSpace(nome1))
            {
                Console.WriteLine("Coloque o nome do jogador 1:");
                nome1 = Console.ReadLine();
                Thread.Sleep(1000);
            }
            
            while (string.IsNullOrWhiteSpace(nome2))
            {
                Console.WriteLine("Coloque o nome do jogador 2:");
                nome2 = Console.ReadLine();
                Thread.Sleep(1000);
            }
            Controlador jogo = new Controlador(nome1, nome2);
            jogo.Jogo();


        }
    }
}
