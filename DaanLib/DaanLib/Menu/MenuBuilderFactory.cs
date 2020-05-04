using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        /// <param name="parentControl">The parent control this menu resides in</param>
        /// <param name="menuLayout">The standard layout to use, either horizontal or vertical</param>
        /// <param name="appearance">The appearance this menu should take<para>Leave null for default layout</para></param>
        /// <param name="eventFunction">The function to execute when the tab changes</param>
        /// <returns>A menu based on the parameters given</returns>
        public IMenu<T> Build<T>(Size tabSize, Control parentControl, MenuLayout menuLayout, MenuAppearance appearance = null, EventHandler<TabChangedEventArgs<T>> eventFunction = null) {
            var menu = new Menu<T> {
                appearance = appearance ?? MenuAppearance.GetDefaultAppearance(),
                allowRightClick = false,
                parentControl = parentControl,
                currentTabIndex = -1,
                currentMouseMode = MouseModes.mouseClick,
            };

            switch (menuLayout) {
                case MenuLayout.horizontal:
                    menu.menuDrawer = new HorizontalMenuDrawer();
                    menu.tabDrawer = new HorizontalTabDrawer();
                    menu.clickHandler = new HorizontalClickHandler();
                    break;
                case MenuLayout.vertical:
                    menu.menuDrawer = new VerticalMenuDrawer();
                    menu.tabDrawer = new VerticalTabDrawer();
                    menu.clickHandler = new VerticalClickHandler();
                    break;
            }

            menu.appearance.tabSize = tabSize;

            parentControl.Paint += menu.OnDraw;
            parentControl.MouseClick += menu.OnClick;

            if (eventFunction != null)
                menu.tabChanged += eventFunction;

            return menu;
        }

        /// <summary>
        /// Builds a menu based on the parameters given
        /// </summary>
        /// <typeparam name="T">The type of data the menu should hold</typeparam>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="parentControl">The parent control this menu resides in</param>
        /// <param name="appearance">The appearance of the menu<para>Leave null for default values</para></param>
        /// <param name="menuDrawer">The menu drawer to use when the menu needs to be drawn</param>
        /// <param name="tabDrawer">The tab drawer to use when a tab needs to be drawn</param>
        /// <param name="clickHandler">The click handler to use with the menu</param>
        /// <param name="eventFunction">The function to execute when the tab changes</param>
        /// <returns>A Menu that conforms to the given parameters</returns>
        public IMenu<T> Build<T>(Size tabSize, Control parentControl, MenuAppearance appearance = null, IMenuDrawer menuDrawer = null, ITabDrawer tabDrawer = null, IClickHandler clickHandler = null, EventHandler<TabChangedEventArgs<T>> eventFunction = null) {
            var menu = new Menu<T> {
                appearance = appearance ?? MenuAppearance.GetDefaultAppearance(),
                allowRightClick = false,
                parentControl = parentControl,
                currentTabIndex = -1,
                currentMouseMode = MouseModes.mouseClick,
                menuDrawer = menuDrawer ?? new VerticalMenuDrawer(),
                tabDrawer = tabDrawer ?? new VerticalTabDrawer(),
                clickHandler = clickHandler ?? new VerticalClickHandler(),
            };

            menu.appearance.tabSize = tabSize;

            parentControl.Paint += menu.OnDraw;
            parentControl.MouseClick += menu.OnClick;

            if (eventFunction != null)
                menu.tabChanged += eventFunction;

            return menu;
        }
    }
}
