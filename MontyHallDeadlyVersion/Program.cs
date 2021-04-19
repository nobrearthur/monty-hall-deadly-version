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
                Thread.Sleep(40);
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

        static void Intro()
        {
            PrintText(" Você acorda um pouco tonto e percebe que está em um quarto iluminado, porém sem janelas.\n");
            Thread.Sleep(1000);
            PrintText("\n Além da porta, que aparentemente leva à saída, vê apenas alguns armários enfileirados, numerados de 1 a 10.\n\n\n");
            Thread.Sleep(500);
            Thread.Sleep(2000);
            PrintText("\n Você até tenta abrir a porta, mas ela está trancada! \n");
            Thread.Sleep(1000);
            PrintText("\n Depois, verifica os armários, em busca de uma chave, cartão ou qualquer coisa.\n");
            Thread.Sleep(500);
            PrintText("\n Sem sucesso! Todos trancados... \n");
            Thread.Sleep(2000);
            Console.Clear();

            PrintText("\n De repente, você ouve um som similar ao de um vazamento de gás!\n");
            Thread.Sleep(2000);
            PrintText("\n Nota então que há fumaça invadindo o recinto aos poucos.\n");
            Thread.Sleep(2000);
            PrintText("\n BIPE!!! \n");
            Thread.Sleep(2000);
            PrintText("\n O som vem de um estranho aparelho, na parte de cima dos armários.\n");
            Thread.Sleep(2000);
            PrintText("\n 'OLÁ! OLÁ! OLÁ!'\n");
            Thread.Sleep(2000);
            PrintText("\n Uma voz! \n");
            Thread.Sleep(2000);
            PrintText("\n 'Você já deve ter percebido que não está em uma boa situação, certo?'\n");
            Thread.Sleep(2000);
            PrintText("\n 'Esta sala está sendo invadida por um gás mortal, e logo logo você morrerá se continuar aí.'\n");
            Thread.Sleep(2000);
            PrintText("\n 'No entanto, tenho uma boa notícia. Dentro de um desses armários há uma máscara! " +
                "Se encontrá-la, terá a chance de sobreviver e sair da sala.'\n");
            Thread.Sleep(2000);
            PrintText("\n 'Ah... E antes que eu me esqueça, você pode escolher APENAS uma porta!'\n");
            Thread.Sleep(3000);
            PrintText("\n 'Escolha rápido! Não vai durar muito se continuar enrolando!'\n");
            Thread.Sleep(2000);
            Console.Clear();

        }
        static int proposal;
        static void Game()
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
            PrintText("\n\nAperte qualquer tecla para continuar...");
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

            PrintText("\n'Muito bem! Olha...  Não me parece tão justo deixar você escolher apenas 1 entre 10 portas... '\n");
            Thread.Sleep(2000);
            PrintText("\n'10% de chances de acertar... Por isso te darei uma nova chance!'\n");
            Thread.Sleep(2000);
            PrintText("\nPressione qualquer tecla para abrir 8 portas!\n");
            Thread.Sleep(2000);
            Console.ReadKey();
            PrintText("\n BIPE!!!\n");
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

            PrintText("\n\n'LEGAL, NÉ???'\n");
            Thread.Sleep(2000);
            PrintText($"\n 'Como já deve ter observado, a máscara está na porta {chosen + 1} ou na porta {proposal + 1}, certo?'\n");
            Thread.Sleep(2000);
            PrintText("\n 'Pois bem, só me responda uma coisa agora, e rápido!'\n");
            Thread.Sleep(2000);
            PrintText($"\n 'Deseja trocar a sua escolha (Porta {chosen + 1}) pela Porta {proposal + 1}?'\n");
            Thread.Sleep(500);
            PrintText("\n [s - SIM | n - NÃO] \n");
            answer = char.Parse(Console.ReadLine());
            Thread.Sleep(2000);

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
            PrintText("\nEstá feito!\n");
            Thread.Sleep(1000);

            PrintText("\nAgora vamos abrir a porta que você escolheu!\n");
            Thread.Sleep(1000);

            visual_doors[new_door] = doors[new_door];

            PrintDoors(visual_doors);

            if (new_door == mask)
            {
                PrintText("\n\n 'PARABÉNS! Você encontrou a máscara!" +
                    " Coloque-a imediatamente, e logo poderá deixar a sala!'");
            }
            else
            {
                PrintText("\n\n 'OPS! Parece que a sorte não está ao seu lado hoje...'");
                Thread.Sleep(200);
                PrintText("\n\n 'Você perderá a consciência em alguns instantes. Não será tão doloroso...'");
                Thread.Sleep(200);
                PrintText("\n\n 'ADEUS!'");
            }
            Console.ReadKey();
        }

        
        public static void Main(string[] args)
        {
          
            char skip;

            PrintText("Monty Hall - Deadly Version\n\n");
            Thread.Sleep(3000);

            Console.WriteLine("Aperte a tecla correspondente: ");
            Console.WriteLine("[C]omeçar");
            Console.WriteLine("[P]ular introdução");
            skip = char.Parse(Console.ReadLine());
            Thread.Sleep(200);
            Console.Clear();


            if (skip == 'c' | skip == 'C')
            {
                Intro();
                Game();
            } 
            else 
          if (skip == 'p' | skip == 'P')
            {
                Game();
            }
        }
    }
}
