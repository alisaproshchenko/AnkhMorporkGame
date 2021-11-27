namespace AnkhMorporkGame.Entities.Models
{
    public abstract class NPC
    {
        protected string WelcomingMessage;
        protected string KillingMessage;
        protected string PlayingMessage;

        public string Say(Player.Player player)
        {
            return WelcomingMessage;
        }

        public abstract string Play(Player.Player player);

        public virtual string Kill(Player.Player player)
        {
            player.Die();
            return KillingMessage;
        }
    }
}
