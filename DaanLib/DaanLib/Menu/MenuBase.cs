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
    /// A base class for the IMenu interface
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tabs</typeparam>
    public abstract class MenuBase<T> : IMenu<T> {
        /// <summary>
        /// The default text color
        /// </summary>
        protected static readonly Color defaultTextColor = Color.Black;
        /// <summary>
        /// The default tab background color
        /// </summary>
        protected static readonly Color defaultTabBackColor = Color.White;
        /// <summary>
        /// The default border color
        /// </summary>
        protected static readonly Color defaultBorderColor = Color.Black;

        /// <summary>
        /// The type of tabs that this menu contains
        /// </summary>
        protected readonly Type tabType;

        /// <summary>
        /// The color of the text
        /// </summary>
        public Color textColor { get; set; }
        /// <summary>
        /// The color of the tab
        /// </summary>
        public Color tabBackColor { get; set; }
        /// <summary>
        /// The color of the border
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
        /// Whether or not the user is allowed to click on the menu with the right mouse button
        /// </summary>
        public bool allowRightClick { get; set; }
        /// <summary>
        /// The list of tabs in this menu
        /// </summary>
        protected List<ITab<T>> tabList;
        /// <summary>
        /// The size of a tab
        /// </summary>
        public Size tabSize { get; protected set; }
        /// <summary>
        /// The parent control this menu rests in
        /// </summary>
        public Control parentControl { get; protected set; }
        /// <summary>
        /// The currently selected index
        /// </summary>
        public int currentTabIndex { get; protected set; } = -1;
        /// <summary>
        /// The current mouse mode, what the user needs to do in order to trigger a switch in tabs
        /// </summary>
        public MouseModes currentMode { get; protected set; }

        /// <summary>
        /// Instantiates a new tab
        /// </summary>
        /// <param name="parentControl">The parent control of this tab</param>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="tabType">The type of tabs in this menu</param>
        public MenuBase(Control parentControl, Size tabSize, Type tabType) : this(parentControl, tabSize, tabType, null, null, null, null) { }

        /// <summary>
        /// Instantiates a new tab
        /// </summary>
        /// <param name="parentControl">The parnet control of this tab</param>
        /// <param name="tabSize">The size of a tab</param>
        /// <param name="tabType">The type of tabs in this menu</param>
        /// <param name="textColor">The color of the text (defaults to black)</param>
        /// <param name="tabBackColor">The background color of a tab (defaults to white)</param>
        /// <param name="borderColor">The color of the border (defaults to black)</param>
        /// <param name="tabFont">The font of the tab (defaults to the font of the control)</param>
        public MenuBase(Control parentControl, Size tabSize, Type tabType, Color? textColor, Color? tabBackColor, Color? borderColor, Font tabFont) {
            this.parentControl = parentControl;
            this.tabSize = tabSize;
            this.tabType = tabType;
            this.textColor = textColor ?? defaultTextColor;
            this.tabBackColor = tabBackColor ?? defaultTabBackColor;
            this.borderColor = borderColor ?? defaultBorderColor;
            this.tabFont = tabFont ?? parentControl.Font;

            this.parentControl.Paint += OnDraw;
            this.parentControl.MouseClick += OnClick;
        }

        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tab">The tab to add</param>
        public void CreateTab(ITab<T> tab) {
            if (tab == null)
                throw new ArgumentNullException("Tab is null!");

            if (tab.GetType() != tabType)
                throw new ArgumentException($"The given tab is not of the correct type, should be {tabType}, not {tab.GetType()}");

            if (tabList.FirstOrDefault(t => t.tabName == tab.tabName) != null)
                throw new ArgumentException($"Already exists a tab named {tab.tabName}");

            tabList.Add(tab);

            parentControl.Invalidate();
        }

        /// <summary>
        /// Creates a new tab in the menu
        /// </summary>
        /// <param name="tabName">The name of the tab to display</param>
        /// <param name="data">The data that the tab contains</param>
        public void CreateTab(string tabName, T data) {
            if (string.IsNullOrEmpty(tabName))
                throw new ArgumentNullException("The tab name cannot be null or empty");

            if (data == null)
                throw new ArgumentNullException("The data cannot be null");

            if (!(Activator.CreateInstance(tabType) is ITab<T> tab))
                throw new Exception("Something went wrong with instantiazing a new tab.");

            tab.SetInformation(tabName, data);

            tabList.Add(tab);

            parentControl.Invalidate();
        }

        /// <summary>
        /// Sets the mouse mode, what the user needs to do in order to change the tab
        /// </summary>
        /// <param name="mode">The new mouse mode</param>
        public void SetMouseMode(MouseModes mode) {
            if (mode == currentMode)
                return;

            switch (currentMode) {
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

            currentMode = mode;

            switch (currentMode) {
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
        /// Changes a tab to the specified index
        /// </summary>
        /// <param name="index">The index to change to</param>
        public void ChangeTab(int index) {
            if (index < 0 || index >= tabList.Count || index == currentTabIndex)
                return;

            if (currentTabIndex != -1)
                tabList[currentTabIndex].Deselect();

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
        /// The event that fires when the tab changes
        /// </summary>
        public event EventHandler<TabChangedEventArgs<T>> tabChanged;

        /// <summary>
        /// Invokes the tab changed event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTabChanged(TabChangedEventArgs<T> e) => tabChanged?.Invoke(this, e);

        /// <summary>
        /// Handles the user clicking on the menu
        /// </summary>
        /// <param name="location">The location where the user clicked</param>
        protected abstract void Click(Point location);

        /// <summary>
        /// Reacts to the user clicking on the menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The MouseEventArgs of the event</param>
        protected virtual void OnClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left || allowRightClick)
                Click(e.Location);
        }

        /// <summary>
        /// Handles drawing the menu
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        protected virtual void Draw(Graphics g) {
            if (borderWidth == 0)
                return;

            using Pen pen = new Pen(borderColor, borderWidth);

            g.DrawRectangle(pen, new Rectangle(parentControl.DisplayRectangle.X, parentControl.DisplayRectangle.Y, parentControl.DisplayRectangle.Width - 1, parentControl.DisplayRectangle.Height - 1));
        }

        /// <summary>
        /// Reacts to needing to redraw the menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The PaintEventArgs of the event</param>
        protected virtual void OnDraw(object sender, PaintEventArgs e) => Draw(e.Graphics);
    }
}
