using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CirclePractice {
    public partial class Form1 : Form {
        Stopwatch sw = new Stopwatch();
        //Circle circle = new Circle(new Point(50, 50), 30.0f, 0.0f, 360f, 2.5f);
        List<Circle> circles = new List<Circle>();

        /// <summary>
        /// Override the Create Params property to allow double buffering
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

            circles = new List<Circle>() {
                new Circle(new Point(60, 50), 15.0f, 0.0f, 360f, 2.5f),
                new Circle(new Point(20, 90), 15.0f, 0.0f, 720f, 2.5f),
            };

            sw.Start();

            backgroundWorker1.RunWorkerAsync();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            // Draw the circles, then draw their blobs
            circles.ForEach(circle => circle.DrawCircle(e.Graphics));
            circles.ForEach(circle => circle.DrawBlob(e.Graphics));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            // THe old time, used to calculate the difference
            long oldTime = 0;
            // Loop till we stop
            while (true) {
                // Get the difference between the previous loop and this loop
                long dif = sw.ElapsedMilliseconds - oldTime;
                
                // If the difference is significant enough, we are going to update the circles
                if(dif > 0) {
                    // Get the elapsed time in milliseconds, then update each circle and invalidate the panel, so they are redrawn
                    float elapsed = dif / 1000f;
                    circles.ForEach(circle => circle.Update(elapsed));
                    panel1.Invalidate();
                }

                // Save the old time
                oldTime = sw.ElapsedMilliseconds;
            }
        }
    }
}
