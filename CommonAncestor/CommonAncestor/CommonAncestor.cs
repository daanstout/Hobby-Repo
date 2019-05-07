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

/// <summary>
/// This is a project based on a recent video from Numberphile which aimed to prove that everyone was decended from royal blood.
/// In it, they showed a simple practice about when the first common ancestor would appear, and when everyone would be either an ancestor, or have no decendents left.
/// <para>https://www.youtube.com/watch?v=Fm0hOex4psA</para>
/// </summary>
namespace CommonAncestor {
    public partial class CommonAncestor : Form {
        const int distanceBetweenPersons = 40;

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

            civilization.Draw(e.Graphics, distanceBetweenPersons, (sender as Control).Height);
        }

        private void DrawButton_Click(object sender, EventArgs e) {
            ancestorTreePanel.Invalidate();
        }

        private void NextGenButton_Click(object sender, EventArgs e) {
            civilization.AddGeneration();

            ancestorTreePanel.Invalidate();
        }

        private void AncestorTreePanel_MouseClick(object sender, MouseEventArgs e) {
            civilization.SelectPerson(e.Location, distanceBetweenPersons, (sender as Control).Height);

            ancestorTreePanel.Invalidate();
        }
    }
}
