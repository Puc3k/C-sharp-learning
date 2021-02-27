using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Figura
{
    class Program
    {
        static void zapiszDoPliku(string nazwa, string[,] tablica)
        {
            try
            {
                string znak;
                bool czy=true;
                int a = tablica.GetLength(0); //długość tablicy
                int b = tablica.GetLength(1); // wysokość tablicy
                using (StreamWriter strWr = new StreamWriter(nazwa))
                {
                    do
                    {
                        for (int i = 0; i < a; i++)// kolumny tablicy
                        {
                            for (int j = 0; j < b; j++) // wiersze tablicy
                            {
                                znak = tablica[i, j]; // przypisanie znaku z tablicy do zmiennej
                                if (znak != null)
                                    strWr.Write(znak); // napisanie w pliku odpowiedniej ilosci znakow
                                else czy = false;
                            }
                            strWr.WriteLine(); // przejscie do nowej lini
                        }
                    }
                    while (czy == false);
                }
            }
            catch(SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int readInt(string komunikat, int max = int.MaxValue, int min = int.MinValue)
        {
            int liczba;
            while (true)
            {
                Console.Write(komunikat);
                string str = Console.ReadLine();
                try
                {
                    liczba = int.Parse(str);
                    if ((liczba <= max) && (liczba >= min) && (liczba >= 1))
                    {
                        break;
                    }
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
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Napotkano koniec strumienia");
                }
            }
            return liczba;
        }
        static string[,] doFigury()
        {
            int a = readInt("Podaj wysokość figury: ");
            int b = readInt("Podaj szerokość figury: ");
            Console.Write("Podaj pierwszy znak figury: ");
            string z1 = Console.ReadLine();
            //Sprawdzenie czy uzytkownik wprowadził tylko jeden znak
            while (z1.Length > 1)
            {
                Console.Write("Podaj tylko jeden znak: ");
                z1 = Console.ReadLine();
            }
            Console.Write("Podaj drugi znak figury: ");
            string z2 = Console.ReadLine();
            //Sprawdzenie czy uzytkownik wprowadził tylko jeden znak
            while (z2.Length > 1)
            {
                Console.Write("Podaj tylko jeden znak: ");
                z2 = Console.ReadLine();
            }
            string[,] figura = new string[a, b];
            for (int i = 0; i < a; i++) //wiersze
            {
                for (int j = 0; j < b; j++) //kolumny
                    if (i % 2 == 0)
                        figura[i, j] = z1;
                    else
                        figura[i, j] = z2;
            }
            return figura;
        }
        static void pokazFigure(string[,] tab)
        {
            int a = tab.GetLength(0);
            int b = tab.GetLength(1);
            for (int i = 0; i < a; i++) //wiersze
            {
                for (int j = 0; j < b; j++) //kolumny
                    Console.Write(tab[i, j]);
                Console.WriteLine();
            }
        }
        static void przesunFiguraPokaz(string[,] tab, int n)
        {
            int a = tab.GetLength(0);
            int b = tab.GetLength(1);
            n = Math.Abs(a - b); //oblicza wartosc bezwgl 
            string spacja = new string(' ', n);
            for (int i = 0; i < a; i++) //wiersze
            {
                Console.Write(spacja);
                for (int j = 0; j < b; j++) //kolumny)
                    Console.Write(tab[i, j]);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = 0;
            string[,] tablica = doFigury();
            pokazFigure(tablica);
            przesunFiguraPokaz(tablica, n);
            zapiszDoPliku("plik2.txt", tablica);
            Console.ReadKey();
        }
    }
}
