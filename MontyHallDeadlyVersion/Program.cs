using System;
using System.Threading;

namespace MontyHallDeadlyVersion
{
    class Program
    {
        static Random rnd = new Random();
        public static void Shuffle<T>(T[] array)
        {
            // Método embaralha dentro de uma lista os valores de um vetor
            // Será utilizado para randomizar a porta em que estará a máscara
            var random = rnd;
            for (int i = array.Length; i > 1; i--)
            {
                int j = random.Next(i);
                T aux = array[j];
                array[j] = array[i - 1];
                array[i - 1] = aux;
            }
        }

        static void PrintText(string text)
        {
            // Método responsável por imprimir as letras com delay de 40ms
            foreach (char word in text)
            {
                Console.Write(word);
                Thread.Sleep(0); // EDITAR DEPOIS!!!!
            }
        }

        static void PrintDoors(string[] array)
        {
            // Mostra as portas organizadas
            for (var i = 0; i < array.Length; i++)
            {
                if (i == array.Length / 2)
                {
                    Console.WriteLine("\n\n");
                }

                PrintText($"|\t{array[i],-10}|");
            }
        }

        static int proposal;
        public static void Main(string[] args)
        {
            int choice, chosen, new_door, mask;
            char answer;

            string[] doors = { "MÁSCARA", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            Shuffle(doors);

            string[] visual_doors = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            PrintDoors(visual_doors);

            do
            {
                PrintText("\n\nEscolha uma porta digitando o número correspondente:\n");
                choice = int.Parse(Console.ReadLine());
            } 
            while (choice < 1 | choice > 10);
            
            PrintText($"\nVocê escolheu a porta {choice}");
            PrintText("\n Aperte qualquer tecla para continuar...");
            Console.ReadKey();

            chosen = choice - 1;


            if (doors[chosen] == "MÁSCARA")
            {
                // Procurar por alguma vazia aleatória para sugerir a troca
                do
                {
                    proposal = rnd.Next(10);
                } 
                while (proposal == chosen);
                mask = chosen;

            }
            else
            {
                // Procurar a porta em que máscara está para sugerir a troca

                for (var i = 0; i < doors.Length; i++)
                {
                    if (doors[i] == "MÁSCARA")
                    {
                        proposal = i;
                    }
                }
                mask = proposal;
            }

            // Revelar as 8 portas vazias

            Console.WriteLine();
            for (var i = 0; i < doors.Length; i++)
            {
                if (i != chosen & i != proposal)
                {
                    visual_doors[i] = " ";
                }
            }

            Console.Clear();
            PrintDoors(visual_doors);

            PrintText($"\n Deseja trocar a sua escolha (Porta {chosen + 1}) pela Porta {proposal + 1}? [s / n]\n");
            answer = char.Parse(Console.ReadLine());

            while (answer != 's' & answer != 'n')
            {
                PrintText("\n Comando inválido! Tecle 's' para SIM ou 'n' para NÃO.\n");
                answer = char.Parse(Console.ReadLine());
            }

            if (answer == 's')
            {
                new_door = proposal;
            } 
            else
            {
                new_door = chosen;
            }


            Console.Clear();
            PrintText("\nAbrindo todas as portas...\n");

            visual_doors[new_door] = doors[new_door];

            PrintDoors(visual_doors);

            /*
            foreach (string open in doors)
            {
                Slow_Text($"\n {open}");
                Thread.Sleep(300);
            }*/

            if (new_door == mask)
            {
                PrintText("\nParabéns! Você encontrou a máscara!" +
                    " Coloque-a imediatamente, e logo poderá deixar a sala com vida!");
            }
            else
            {
                PrintText("\nInfelizmente você não encontrou a máscara. Em instantes perderá a consciência... Adeus!");
            }
            Console.ReadKey();
        }
    }
}
