using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// Handles the user clicking on the control
    /// </summary>
    public interface IClickHandler {
        /// <summary>
        /// Handles the user clicking on the control
        /// </summary>
        /// <param name="menu">The menu to handle on</param>
        /// <param name="location">The location on the control the user clicked</param>
        /// <param name="tabSize">The size of a tab</param>
        void HandleClick<T>(IMenu<T> menu, Point location, Size tabSize);
    }
}
