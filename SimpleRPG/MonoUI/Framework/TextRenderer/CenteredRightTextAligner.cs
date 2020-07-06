using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace IdleGame.UI.Framework.TextRenderer {
    public class CenteredRightTextAligner : ITextAligner {
        public readonly static CenteredRightTextAligner instance = new CenteredRightTextAligner();

        public void RenderText(string text, Rectangle bounds, SpriteFont font, Color color, Padding padding, SpriteBatch spriteBatch) {
            var x = bounds.Width - font.MeasureString(text).X;
            var y = (bounds.Height - font.MeasureString(text).Y) / 2;
            spriteBatch.DrawString(font, text, new Vector2(x - padding.right + bounds.X, y + bounds.Y), color);
        }

        private CenteredRightTextAligner() { }
    }
}
