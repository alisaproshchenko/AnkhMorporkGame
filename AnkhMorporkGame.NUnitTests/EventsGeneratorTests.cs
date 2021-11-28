using AnkhMorporkGame.Auxiliary;
using AnkhMorporkGame.Entities.Models;
using NUnit.Framework;

namespace AnkhMorporkGame.NUnitTests
{
    [TestFixture]
    class EventsGeneratorTests
    {
        [Test]
        [TestCase(0.25, 0.25, 1, 1)]
        [TestCase(0.25, 0.25, 3, 1)]
        public void RecalculateProbabilities_NPCsAreNotSame_SetsDefaultProbabilities(double currentNPCProbability, double anotherNPCProbability,
            int repetitions, int expectedRepetitions)
        {
            var events = new EventsGenerator();
            var current = new Assassin(1, false, (10, 20));
            var previous = new ThievesGuild(6, 10);

            events.RecalculateProbabilities(current, previous, ref repetitions);

            Assert.That(events.Variety[NPCs.Assassin], Is.EqualTo(currentNPCProbability));
            Assert.That(events.Variety[NPCs.ThievesGuild], Is.EqualTo(anotherNPCProbability));
            Assert.That(repetitions, Is.EqualTo(expectedRepetitions));
        }

        [Test]
        [TestCase(0.25, 0.25, 1, 1)]
        public void RecalculateProbabilities_PreviousNPCIsNull_SetsDefaultProbabilities(double currentNPCProbability, double anotherNPCProbability,
            int repetitions, int expectedRepetitions)
        {
            var events = new EventsGenerator();
            var current = new Assassin(1, false, (10, 20));
            NPC previous = null;

            events.RecalculateProbabilities(current, previous, ref repetitions);

            Assert.That(events.Variety[NPCs.Assassin], Is.EqualTo(currentNPCProbability));
            Assert.That(events.Variety[NPCs.ThievesGuild], Is.EqualTo(anotherNPCProbability));
            Assert.That(repetitions, Is.EqualTo(expectedRepetitions));
        }

        [Test]
        [TestCase(0.22, 0.26,1, 2)]
        [TestCase(0.19, 0.27, 2, 3)]
        public void RecalculateProbabilities_NPCsAreSame_RecalculateProbabilities(double currentNPCProbability, double anotherNPCProbability,
            int repetitions, int expectedRepetitions)
        {
            var events = new EventsGenerator();
            var current = new Assassin(1, false, (10, 20));
            var previous = new Assassin(2, false, (5, 10));

            events.RecalculateProbabilities(current, previous, ref repetitions);

            Assert.That(events.Variety[NPCs.Assassin], Is.EqualTo(currentNPCProbability));
            Assert.That(events.Variety[NPCs.ThievesGuild], Is.EqualTo(anotherNPCProbability));
            Assert.That(repetitions, Is.EqualTo(expectedRepetitions));
        }
    }
}
