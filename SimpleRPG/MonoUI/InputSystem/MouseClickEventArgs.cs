using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace MonoUI.InputSystem {
    public class MouseClickEventArgs : EventArgs {
        public MouseButtons button { get; private set; }
        public Point location { get; private set; }
        public int x => location.X;
        public int y => location.Y;

        public MouseClickEventArgs(MouseButtons button, Point location) {
            this.button = button;
            this.location = location;
        }
    }
}
