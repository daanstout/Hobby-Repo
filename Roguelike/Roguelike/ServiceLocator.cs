using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.Graphics;

namespace Roguelike {
    public static class ServiceLocator {
        public static ProjectilePool ProjectilePool { get; } = new ProjectilePool();

        public static void Initialize() {
            
        }

        public static void Load() {
            ProjectilePool.Load();
        }

        public static void Update(GameTime gameTime) {
            ProjectilePool.Update(gameTime);
        }

        public static void Draw(DrawData drawData) {
            ProjectilePool.Draw(drawData);
        }
    }
}
