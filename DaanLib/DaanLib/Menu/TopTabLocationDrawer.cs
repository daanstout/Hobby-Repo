using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// Finalizes the drawing of a tab that is located at the top of the screen
    /// </summary>
    public class TopTabLocationDrawer : ITabLocationDrawer {
        /// <summary>
        /// Finalizes the drawing of the tab based on its position of the tab
        /// </summary>
        /// <param name="g">The Graphics instance to draw to</param>
        /// <param name="location">The location the tab is located at</param>
        /// <param name="appearance">The appearance of the tab</param>
        public void Draw(Graphics g, Point location, MenuAppearance appearance) {
            using Pen pen = new Pen(appearance.tabBackColor, appearance.borderWidth);

            g.DrawLine(pen,
                       location.X + appearance.borderWidth,
                       location.Y + appearance.tabSize.Height - 1,
                       location.X + appearance.tabSize.Width - appearance.borderWidth,
                       location.Y + appearance.tabSize.Height - 1);
        }
    }
}
