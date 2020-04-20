using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// A drawer that can draw a tab to a control
    /// </summary>
    public interface ITabDrawer {
        /// <summary>
        /// Draws the tab to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance of the tab</param>
        /// <param name="tabSize">The size of a tab</param>
        void Draw(Graphics g, MenuAppearance appearance, Size tabSize);
    }
}
