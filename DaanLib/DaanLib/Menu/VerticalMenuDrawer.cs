using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// A Drawer that can draw the menu to a control
    /// </summary>
    public class VerticalMenuDrawer : IMenuDrawer {
        /// <summary>
        /// Draws the menu to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance data of the menu</param>
        /// <param name="menuSize">The size of the menu</param>
        /// <param name="tabList">The list of tabs to draw</param>
        /// <param name="tabDrawer">The tab drawer to use when drawing the tabs</param>
        public void Draw<T>(Graphics g, MenuAppearance appearance, Size menuSize, IEnumerable<ITab<T>> tabList, ITabDrawer tabDrawer) {
            if (appearance.borderWidth > 0) {
                using Pen pen = new Pen(appearance.borderColor, appearance.borderWidth);

                g.DrawRectangle(pen, new Rectangle(0, 0, menuSize.Width - 1, menuSize.Height - 1));
            }

            int y = 0;

            foreach (var tab in tabList) {
                tabDrawer.Draw(g, appearance, tab, new Point(0, y));

                y += appearance.tabSize.Height;
            }
        }
    }
}
