using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RayMarching {
    public class Camera {
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }

        public float Near { get; set; }
        public float Far { get; set; }

        public bool IsInView(Vector3 position) => Vector3.Dot(Direction, position - Position) >= 0;
        public bool IsInViewPlane(Vector3 position) => IsInView(position) && Vector3.Distance(Position, position) < Far;
    }
}
