using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Projeto2
{

    public class Controlador {

        private Jogador jogador1;
        private Jogador jogador2;
        private Dado dado;
        private Tabuleiro tabuleiro;
        private char[] arrayTabuleiro;
        //private int casa1, casa2;
        private int movimentacao;
        private string Nome1, Nome2;



        public Controlador(string nome1, string nome2)
        {

            Nome1 = nome1;
            Nome2 = nome2;
            jogador1 = new Jogador(nome1);
            jogador2 = new Jogador(nome2);
            dado = new Dado();
            tabuleiro = new Tabuleiro();
            arrayTabuleiro = tabuleiro.arrayTabuleiro;
        }




        public void Jogo() {


            int casa1 = 0;
            int casa2 = 0;
            bool vencedor = false;

            Console.WriteLine($"Começaremos o jogo, sejam bem vindos a nossa corrida mágica: {Nome1} e {Nome2}!");
            Thread.Sleep(1000);
            Console.WriteLine("Nosso Tabuleiro será represntado na tela. J1 significa a posição do primeiro, jogador enquanto J2 significa a posição do segundo,");
            Thread.Sleep(1000);
            Console.WriteLine("[J1J2] Significa que os dois jogadores estão na mesma casa");
            Thread.Sleep(1000);
            Console.WriteLine("[s], [a] e [f] são respectivamente nossas casas da sorte, azar e final. [c] são casas comuns");
            Thread.Sleep(1000);
            Console.WriteLine("A casa da sorte te faz avançar 3 casas, enquanto a do azar faz voltar duas. Quem chega ou passa da casa final ganha!");
            Thread.Sleep(1000);
            Console.WriteLine("Entendidas as regras? Quando solicitados aperte qualquer tecla para rodar o dado");
            Thread.Sleep(1000);
            var (primeiroNome, segundoNome) = DecidirQuemComeca();
            Nome1 = primeiroNome;
            Nome2 = segundoNome;
            Console.WriteLine("Começando já!");
            Thread.Sleep(1000);

            while (casa1 < 49 && casa2 < 49)
            {
                Console.WriteLine($"{Nome1}, aperte qualquer tecla para rodar seu dado:");
                Thread.Sleep(1000);
                Console.ReadKey();
                Console.WriteLine();
                Thread.Sleep(3000);
                Console.WriteLine($"Rolando o Dado para {Nome1}");
                movimentacao = dado.Sortear();
                Console.WriteLine("Valor obtido foi: " + movimentacao);
                casa1 = jogador1.Jogada(movimentacao);



                TestaVitoria(false, casa1, casa2); // o booleano false indicará vitória de jogador 1
                



                Console.WriteLine($"O {Nome1} andou {movimentacao} casas e está na casa {casa1}");





                if (arrayTabuleiro[casa1] == 'a')
                {
                    movimentacao = -2;
                    casa1 = jogador1.Jogada(movimentacao);
                    Console.WriteLine($"Ixe. é a casa do Azar, retornará duas casas e irá para a casa {casa1} ");
                }
                else
                if (arrayTabuleiro[casa1] == 's')
                {
                    movimentacao = 3;
                    casa1 = jogador1.Jogada(movimentacao);
                    TestaVitoriaComSorte(false, casa1, casa2);
                    Console.WriteLine($"Os ventos estão a seu favor, avançará três casas e irá para a casa {casa1} ");
                }





                Console.WriteLine($"{Nome2}, aperte qualquer tecla para rodar seu dado:");
                Thread.Sleep(1000);
                Console.ReadKey();
                Console.WriteLine();
                Thread.Sleep(3000);
                Console.WriteLine($"Rolando o Dado para {Nome2}");
                movimentacao = dado.Sortear();
                Console.WriteLine("Valor obtido foi: " + movimentacao);
                casa2 = jogador2.Jogada(movimentacao);



                TestaVitoria(true, casa2, casa1); // o booleano true indicará vitória de jogador 1






                Console.WriteLine($"O {Nome2} andou {movimentacao} casas e está na casa {casa2}");





                if (arrayTabuleiro[casa2] == 'a')
                {
                    movimentacao = -2;
                    casa2 = jogador2.Jogada(movimentacao);
                    Console.WriteLine($"Ixe. é a casa do Azar, retornará duas casas e irá para a casa {casa2}");
                }
                else
                    if (arrayTabuleiro[casa2] == 's')
                {
                    movimentacao = 3;
                    casa2 = jogador2.Jogada(movimentacao);
                    TestaVitoriaComSorte(true, casa2, casa1);
                    Console.WriteLine($"Os ventos estão a seu favor, avançará três casas e irá para a casa {casa2} ");
                }






                Console.WriteLine("Veremos como está o tabuleiro agora:");
                GerarTabuleiro(casa1, casa2);
                


            }


            Finalizar(vencedor, casa1, casa2);


        } 

        public (string,string) DecidirQuemComeca()
        {
            Console.WriteLine("Decidiremos que começa:");


            int dado1, dado2;


            do
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{Nome1}, aperte qualquer tecla para rodar seu dado:");
                Thread.Sleep(1000);
                Console.ReadKey();
                Console.WriteLine();
                dado1 = dado.Sortear();            
                Thread.Sleep(1000);
                Console.WriteLine($"{Nome1} sorteou {dado1}");
                Thread.Sleep(1000);
                Console.WriteLine($"{Nome2}, aperte qualquer tecla para rodar seu dado:");
                Thread.Sleep(1000);
                Console.ReadKey();
                Console.WriteLine();
                dado2 = dado.Sortear();
                Thread.Sleep(1000);
                Console.WriteLine($"{Nome2} sorteou {dado2}");

                if (dado1 == dado2)
                    Console.WriteLine($"Ixe Empate! Rolaremos de novo.");

                else
                    if (dado1 > dado2)
                {
                    Console.WriteLine($"{Nome1} começa!");
                    return (Nome1, Nome2);
                }
                else
                {
                    Console.WriteLine($"{Nome2} começa!");
                    return (Nome2, Nome1);
                }

                    } while (dado1 == dado2);
                
                return (Nome1, Nome2);
            }


        public void TestaVitoria(bool vencedor, int casa, int outracasa)
        {
            if (casa >= arrayTabuleiro.Length)
            {
                casa = arrayTabuleiro.Length - 1;

                if (vencedor == false)
                {


                    Console.WriteLine($"O {Nome1} andou {movimentacao} casas e está na casa final!");
                    Finalizar(vencedor, casa, outracasa);
                }
                else
                {


                    Console.WriteLine($"O {Nome2} andou {movimentacao} casas e está na casa final!");
                    Finalizar(vencedor, outracasa, casa);
                }
                   // Finalizar(vencedor, casa, outracasa);
            }
        }



        public void TestaVitoriaComSorte(bool vencedor, int casa, int outracasa)
        {
            if (casa >= arrayTabuleiro.Length)
            {
                casa = arrayTabuleiro.Length - 1;

                
                 Console.WriteLine($"Os ventos estão a seu favor, avançará para a casa final! ");
           
                   
                if(vencedor == false)
                Finalizar(vencedor, casa, outracasa);
                else
                Finalizar(vencedor, outracasa, casa);

            }
        }


        public void GerarTabuleiro(int casa1, int casa2)
        {

            for (int posicao = 0; posicao < 50; posicao++)
            {
                if (posicao == casa1 && posicao == casa2)
                    Console.Write("[J1J2]");
                else
                    if (posicao == casa1)
                    Console.Write("[J1]");
                else
                    if (posicao == casa2)
                    Console.Write("[J2]");
                else
                    Console.Write($"[{arrayTabuleiro[posicao]}]");

            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            Thread.Sleep(3000);
        }


        public void Finalizar(bool vencedor, int casa1, int casa2)
        {
            Console.WriteLine("Chegamos ao fim do jogo!");
            Console.WriteLine("Eis o tabuleiro final:");
            GerarTabuleiro(casa1, casa2);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
            Thread.Sleep(3000);

            if (vencedor == false)
            {
                Console.WriteLine($"Parabéns ao vencedor: {Nome1}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Parabéns ao vencedor: {Nome2}");
            Console.ReadKey();
            return;

        }

    }

}


