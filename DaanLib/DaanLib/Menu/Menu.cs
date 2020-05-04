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
        /// The menu drawer to use when the menu needs to be drawn
        /// </summary>
        public IMenuDrawer menuDrawer { get; internal set; }
        /// <summary>
        /// The tab drawer to use when a tab needs to be drawn
        /// </summary>
        public ITabDrawer tabDrawer { get; internal set; }
        /// <summary>
        /// The click handler to use to handle the user clicking on the menu
        /// </summary>
        public IClickHandler clickHandler { get; internal set; }

        ///// <summary>
        ///// The type of tabs that this menu contains
        ///// </summary>
        //protected internal Type tabType { get; internal set; }

        /// <summary>
        /// Instantiates a new Menu object
        /// </summary>
        protected internal Menu() { }

        /// <summary>
        /// Changes a tab to the specified index
        /// </summary>
        /// <param name="index">The index to change to</param>
        public virtual void ChangeTab(int index) {
            if (index < 0 || index >= tabList.Count)
                return;

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
        public virtual void ChangeTab(string name) => ChangeTab(tabList.FindIndex(tab => tab.tabName == name));

        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tab">The tab to add</param>
        public virtual void CreateTab(ITab<T> tab) {
            if (tab == null)
                throw new ArgumentException("Tab cannot be null");

            //if (tab.GetType() != tabType)
            //    throw new ArgumentException($"The given tab is not of the correct type. Should be {tabType}, but is {tab.GetType()}");

            if (tabList.Exists(t => t.tabName == tab.tabName))
                throw new ArgumentException($"There already is a tab named {tab.tabName}");

            tabList.Add(tab);

            parentControl.Invalidate();
        }

        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tabName">The name of the tab to display</param>
        /// <param name="data">The data that the tab contains</param>
        public virtual void CreateTab(string tabName, T data) {
            if (string.IsNullOrEmpty(tabName))
                throw new ArgumentException("The tab name cannot be null or empty");

            if (data == null)
                throw new ArgumentException("The data cannot be null");

            //if (!(Activator.CreateInstance(tabType) is ITab<T> tab))
            //    throw new Exception("Something went wrong with instantiating a new tab, check if everything is correctly set");

            var tab = new Tab<T>();

            tab.SetInformation(tabName, data);

            CreateTab(tab);
        }

        /// <summary>
        /// Sets the mouse mode, what the user needs to do in order to change the tab
        /// </summary>
        /// <param name="mode">The new mouse mode</param>
        public virtual void SetMouseMode(MouseModes mode) {
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
        protected internal virtual void OnClick(object sender, MouseEventArgs e) => clickHandler.HandleClick(this, e.Location, appearance.tabSize);

        /// <summary>
        /// Reacts to needing to redraw the menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The PaintEventArgs of the event</param>
        protected internal virtual void OnDraw(object sender, PaintEventArgs e) => menuDrawer.Draw(e.Graphics, appearance, parentControl.Size, tabList, tabDrawer);
    }
}
