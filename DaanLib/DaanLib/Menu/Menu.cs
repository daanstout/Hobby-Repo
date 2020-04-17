using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaanLib.Menu {
    /// <summary>
    /// A base class for the IMenu interface
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tabs</typeparam>
    public class Menu<T> : IMenu<T> {
        /// <summary>
        /// The appearance of thismenu
        /// </summary>
        public MenuAppearance appearance { get; protected internal set; }
        /// <summary>
        /// Whether or not the user is allowed to click on the menu with the right mouse button
        /// </summary>
        public bool allowRightClick { get; set; }
        /// <summary>
        /// The size of a tab
        /// </summary>
        public Size tabSize { get; internal set; }
        /// <summary>
        /// The parent control this menu rests in
        /// </summary>
        public Control parentControl { get; internal set; }
        /// <summary>
        /// The currently selected index
        /// </summary>
        public int currentTabIndex { get; protected internal set; }
        /// <summary>
        /// The event that fires when the tab changes
        /// </summary>
        public event EventHandler<TabChangedEventArgs<T>> tabChanged;
        /// <summary>
        /// The list of tabs in this menu
        /// </summary>
        protected List<ITab<T>> tabList = new List<ITab<T>>();
        /// <summary>
        /// The current mouse mode, what the user needs to do in order to trigger a switch in tabs
        /// </summary>
        public MouseModes currentMouseMode { get; protected internal set; } = MouseModes.mouseClick;

        /// <summary>
        /// The type of tabs that this menu contains
        /// </summary>
        protected internal Type tabType { get; internal set; }

        internal Menu() { }

        /// <summary>
        /// Changes a tab to the specified index
        /// </summary>
        /// <param name="index">The index to change to</param>
        public void ChangeTab(int index) {
            if (index < 0 || index >= tabList.Count)
                throw new ArgumentException("Index must be within the bounds");

            if (index == currentTabIndex)
                return;

            currentTabIndex = index;

            T data = tabList[currentTabIndex].Select();

            TabChangedEventArgs<T> args = new TabChangedEventArgs<T>(data, index);

            OnTabChanged(args);

            parentControl.Invalidate();
        }

        /// <summary>
        /// Changes the tab to the tab with the given name
        /// </summary>
        /// <param name="name">The name of the tab to change to</param>
        public void ChangeTab(string name) => ChangeTab(tabList.FindIndex(tab => tab.tabName == name));
        
        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tab">The tab to add</param>
        public void CreateTab(ITab<T> tab) => throw new NotImplementedException();

        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tabName">The name of the tab to display</param>
        /// <param name="data">The data that the tab contains</param>
        public void CreateTab(string tabName, T data) => throw new NotImplementedException();

        /// <summary>
        /// Sets the mouse mode, what the user needs to do in order to change the tab
        /// </summary>
        /// <param name="mode">The new mouse mode</param>
        public void SetMouseMode(MouseModes mode) {
            if (mode == currentMouseMode)
                return;

            switch (currentMouseMode) {
                case MouseModes.mouseClick:
                    parentControl.MouseClick -= OnClick;
                    break;
                case MouseModes.mouseDoubleClick:
                    parentControl.MouseDoubleClick -= OnClick;
                    break;
                case MouseModes.mouseDown:
                    parentControl.MouseDown -= OnClick;
                    break;
                case MouseModes.mouseUp:
                    parentControl.MouseUp -= OnClick;
                    break;
            }

            currentMouseMode = mode;

            switch (currentMouseMode) {
                case MouseModes.mouseClick:
                    parentControl.MouseClick += OnClick;
                    break;
                case MouseModes.mouseDoubleClick:
                    parentControl.MouseDoubleClick += OnClick;
                    break;
                case MouseModes.mouseDown:
                    parentControl.MouseDown += OnClick;
                    break;
                case MouseModes.mouseUp:
                    parentControl.MouseUp += OnClick;
                    break;
            }
        }

        /// <summary>
        /// Invokes the tab changed event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTabChanged(TabChangedEventArgs<T> e) => tabChanged?.Invoke(this, e);

        /// <summary>
        /// Reacts to the user clicking on the menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The MouseEventArgs of the event</param>
        protected virtual void OnClick(object sender, MouseEventArgs e) {

        }

        /// <summary>
        /// Reacts to needing to redraw the menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The PaintEventArgs of the event</param>
        protected virtual void OnDraw(object sender, PaintEventArgs e) {

        }
    }
}
