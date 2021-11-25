using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Models
{
    public abstract class NPC
    {
        protected string _message;

        public virtual string Say(Player.Player player)
        {
            return _message;
        }

        public virtual void Play(Player.Player player)
        {
            
        }

        public virtual void Kill(Player.Player player)
        {
            player.Die();
        }
    }
}
