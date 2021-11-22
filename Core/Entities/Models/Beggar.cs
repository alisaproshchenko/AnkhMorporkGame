﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Beggar
    {
        public int Id;
        public string Name;
        public double Fee;

        public Beggar(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
        }
    }
}
