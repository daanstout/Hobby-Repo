using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Drawing;

namespace RayMarching.Objects {
    public class Sphere : IWorldObject {
        public Vector3 Position { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }

        public float GetDistance(Vector3 position) => Vector3.Distance(Position, position) - Radius;

        public bool IsInside(Vector3 position) => GetDistance(position) < 0;
        public bool IsOn(Vector3 position) => Math.Abs(GetDistance(position)) < 1e-6f;

        public void Update(float deltaTime) {

        }
    }
}
