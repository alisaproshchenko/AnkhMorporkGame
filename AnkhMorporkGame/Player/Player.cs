namespace AnkhMorporkGame.Player
{
    public class Player
    {
        public string Name { get; }

        public double Money { get; private set; }
        public UnitOfWork Uow;
        public bool IsDead { get; private set; }

        public Player(string name)
        {
            Name = name;
            Money = 100.0;
            IsDead = false;
        }

        public override string ToString()
        {
            return $"\n\n+ + + {Name}, you currently have {Money:0.00}$ on your budget!\n";
        }

        public void GainMoney(double income)
        {
            Money += income;
        }

        public void SpendMoney(double expenditure)
        {
            Money -= expenditure;
        }

        public void Die()
        {
            IsDead = true;
        }
    }
}
