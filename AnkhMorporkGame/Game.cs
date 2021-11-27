using System;
using System.Collections.Generic;
using System.Text;
using AnkhMorporkGame.Auxiliary;
using AnkhMorporkGame;
using AnkhMorporkGame.Entities.Models;
using AnkhMorporkGame.Player;

namespace AnkhMorporkGame
{
    public class Game
    {
        private readonly Player.Player _player;

        public Game(Player.Player player)
        {
            _player = player;
        }
        public void Run()
        {
            DisplayRules();

            var uow = new UnitOfWork();
            var events = new EventsGenerator();

            while (!_player.IsDead)     // while player is alive
            {
                Console.WriteLine(_player);

                var nextEvent = events.GenerateEvent(); // choosing a next character to meet

                NPC npc = nextEvent switch
                {
                    NPCs.ThievesGuild => uow.ThievesGuildService.Get(0),    //hardcoded (!)
                    NPCs.Beggar => uow.BeggarsService.Get(EventsGenerator.GenerateIndex(uow.BeggarsService.GetAll())),
                    NPCs.Fool => uow.FoolsService.Get(EventsGenerator.GenerateIndex(uow.FoolsService.GetAll())),
                    NPCs.Assassin => uow.AssassinsService.Get(0),           //hardcoded (!)
                    _ => uow.AssassinsService.Get(0)                        // default case is never going to happen
                };

                Console.WriteLine(npc.Say(_player)); // welcoming the player

                if (Selection())        // two options for user // playing
                {
                    Console.WriteLine(npc.Play(_player));
                }
                else          // skipping // losing the game // if npc is NOT a fool
                {
                    Console.WriteLine(npc.Kill(_player));         
                    break;
                }

                // recalculation of probabilities should be HERE
            }
        }
        private (NPC, int) AssassinsPaymentGetter(UnitOfWork uow)
        {
            var trying = 0;
            const int times = 3;
            var payment = -1;
            NPC found = null;

            while (trying++ < times)
            {
                Console.WriteLine("Enter how much you are able to pay:   (usually between 5$ and 35$)");
                payment = Convert.ToInt32(Console.ReadLine());
                found = uow.AssassinsService.Get(payment);

                if (found != null) break;
            }

            return (found, payment);
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

        private void DisplayRules()
        {
            Console.WriteLine("You are going to meet different enemies you must deal with... By the way, friends will be there too :)\n");
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
            Console.WriteLine($"These are all the rules, so you are ready to start!\nGood luck, {_player.Name}!");
            Console.ReadKey();
        }
    }
}
