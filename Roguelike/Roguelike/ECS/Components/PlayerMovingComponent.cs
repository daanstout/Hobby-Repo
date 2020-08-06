
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Roguelike.ECS.Entities;

namespace Roguelike.ECS.Components {
    public class PlayerMovingComponent : IComponent {
        public Entity Entity { get; set; }

        public IComponent Copy() {
            return new PlayerMovingComponent();
        }

        public void Execute(GameTime gameTime) {
            var speed = Entity.speed;

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                speed *= 2;

            Entity.previousLocation = Entity.location;
            Entity.velocity = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Entity.velocity.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Entity.velocity.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Entity.velocity.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Entity.velocity.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Entity.location += Entity.velocity;
        }
    }
}
