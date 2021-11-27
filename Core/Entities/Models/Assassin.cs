using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Assassin : NPC
    {
        public int Id;
        public bool Busy;
        public (int, int) RewardRange;

        public delegate (NPC, int) AssassinsPaymentGetter(UnitOfWork uow);

        public AssassinsPaymentGetter ActualPaymentGetter;
        public UnitOfWork Uow;

        public Assassin(int id, bool busy, (int, int) rewardRange)
        {
            Id = id;
            Busy = busy;
            RewardRange = rewardRange;
            _welcomingMessage = "Oh! It seems like someone wants to kill you! I think you should make a contract with " +
                       "The Assassins Guild to help you";
            _killingMessage = "Unfortunately, the Assassins` Guild didn`t help you and you WERE KILLED";
            _playingMessage = "Okay, we will take this situation under our control";
        }

        public override string Play(Player.Player player)
        {
            var (foundAssassin, actualPayment) = ActualPaymentGetter(Uow);

            if (foundAssassin == null)     // if player cannot actually pay for assassin or all of them are busy
                return Kill(player);
            
            player.SpendMoney(actualPayment);
            return _playingMessage;
        }
        
    }
}
