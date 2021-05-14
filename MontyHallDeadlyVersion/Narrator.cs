using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace MontyHallDeadlyVersion
{
    class Narrator
    {
        public static void PrintText(string text)
        {
            // Método responsável por imprimir as letras com delay de 40ms
            foreach (char word in text)
            {
                Console.Write(word);
                Thread.Sleep(40);
            }
        }

        public static void Intro()
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
            Console.Clear();

        }

        public static void Voice1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\n 'OLÁ! OLÁ! OLÁ!'\n");
            Thread.Sleep(2000);
            Console.ResetColor();
            PrintText("\n Uma voz! \n");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;
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
            Console.ResetColor();
            Console.Clear();
        }

        public static void Voice2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\n'Muito bem! Olha...  Não me parece tão justo deixar você escolher apenas 1 entre 10 portas... '\n");
            Thread.Sleep(2000);
            PrintText("\n'10% de chances de acertar... Por isso te darei uma nova chance!'\n");
            Thread.Sleep(2000);
            PrintText("\nPressione qualquer tecla para abrir 8 portas!\n");
            Thread.Sleep(2000);
            Console.ResetColor();
            Console.ReadKey();   
        }

        public static void Voice3(int chosen, int proposal)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\n\n'LEGAL, NÉ???'\n");
            Thread.Sleep(2000);
            PrintText($"\n 'Como já deve ter observado, a máscara está na porta {chosen + 1} ou na porta {proposal + 1}, certo?'\n");
            Thread.Sleep(2000);
            PrintText("\n 'Pois bem, só me responda uma coisa agora, e rápido!'\n");
            Thread.Sleep(2000);
            PrintText($"\n 'Deseja trocar a sua escolha (Porta {chosen + 1}) pela Porta {proposal + 1}?'\n");
            Thread.Sleep(500);
            Console.ResetColor();
            PrintText("\n [s - SIM | n - NÃO] \n");
            
        }

        public static void Voice4()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\nEstá feito!\n");
            Thread.Sleep(1000);

            PrintText("\nAgora vamos abrir a porta que você escolheu!\n");
            Thread.Sleep(1000);
            Console.ResetColor();
        }

        public static void Voice5()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\n\n\n 'PARABÉNS! Você encontrou a máscara!" +
                    " Coloque-a imediatamente, e logo poderá deixar a sala!'");
            Console.ResetColor();
        }

        public static void Voice6()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintText("\n\n\n 'OPS! Parece que a sorte não está ao seu lado hoje...'");
            Thread.Sleep(200);
            PrintText("\n\n 'Você perderá a consciência em alguns instantes. Não será tão doloroso quanto parece...'");
            Thread.Sleep(200);
            PrintText("\n\n 'ADEUS!'");
            Console.ResetColor();
        }
    }
}
