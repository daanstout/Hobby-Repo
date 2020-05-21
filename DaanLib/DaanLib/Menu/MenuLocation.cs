using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// Indicates where the menu is located in the screen
    /// </summary>
    public enum MenuLocation {
        /// <summary>
        /// Indicates the menu is on the top side of the screen, above the content
        /// </summary>
        top,
        /// <summary>
        /// Indicates the menu is on the bottom side of the screen, under the content
        /// </summary>
        bottom,
        /// <summary>
        /// Indicates the menu is on the left side of the screen, to the side of the content
        /// </summary>
        left,
        /// <summary>
        /// Indicates the menu is on the right side of the screen, to the side of the content
        /// </summary>
        right
    }
}
