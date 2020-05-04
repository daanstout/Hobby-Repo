using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DaanLib.Menu {
    /// <summary>
    /// Keeps track of how the menu should appear
    /// </summary>
    public class MenuAppearance {
        /// <summary>
        /// The color of the text
        /// </summary>
        public Color textColor { get; set; }
        /// <summary>
        /// The background color of the tab
        /// </summary>
        public Color tabBackColor { get; set; }
        /// <summary>
        /// The color of the border around the tab
        /// </summary>
        public Color borderColor { get; set; }
        /// <summary>
        /// The font of the tab
        /// </summary>
        public Font tabFont { get; set; }
        /// <summary>
        /// The width of the border
        /// </summary>
        public int borderWidth { get; set; }
        /// <summary>
        /// The size of a tab
        /// </summary>
        public Size tabSize { get; set; }

        /// <summary>
        /// Gets a default appearance for the menu
        /// </summary>
        /// <returns>A default appearance for the menu</returns>
        public static MenuAppearance GetDefaultAppearance() {
            return new MenuAppearance {
                textColor = Color.Black,
                tabBackColor = Color.White,
                borderColor = Color.Black,
                tabFont = new Font("Times New Roman", 11),
                borderWidth = 1,
                tabSize = new Size(50, 20),
            };
        }
    }
}
