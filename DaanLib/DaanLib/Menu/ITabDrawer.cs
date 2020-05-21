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
        /// The location drawer for the tab
        /// </summary>
        ITabLocationDrawer tabLocationDrawer { get; set; }

        /// <summary>
        /// Draws the tab to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance of the tab</param>
        /// <param name="tab">The tab to draw</param>
        /// <param name="location">The point where to draw the tab</param>
        void Draw<T>(Graphics g, MenuAppearance appearance, ITab<T> tab, Point location);
    }
}
