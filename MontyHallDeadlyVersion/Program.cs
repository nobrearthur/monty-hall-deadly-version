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

        static void Slow_Text(string text)
        {
            // Método responsável por imprimir as letras com delay de 40ms
            foreach (char word in text)
            {
                Console.Write(word);
                Thread.Sleep(40);
            }
        }
        static int proposal;
        public static void Main(string[] args)
        {
            int choice, chosen, new_door, mask;
            char answer;

            string[] doors = { "mask", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" };
            Shuffle(doors);

            Slow_Text("Escolha uma porta digitando o número correspondente:\n");
            choice = int.Parse(Console.ReadLine());
            Slow_Text($"\nVocê escolheu a porta {choice}");

            chosen = choice - 1;


            if (doors[chosen] == "mask")
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
                    if (doors[i] == "mask")
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
                if (i == chosen)
                {
                    Slow_Text($"{chosen + 1}\n");
                }
                else if (i == proposal)
                {
                    Slow_Text($"{proposal + 1}\n");
                }
                else
                {
                    Slow_Text($"VAZIA\n");
                }
            }

            Slow_Text($"\n Deseja trocar a sua escolha (Porta {chosen + 1}) pela Porta {proposal + 1}? [s / n]\n");
            answer = char.Parse(Console.ReadLine());

            if (answer == 's')
            {
                new_door = proposal;
            } 
            else
            {
                new_door = chosen;
            }

            Slow_Text("\nAbrindo todas as portas...\n");

            foreach (string open in doors)
            {
                Slow_Text($"\n {open}");
                Thread.Sleep(300);
            }

            if (new_door == mask)
            {
                Slow_Text("\nParabéns! Você encontrou a máscara!" +
                    " Coloque-a imediatamente, e logo poderá deixar a sala com vida!");
            }
            else
            {
                Slow_Text("\nInfelizmente você não encontrou a máscara. Em instantes perderá a consciência... Adeus!");
            }
            Console.ReadKey();
        }
    }
}
