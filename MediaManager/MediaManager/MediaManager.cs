using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaManager.ViewControls;

namespace MediaManager {
    public partial class MediaManager : Form {
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

        private const string windowSlug = "Media Manager";

        public const string moviesDir = @"G:\Movies\";

        public static MediaManager instance { get; private set; }

        public MediaManager() {
            InitializeComponent();

            instance = this;

            SetViewControl(MoviesUserControl.instance);
        }

        public bool SetViewControl(UserControl control) {
            if (control == null)
                return false;

            viewPanel.Controls.Clear();
            viewPanel.Controls.Add(control);

            control.Focus();

            return true;
        }

        private void bannerPanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            e.Graphics.DrawLine(Pens.White, 0.0f, panel.Height - 1, panel.Width - 1, panel.Height - 1);

            SizeF slugSize = e.Graphics.MeasureString(windowSlug, panel.Font);

            float margin = (panel.Height - slugSize.Height) / 2f;

            PointF slugLocation = new PointF() {
                X = margin,
                Y = margin,
            };

            e.Graphics.DrawString(windowSlug, panel.Font, Brushes.White, slugLocation);
        }

        private void bannerPanel_MouseDown(object sender, MouseEventArgs e) {
            if (!(sender is Panel))
                return;

            if (e.Button == MouseButtons.Left)
                HandleWindowDrag(Handle);
        }

        private void closeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button))
                return;

            Close();
        }
    }
}
