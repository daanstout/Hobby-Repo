using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace IdleGame.UI.Framework.TextRenderer {
    public class BottomLeftTextAligner : ITextAligner {
        public readonly static BottomLeftTextAligner instance = new BottomLeftTextAligner();

        public void RenderText(string text, Rectangle bounds, SpriteFont font, Color color, Padding padding, SpriteBatch spriteBatch) {
            var y = bounds.Height - font.MeasureString(text).Y;
            spriteBatch.DrawString(font, text, new Vector2(padding.left + bounds.X, y - padding.bottom + bounds.Y), color);
        }

        private BottomLeftTextAligner() { }
    }
}