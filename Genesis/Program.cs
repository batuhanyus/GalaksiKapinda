using System;

namespace Genesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Galaxy DB Genesis started...");
            GalaxyDBContext context = new();

            Console.WriteLine("Creating categories and products...");
            ProductWorks pw = new();
            pw.Run(context);


            Console.ReadKey();
        }
    }
}
