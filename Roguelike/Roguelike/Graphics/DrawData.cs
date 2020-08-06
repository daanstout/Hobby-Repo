using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.Utils;

namespace Roguelike.Graphics {
    public struct DrawData {
        public SpriteBatch SpriteBatch { get; }
        public RectangleF ScreenBounds { get; }

        public DrawData(SpriteBatch spriteBatch, RectangleF screenBounds) {
            SpriteBatch = spriteBatch;
            ScreenBounds = screenBounds;
        }
    }
}
