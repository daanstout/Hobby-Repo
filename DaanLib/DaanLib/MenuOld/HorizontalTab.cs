using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.MenuOld {
    /// <summary>
    /// A horizontal tab that is meant to be put above the application
    /// </summary>
    /// <typeparam name="T">The type of data stored</typeparam>
    public class HorizontalTab<T> : TabBase<T> {
        /// <summary>
        /// Instantiates a new Horizontal tab
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data to be stored</param>
        public HorizontalTab(string tabName, T data) : base(tabName, data) { }

        /// <summary>
        /// Draws the tab to the panel
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tabSize">The size of the tab</param>
        /// <param name="location">The location of the tab in the panel</param>
        /// <param name="textFont">The font to use for the text</param>
        /// <param name="textColor">The color of the text</param>
        /// <param name="tabColor">The background color of the tab</param>
        /// <param name="borderColor">The color of the border around the tab</param>
        /// <param name="borderWidth">The width of the border around the tab</param>
        public override void Draw(Graphics g, Size tabSize, Point location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            base.Draw(g, tabSize, location, textFont, textColor, tabColor, borderColor, borderWidth);

            if (!isSelected)
                return;

            if (borderWidth == 0)
                return;

            using Pen pen = new Pen(tabColor, borderWidth);

            g.DrawLine(pen, location.X + borderWidth, location.Y + tabSize.Height, location.X + tabSize.Width - borderWidth, location.Y + tabSize.Height);
        }
    }
}
