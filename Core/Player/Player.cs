using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Player
{
    public class Player
    {
        public string Name { get; }
        public double Money { get; }
        public bool Dead { get; }

        public Player(string name)
        {
            Name = name;
            Money = 100.0;
            Dead = false;
        }

        public override string ToString()
        {
            return $"{Name}, you currently have {Money}$ on your budget!";
        }
    }
}
