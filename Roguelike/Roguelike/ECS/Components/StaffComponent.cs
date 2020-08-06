using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Roguelike.ECS.Entities;

namespace Roguelike.ECS.Components {
    public class StaffComponent : IComponent{
        public Entity Entity { get; set; }

        MouseState previousMouseState;

        public StaffComponent() {
            previousMouseState = Mouse.GetState();
        }

        public void Execute(GameTime gameTime) {
            var mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released) {
                var direction = mouseState.Position.ToVector2() + Camera.ScreenOffset - Entity.location;
                direction.Normalize();
                ServiceLocator.ProjectilePool.Create(Entity.location, direction, 1000);
            }

            previousMouseState = mouseState;
        }

        public IComponent Copy() {
            return new StaffComponent();
        }
    }
}
