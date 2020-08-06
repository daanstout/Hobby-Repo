
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.ECS.Components;
using Roguelike.Graphics;

namespace Roguelike.ECS.Entities {
    public class Projectile : Entity{
        private Texture2D sprite;

        public float maxDistance;
        public float distanceFlown;

        public Projectile Next { get; set; }

        private readonly IDrawComponent drawComponent;

        public bool IsDead => distanceFlown >= maxDistance;

        public Projectile() : base() {
            spriteSize = new Vector2(10, 10);
            drawComponent = new Animation("Firebolt", 4, TimeSpan.FromMilliseconds(100)) {
                Entity = this
            };
        }

        public override void Load() {
            sprite = ContentLibrary.CaveContentManager.Load<Texture2D>("Firebolt");
        }

        public override Entity Copy() {
            var copy = new Projectile() {
                location = location,
                speed = speed,
                previousLocation = previousLocation,
                sprite = sprite,
                spriteSize = spriteSize,
                velocity = velocity
            };

            foreach (var component in components)
                copy.AddComponent(component.Copy());

            return copy;
        }

        public void Initialize(Vector2 location, Vector2 direction, float maxDistance, float speed = 500.0f) {
            this.location = location;
            this.speed = speed;
            velocity = direction; // We can use the velocity as the direction
            this.maxDistance = maxDistance;
            distanceFlown = 0;
            previousLocation = location;
        }

        public override void Draw(DrawData drawData) {
            //drawData.SpriteBatch.Draw(sprite, GetEntityRectangle(drawData.ScreenBounds.Location), Color.White);
            drawComponent.Draw(drawData);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            drawComponent.Execute(gameTime);
            distanceFlown += Math.Abs((previousLocation - location).Length());
        }
    }
}
