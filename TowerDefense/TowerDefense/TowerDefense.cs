using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DaanLib;

using TowerDefense.World;

namespace TowerDefense {
    public partial class TowerDefense : Form {
        public static TowerDefense instance;

        GameWorld world;

        public TowerDefense() {
            instance = this;

            InitializeComponent();

            world = new GameWorld(gamePanel.Width, gamePanel.Height);
        }

        public void RedrawBackground() => gamePanel.Invalidate();

        private void GamePanel_Paint(object sender, PaintEventArgs e) => world.RenderBackground(e.Graphics);

        private void BannerPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                WinFormHelper.HandleWindowDrag(Handle);
            }
        }
    }
}
