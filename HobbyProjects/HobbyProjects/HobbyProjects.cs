using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaanLib.Menu;

using HobbyProjects.Projects.GameOfLife;

namespace HobbyProjects {
    public partial class HobbyProjects : Form {
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        IMenu<UserControl> mainMenu;

        public HobbyProjects() {
            InitializeComponent();

            mainMenu = MenuBuilderFactory.Build<UserControl>(mainMenuPanel,
                MenuLayout.vertical,
                MenuLocation.left,
                appearance: MenuAppearance.GetDefaultAppearance()
                    .SetTabSize(new Size(150, 50))
                    .SetTabBackColor(Color.FromArgb(50, 50, 50))
                    .SetTabFont(Font)
                    .SetTabBorderColor(Color.White)
                    .SetTextColor(Color.White),
                eventFunction: OnTabChange);

            mainMenu.CreateTab("Game of Life", new GameOfLife());
            mainMenu.CreateTab("Dot Product", new UserControl());
            mainMenu.CreateTab("Mazes", new UserControl());

            mainMenu.ChangeTab(0);
        }

        private void OnTabChange(object sender, TabChangedEventArgs<UserControl> e) {
            mainViewPanel.Controls.Clear();

            mainViewPanel.Controls.Add(e.data);
        }
    }
}
