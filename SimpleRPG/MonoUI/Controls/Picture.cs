using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using MonoUI.Framework;

namespace MonoUI.Controls {
    public class Picture : ComponentBase {
        public Picture(Rectangle displayRectangle) : base(displayRectangle) { }

        public Picture(Point location, Point size) : this(new Rectangle(location, size)) { }

        public Picture(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }
    }
}
