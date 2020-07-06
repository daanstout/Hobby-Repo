using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace IdleGame.UI.Framework.TextRenderer {
    public class BottomRightTextAligner : ITextAligner {
        public readonly static BottomRightTextAligner instance = new BottomRightTextAligner();

        public void RenderText(string text, Rectangle bounds, SpriteFont font, Color color, Padding padding, SpriteBatch spriteBatch) {
            var x = bounds.Width - font.MeasureString(text).X;
            var y = bounds.Height - font.MeasureString(text).Y;
            spriteBatch.DrawString(font, text, new Vector2(x - padding.right + bounds.X, y - padding.bottom + bounds.Y), color);
        }

        private BottomRightTextAligner() { }
    }
}
