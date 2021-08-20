using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Text;

using RayMarching.Objects;

namespace RayMarching {
    public class Ray {
        private const int MAX_ITERATIONS = 50;
        private const int BORDER_MAX_STEP_RATE = 70;

        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        public Color Color { get; set; }
        public int Steps { get; private set; }

        private bool march = true;

        public void March(List<IWorldObject> marchables, Camera camera) {
            while (camera.IsInViewPlane(Position) && march) {
                var smallestDistance = float.MaxValue;

                foreach (var marchable in marchables) {
                    var distance = marchable.GetDistance(Position);

                    if (distance < smallestDistance)
                        smallestDistance = distance;
                    else
                        continue;

                    if (Math.Abs(smallestDistance) < 1e-3f) {
                        Color = marchable.Color;
                        march = false;
                    }
                }

                Position += Direction * smallestDistance;
                Steps++;

                if (Steps > MAX_ITERATIONS)
                    march = false;
            }
        }

        public void SmoothColor() {
            if ((Steps * 100) / MAX_ITERATIONS > BORDER_MAX_STEP_RATE)
                Color = Color.Gray;
            else
                Color = LerpColor(Color, Color.Black, Steps / 15f);
        }

        private Color LerpColor(Color start, Color end, float delta) {
            //if (start.R > 10)
            //    Debugger.Break();



            if (delta < 0.0f)
                delta = 0.0f;
            else if (delta > 1.0f)
                delta = 1.0f;

            int r = (int)(start.R * (1 - delta) + end.R * delta);
            int g = (int)(start.G * (1 - delta) + end.G * delta);
            int b = (int)(start.B * (1 - delta) + end.B * delta);

            return Color.FromArgb(r, g, b);

            //if (delta > 0.75f)
            //    return Color.Blue;
            //if (delta > 0.5f)
            //    return Color.Green;
            //if (delta > 0.25f)
            //    return Color.Yellow;
            //return start;
        }
    }
}
