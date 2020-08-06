using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Roguelike.Graphics;

namespace Roguelike.ECS.Components {
    public interface IDrawComponent : IComponent {
        void Draw(DrawData drawData);
    }
}
