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
    public partial class MainMenu : UserControl {
        private static readonly MainMenu _instance = new MainMenu();

        public static MainMenu instance {
            get {
                return _instance;
            }
        }

        protected MainMenu() {
            InitializeComponent();
        }

        private void playRegularButton_Click(object sender, EventArgs e) {
            if (ClassicConnectControl.instance.game is ThreePlayerConnect)
                ClassicConnectControl.instance.game = new ClassicConnect();

            ConnectFour.instance.SetViewControl(ClassicConnectControl.instance);
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(SettingsControl.instanced);
        }

        private void connectThreeButton_Click(object sender, EventArgs e) {
            if (!(ClassicConnectControl.instance.game is ThreePlayerConnect))
                ClassicConnectControl.instance.game = new ThreePlayerConnect();

            ConnectFour.instance.SetViewControl(ClassicConnectControl.instance);
        }
    }
}
