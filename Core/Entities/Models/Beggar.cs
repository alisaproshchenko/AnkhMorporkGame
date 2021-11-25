using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Beggar : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Beggar(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
            _message = $"Hello there! - you`re hearing from a suspicious guy '{Name}'. He wants {Fee}$ from you.";
        }
    }
}
