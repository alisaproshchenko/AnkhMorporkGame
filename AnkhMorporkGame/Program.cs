using System;
using Core.Auxiliary;
using Core.Player;
using Core.Services;

namespace AnkhMorporkGame
{
    class Program
    {
        private static Player _player;

        private static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to the fine city of Ankh-Morpork!");
                Console.WriteLine("Please enter your name: ");
                var playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName)) throw new Exception("The player`s name is invalid");

                _player = new Player(playerName);

                Console.WriteLine(
                    "You are going to meet different enemies you must deal with... By the way, friends will be there too :)\n");
                Console.ReadKey();
                Console.WriteLine("--(1)-- Each step of the game you will have to make a decision of only TWO ways!");
                Console.ReadKey();
                Console.WriteLine("--(2)-- You LOOSE if: ");
                Console.WriteLine("- - - - - - - - you`re getting killed; ");
                Console.ReadKey();
                Console.WriteLine("- - - - - - - - you`re chased to death by beggar; ");
                Console.ReadKey();
                Console.WriteLine("- - - - - - - - you`re out of money. ");
                Console.ReadKey();
                Console.WriteLine("\n- - press any key once more :) - -\n");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine($"These are all the rules, so you are ready to start!\nGood luck, {playerName}!");
                Console.ReadKey();

                Run();

                
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"!!! {e.Message}. Try another time");
            }
            Console.ReadKey();
        }

        private static void Run()
        {
            var events = new EventsGenerator();
            var repetitions = 0;
            while (!_player.Dead)
            {
                Console.WriteLine(_player);

                
                var nextEvent = events.GenerateEvent();
                //events.RecalculateProbabilities(nextEvent, null, repetitions);


            }
        }
    }
}
