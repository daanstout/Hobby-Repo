using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace MonoUI.InputSystem {
    public class MouseMoveEventArgs {
        public Point location { get; private set; }
        public int x => location.X;
        public int y => location.Y;

        public MouseMoveEventArgs(Point location) {
            this.location = location;
        }
    }
}
