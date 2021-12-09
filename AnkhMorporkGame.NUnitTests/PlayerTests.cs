using Core.Player;
using NUnit.Framework;

namespace AnkhMorporkGame.NUnitTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        [TestCase(5, 105.0)]
        [TestCase(10, 110.0)]
        public void GainMoney_WhenCalled_AddMoneyToThePlayer(double money, double expectedResult)
        {
            var player = new Player("TestName");

            player.GainMoney(money);

            Assert.That(player.Money, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(5, 95.0)]
        [TestCase(10, 90.0)]
        public void SpendMoney_WhenCalled_SubstractMoneyFromThePlayer(double money, double expectedResult)
        {
            var player = new Player("TestName");

            player.SpendMoney(money);

            Assert.That(player.Money, Is.EqualTo(expectedResult));
        }
    }
}
