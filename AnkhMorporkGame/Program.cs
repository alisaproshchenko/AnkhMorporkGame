using System;

namespace AnkhMorporkGame
{
    class Program
    {
        private static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to the fine city of Ankh-Morpork!");
                Console.WriteLine("Please enter your name: ");
                var playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName)) throw new Exception("The player`s name is invalid");

                Console.WriteLine($"Hello, {playerName}!");
                var player = new Player.Player(playerName);
                var game = new Game(player);
                game.Run();
                Console.WriteLine("\n- - - \tThe game is over! I hope you enjoyed the time you spent here :)");

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"!!! {e.Message}. Try another time");
            }
            Console.ReadKey();
        }

        
    }
}
