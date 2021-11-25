using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.Entities.Models;

namespace Core.Services
{
    public class AssassinsService : IService<Assassin>
    {
        public static List<Assassin> Assassins;
        public AssassinsService()
        {
            Assassins = GetAll();
        }
        public List<Assassin> GetAll()
        {
            if (Assassins != null) 
                return Assassins;

            var list = new List<Assassin>(5);
            var xml = XDocument.Load("Entities/DataResources/Assassins.xml");

            list.AddRange(xml.Descendants("Assassin")
                .Select(assassin => new Assassin(
                    Convert.ToInt32(assassin.Element("Id")?.Value), 
                    Convert.ToBoolean(assassin.Element("Busy")?.Value), 
                    (Convert.ToInt32(assassin.Element("StartRange")?.Value), 
                        Convert.ToInt32(assassin.Element("EndRange")?.Value)))));

            return list;
        }

        public string Output()
        {
            var sb = new StringBuilder();
            foreach (var assassin in Assassins)
            {
                sb.Append($"Assassin #{assassin.Id}: Busy - {assassin.Busy}, Owns in a range of " +
                          $"{assassin.RewardRange.Item1} to {assassin.RewardRange.Item2}\n");
            }

            return sb.ToString();
        }

        public Assassin Get(int i)
        {
            return Assassins.Find(x => x.RewardRange.Item1 <= i && x.RewardRange.Item2 >= i && !x.Busy);
        }
    }
}
