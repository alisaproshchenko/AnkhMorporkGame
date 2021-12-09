namespace Core.Entities.Models
{
    public class Fool : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Fool(int id, string name, double fee, string welcomingMessage, string killingMessage, string playingMessage) 
            : base(welcomingMessage, killingMessage, playingMessage)
        {
            Id = id;
            Name = name;
            Fee = fee;
        }

        public override string Play(Player.Player player)
        {
            player.GainMoney(Fee);
            return PlayingMessage;
        }

        public override string Kill(Player.Player player)
        {
            return KillingMessage;
        }
    }
}
