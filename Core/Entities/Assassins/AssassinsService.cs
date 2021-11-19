using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Core.Entities.Assassins
{
    public class AssassinsService
    {
        public static readonly List<Assassin> Assassins = new List<Assassin>(5);
        public AssassinsService()
        {
            if (Assassins.Any()) return;

            var xml = XDocument.Load("Entities/Assassins/Assassins.xml");
            foreach (var assassin in xml.Descendants("Assassin"))
            {
                Assassins.Add(new Assassin(
                        Convert.ToInt32(assassin.Element("Id")?.Value),
                        Convert.ToBoolean(assassin.Element("Busy")?.Value),
                        (Convert.ToInt32(assassin.Element("StartRange")?.Value), 
                            Convert.ToInt32(assassin.Element("EndRange")?.Value))
                    )
                );
            }
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
    }
}
