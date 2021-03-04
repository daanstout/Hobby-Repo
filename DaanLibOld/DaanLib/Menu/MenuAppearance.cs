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
        public static MenuAppearance GetDefaultAppearance(Size? tabSize = null) {
            return new MenuAppearance {
                textColor = Color.Black,
                tabBackColor = Color.White,
                borderColor = Color.Black,
                tabFont = new Font("Times New Roman", 11),
                borderWidth = 1,
                tabSize = tabSize ?? new Size(50, 20),
            };
        }

        /// <summary>
        /// Sets the text color to the specified color
        /// </summary>
        /// <param name="color">The color the text should appear with</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetTextColor(Color color) {
            textColor = color;
            return this;
        }

        /// <summary>
        /// Sets the background color of the tab
        /// </summary>
        /// <param name="color">The color the tab should have as background</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetTabBackColor(Color color) {
            tabBackColor = color;
            return this;
        }

        /// <summary>
        /// Sets the border color for the tab
        /// </summary>
        /// <param name="color">The color the border should appear with</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetTabBorderColor(Color color) {
            borderColor = color;
            return this;
        }

        /// <summary>
        /// Sets the font the tab should use to display the text with
        /// </summary>
        /// <param name="font">The font to display the text with</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetTabFont(Font font) {
            tabFont = font;
            return this;
        }

        /// <summary>
        /// Sets the with of the border
        /// </summary>
        /// <param name="width">The width of the border</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetBorderWidth(int width) {
            borderWidth = width;
            return this;
        }

        /// <summary>
        /// Sets the size of the tab
        /// </summary>
        /// <param name="size">The size of the tab</param>
        /// <returns>The instance of the appearance</returns>
        public MenuAppearance SetTabSize(Size size) {
            tabSize = size;
            return this;
        }
    }
}
