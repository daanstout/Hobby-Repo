using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    public struct Vector3f {
        #region Static Varriables
        public static Vector3f Up => new Vector3f(0.0f, 1.0f, 0.0f);
        public static Vector3f Down => new Vector3f(0.0f, -1.0f, 0.0f);
        public static Vector3f Left => new Vector3f(-1.0f, 0.0f, 0.0f);
        public static Vector3f Right => new Vector3f(1.0f, 0.0f, 0.0f);
        public static Vector3f Forward => new Vector3f(0.0f, 0.0f, 1.0f);
        public static Vector3f Backward => new Vector3f(0.0f, 0.0f, -1.0f);
        public static Vector3f Zero => new Vector3f(0.0f);
        public static Vector3f One => new Vector3f(1.0f);
        #endregion

        public float x;
        public float y;
        public float z;

        #region Constructors
        public Vector3f(float val) {
            x = y = z = val;
        }

        public Vector3f(float x, float y) {
            this.x = x;
            this.y = y;
            z = 0.0f;
        }

        public Vector3f(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3f(Vector2f origin) {
            x = origin.x;
            y = origin.y;
            z = 0.0f;
        }

        public Vector3f(Vector2f origin, float z) {
            x = origin.x;
            y = origin.y;
            this.z = z;
        }

        public Vector3f(Vector3f origin) {
            x = origin.x;
            y = origin.y;
            z = origin.z;
        }
        #endregion

        #region Operators
        public static Vector3f operator +(Vector3f a, Vector3f b) => new Vector3f(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3f operator +(Vector3f a, Vector2f b) => new Vector3f(a.x + b.x, a.y + b.y, a.z);
        public static Vector3f operator +(Vector2f a, Vector3f b) => new Vector3f(a.x + b.x, a.y + b.y, b.z);

        public static Vector3f operator -(Vector3f a, Vector3f b) => new Vector3f(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3f operator -(Vector3f a, Vector2f b) => new Vector3f(a.x - b.x, a.y - b.y, a.z);
        public static Vector3f operator -(Vector2f a, Vector3f b) => new Vector3f(a.x - b.x, a.y - b.y, b.z);
        public static Vector3f operator -(Vector3f v) => new Vector3f(-v.x, -v.y, -v.z);

        public static Vector3f operator *(Vector3f a, Vector3f b) => new Vector3f(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3f operator *(Vector3f a, float f) => new Vector3f(a.x * f, a.y * f, a.z * f);
        public static Vector3f operator *(float f, Vector3f a) => new Vector3f(a.x * f, a.y * f, a.z * f);
        public static Vector3f operator *(Vector3f a, int i) => new Vector3f(a.x * i, a.y * i, a.z * i);
        public static Vector3f operator *(int i, Vector3f a) => new Vector3f(a.x * i, a.y * i, a.z * i);

        public static Vector3f operator /(Vector3f a, Vector3f b) => new Vector3f(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vector3f operator /(Vector3f a, float f) => new Vector3f(a.x / f, a.y / f, a.z / f);
        public static Vector3f operator /(float f, Vector3f a) => new Vector3f(a.x / f, a.y / f, a.z / f);
        public static Vector3f operator /(Vector3f a, int i) => new Vector3f(a.x / i, a.y / i, a.z / i);
        public static Vector3f operator /(int i, Vector3f a) => new Vector3f(a.x / i, a.y / i, a.z / i);

        public static Vector3f operator %(Vector3f a, Vector3f b) => new Vector3f(a.x % b.x, a.y % b.y, a.z % b.z);
        public static Vector3f operator %(Vector3f a, int i) => new Vector3f(a.x % i, a.y % i, a.z % i);
        public static Vector3f operator %(Vector3f a, float f) => new Vector3f(a.x % f, a.y % f, a.z % f);

        public static bool operator ==(Vector3f a, Vector3f b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(Vector3f a, Vector3f b) => a.x != b.x || a.y != b.y || a.z != b.z;

        public static implicit operator Vector3f(Vector2f v) => new Vector3f(v);
        public static implicit operator Vector2f(Vector3f v) => new Vector2f(v);
        #endregion

        public void SetZero() => x = y = z = 0.0f;
        public readonly bool IsZero() => x == 0.0f && y == 0.0f && z == 0.0f;
        public readonly float Length() => (float)Math.Sqrt(x * x + y * y + z * z);
        public readonly float LengthSq() => x * x + y * y + z * z;
        public readonly float Dot(Vector3f other) => x * other.x + y * other.y + z * other.z;
        public Vector3f Reverse() => -this;
        public readonly float Distance(Vector3f other) {
            var dx = x - other.x;
            var dy = y - other.y;
            var dz = z - other.z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
        public readonly float DistanceSq(Vector3f other) {
            var dx = x - other.x;
            var dy = y - other.y;
            var dz = z - other.z;

            return dx * dx + dy * dy + dz * dz;
        }
        public readonly float Manhattan(Vector3f other) => Math.Abs(x - other.x) + Math.Abs(y - other.y) + Math.Abs(z + other.z);
        public void Normalize() {
            var length = Length();
            if (length == 0.0f)
                return;
            this /= length;
        }
        public Vector3f Normalized() {
            var length = Length();
            if (length == 0.0f)
                return Zero;
            return this / length;
        }
        public void Truncate(float max) {
            if (Length() <= max)
                return;
            
            Normalize();

            this *= max;
        }
        public void Reflect(Vector3f normal) {
            var res = new Vector3f(this);
            res += 2 * Dot(normal) * normal.Reverse();
            this = res;
        }
        public void Wrap(float maxX, float maxY, float maxZ) {
            if (x > maxX)
                x = 0;
            else if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            else if (y < 0)
                y = maxY;

            if (z > maxZ)
                z = 0;
            else if (z < 0)
                z = maxZ;
        }
        public readonly bool InsideRegion(Vector3f topLeft, Vector3f bottomRight) =>
            (x > topLeft.x && x < bottomRight.x) &&
            (y > topLeft.y && y < bottomRight.y) &&
            (z > topLeft.z && z < bottomRight.z);
        public readonly bool NotInsideRegion(Vector3f topLeft, Vector3f bottomRight) =>
            x < topLeft.x || x > bottomRight.x ||
            y < topLeft.y || y > bottomRight.y ||
            z < topLeft.z || z > bottomRight.z;
        public static bool IsSecondInFOVOfFirst(Vector3f posFirst, Vector3f forwardFirst, Vector3f posSecond, float fov) {
            var toTarget = posSecond - posFirst;
            toTarget.Normalize();
            forwardFirst.Normalize();

            return forwardFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }
        public static Vector3f Lerp(Vector3f start, Vector3f end, float delta) {
            Vector3f v;

            v.x = start.x * (1.0f - delta) + end.x * delta;
            v.y = start.y * (1.0f - delta) + end.y * delta;
            v.z = start.z * (1.0f - delta) + end.z * delta;

            return v;
        }
        public readonly override bool Equals(object obj) => obj is Vector3f v && Equals(v);
        public readonly bool Equals(Vector3f other) {
            return x == other.x && y == other.y && z == other.z;
        }
        public readonly override int GetHashCode() {
            int hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }
        public readonly override string ToString() => $"[{x}, {y}, {z}]";
        public readonly void Deconstruct(out float x, out float y, out float z) => (x, y, z) = (this.x, this.y, this.z);
    }
}
