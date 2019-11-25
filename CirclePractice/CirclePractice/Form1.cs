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

        List<Circle> horizontalList;

        List<Circle> verticalList;

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

            float baseSpeed = 90.0f;

            horizontalList = new List<Circle>();
            verticalList = new List<Circle>();

            for (int x = 0; x < 10; x++)
                horizontalList.Add(new Circle(new Point(60 + 50 * x, 50), 15.0f, 0.0f, baseSpeed * (1 + x), 2.5f));

            for (int y = 0; y < 10; y++)
                verticalList.Add(new Circle(new Point(20, 90 + 50 * y), 15.0f, 0.0f, baseSpeed * (1 + y), 2.5f));

            //horizontalList = new List<Circle>() {
            //    new Circle(new Point(60, 50), 15.0f, 0.0f, baseSpeed * 1, 2.5f),
            //    new Circle(new Point(110, 50), 15.0f, 0.0f, baseSpeed * 2, 2.5f),
            //    new Circle(new Point(160, 50), 15.0f, 0.0f, baseSpeed * 3, 2.5f),
            //    new Circle(new Point(210, 50), 15.0f, 0.0f, baseSpeed * 4, 2.5f),
            //    new Circle(new Point(260, 50), 15.0f, 0.0f, baseSpeed * 5, 2.5f),
            //    new Circle(new Point(310, 50), 15.0f, 0.0f, baseSpeed * 6, 2.5f)
            //};

            //verticalList = new List<Circle>() {
            //    new Circle(new Point(20, 90), 15.0f, 0.0f, baseSpeed * 1, 2.5f),
            //    new Circle(new Point(20, 140), 15.0f, 0.0f, baseSpeed * 2, 2.5f),
            //    new Circle(new Point(20, 190), 15.0f, 0.0f, baseSpeed * 3, 2.5f),
            //    new Circle(new Point(20, 240), 15.0f, 0.0f, baseSpeed * 4, 2.5f),
            //    new Circle(new Point(20, 290), 15.0f, 0.0f, baseSpeed * 5, 2.5f),
            //    new Circle(new Point(20, 340), 15.0f, 0.0f, baseSpeed * 6, 2.5f)
            //};

            sw.Start();

            backgroundWorker1.RunWorkerAsync();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            // Draw the circles, then draw their blobs

            horizontalList.ForEach(circle => circle.DrawCircle(e.Graphics));
            verticalList.ForEach(circle => circle.DrawCircle(e.Graphics));

            horizontalList.ForEach(circle => circle.DrawBlob(e.Graphics));
            verticalList.ForEach(circle => circle.DrawBlob(e.Graphics));

            Bitmap bitmap = (Bitmap)panel.BackgroundImage ?? new Bitmap(panel.Width, panel.Height);

            for (int x = 0; x < horizontalList.Count; x++) {
                for (int y = 0; y < verticalList.Count; y++) {
                    e.Graphics.DrawLine(Pens.Blue, horizontalList[x].centeredWorldBlobX, horizontalList[x].centeredWorldBlobY, horizontalList[x].centeredWorldBlobX, panel.Height);
                    e.Graphics.DrawLine(Pens.Blue, verticalList[y].centeredWorldBlobX, verticalList[y].centeredWorldBlobY, panel.Width, verticalList[y].centeredWorldBlobY);

                    bitmap.SetPixel((int)horizontalList[x].centeredWorldBlobX, (int)verticalList[y].centeredWorldBlobY, Color.Green);
                }
            }

            panel.BackgroundImage = bitmap;

            //circles.ForEach(circle => circle.DrawCircle(e.Graphics));
            //circles.ForEach(circle => circle.DrawBlob(e.Graphics));

            //e.Graphics.DrawLine(Pens.Blue, circles[0].centeredWorldBlobX, circles[0].centeredWorldBlobY, circles[0].centeredWorldBlobX, panel.Height);
            //e.Graphics.DrawLine(Pens.Blue, circles[1].centeredWorldBlobX, circles[1].centeredWorldBlobY, panel.Width, circles[1].centeredWorldBlobY);

            //Bitmap bitmap = (Bitmap)panel.BackgroundImage ?? new Bitmap(panel.Width, panel.Height);

            //bitmap.SetPixel((int)circles[0].centeredWorldBlobX, (int)circles[1].centeredWorldBlobY, Color.Green);

            //panel.BackgroundImage = bitmap;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            // THe old time, used to calculate the difference
            long oldTime = 0;
            // Loop till we stop
            while (true) {
                // Get the difference between the previous loop and this loop
                long dif = sw.ElapsedMilliseconds - oldTime;

                // If the difference is significant enough, we are going to update the circles
                if (dif > 0) {
                    // Get the elapsed time in milliseconds, then update each circle and invalidate the panel, so they are redrawn
                    float elapsed = dif / 1000f;
                    //circles.ForEach(circle => circle.Update(elapsed));
                    horizontalList.ForEach(circle => circle.Update(elapsed));
                    verticalList.ForEach(circle => circle.Update(elapsed));

                    panel1.Invalidate();
                }

                // Save the old time
                oldTime = sw.ElapsedMilliseconds;
            }
        }
    }
}
