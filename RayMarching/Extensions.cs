using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RayMarching {
    public class Extensions {
        public static Vector3 AbsVec3(Vector3 vec) {
            vec.X = MathF.Abs(vec.X);
            vec.Y = MathF.Abs(vec.Y);
            vec.Z = MathF.Abs(vec.Z);

            return vec;
        }

        public static Vector3 MaxVec3(Vector3 vec, float max) {
            vec.X = MathF.Max(vec.X, max);
            vec.Y = MathF.Max(vec.Y, max);
            vec.Z = MathF.Max(vec.Z, max);

            return vec;
        }
    }
}
