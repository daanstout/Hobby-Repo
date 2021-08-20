using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RayMarching.Objects {
    public class Box : IWorldObject {
        public Vector3 Position { get; set; }
        public Vector3 Size { get; set; }
        public Color Color { get; set; }
        
        public float GetDistance(Vector3 position) {
            var q = Extensions.AbsVec3(position - Position) - Size;
            var tmp = Extensions.MaxVec3(q, 0);
            return tmp.Length() + MathF.Min(MathF.Max(q.X, MathF.Max(q.Y, q.Z)), 0.0f);
        }

        public bool IsInside(Vector3 position) => GetDistance(position) < 0;
        public bool IsOn(Vector3 position) => Math.Abs(GetDistance(position)) < 1e-6f;

        public void Update(float deltaTime) {

        }
    }
}
