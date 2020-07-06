using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using MonoUI.Framework;

namespace MonoUI.Controls {
    public class Button : ComponentBase {
        public Button(Rectangle displayRectangle) : base(displayRectangle) { }

        public Button(Point location, Point size) : base(location, size) { }

        public Button(int x, int y, int width, int height) : base(x, y, width, height) { }
    }

}
