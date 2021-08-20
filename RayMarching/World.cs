using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using RayMarching.Objects;

namespace RayMarching {
    public class World {
        private List<IWorldObject> marchables;
        private object syncRoot;

        public World() {
            marchables = new List<IWorldObject>();
            syncRoot = new object();
        }

        public void AddSphere(Vector3 position, float radius, Color color) {
            marchables.Add(new Sphere { Position = position, Radius = radius, Color = color });
        }

        public void AddObject(IWorldObject obj) {
            marchables.Add(obj);
        }

        public void Render(Bitmap target, Camera camera) {
            int width = target.Width;
            int height = target.Height;

            //Parallel.For(0, width, x => {
            //    Parallel.For(0, height, y => {
            //        var pos = camera.Position;
            //        pos.Z -= width / 2 - x;
            //        pos.Y -= height / 2 - y;

            //        var ray = new Ray {
            //            Position = pos,
            //            Direction = camera.Direction,
            //            Color = Color.Black,
            //        };

            //        ray.March(marchables, camera);

            //        lock (syncRoot) {
            //            target.SetPixel(x, y, ray.Color);
            //        }
            //    });
            //});

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    //if (x == 100 && y == 120)
                    //    Debugger.Break();

                    var pos = camera.Position;
                    pos.Z -= width / 2 - x;
                    pos.Y += height / 2 - y;

                    var ray = new Ray {
                        Position = pos,
                        Direction = camera.Direction,
                        Color = Color.Black,
                    };

                    ray.March(marchables, camera);
                    ray.SmoothColor();

                    var pixelColor = ray.Color;

                    target.SetPixel(x, y, pixelColor);
                }
            }
        }
    }
}
