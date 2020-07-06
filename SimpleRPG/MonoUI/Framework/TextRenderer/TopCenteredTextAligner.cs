using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace IdleGame.UI.Framework.TextRenderer {
    public class TopCenteredTextAligner : ITextAligner {
        public static readonly TopCenteredTextAligner instance = new TopCenteredTextAligner();

        public void RenderText(string text, Rectangle bounds, SpriteFont font, Color color, Padding padding, SpriteBatch spriteBatch) {
            var x = (bounds.Width - font.MeasureString(text).X) / 2;
            spriteBatch.DrawString(font, text, new Vector2(x + bounds.X, padding.top + bounds.Y), color);
        }

        private TopCenteredTextAligner() { }
    }
}
