using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Roguelike.ECS.Entities;

namespace Roguelike.ECS.Components {
    public class ProjectileMovingComponent : IComponent{
        public Entity Entity { get; set; }

        public void Execute(GameTime gameTime) {
            Entity.previousLocation = Entity.location;
            var distanceMoved = Entity.velocity * Entity.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Entity.location += distanceMoved;
            (Entity as Projectile).distanceFlown += Math.Abs(distanceMoved.Length());
        }

        public IComponent Copy() {
            return new ProjectileMovingComponent();
        }
    }
}
