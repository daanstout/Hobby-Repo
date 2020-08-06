
using Microsoft.Xna.Framework;

using Roguelike.ECS.Entities;

namespace Roguelike.ECS.Components {
    public interface IComponent {
        Entity Entity { get; set; }
        void Execute(GameTime gameTime);
        IComponent Copy();
    }
}
