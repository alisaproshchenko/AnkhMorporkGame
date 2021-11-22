using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.Entities.Models;

namespace Core.Services
{
    public class ThievesGuildService : IService<ThievesGuild>
    {
        public static List<ThievesGuild> ThievesGuilds;

        public ThievesGuildService()
        {
            ThievesGuilds = GetAll();
        }
        public List<ThievesGuild> GetAll()
        {
            if (ThievesGuilds != null)
                return ThievesGuilds;

            var list = new List<ThievesGuild>(1);
            var xml = XDocument.Load("Entities/DataResources/ThievesGuild.xml");

            list.AddRange(xml.Descendants("ThievesGuild")
                .Select(thieves => new ThievesGuild(
                    Convert.ToInt32(thieves.Element("Thefts")?.Value),
                    Convert.ToInt32(thieves.Element("Fee")?.Value))));

            return list;
        }

        public string Output()
        {
            var sb = new StringBuilder();
            foreach (var thieves in ThievesGuilds)
            {
                sb.Append($"Thieves guild: Acceptable number of thefts: {thieves.Thefts}, Fee: {thieves.Fee}\n");
            }

            return sb.ToString();
        }
    }
}
