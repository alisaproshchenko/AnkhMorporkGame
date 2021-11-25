using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Models;
using System.Linq;
using Core;
using Core.Services;

namespace AnkhMorporkGame.Auxiliary 
{
    public class EventsGenerator
    {
        private readonly Dictionary<NPCs, double> _variety = new Dictionary<NPCs, double>();
        private static readonly Random Random = new Random();

        public EventsGenerator()
        {
            _variety.Add(NPCs.Assassin, 0.25);
            _variety.Add(NPCs.ThievesGuild, 0.25);
            _variety.Add(NPCs.Beggar, 0.25);
            _variety.Add(NPCs.Fool, 0.25);
        }

        public NPCs GenerateEvent() //choosing a next character to meet
        {
            var key = Random.NextDouble();
            var intervalEnds = 0.0;

            for (var i = 0; i < _variety.Count; i++)
            {
                
                intervalEnds += _variety[(NPCs)i];
                if (!(key <= intervalEnds)) continue;

                return (NPCs) i;
            }
            return NPCs.Assassin; //bruh moment
        }

        public void RecalculateProbabilities(NPCs current, NPCs previous, int repetitions)
        {
            if (current != previous) 
                ResumeProbabilities();
            else
                ResumeProbabilities(++repetitions, current);
        }

        private void ResumeProbabilities()
        {
            for (var i = 0; i < _variety.Count; i++)
            {
                _variety[(NPCs) i] = 0.25;
            }
        }
        private void ResumeProbabilities(int repetitions, NPCs current)
        {
            for (var i = 0; i < _variety.Count; i++)
            {
                if((NPCs)i == current)
                    _variety[(NPCs)i] -= (0.3 * repetitions);
                else
                    _variety[(NPCs)i] += (0.1 * repetitions);
            }
        }

        public static int GenerateIndex(IEnumerable<NPC> entities)
        {
            return Random.Next(0, entities.Count());
        }
    }
}
