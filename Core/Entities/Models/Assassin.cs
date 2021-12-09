using System;

namespace Core.Entities.Models
{
    public class Assassin : NPC
    {
        public int Id;
        public bool Busy;
        public (int, int) RewardRange;

        public Assassin(int id, bool busy, (int, int) rewardRange, string welcomingMessage, string killingMessage, string playingMessage) 
            : base(welcomingMessage, killingMessage, playingMessage)
        {
            Id = id;
            Busy = busy;
            RewardRange = rewardRange;
        }
        public override string Play(Player.Player player)
        {
            if(player.Uow.AssassinsService.GetMinReward() > player.Money) // if player is out of money
                return "\n!!! - You are OUT OF MONEY" + Kill(player);

            var (foundAssassin, actualPayment) = player.Uow.AssassinsService.GetPayment(player);

            if (foundAssassin == null)     // if player cannot actually pay for assassin or all of them are busy
                return Kill(player);
            
            player.SpendMoney(actualPayment);
            return PlayingMessage;
        }
    }
}
