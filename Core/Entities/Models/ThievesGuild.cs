using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class ThievesGuild : NPC
    {
        public int Thefts;
        public int Fee;

        public ThievesGuild(int thefts, int fee)
        {
            Thefts = thefts;
            Fee = fee;
            _message = $"Oh no! There`s a guy from the Guild og Thieves. You have to pay {Fee}$ to them";
        }
    }
}
