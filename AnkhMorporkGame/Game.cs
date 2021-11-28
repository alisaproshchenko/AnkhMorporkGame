using System;
using AnkhMorporkGame.Auxiliary;
using AnkhMorporkGame.Entities.Models;

namespace AnkhMorporkGame
{
    public class Game
    {
        private readonly Player.Player _player;
        private readonly UnitOfWork _uow;
        private readonly EventsGenerator _events;
        public Game(Player.Player player)
        {
            _player = player;
            _uow = new UnitOfWork();
            _events = new EventsGenerator();
            _player.Uow = _uow;
        }
        public void Run()
        {
            DisplayRules();

            NPC previous = null;
            var repetitions = 1;
            while (!_player.IsDead)     
            {
                Console.Clear();
                Console.WriteLine(_player);

                var nextEvent = _events.GenerateEvent(); // choosing a next character to meet

                NPC npc = nextEvent switch
                {
                    NPCs.ThievesGuild => _uow.ThievesGuildService.Get(0),  
                    NPCs.Beggar => _uow.BeggarsService.Get(EventsGenerator.GenerateIndex(_uow.BeggarsService.GetAll())),
                    NPCs.Fool => _uow.FoolsService.Get(EventsGenerator.GenerateIndex(_uow.FoolsService.GetAll())),
                    NPCs.Assassin => _uow.AssassinsService.Get(15)           
                };

                if(npc is ThievesGuild && ThievesGuild.Thefts == 0) // socially acceptable number of thefts has run out
                    continue;

                Console.WriteLine(npc.Say(_player)); // welcoming the player

                Console.WriteLine(!Selection() ? npc.Kill(_player) : npc.Play(_player));

                _events.RecalculateProbabilities(npc, previous, ref repetitions);
                previous = npc;

                Console.WriteLine("\n- - press any key to continue - -\n");
                Console.ReadKey();
            }
        }
        
        private static bool Selection()
        {
            Console.WriteLine("What will you do:\n --- 1. Play\n --- 2. Skip");
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (key != '1' && key != '2');

            return key == '1';
        }

        private void DisplayRules()
        {
            Console.WriteLine("You are going to meet different enemies you must deal with... By the way, friends will be there too :)\n");
            Console.WriteLine("\n- - press any key to continue - -\n");
            Console.ReadKey();
            Console.WriteLine("\t\tRULES");
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
