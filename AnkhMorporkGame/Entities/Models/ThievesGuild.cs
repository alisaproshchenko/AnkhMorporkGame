using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkGame.Entities.Models
{
    public class ThievesGuild : NPC
    {
        private int _thefts;
        public static int Thefts { get; }
        public int Fee;

        public ThievesGuild(int thefts, int fee)
        {
            _thefts = thefts;
            Fee = fee;
            _welcomingMessage = $"Oh no! There`s a guy from the Guild og Thieves. You have to pay {Fee}$ to them";
            _killingMessage = "You definitely had to bring them those 10$..... Because the Game IS OVER for you by now";
            _playingMessage = "- Have a nice evening!";
        }

        public override string Play(Player.Player player)
        {
            player.SpendMoney(Fee);
            _thefts--;
            return _playingMessage;
        }
    }
}
