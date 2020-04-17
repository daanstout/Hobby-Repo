using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// A base class for the ITab Interface
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tab</typeparam>
    public abstract class TabBase<T> : ITab<T> {
        /// <summary>
        /// The name of the tab
        /// </summary>
        public string tabName { get; protected set; }
        /// <summary>
        /// The data that the tab contains
        /// </summary>
        public T data { get; protected set; }

        /// <summary>
        /// Indicates whether this tab is currently selected
        /// </summary>
        protected bool isSelected = false;

        /// <summary>
        /// Instantiates a new Tab
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data to be stored in the tab</param>
        public TabBase(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        /// <summary>
        /// Sets the tab information
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data that the tab contains</param>
        public void SetInformation(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }

        /// <summary>
        /// Selects the tab
        /// </summary>
        /// <returns>The data the tab stores</returns>
        public virtual T Select() {
            isSelected = true;

            return data;
        }
        /// <summary>
        /// Deselects the tab
        /// </summary>
        public virtual void Deselect() => isSelected = false;

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
        public virtual void Draw(Graphics g, Size tabSize, Point location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth) {
            using SolidBrush tabBrush = new SolidBrush(tabColor);
            using Pen pen = new Pen(borderColor, borderWidth);
            using SolidBrush textBrush = new SolidBrush(textColor);

            g.FillRectangle(tabBrush, location.X, location.Y, tabSize.Width - 1, tabSize.Height - 1);

            if (borderWidth > 0)
                g.DrawRectangle(pen, location.X, location.Y, tabSize.Width - 1, tabSize.Height - 1);

            SizeF tabNameSize = g.MeasureString(tabName, textFont);
            Point tabNamePoint = new Point((int)((tabSize.Width - tabNameSize.Width) / 2) + location.X, (int)((tabSize.Height - tabNameSize.Height) / 2) + location.Y);

            g.DrawString(tabName, textFont, textBrush, tabNamePoint);
        }
    }
}
