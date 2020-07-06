using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

using MonoUI.InputSystem;

namespace MonoUI.Framework {
    public abstract class ContainerBase : ControlBase {
        public ContainerBase(Rectangle displayRectangle) : base(displayRectangle) {
            Input.onMouseClick += Click;
        }

        public ContainerBase(Point location, Point size) : this(new Rectangle(location, size)) { }

        public ContainerBase(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height)) { }
    }
}
