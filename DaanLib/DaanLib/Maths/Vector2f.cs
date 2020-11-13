using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    public struct Vector2f {
        public float x;
        public float y;

        public Vector2f(Vector3f v) {
            x = v.x;
            y = v.y;
        }
    }
}
