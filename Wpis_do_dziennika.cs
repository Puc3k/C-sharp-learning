using System;
using System.IO;

namespace Dziennik
{
    class Program
    {
        static void listaPlikow(string date, string time)
        {
            string path = Directory.GetCurrentDirectory();
            string[] a = Directory.GetFiles(path);
            foreach (string Nazwa in a)
            {
                FileInfo info = new FileInfo(Nazwa);
                if (info.Extension == ".txt") Console.WriteLine("{0}\t{1}", info.Name,info.Extension);
            }

        }
        static void Main(string[] args)
        {
            string data = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            do
            {
                Console.WriteLine("Jeżeli chcesz rozpocząć wpis do dziennika wpisz \"start\", jeśli chcesz zakończyć to wpisz \"stop\"");
                string linia = Console.ReadLine();
                if (linia == "start")
                {
                            using (StreamWriter sw = new StreamWriter(data + ".txt"))
                            {
                        sw.WriteLine("Captain’s log");
                        sw.WriteLine("Stardate: "+data);
                        sw.WriteLine("Czas: " + time);
                        do
                        {
                                        string linia2;
                                        linia2 = Console.ReadLine();
                            if (linia2 == "stop") break;
                            sw.Write(linia2);
                            sw.WriteLine();
                        } while (true);
                        sw.WriteLine("Jean - Luc Picard");
                    }
                }
                else if (linia == "stop")
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Możliwe opcje to wyłącznie start i stop!");
                }
            } while (true);
        }
    }
}
