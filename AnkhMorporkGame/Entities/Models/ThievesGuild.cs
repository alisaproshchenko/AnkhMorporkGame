namespace AnkhMorporkGame.Entities.Models
{
    public class ThievesGuild : NPC
    {
        public static int Thefts { get; set; }
        public int Fee;

        public ThievesGuild(int thefts, int fee)
        {
            Thefts = thefts;
            Fee = fee;
            WelcomingMessage = $"Oh no! There`s a guy from the Guild of Thieves. You have to pay {Fee}$ to them";
            KillingMessage = "\nYou definitely had to bring them those 10$..... Because the Game IS OVER for you by now";
            PlayingMessage = "\n- Have a nice evening!";
        }

        public override string Play(Player.Player player)
        {
            if (Fee > player.Money) // if player is out of money
                return "\n!!! - You are OUT OF MONEY" + Kill(player);

            player.SpendMoney(Fee);
            Thefts--;
            return PlayingMessage;
        }
    }
}
