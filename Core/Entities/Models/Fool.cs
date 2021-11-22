using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Fool
    {
        public int Id;
        public string Name;
        public double Fee;

        public Fool(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
        }
    }
}
