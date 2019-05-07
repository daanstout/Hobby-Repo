using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonAncestor.Ancestors;
using DaanLib;

namespace CommonAncestor {
    public partial class CommonAncestor : Form {
        Tree civilization;

        public CommonAncestor() {
            InitializeComponent();

            civilization = new Tree(6);
        }

        private void Banner_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                WinFormHelper.HandleWindowDrag(Handle);
        }

        private void Banner_Paint(object sender, PaintEventArgs e) => e.Graphics.DrawRectangle(new Pen(Brushes.White), 0, 0, banner.Width - 1, banner.Height - 1);

        private void AncestorTreePanel_Paint(object sender, PaintEventArgs e) {
            if (civilization == null)
                return;

            civilization.Draw(e.Graphics, 40);
        }

        private void DrawButton_Click(object sender, EventArgs e) {
            ancestorTreePanel.Invalidate();
        }

        private void NextGenButton_Click(object sender, EventArgs e) {
            civilization.AddGeneration();

            ancestorTreePanel.Invalidate();
        }
    }
}
