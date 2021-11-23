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
        }
    }
}
