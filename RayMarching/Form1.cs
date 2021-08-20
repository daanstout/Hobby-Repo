using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RayMarching.Objects;

namespace RayMarching {
    public partial class Form1 : Form {
        private readonly World world;
        private readonly Camera camera;
        private readonly Bitmap bitmap;

        public Form1() {
            InitializeComponent();

            world = new World();
            world.AddSphere(Vector3.Zero, 25.0f, Color.Red);
            //world.AddSphere(new Vector3(100.0f, 100.0f, 0.0f), 30, Color.Blue);
            //world.AddSphere(new Vector3(-50.0f, -50.0f, -50.0f), 15, Color.Green);
            //world.AddSphere(new Vector3(0.0f, 0.0f, 20.0f), 20.0f, Color.Yellow);
            world.AddObject(new Box {
                Position = new Vector3(0.0f, 50.0f, 50.0f),
                Size = new Vector3(20.0f, 10.0f, 10.0f),
                Color = Color.Green
            });
            camera = new Camera {
                Position = new Vector3(-100.0f, 0.0f, 0.0f),
                Direction = Vector3.UnitX,
                Near = 0.1f,
                Far = 1000.0f
            };
            bitmap = new Bitmap(200, 200);

            world.Render(bitmap, camera);
            view.BackgroundImage = bitmap;

            //frameTimer.Enabled = true;
        }

        private void frameTimer_Tick(object sender, EventArgs e) {
            world.Render(bitmap, camera);
            view.BackgroundImage = bitmap;

            //frameTimer.Enabled = false;
        }
    }
}
