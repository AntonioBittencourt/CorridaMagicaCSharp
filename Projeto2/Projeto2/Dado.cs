using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public class Dado
    {
        public int Sortear()
        {
            Random valoraleatorio = new Random();
            int valor = valoraleatorio.Next(1, 7);
            Console.WriteLine("Valor sorteado foi: " + valor);
            return valor;
        }

    }





}
