using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.MenuOld {
    /// <summary>
    /// Possible mouse modes the menu listens for
    /// </summary>
    public enum MouseModes {
        /// <summary>
        /// Releasing the mouse when clicking
        /// </summary>
        mouseUp,
        /// <summary>
        /// Pressing the mouse when clicking
        /// </summary>
        mouseDown,
        /// <summary>
        /// Clicking with the mouse
        /// </summary>
        mouseClick,
        /// <summary>
        /// Double clicking with the mouse
        /// </summary>
        mouseDoubleClick
    }
}
