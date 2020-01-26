using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour {
    /// <summary>
    /// The control to select the current settings
    /// </summary>
    public partial class SettingsControl : UserControl {
        /// <summary>
        /// The instance of this control
        /// </summary>
        public static SettingsControl instance { get; } = new SettingsControl();

        /// <summary>
        /// The button for the currently selected board size
        /// </summary>
        private Button currentBoardSizeButton;
        /// <summary>
        /// The button for the currently selected win length
        /// </summary>
        private Button currentWinLengthButton;

        /// <summary>
        /// Instantiates a new Settings Control
        /// </summary>
        private SettingsControl() {
            InitializeComponent();

            // Set everything to the default values
            defaultButton_Click(defaultButton, null);
        }

        /// <summary>
        /// Saves the newly pressed button as the current button, and handles the switching
        /// </summary>
        /// <param name="newButton">The newly pressed button</param>
        /// <param name="buttonSave">The button it needs to be switched with</param>
        private void SwitchButton(Button newButton, ref Button buttonSave) {
            if (newButton == buttonSave)
                return;

            if (buttonSave != null)
                buttonSave.Font = new Font(buttonSave.Font, FontStyle.Regular);

            newButton.Font = new Font(newButton.Font, FontStyle.Underline | FontStyle.Bold);
            buttonSave = newButton;
        }

        /// <summary>
        /// Allows the user to go back to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(MainMenu.instance);
        }

        /// <summary>
        /// Allows the user to select a small board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeSmallButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            //currentBoardSizeButton = button;

            Settings.currentFieldSizeIndex = 0;
        }

        /// <summary>
        /// Allows the user to select a normal board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeNormalButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 1;
        }

        /// <summary>
        /// Allows the user to select a large board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeLargeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 2;
        }

        /// <summary>
        /// Allows the user to select an extra large board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeExtraLargeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 3;
        }

        /// <summary>
        /// Paints a small outline around the label, to better show what button it is connected to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultLabel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Label label))
                return;

            e.Graphics.DrawLines(Pens.White, new Point[4] {
                new Point(0, 0),
                new Point(0, label.Height - 1),
                new Point(label.Width - 1, label.Height - 1),
                new Point(label.Width - 1, 0)
            });
        }

        /// <summary>
        /// Allows the user to select a small win length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winLengthSmallButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 3;
        }
        
        /// <summary>
        /// Allows the user to select a normal win length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winLengthNormalButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 4;
        }

        /// <summary>
        /// Allows the user to select a large win length
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void winLengthLargeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 5;
        }

        /// <summary>
        /// Allows the user to quickly go to default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultButton_Click(object sender, EventArgs e) {
            if (!(sender is Button))
                return;

            winLengthNormalButton_Click(winLengthNormalButton, null);
            sizeNormalButton_Click(sizeNormalButton, null);
        }
    }
}
