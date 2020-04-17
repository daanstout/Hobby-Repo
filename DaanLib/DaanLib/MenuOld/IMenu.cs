using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.MenuOld {
    /// <summary>
    /// A configurable menu that allows you to switch between various tabs
    /// </summary>
    /// <typeparam name="T">The type of data stored within the tabs</typeparam>
    public interface IMenu<T> {
        /// <summary>
        /// The color of the text
        /// </summary>
        Color textColor { get; set; }
        /// <summary>
        /// The background color of the tab
        /// </summary>
        Color tabBackColor { get; set; }
        /// <summary>
        /// The color of the border around the tab
        /// </summary>
        Color borderColor { get; set; }
        /// <summary>
        /// The font of the tab
        /// </summary>
        Font tabFont { get; set; }
        /// <summary>
        /// The width of the border
        /// </summary>
        int borderWidth { get; set; }
        /// <summary>
        /// Whether the menu allows the user to use the menu with the right mouse button or not (The user is always allowed to use the left mouse button)
        /// </summary>
        bool allowRightClick { get; set; }
        /// <summary>
        /// The size of the tab
        /// </summary>
        Size tabSize { get; }
        /// <summary>
        /// THe parent control that houses this tab
        /// </summary>
        Control parentControl { get; }
        /// <summary>
        /// The index of the currently selected tab
        /// </summary>
        int currentTabIndex { get; }

        /// <summary>
        /// Adds a new tab to the menu
        /// </summary>
        /// <param name="tab">The tab to add</param>
        /// <exception cref="ArgumentException">Thrown if the tab is not of the same type as the menu tabtype</exception>
        /// <exception cref="ArgumentNullException">Thrown if the tab given is null</exception>
        void CreateTab(ITab<T> tab);
        /// <summary>
        /// Creates and adds a new tab to the menu
        /// </summary>
        /// <param name="tabName">The display name of the tab</param>
        /// <param name="data">The data the tab should store</param>
        /// <exception cref="ArgumentNullException">Thrown if the data or the name is null</exception>
        void CreateTab(string tabName, T data);
        /// <summary>
        /// Changes the type of mouse click the menu listens to
        /// </summary>
        /// <param name="mode">The type of mouse click to listen to</param>
        void SetMouseMode(MouseModes mode);
        /// <summary>
        /// Changes the currently selected tab
        /// </summary>
        /// <param name="index">The index of the tab in the menu</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is outside of the range</exception>
        void ChangeTab(int index);
        /// <summary>
        /// Changes the currently selected tab
        /// </summary>
        /// <param name="name">The name of the tab in the menu</param>
        /// <exception cref="ArgumentNullException">Thrown if the name is null</exception>
        void ChangeTab(string name);

        /// <summary>
        /// The event that is thrown when the tab is changed
        /// </summary>
        event EventHandler<TabChangedEventArgs<T>> tabChanged;
    }
}
