using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Fool : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Fool(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
            _message = "What`s the fortune! You met up with an old friend, who is ready to propose a some kind of job." +
                       $" What about trying yourself as a {name} and earn {Fee}$?";
        }
    }
}
