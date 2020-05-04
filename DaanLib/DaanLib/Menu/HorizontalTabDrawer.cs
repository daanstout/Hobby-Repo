﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menu {
    /// <summary>
    /// A drawer that can draw a tab to a control
    /// </summary>
    public class HorizontalTabDrawer : ITabDrawer {
        /// <summary>
        /// Draws the tab to a graphics instance
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        /// <param name="appearance">The appearance of the tab</param>
        /// <param name="tab">The tab to draw</param>
        /// <param name="location">The point where to draw the tab</param>
        /// <param name="tabSize">The size of a tab</param>
        public void Draw<T>(Graphics g, MenuAppearance appearance, ITab<T> tab, Point location, Size tabSize) {
            using SolidBrush tabBrush = new SolidBrush(appearance.tabBackColor);
            using Pen tabBorderPen = new Pen(appearance.borderColor, appearance.borderWidth);
            using SolidBrush textBrush = new SolidBrush(appearance.textColor);

            g.FillRectangle(tabBrush, location.X, location.Y, tabSize.Width - 1, tabSize.Height - 1);

            if (appearance.borderWidth > 0)
                g.DrawRectangle(tabBorderPen, location.X, location.Y, tabSize.Width - 1, tabSize.Height - 1);

            SizeF tabNameSize = g.MeasureString(tab.tabName, appearance.tabFont);
            Point tabNamePoint = new Point((int)((tabSize.Width - tabNameSize.Width) / 2) + location.X,
                                           (int)((tabSize.Height - tabNameSize.Height) / 2) + location.Y);

            if (tabNamePoint.X < 0) {
                tabNameSize = TextRenderer.MeasureText(tab.tabName, appearance.tabFont);
                tabNamePoint = new Point((int)((tabSize.Width - tabNameSize.Width) / 2) + location.X,
                                         (int)((tabSize.Height - tabNameSize.Height) / 2) + location.Y);

                TextRenderer.DrawText(null, tab.tabName, appearance.tabFont, tabNamePoint, appearance.textColor);
            } else {
                g.DrawString(tab.tabName, appearance.tabFont, textBrush, tabNamePoint);
            }

            if (!tab.selected)
                return;

            if (appearance.borderWidth == 0)
                return;

            using Pen pen = new Pen(appearance.tabBackColor, appearance.borderWidth);

            g.DrawLine(pen,
                       location.X + appearance.borderWidth,
                       location.Y + tabSize.Height,
                       location.X + tabSize.Width - appearance.borderWidth,
                       location.Y + tabSize.Height);
        }
    }
}
