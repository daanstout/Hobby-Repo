using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.MenuOld {
    /// <summary>
    /// A horizontal menu
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tab</typeparam>
    public class HorizontalMenu<T> : MenuBase<T> {
        /// <summary>
        /// Instantiates a new Horizontal Menu with horizontal tabs and default colors
        /// </summary>
        /// <param name="parentControl">The control this menu resides in</param>
        /// <param name="tabSize">The size of each tab</param>
        public HorizontalMenu(Control parentControl, Size tabSize) : base(parentControl, tabSize, typeof(HorizontalTab<T>)) { }

        /// <summary>
        /// Instantiates a new Horizontal Menu with default colors
        /// </summary>
        /// <param name="parentControl">The control this menu resides in</param>
        /// <param name="tabSize">The size of each tab</param>
        /// <param name="tabType">The type of tab this menu uses</param>
        public HorizontalMenu(Control parentControl, Size tabSize, Type tabType) : base(parentControl, tabSize, tabType) { }

        /// <summary>
        /// Instantiates a new Horizontal Menu with horizontal tabs
        /// </summary>
        /// <param name="parentControl">The control this menu resides in</param>
        /// <param name="tabSize">The size of each tab</param>
        /// <param name="textColor">The color of the text in the tab (defaults to black)</param>
        /// <param name="tabBackColor">The background color of th tab (defaults to white)</param>
        /// <param name="borderColor">The color of the border around the tab (defaults to black)</param>
        /// <param name="tabFont">The font used for the text in the tab (defaults to the font of the control)</param>
        public HorizontalMenu(Control parentControl, Size tabSize, Color? textColor, Color? tabBackColor, Color? borderColor, Font tabFont) : base(parentControl, tabSize, typeof(HorizontalTab<T>), textColor, tabBackColor, borderColor, tabFont) { }

        /// <summary>
        /// Instantiates a new Horizontal Menu with horizontal tabs
        /// </summary>
        /// <param name="parentControl">The control this menu resides in</param>
        /// <param name="tabSize">The size of each tab</param>
        /// <param name="tabType">The type of tab this menu uses</param>
        /// <param name="textColor">The color of the text in the tab (defaults to black)</param>
        /// <param name="tabBackColor">The background color of th tab (defaults to white)</param>
        /// <param name="borderColor">The color of the border around the tab (defaults to black)</param>
        /// <param name="tabFont">The font used for the text in the tab (defaults to the font of the control)</param>
        public HorizontalMenu(Control parentControl, Size tabSize, Type tabType, Color? textColor, Color? tabBackColor, Color? borderColor, Font tabFont) : base(parentControl, tabSize, tabType, textColor, tabBackColor, borderColor, tabFont) { }

        /// <summary>
        /// Draws the menu to the control
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        protected override void Draw(Graphics g) {
            base.Draw(g);

            int x = 0;

            foreach (ITab<T> tab in tabList) {
                tab.Draw(g, tabSize, new Point(x, 0), tabFont, textColor, tabBackColor, borderColor, borderWidth);

                x += tabSize.Width;
            }
        }

        /// <summary>
        /// Handles the user clicking on the menu
        /// </summary>
        /// <param name="location">The location where the user clicked in the control</param>
        protected override void Click(Point location) {
            int index = location.X / tabSize.Width;

            ChangeTab(index);
        }
    }
}
