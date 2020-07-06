using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleRPG.Actors {
    public abstract class ActorBase {
        public Texture2D sprite;
        public string name;

        public ActorBase(string spriteName, string name) {
            sprite = Game1.instance.Content.Load<Texture2D>(spriteName);
            this.name = name;
        }
    }
}
