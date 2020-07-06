using System;
using System.Collections.Generic;
using System.Text;

using IdleGame.UI.Framework.TextRenderer;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoUI.Framework;
using MonoUI.InputSystem;

namespace MonoUI.Controls {
    public class Checkbox : ComponentBase {
        public bool check { get; private set; }

        private Texture2D checkmark { get; set; }

        public Label label { get; private set; }

        public Checkbox(Rectangle displayRectangle) : base(displayRectangle) {
            label = new Label(displayRectangle.Location + new Point(displayRectangle.Width + 3, 0), new Point(0, displayRectangle.Height)) {
                textAligner = CenteredLeftTextAligner.instance
            };

            AddControl(label);
        }

        public Checkbox(Point location, Point size) : this(new Rectangle(location, size)) { }

        public Checkbox(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }

        public override void Click(MouseClickEventArgs e) {
            if (!displayRectangle.Contains(e.location))
                return;

            check = !check;

            OnClickHandler(e);
        }

        public override void Load(ContentManager content) {
            base.Load(content);

            checkmark = content.Load<Texture2D>("CheckMark");
        }

        protected override void DrawBackground(SpriteBatch spriteBatch) {
            base.DrawBackground(spriteBatch);

            if (check)
                spriteBatch.Draw(checkmark, new Vector2(location.X, location.Y), Color.White);
        }

        protected override void DrawText(SpriteBatch spriteBatch) {
            if (!string.IsNullOrEmpty(text) && renderText)
                textAligner.RenderText(text, new Rectangle(displayRectangle.Location + new Point(45, 0), displayRectangle.Size), null, textColor, textPadding, spriteBatch);
        }
    }
}
