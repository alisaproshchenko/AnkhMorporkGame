namespace Core.Entities.Models
{
    public class ThievesGuild : NPC
    {
        public static int Thefts { get; set; }
        public int Fee;

        public ThievesGuild(int thefts, int fee, string welcomingMessage, string killingMessage, string playingMessage)
            : base(welcomingMessage, killingMessage, playingMessage)
        {
            Thefts = thefts;
            Fee = fee;
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
