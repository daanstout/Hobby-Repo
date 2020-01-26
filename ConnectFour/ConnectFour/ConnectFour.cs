using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour {
    /// <summary>
    /// A form that allows the user to play Connect Four
    /// </summary>
    public partial class ConnectFour : Form {
        #region Handle Window Drag
        // I like to keep the windows simple, and have no border. But then the user can't drag the window. This piece of code fixes that issue.
        // More info can be found here: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/1592899

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool ReleaseCapture();

        public static void HandleWindowDrag(IntPtr handle) {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion

        #region Handle Double Buffering
        /// <summary>
        /// Override the Create Params property to allow double buffering
        /// <para>Simply setting the property to true in the designer only applies doublebuffering to the application, but not the child controls</para>
        /// <para>This also applies double buffering to the child controls</para>
        /// </summary>
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        /// <summary>
        /// The instance of the application
        /// </summary>
        public static ConnectFour instance { get; private set; }

        /// <summary>
        /// The text to display on the window
        /// </summary>
        private const string WINDOW_TEXT = "Connect Four";

        /// <summary>
        /// Whether the message should be cleared
        /// </summary>
        private bool clearMessage = true;

        /// <summary>
        /// Instantiates a new Connect Four game
        /// </summary>
        public ConnectFour() {
            instance = this;

            InitializeComponent();

            // The default control should be the main menu
            SetViewControl(MainMenu.instance);
        }

        /// <summary>
        /// Sets the view control to the specified control
        /// </summary>
        /// <param name="control">The control that should get the view now</param>
        public void SetViewControl(Control control) {
            if (control == null || viewPanel == null)
                return;

            viewPanel.Controls.Clear();
            viewPanel.Controls.Add(control);

            viewPanel.Invalidate();

            // If the message should be cleared, clear it
            if (clearMessage)
                smallMessageLabel.Text = "";
            else
                clearMessage = true;
        }

        /// <summary>
        /// Shows a message to the user, in the bottom-left corner.
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="color">The color to display the message in</param>
        public void ShowMessage(string message, Color color) {
            // If the message is already being displayed, that we can just leave
            if (smallMessageLabel.Text == message)
                return;

            smallMessageLabel.ForeColor = color;
            smallMessageLabel.Text = message;

            clearMessage = false;
        }

        /// <summary>
        /// Allows the user to draw the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bannerPanel_MouseDown(object sender, MouseEventArgs e) {
            // If the user is using the left mouse button, allow them to drag the form
            if (e.Button == MouseButtons.Left)
                HandleWindowDrag(Handle);
        }

        /// <summary>
        /// Draws the window text to the banner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bannerPanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            e.Graphics.DrawLine(Pens.White, 0, panel.Height - 1, panel.Width - 1, panel.Height - 1);

            SizeF textSize = e.Graphics.MeasureString(WINDOW_TEXT, panel.Font);

            PointF location = new PointF {
                X = 5,
                Y = (panel.Height - textSize.Height) / 2
            };

            if (location.Y < 0)
                location.Y = 0;

            e.Graphics.DrawString(WINDOW_TEXT, panel.Font, Brushes.White, location);
        }

        /// <summary>
        /// Allows the user to close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
