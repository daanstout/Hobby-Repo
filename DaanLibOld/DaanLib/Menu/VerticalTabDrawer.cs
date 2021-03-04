using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menu {
    /// <summary>
    /// A drawer that can draw a tab to a control
    /// </summary>
    public class VerticalTabDrawer : ITabDrawer {
        /// <summary>
        /// Finalizes the drawing of the tab
        /// </summary>
        public ITabLocationDrawer tabLocationDrawer { get; set; } = new LeftTabLocationDrawer();

        /// <summary>
        /// Draws the tab to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance of the tab</param>
        /// <param name="tab">The tab to draw</param>
        /// <param name="location">The point where to draw the tab</param>
        /// <param name="isStart">Indicates this is the first tab</param>
        /// <param name="isEnd">Indicates this is the last tab and at the end of the menu</param>
        public void Draw<T>(Graphics g, MenuAppearance appearance, ITab<T> tab, Point location, bool isStart = false, bool isEnd = false) {
            using SolidBrush tabBrush = new SolidBrush(appearance.tabBackColor);
            using Pen tabBorderPen = new Pen(appearance.borderColor, appearance.borderWidth);
            using SolidBrush textBrush = new SolidBrush(appearance.textColor);

            g.FillRectangle(tabBrush, location.X, location.Y, appearance.tabSize.Width - 1, appearance.tabSize.Height - 1);

            if (appearance.borderWidth > 0)
                g.DrawRectangle(tabBorderPen, location.X, location.Y, appearance.tabSize.Width - 1, appearance.tabSize.Height - 1);

            SizeF tabNameSize = g.MeasureString(tab.tabName, appearance.tabFont);
            Point tabNamePoint = new Point((int)((appearance.tabSize.Width - tabNameSize.Width) / 2) + location.X,
                                           (int)((appearance.tabSize.Height - tabNameSize.Height) / 2) + location.Y);

            if (tabNamePoint.X < 0) {
                TextRenderer.DrawText(null, tab.tabName, appearance.tabFont, new Rectangle(location, appearance.tabSize), appearance.textColor);
            } else {
                g.DrawString(tab.tabName, appearance.tabFont, textBrush, tabNamePoint);
            }

            if (appearance.borderWidth != 0) {

                if (isStart)
                    g.DrawLine(new Pen(appearance.tabBackColor, appearance.borderWidth), new Point(0, 0), new Point(appearance.tabSize.Width, 0));

                if (tab.selected)
                    tabLocationDrawer.Draw(g, location, appearance);
            }
        }
    }
}
