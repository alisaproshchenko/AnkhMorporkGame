using System;
using System.Collections.Generic;
using AnkhMorporkGame.Entities.Models;
using System.Linq;

namespace AnkhMorporkGame.Auxiliary 
{
    public class EventsGenerator
    {
        private readonly Dictionary<NPCs, double> _variety = new Dictionary<NPCs, double>();
        private readonly double _probability;
        private readonly double _part;
        private static readonly Random Random = new Random();

        public EventsGenerator()
        {
            _probability = 1.0 / Enum.GetNames(typeof(NPCs)).Length;
            _variety.Add(NPCs.Assassin, _probability);
            _variety.Add(NPCs.ThievesGuild, _probability);
            _variety.Add(NPCs.Beggar, _probability);
            _variety.Add(NPCs.Fool, _probability);
            _part = 0.1 * (_variety.Count - 1);
        }

        public NPCs GenerateEvent() //choosing a next character to meet
        {
            var key = Random.NextDouble();
            var intervalEnds = 0.0;
            var chosen = NPCs.Assassin;

            for (var i = 0; i < _variety.Count; i++)
            {
                intervalEnds += _variety[(NPCs)i];
                if (key > intervalEnds) continue;

                chosen = (NPCs) i;
                break;
            }

            return chosen;
        }

        public void RecalculateProbabilities(NPC current, NPC previous, ref int repetitions) ///////////////////////////////////////////////////////////
        {
            if (current != previous) 
                ResumeProbabilities(ref repetitions);
            else
                ResumeProbabilities(++repetitions, current);
        }

        private void ResumeProbabilities(ref int repetitions)
        {
            for (var i = 0; i < _variety.Count; i++)
            {
                _variety[(NPCs) i] = _probability;
            }

            repetitions = 0;
        }                                                                                   ///////////////////////////////////////////////////////////

        private void ResumeProbabilities(int repetitions, NPC current)
        {
            for (var i = 0; i < _variety.Count; i++)
            {
                if(current.GetType().ToString().EndsWith(((NPCs)i).ToString()))
                    _variety[(NPCs)i] -= (_part * repetitions);
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
