using System;
using System.Collections.Generic;
using System.Text;

namespace MonoUI.InputSystem {
    enum State {
        /// <summary>The key was released this frame</summary>
        Released,
        /// <summary>The key is pressed</summary>
        Down,
        /// <summary>The key is not pressed</summary>
        Up,
        /// <summary>They key was pressed this frame</summary>
        Pressed
    }
}
