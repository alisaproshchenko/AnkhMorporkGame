using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Fool : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Fool(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
            _welcomingMessage = "What`s the fortune! You met up with an old friend, who is ready to propose a some kind of job." +
                       $" What about trying yourself as a {Name} and earn {Fee}$?";
            _killingMessage = "- Okay, as you wish.... Hope we`ll meet later more!";
            _playingMessage = "- That`s a really nice idea, moreover, these money will be useful for you!";
        }

        public override string Play(Player.Player player)
        {
            player.GainMoney(Fee);
            return _playingMessage;
        }

        public override string Kill(Player.Player player)
        {
            return _killingMessage;
        }
    }
}
