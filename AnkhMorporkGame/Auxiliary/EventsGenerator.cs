using System;
using System.Collections.Generic;
using AnkhMorporkGame.Entities.Models;
using System.Linq;

namespace AnkhMorporkGame.Auxiliary 
{
    public class EventsGenerator
    {
        public Dictionary<NPCs, double> Variety { get; }
        private readonly double _probability;
        private readonly double _part;
        private static readonly Random Random = new Random();

        public EventsGenerator()
        {
            _probability = 1.0 / Enum.GetNames(typeof(NPCs)).Length;

            Variety = new Dictionary<NPCs, double>
            {
                {NPCs.Assassin, _probability},
                {NPCs.ThievesGuild, _probability},
                {NPCs.Beggar, _probability},
                {NPCs.Fool, _probability}
            };
            _part = 0.01 * (Variety.Count - 1);
        }

        public NPCs GenerateEvent() //choosing a next character to meet
        {
            var key = Random.NextDouble();
            var intervalEnds = 0.0;
            var chosen = NPCs.Assassin;

            for (var i = 0; i < Variety.Count; i++)
            {
                intervalEnds += Variety[(NPCs)i];
                if (key > intervalEnds) continue;

                chosen = (NPCs) i;
                break;
            }

            return chosen;
        }

        public void RecalculateProbabilities(NPC current, NPC previous, ref int repetitions) 
        {
            if (previous != null && current.GetType() == previous.GetType()) 
                ResumeProbabilities(repetitions++, current);
            else
                ResumeProbabilities(ref repetitions);
        }

        private void ResumeProbabilities(ref int repetitions)
        {
            for (var i = 0; i < Variety.Count; i++)
            {
                Variety[(NPCs) i] = _probability;
            }

            repetitions = 1;
        }                                                                                  

        private void ResumeProbabilities(int repetitions, NPC current)
        {
            for (var i = 0; i < Variety.Count; i++)
            {
                if(current.GetType().ToString().EndsWith(((NPCs)i).ToString()))
                    Variety[(NPCs)i] -= (_part * repetitions);
                else
                    Variety[(NPCs)i] += (0.01 * repetitions);
            }
        }

        public static int GenerateIndex(IEnumerable<NPC> entities)
        {
            return Random.Next(0, entities.Count());
        }
    }
}
