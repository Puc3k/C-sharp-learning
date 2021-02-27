using System;
using System.IO;

namespace obsluga_txt
{
    class Program
    {   
        static void zapiszPlik(string nazwa)
        {
            string linia;
            Console.WriteLine("Wprowadź kolejne wiersze do pliku, jeśli koniec to CTRL+Z");
            try
            {
                using (StreamWriter strWr = new StreamWriter(nazwa))
                {
                    while (true)
                    {
                        linia = Console.ReadLine();
                        if (linia != null)
                            strWr.WriteLine(linia);
                        else break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            //strWr.Close();
        }
        static void czytajPlik(string nazwa)
        {
            try
            {
                using (StreamReader strRd = new StreamReader(nazwa))
                {
                    while (!strRd.EndOfStream)
                    {
                        Console.WriteLine(strRd.ReadLine());
                    }


                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);

            }
        }
        static void Main(string[] args)
        {
            zapiszPlik("plik1.txt");
            czytajPlik("plik1.txt");
        }
    }
}
