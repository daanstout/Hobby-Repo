using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace SimpleRPG.Actors {
    public class Creature : ActorBase {
        public int health;
        public int maxHealth;
        public int damage;

        public Creature(string spriteName, string name, int health, int maxHealth, int damage) : base(spriteName, name) {
            this.health = health;
            this.maxHealth = maxHealth;
            this.damage = damage;
        }
    }
}
