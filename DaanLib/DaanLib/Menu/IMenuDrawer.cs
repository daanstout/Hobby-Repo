﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// A Drawer that can draw the menu to a control
    /// </summary>
    public interface IMenuDrawer {
        /// <summary>
        /// Draws the menu to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance data of the menu</param>
        /// <param name="menuSize">The size of the menu</param>
        void Draw(Graphics g, MenuAppearance appearance, Size menuSize);
    }
}
