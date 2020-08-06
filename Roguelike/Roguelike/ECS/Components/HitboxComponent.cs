using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Roguelike.ECS.Entities;
using Roguelike.GridSystem;
using Roguelike.Utils;

namespace Roguelike.ECS.Components {
    public abstract class HitboxComponent : IComponent {
        public Entity Entity { get; set; }

        public abstract IComponent Copy();
        public abstract void Execute(GameTime gameTime);

        protected void ApplyCollision(Cell[] cells) {
            // This finds all the cells that are walls and the entity is colliding with
            List<(Cell, float)> pairs = new List<(Cell, float)>();

            foreach (var cell in cells) {
                if (!cell.isWall)
                    continue;

                if (CheckCollision(cell.ViewRectangle, out Vector2 contactPoint, out Vector2 contactNormal, out float contactTime))
                    pairs.Add((cell, contactTime));
            }

            if (pairs.Count == 0)
                return;

            // We then sort it, and finally check and resolve the collisions based on proximity to the entity, instead of just the order they were created in
            pairs.Sort(comparePairs);

            foreach (var item in pairs)
                ResolveCollision(item.Item1.ViewRectangle);
        }

        protected int comparePairs((Cell, float) first, (Cell, float) second) {
            if (first.Item2 == second.Item2)
                return 0;
            else if (first.Item2 > second.Item2)
                return 1;
            else
                return -1;
        }

        // These functions are taken from Javidx9's Arbitrary Rectangle Collision Detectionand Resolution video, thanks David!
        protected bool ResolveCollision(RectangleF hitbox) {
            if (CheckCollision(hitbox, out _, out Vector2 contactNormal, out float contactTime)) {
                var offset = contactNormal * new Vector2(Math.Abs(Entity.velocity.X), Math.Abs(Entity.velocity.Y)) * (1.0f - contactTime);

                Entity.location += offset;
                Entity.velocity += offset;

                return true;
            }
            return false;
        }

        protected bool CheckCollision(RectangleF hitbox, out Vector2 contactPoint, out Vector2 contactNormal, out float contactTime) {
            var expandedTarget = new RectangleF {
                Location = hitbox.Location - (Entity.spriteSize / 2),
                Size = hitbox.Size + Entity.spriteSize
            };

            if (CheckCollision(Entity.previousLocation, Entity.velocity, expandedTarget, out contactPoint, out contactNormal, out contactTime))
                return contactTime >= 0.0f && contactTime < 1.0f;
            else
                return false;
        }

        protected bool CheckCollision(Vector2 origin, Vector2 direction, RectangleF target, out Vector2 contactPoint, out Vector2 contactNormal, out float hitNear) {
            contactPoint = Vector2.Zero;
            contactNormal = Vector2.Zero;
            hitNear = 0.0f;

            var inverseDir = new Vector2(1.0f / direction.X, 1.0f / direction.Y);

            var tNear = (target.Location - origin) * inverseDir;
            var tFar = (target.Location + target.Size - origin) * inverseDir;

            if (float.IsNaN(tFar.Y) || float.IsNaN(tFar.X))
                return false;
            if (float.IsNaN(tNear.Y) || float.IsNaN(tNear.X))
                return false;

            if (tNear.X > tFar.X) {
                var tmp = tNear.X;
                tNear.X = tFar.X;
                tFar.X = tmp;
            }
            if (tNear.Y > tFar.Y) {
                var tmp = tNear.Y;
                tNear.Y = tFar.Y;
                tFar.Y = tmp;
            }

            if (tNear.X > tFar.Y || tNear.Y > tFar.X)
                return false;

            hitNear = Math.Max(tNear.X, tNear.Y);
            float hitFar = Math.Min(tFar.X, tFar.Y);

            if (hitFar < 0)
                return false;

            contactPoint = origin + hitNear * direction;

            if (tNear.X > tNear.Y)
                if (direction.X < 0)
                    contactNormal = new Vector2(1, 0);
                else
                    contactNormal = new Vector2(-1, 0);
            else if (tNear.X < tNear.Y)
                if (direction.Y < 0)
                    contactNormal = new Vector2(0, 1);
                else
                    contactNormal = new Vector2(0, -1);

            return true;
        }
    }
}
