using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menu {
    /// <summary>
    /// A factory to create a menu based on specific requirements
    /// </summary>
    public class MenuBuilderFactory {
        /// <summary>
        /// Builds a menu based on the parameters given
        /// </summary>
        /// <typeparam name="T">The type of data the menu should hold</typeparam>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="parentControl">The size of the parent control</param>
        /// <param name="appearance">The appearance of the menu<para>Leave null for default values</para></param>
        /// <param name="menuDrawer">The menu drawer to use when the menu needs to be drawn</param>
        /// <param name="tabDrawer">The tab drawer to use when a tab needs to be drawn</param>
        /// <returns>A Menu that conforms to the given parameters</returns>
        public IMenu<T> Build<T>(Size tabSize, Control parentControl, MenuAppearance appearance = null, IMenuDrawer menuDrawer = null, ITabDrawer tabDrawer = null) {
            var menu = new Menu<T> {
                appearance = appearance ?? MenuAppearance.GetDefaultAppearance(),
                allowRightClick = false,
                tabSize = tabSize,
                parentControl = parentControl,
                currentTabIndex = -1,
                currentMouseMode = MouseModes.mouseClick,
                menuDrawer = menuDrawer ?? new VerticalMenuDrawer(),
                tabDrawer = tabDrawer ?? new VerticalTabDrawer(),
            };

            parentControl.Paint += menu.OnDraw;
            parentControl.MouseClick += menu.OnClick;

            return menu;
        }
    }
}
