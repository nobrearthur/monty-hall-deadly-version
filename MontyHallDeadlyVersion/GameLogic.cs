using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MontyHallDeadlyVersion
{
    class GameLogic
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
        static void PrintDoors(string[] array)
        {
            // Mostra as portas organizadas
            for (var i = 0; i < array.Length; i++)
            {
                if (i == array.Length / 2)
                {
                    Console.WriteLine("\n\n");
                }

                Narrator.PrintText($"|\t{array[i],-10}|");
            }
        }

        public static void Game()
        {
            int choice, chosen, new_door, mask, proposal = -1;

            char answer;

            string[] doors = { "MÁSCARA", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            Shuffle(doors);

            string[] visual_doors = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            PrintDoors(visual_doors);

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Narrator.PrintText("\n\nEscolha uma porta digitando o número correspondente:\n");
                Console.ResetColor();
                choice = int.Parse(Console.ReadLine());
            }
            while (choice < 1 | choice > 10);

            Console.ForegroundColor = ConsoleColor.Red;
            Narrator.PrintText($"\nVocê escolheu a porta {choice}");
            Console.ResetColor();
            Narrator.PrintText("\n\nAperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

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

            Narrator.Voice2();

            Narrator.PrintText("\n BIPE!!!\n");
            Thread.Sleep(2000);

            Console.WriteLine();
            for (var i = 0; i < doors.Length; i++)
            {
                if (i != chosen & i != proposal)
                {
                    visual_doors[i] = " ";
                }
            }

            // Revelar as 8 portas vazias
            Console.Clear();
            PrintDoors(visual_doors);

            Narrator.Voice3(chosen, proposal);

            answer = char.Parse(Console.ReadLine());
            Thread.Sleep(2000);

            while (answer != 's' & answer != 'n')
            {
                Narrator.PrintText("\n Comando inválido! Tecle 's' para SIM ou 'n' para NÃO.\n");
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

            Narrator.Voice4();
            Console.Clear();

            visual_doors[new_door] = doors[new_door];

            PrintDoors(visual_doors);

            if (new_door == mask)
            {
                Narrator.Voice5();
            }
            else
            {
                Narrator.Voice6();
            }
            Console.ReadKey();

        }
    }
 }
