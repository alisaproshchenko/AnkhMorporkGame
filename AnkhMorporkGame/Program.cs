using System;
using Core.Entities.Assassins;

namespace AnkhMorporkGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new AssassinsService();
            Console.WriteLine(service.Output());

            Console.ReadKey();
        }
    }
}
