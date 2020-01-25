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
    public partial class SettingsControl : UserControl {
        private static readonly SettingsControl _instance = new SettingsControl();

        public static SettingsControl instanced {
            get {
                return _instance;
            }
        }

        private Button currentBoardSizeButton;
        private Button currentWinLengthButton;

        private SettingsControl() {
            InitializeComponent();

            SwitchButton(sizeNormalButton, ref currentBoardSizeButton);
            SwitchButton(normalWinLengthButton, ref currentWinLengthButton);
        }

        private void SwitchButton(Button newButton, ref Button ButtonSave) {
            if (ButtonSave != null)
                ButtonSave.Enabled = true;

            newButton.Enabled = false;
            ButtonSave = newButton;
        }

        private void backButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(MainMenu.instance);
        }

        private void sizeSmallButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            //currentBoardSizeButton = button;

            Settings.currentFieldSizeIndex = 0;
        }

        private void sizeNormalButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 1;
        }

        private void sizeLargeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 2;
        }

        private void sizeExtraLargeButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentBoardSizeButton);

            Settings.currentFieldSizeIndex = 3;
        }

        private void defaultBoardSizeLabel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Label label))
                return;

            e.Graphics.DrawLines(Pens.White, new Point[4] {
                new Point(0, 0),
                new Point(0, label.Height - 1),
                new Point(label.Width - 1, label.Height - 1),
                new Point(label.Width - 1, 0)
            });
        }

        private void smallWinLengthButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 3;
        }

        private void normalWinLengthButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 4;
        }

        private void largeWinLengthButton_Click(object sender, EventArgs e) {
            if (!(sender is Button button))
                return;

            SwitchButton(button, ref currentWinLengthButton);

            Settings.currentWinLength = 5;
        }
    }
}
