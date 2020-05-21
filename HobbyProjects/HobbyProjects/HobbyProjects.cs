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

namespace HobbyProjects {
    public partial class HobbyProjects : Form {
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

            mainMenu.CreateTab("Game of Life", new UserControl());
            mainMenu.CreateTab("Dot Product", new UserControl());
            mainMenu.CreateTab("Mazes", new UserControl());

            mainMenu.ChangeTab(0);
        }

        private void OnTabChange(object sender, TabChangedEventArgs<UserControl> e) {
            Console.WriteLine(e.tabName);
        }
    }
}
