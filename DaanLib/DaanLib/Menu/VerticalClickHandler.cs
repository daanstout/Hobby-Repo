﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// Handles the user clicking on the control in a menu with a vertical lay-out
    /// </summary>
    public class VerticalClickHandler : IClickHandler {
        /// <summary>
        /// Handles the user clicking on the control
        /// </summary>
        /// <param name="menu">The menu to handle on</param>
        /// <param name="location">The location on the control the user clicked</param>
        /// <param name="tabSize">The size of a tab</param>
        public void HandleClick<T>(IMenu<T> menu, Point location, Size tabSize) {
            var index = location.Y / tabSize.Height;

            menu.ChangeTab(index);
        }
    }
}
