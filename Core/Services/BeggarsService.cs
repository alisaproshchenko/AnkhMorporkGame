using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.Entities.Models;

namespace Core.Services
{
    public class BeggarsService : IService<Beggar>
    {
        public static List<Beggar> Beggars;

        public BeggarsService()
        {
            Beggars = GetAll();
        }
        public List<Beggar> GetAll()
        {
            if (Beggars != null)
                return Beggars;

            var list = new List<Beggar>(11);
            var xml = XDocument.Load("Entities/DataResources/Beggars.xml");

            list.AddRange(xml.Descendants("Beggar")
                .Select(beggar => new Beggar(
                    Convert.ToInt32(beggar.Element("Id")?.Value),
                    beggar.Element("Name")?.Value,
                    Convert.ToDouble(beggar.Element("Fee")?.Value),
                    beggar.Element("WelcomingMessage")?.Value,
                    beggar.Element("KillingMessage")?.Value,
                    beggar.Element("PlayingMessage")?.Value)));

            return list;
        }

        public string Output()
        {
            var sb = new StringBuilder();
            foreach (var beggar in Beggars)
            {
                sb.Append($"Beggar #{beggar.Id}: {beggar.Name} - {beggar.Fee}\n");
            }

            return sb.ToString();
        }

        public Beggar Get(int i)
        {
            return Beggars.ElementAt(i);
        }
    }
}
