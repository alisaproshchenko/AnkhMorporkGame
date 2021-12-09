using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.Entities.Models;

namespace Core.Services
{
    public class FoolsService : IService<Fool>
    {
        public static List<Fool> Fools;

        public FoolsService()
        {
            Fools = GetAll();
        }
        public List<Fool> GetAll()
        {
            if (Fools != null)
                return Fools;

            var list = new List<Fool>(9);
            var xml = XDocument.Load("Entities/DataResources/Fools.xml");

            list.AddRange(xml.Descendants("Fool")
                .Select(fool => new Fool(
                    Convert.ToInt32(fool.Element("Id")?.Value),
                    fool.Element("Name")?.Value,
                    Convert.ToDouble(fool.Element("Fee")?.Value),
                    fool.Element("WelcomingMessage")?.Value,
                    fool.Element("KillingMessage")?.Value,
                    fool.Element("PlayingMessage")?.Value)));

            return list;
        }

        public string Output()
        {
            var sb = new StringBuilder();
            foreach (var fool in Fools)
            {
                sb.Append($"Fool #{fool.Id}: {fool.Name} - {fool.Fee}\n");
            }

            return sb.ToString();
        }

        public Fool Get(int i)
        {
            return Fools.ElementAt(i);
        }
    }
}
