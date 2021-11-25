using System;
using AnkhMorporkGame.Auxiliary;
using Core;
using Core.Entities.Models;
using Core.Player;

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
            var uow = new UnitOfWork();
            var events = new EventsGenerator();
            while (!_player.IsDead)     // while player is alive
            {
                Console.WriteLine(_player);

                var nextEvent = events.GenerateEvent(); // choosing a next character to meet

                NPC npc = nextEvent switch 
                {
                    NPCs.ThievesGuild => uow.ThievesGuildService.Get(0) //hardcoded
                    ,
                    NPCs.Beggar => uow.BeggarsService.Get(EventsGenerator.GenerateIndex(uow.BeggarsService.GetAll())),
                    NPCs.Fool => uow.FoolsService.Get(EventsGenerator.GenerateIndex(uow.FoolsService.GetAll())),
                    NPCs.Assassin => uow.AssassinsService.Get(0) //hardcoded
                    ,
                    _ => uow.AssassinsService.Get(0) // default case is never going to happen
                };

                npc.Say(_player);

                if (Selection()) // two options for user // playing
                {
                    if (npc is Assassin)
                    {
                        Console.WriteLine("Enter how much you are able to pay: (usually between 5$ and 35$)");
                        var payment = Convert.ToInt32(Console.ReadLine());
                        npc = uow.AssassinsService.Get(payment);

                    }

                    npc.Play(_player);
                }
                else // skipping
                {
                    if(npc is Fool)            //skipping only
                        continue;

                    npc.Kill(_player);         //losing the game
                    break;
                }
                
            }
        }

        private static bool Selection()
        {
            Console.WriteLine("What will you do:\n --- 1. Play\n --- 2. Skip");
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
            } while (key != '1' && key != '2');

            return key == '1';
        }
    }
}
