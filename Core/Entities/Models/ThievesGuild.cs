using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class ThievesGuild
    {
        public int Thefts;
        public int Fee;

        public ThievesGuild(int thefts, int fee)
        {
            Thefts = thefts;
            Fee = fee;
        }
    }
}
