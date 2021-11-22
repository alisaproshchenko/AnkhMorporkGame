using System;
using Core.Services;

namespace AnkhMorporkGame
{
    class Program
    {
        static void Main()
        {
            var assassins = new AssassinsService();
            Console.WriteLine(assassins.Output());

            var thieves = new ThievesGuildService();
            Console.WriteLine(thieves.Output());

            var beggars = new BeggarsService();
            Console.WriteLine(beggars.Output());

            var fools = new FoolsService();
            Console.WriteLine(fools.Output());

            Console.ReadKey();
        }
    }
}
