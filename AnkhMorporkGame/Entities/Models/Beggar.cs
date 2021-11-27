namespace AnkhMorporkGame.Entities.Models
{
    public class Beggar : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Beggar(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
            WelcomingMessage = $"- Hello there! - you`re hearing from a suspicious guy '{Name}'. He wants {Fee}$ from you.";
            KillingMessage = "\nYou`d better found any money for that beggar! After several hours of being chased by him, you DIED";
            PlayingMessage = "\n- Oh THANK YOU Sooooooooo much my dear friend!";
        }

        public override string Play(Player.Player player)
        {
            if (Fee > player.Money) // if player is out of money
                return "\n!!! - You are OUT OF MONEY" + Kill(player);

            player.SpendMoney(Fee);
            return PlayingMessage;
        }

        public override string Kill(Player.Player player)
        {
            if (Fee != 0) return base.Kill(player);

            player.Die();
            return "\nYou`d better given that BOTTLE OF BEER for that beggar! After several hours of being chased by him, you actually DIED";

        }
    }
}
