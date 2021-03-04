using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// An Interface that is used to finalize drawing a tab depending on where the tab is drawn on the screen
    /// </summary>
    public interface ITabLocationDrawer {
        /// <summary>
        /// Finalizes the drawing of the tab based on its position of the tab
        /// </summary>
        /// <param name="g">The Graphics instance to draw to</param>
        /// <param name="location">The location the tab is located at</param>
        /// <param name="appearance">The appearance of the tab</param>
        void Draw(Graphics g, Point location, MenuAppearance appearance);
    }
}
