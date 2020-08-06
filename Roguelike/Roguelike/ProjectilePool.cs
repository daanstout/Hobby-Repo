using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.ECS.Components;
using Roguelike.ECS.Entities;
using Roguelike.Graphics;

namespace Roguelike {
    public class ProjectilePool {
        private const int MAX_PROJECTILES = 100;

        private Projectile firstAvailable;
        private readonly Projectile[] projectiles;

        public ProjectilePool() {
            projectiles = new Projectile[MAX_PROJECTILES];

            for (int i = 0; i < MAX_PROJECTILES; i++) {
                projectiles[i] = new Projectile();
                projectiles[i].AddComponent(new ProjectileMovingComponent());
            }

            for (int i = 0; i < MAX_PROJECTILES - 1; i++)
                projectiles[i].Next = projectiles[i + 1];

            firstAvailable = projectiles[0];
        }

        public void Create(Vector2 location, Vector2 direction, float maxDistance, float speed = 500.0f) {
            if (firstAvailable == null)
                return;

            var newParticle = firstAvailable;
            firstAvailable = newParticle.Next;

            newParticle.Initialize(location, direction, maxDistance, speed);
        }

        public void Load() {
            foreach (var projectile in projectiles)
                projectile.Load();
        }

        public void Update(GameTime gametime) {
            for(int i = 0; i < MAX_PROJECTILES; i++) {
                if (projectiles[i].IsDead)
                    continue;

                projectiles[i].Update(gametime);

                if (projectiles[i].IsDead) {
                    projectiles[i].Next = firstAvailable;
                    firstAvailable = projectiles[i];
                }
            }
        }

        public void Draw(DrawData drawData) {
            for (int i = 0; i < MAX_PROJECTILES; i++) {
                if (projectiles[i].IsDead)
                    continue;

                projectiles[i].Draw(drawData);
            }
        }
    }
}
