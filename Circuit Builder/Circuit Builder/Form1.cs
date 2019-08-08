using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Circuit_Builder.Gates;
using Circuit_Builder.Wires;
using DaanLib;

namespace Circuit_Builder {
    public partial class Form1 : Form {
        /// <summary>
        /// Overrides the CreateParams property to make everything double-buffered
        /// </summary>
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Form1() {
            InitializeComponent();

            Gate gate = new InvertGate();
            Wire wireOne = new Wire();
            Wire wireTwo = new Wire();
            Wire wireThree = new Wire();

            gate.AddInput(wireOne);
            //gate.AddInput(wireTwo);
            gate.AddOutput(wireThree);

            wireOne.Update(true);

            Console.WriteLine(wireThree.state);

            //wireTwo.Update(true);

            //Console.WriteLine(wireThree.state);

            //wireTwo.Update(false);

            //Console.WriteLine(wireThree.state);

            wireOne.Update(false);

            Console.WriteLine(wireThree.state);
        }

        /// <summary>
        /// Allows the user to drag the window
        /// </summary>
        /// <param name="sender">The sender of the Event</param>
        /// <param name="e">The MouseEventArgs of the Event</param>
        private void BannerPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                NativeMethods.HandleWindowDrag(Handle);
        }
    }
}
