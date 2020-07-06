using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace IdleGame.UI.Framework.TextRenderer {
    public class TopLeftTextAligner : ITextAligner {
        public readonly static TopLeftTextAligner instance = new TopLeftTextAligner();

        public void RenderText(string text, Rectangle bounds, SpriteFont font, Color color, Padding padding, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, text, new Vector2(padding.left + bounds.X, padding.top + bounds.Y), color);
        }

        private TopLeftTextAligner() { }
    }
}
