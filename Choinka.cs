using System;

namespace ChoinkaCw
{
    class Program
    {
        static int readInt(string komunikat, int max = int.MaxValue, int min = int.MinValue)
        {
            int liczba;
            while (true)
            {
                Console.WriteLine(komunikat);
                string str = Console.ReadLine();
                try
                {
                    liczba = int.Parse(str);
                    if ((liczba <= max) && (liczba >= min))
                        break;
                    else
                        Console.Write("Liczba przekracza maksymalną wartość");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadzono liczbę w złym formacie");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadzona liczba jest poza dopuszczalnym zakresem");
                }
                catch (ArgumentNullException) // ^Z
                {
                    Console.WriteLine("Napotkano koniec strumienia");
                }



            }
            return liczba;
        }
        static void Choinka()
        {
            int x = readInt("Podaj wysokość choinki");
            for(int i=1; i <= x; i++) //wiersz
            {
                for (int j = 1; j <= x-i; j++)//spacje
                    Console.Write(" ");
                for(int k=1; k <= 2 * i - 1;k++) //wypełnienie_gwiazdkami
                {
                    if (k % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            //korzen
            for (int k = 1; k <= x - 1; k++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }
            Console.WriteLine("|");
            for (int k = 1; k <= x - 1; k++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        static void Main(string[] args)
        {
            Choinka();
        }
    }
}
