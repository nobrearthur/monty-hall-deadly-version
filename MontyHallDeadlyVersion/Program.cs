using System;
using System.Threading;

namespace MontyHallDeadlyVersion
{
    class Program
    {
        public static void Main(string[] args)
        {
          
            char skip;
            
            Narrator.PrintText("Monty Hall - Deadly Version\n\n");
            Thread.Sleep(3000);

            Console.WriteLine("Aperte a tecla correspondente: ");
            Console.WriteLine("[C]omeçar");
            Console.WriteLine("[P]ular introdução");
            skip = char.Parse(Console.ReadLine());
            Thread.Sleep(200);
            Console.Clear();


            if (skip == 'c' | skip == 'C')
            {
                Narrator.Intro();
                Narrator.Voice1();
                GameLogic.Game();
            } 
            else 
          if (skip == 'p' | skip == 'P')
            {
                GameLogic.Game();
            }
        }
    }
}
