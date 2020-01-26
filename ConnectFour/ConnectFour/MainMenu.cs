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
    /// A Main Menu for the user to select what they want to do
    /// </summary>
    public partial class MainMenu : UserControl {
        /// <summary>
        /// The instance of the Main Menu
        /// </summary>
        public static MainMenu instance { get; } = new MainMenu();

        /// <summary>
        /// Instantiates a new Main Menu
        /// </summary>
        protected MainMenu() {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to play a regular game of Connect Four, with the settings they put in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playRegularButton_Click(object sender, EventArgs e) {
            if (!(ConnectControl.instance.game is ClassicConnect))
                ConnectControl.instance.game = new ClassicConnect();

            ConnectFour.instance.SetViewControl(ConnectControl.instance);
        }

        /// <summary>
        /// Allows the user to play Connect Four with three players, instead of two
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectThreeButton_Click(object sender, EventArgs e) {
            if (!(ConnectControl.instance.game is ThreePlayerConnect))
                ConnectControl.instance.game = new ThreePlayerConnect();

            ConnectFour.instance.SetViewControl(ConnectControl.instance);
        }

        /// <summary>
        /// Allows the user to go to the settings panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(SettingsControl.instance);
        }
    }
}
