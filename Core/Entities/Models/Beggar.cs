using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public class Beggar : NPC
    {
        public int Id;
        public string Name;
        public double Fee;

        public Beggar(int id, string name, double fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
            _welcomingMessage = $"- Hello there! - you`re hearing from a suspicious guy '{Name}'. He wants {Fee}$ from you.";
            _killingMessage = "You`d better have found any money for that beggar! After several hours of being chased by him, you DIED";
            _playingMessage = "- Oh THANK YOU Sooooooooo much my dear friend!";
        }

        public override string Play(Player.Player player)
        {
            player.SpendMoney(Fee);
            return _playingMessage;
        }
    }
}
