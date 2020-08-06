using System;
using System.Collections.Generic;
using System.Text;

using IdleGame.UI.Framework.TextRenderer;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;

namespace MonoUI.Controls {
    public class Label : ComponentBase {
        public Label(Rectangle displayRectangle) : base(displayRectangle) {
            textAligner = TopLeftTextAligner.instance;
        }

        public Label(Point location, Point size) : this(new Rectangle(location, size)) { }

        public Label(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }

        protected override void DrawText(SpriteBatch spriteBatch) {
            if (!string.IsNullOrEmpty(text) && renderText)
                textAligner.RenderText(text, viewRectangle, font, textColor, textPadding, spriteBatch);
        }
    }
}
