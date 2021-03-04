using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    public class Quaternion {
        public static Quaternion Identity => new Quaternion();

        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion() {
            x = y = z = 0.0f;
            w = 1.0f;
        }

        public Quaternion(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}
