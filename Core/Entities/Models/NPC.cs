namespace Core.Entities.Models
{
    public abstract class NPC
    {
        protected string WelcomingMessage;
        protected string KillingMessage;
        protected string PlayingMessage;

        protected NPC(string welcomingMessage, string killingMessage, string playingMessage)
        {
            WelcomingMessage = welcomingMessage;
            KillingMessage = killingMessage;
            PlayingMessage = playingMessage;
        }

        public string Say()
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
