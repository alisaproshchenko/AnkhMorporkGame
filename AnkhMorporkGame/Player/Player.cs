using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkGame.Player
{
    public class Player
    {
        public string Name { get; }
        private double _money;

        public bool IsDead { get; private set; }

        public Player(string name)
        {
            Name = name;
            _money = 100.0;
            IsDead = false;
        }

        public override string ToString()
        {
            return $"{Name}, you currently have {_money}$ on your budget!\n";
        }

        public void GainMoney(double income)
        {
            _money += income;
        }

        public void SpendMoney(double expenditure)
        {
            _money -= expenditure;
        }

        public void Die()
        {
            IsDead = true;
        }
    }
}
