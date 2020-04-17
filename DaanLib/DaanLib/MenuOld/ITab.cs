using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.MenuOld {
    /// <summary>
    /// Displays a tab inside of the menu
    /// </summary>
    /// <typeparam name="T">The data that the tab stores</typeparam>
    public interface ITab<T> {
        /// <summary>
        /// The name of the tab
        /// </summary>
        string tabName { get; }
        /// <summary>
        /// The data that the tab contains
        /// </summary>
        T data { get; }

        /// <summary>
        /// Selects the tab
        /// </summary>
        /// <returns>The data the tab stores</returns>
        T Select();
        /// <summary>
        /// Deselects the tab
        /// </summary>
        void Deselect();

        /// <summary>
        /// Sets the tab information
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data that the tab contains</param>
        void SetInformation(string tabName, T data);

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
        void Draw(Graphics g, Size tabSize, Point location, Font textFont, Color textColor, Color tabColor, Color borderColor, int borderWidth);
    }
}
