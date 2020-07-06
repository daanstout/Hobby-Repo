using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using MonoUI.InputSystem;

namespace MonoUI.Framework {
    public abstract class ComponentBase : ControlBase {
        public ComponentBase(Rectangle displayRectangle) : base(displayRectangle) { }

        public ComponentBase(Point location, Point size) : base(location, size) { }

        public ComponentBase(int x, int y, int width, int height) : base(x, y, width, height) { }
    }
}
