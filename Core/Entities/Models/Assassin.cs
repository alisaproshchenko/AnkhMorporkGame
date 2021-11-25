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

        public Assassin(int id, bool busy, (int, int) rewardRange)
        {
            Id = id;
            Busy = busy;
            RewardRange = rewardRange;
            _message = "Oh! It seems like someone wants to kill you! I think you should make a contract with " +
                       "The Assassins Guild to help you";
        }
    }
}
