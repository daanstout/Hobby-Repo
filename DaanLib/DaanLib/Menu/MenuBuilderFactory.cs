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
    public static class MenuBuilderFactory {
        /// <summary>
        /// Builds a menu based on the parameters given
        /// </summary>
        /// <typeparam name="T">The type of data the menu should hold</typeparam>
        /// <param name="parentControl">The parent control this menu resides in</param>
        /// <param name="menuLayout">The standard layout to use, either horizontal or vertical</param>
        /// <param name="menuLocation">The location in the screen the menu is located at</param>
        /// <param name="appearance">The appearance this menu should take<para>Leave null for default layout</para></param>
        /// <param name="eventFunction">The function to execute when the tab changes</param>
        /// <returns>A menu based on the parameters given</returns>
        public static IMenu<T> Build<T>(Control parentControl, MenuLayout menuLayout, MenuLocation menuLocation, MenuAppearance appearance = null, EventHandler<TabChangedEventArgs<T>> eventFunction = null) {
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

            switch (menuLocation) {
                case MenuLocation.top:
                    menu.tabDrawer.tabLocationDrawer = new TopTabLocationDrawer();
                    break;
                case MenuLocation.right:
                    menu.tabDrawer.tabLocationDrawer = new RightTabLocationDrawer();
                    break;
                case MenuLocation.bottom:
                    menu.tabDrawer.tabLocationDrawer = new BottomTabLocationDrawer();
                    break;
                case MenuLocation.left:
                    menu.tabDrawer.tabLocationDrawer = new LeftTabLocationDrawer();
                    break;
            }

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
        /// <param name="parentControl">The parent control this menu resides in</param>
        /// <param name="appearance">The appearance of the menu<para>Leave null for default values</para></param>
        /// <param name="menuDrawer">The menu drawer to use when the menu needs to be drawn</param>
        /// <param name="tabDrawer">The tab drawer to use when a tab needs to be drawn</param>
        /// <param name="clickHandler">The click handler to use with the menu</param>
        /// <param name="locationDrawer">The location drawer the tab uses to finalize location dependent tab visuals</param>
        /// <param name="eventFunction">The function to execute when the tab changes</param>
        /// <returns>A Menu that conforms to the given parameters</returns>
        public static IMenu<T> Build<T>(Control parentControl, MenuAppearance appearance = null, IMenuDrawer menuDrawer = null, ITabDrawer tabDrawer = null, IClickHandler clickHandler = null, ITabLocationDrawer locationDrawer = null, EventHandler<TabChangedEventArgs<T>> eventFunction = null) {
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

            parentControl.Paint += menu.OnDraw;
            parentControl.MouseClick += menu.OnClick;

            if (locationDrawer != null)
                menu.tabDrawer.tabLocationDrawer = locationDrawer;

            if (eventFunction != null)
                menu.tabChanged += eventFunction;

            return menu;
        }
    }
}
