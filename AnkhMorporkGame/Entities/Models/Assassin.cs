using System;

namespace AnkhMorporkGame.Entities.Models
{
    public class Assassin : NPC
    {
        public int Id;
        public bool Busy;
        public (int, int) RewardRange;

        public Assassin(int id, bool busy, (int, int) rewardRange)
        {
            Id = id;
            Busy = busy;
            RewardRange = rewardRange;
            WelcomingMessage = "Oh! It seems like someone wants to kill you! I think you should make a contract with " +
                       "The Assassins Guild to help you";
            KillingMessage = "\nUnfortunately, the Assassins` Guild didn`t help you and you WERE KILLED";
            PlayingMessage = "\nOkay, we will take this situation under our control";
        }

        public override string Play(Player.Player player)
        {
            if(player.Uow.AssassinsService.GetMinReward() > player.Money) // if player is out of money
                return "\n!!! - You are OUT OF MONEY" + Kill(player);

            var (foundAssassin, actualPayment) = AssassinsPaymentGetter(player);

            if (foundAssassin == null)     // if player cannot actually pay for assassin or all of them are busy
                return Kill(player);
            
            player.SpendMoney(actualPayment);
            return PlayingMessage;
        }
        private static (NPC, int) AssassinsPaymentGetter(Player.Player player)
        {
            var trying = 0;
            const int times = 3;
            var payment = default(int);
            NPC found = null;

            while (trying++ < times)
            {
                Console.WriteLine($"\nEnter how much you are able to pay:   (usually between 5$ and 35$) //{times - trying + 1} tries left//");

                if (!int.TryParse(Console.ReadLine(), out payment))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nYou should enter the integer value");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                if (payment < 1 || payment > player.Money)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nInvalid input sum (out of the amount of your pocket)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                found = player.Uow.AssassinsService.Get(payment);

                if (found != null) break; //there is available assassin for the work

                Console.WriteLine("\nThere is no available assassin for this reward");
            }

            return (found, payment);
        }
    }
}
