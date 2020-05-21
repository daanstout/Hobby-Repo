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

namespace TestWinForm {
    public partial class Form1 : Form {
        readonly IMenu<int> horizontalMenu;
        readonly IMenu<Color> verticalMenu;

        public Form1() {
            InitializeComponent();

            horizontalMenu = MenuBuilderFactory.Build<int>(horizontalMenuPanel, MenuLayout.horizontal, MenuLocation.top, eventFunction: OnTabChange);
            verticalMenu = MenuBuilderFactory.Build<Color>(verticalMenuPanel, eventFunction: OnTabChange, appearance: MenuAppearance.GetDefaultAppearance(new Size(50, 100)).SetTabBackColor(Color.Red).SetBorderWidth(3));

            for(int i = 0; i < 3; i++) {
                horizontalMenu.CreateTab(i.ToString(), i);
            }

            verticalMenu.CreateTab("Red", Color.Red);
            verticalMenu.CreateTab("White", Color.White);
            verticalMenu.CreateTab("Blue", Color.Blue);
        }

        private void OnTabChange(object sender, TabChangedEventArgs<int> e) {
            Console.WriteLine(e.data);
        }

        private void OnTabChange(object sender, TabChangedEventArgs<Color> e) {
            verticalMenu.appearance.tabBackColor = e.data;
        }
    }
}
