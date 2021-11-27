using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkGame.Entities.Models
{
    public abstract class NPC
    {
        protected string _welcomingMessage;
        protected string _killingMessage;
        protected string _playingMessage;

        public string Say(Player.Player player)
        {
            return _welcomingMessage;
        }

        public abstract string Play(Player.Player player);

        public virtual string Kill(Player.Player player)
        {
            player.Die();
            return _killingMessage;
        }
    }
}
