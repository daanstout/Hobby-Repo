using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Maths {
    /// <summary>A 2-dimensional vector that has an x-component and a y-component</summary>
    public struct Vector2 : IEquatable<Vector2> {
        #region Variables
        #region Static Variables
        /// <summary>Returns a <see cref="Vector2"/> pointing to the right (1.0, 0.0)</summary>
        public static Vector2 Right => new Vector2(1.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector2"/> pointing to the left (-1.0, 0.0)</summary>
        public static Vector2 Left => new Vector2(-1.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector2"/> pointing up (0.0, 1.0)</summary>
        public static Vector2 Up => new Vector2(0.0f, 1.0f);
        /// <summary>Returns a <see cref="Vector2"/> pointing down (0.0, -1.0)</summary>
        public static Vector2 Down => new Vector2(0.0f, -1.0f);
        /// <summary>Returns a <see cref="Vector2"/> with all values 0 (0.0, 0.0)</summary>
        public static Vector2 Zero => new Vector2();
        /// <summary>Returns a <see cref="Vector2"/> with all values 1 (1.0, 1.0)</summary>
        public static Vector2 One => new Vector2(1.0f);
        #endregion
        #region Member Variables
        /// <summary>The x-component of this <see cref="Vector2"/></summary>
        public float x;
        /// <summary>The y-component of this <see cref="Vector2"/></summary>
        public float y;
        #endregion
        #region Properties
        /// <summary>Returns a copy of this <see cref="Vector2"/> with a length of 1</summary>
        public Vector2 Normalized => this / MathF.Sqrt(x * x + y * y);
        /// <summary>Returns a <see cref="Vector2"/> that is perpandicular to this <see cref="Vector2"/>, anti-clockwise</summary>
        public Vector2 Perp => new Vector2(-y, x);
        /// <summary>True if the <see cref="Vector2"/> is normalized<para>The accuracy of this calculation is to 6 significant digits</para></summary>
        public bool IsNormal => MathF.Abs((x * x + y * y) - 1.0f) < 1.0e-6;
        #endregion
        #endregion
        #region Constructors
        /// <summary>Instantiates a new <see cref="Vector2"/> with the given value for both the x and y fields</summary>
        /// <param name="val">The value to initialize all components to</param>
        public Vector2(float val) => x = y = val;
        /// <summary>Instantiates a new <see cref="Vector2"/> with the given x and y values</summary>
        /// <param name="x">The x-component of this <see cref="Vector2"/></param>
        /// <param name="y">The y-component of this <see cref="Vector2"/></param>
        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }
        /// <summary>Instantiates a new <see cref="Vector2"/> with the given x and y values</summary>
        /// <param name="vec">The <see cref="Vector2"/> to copy the values from</param>
        public Vector2(Vector2 vec) {
            x = vec.x;
            y = vec.y;
        }
        /// <summary>Instantiates a new <see cref="Vector2"/> based on a given <see cref="Vector3"/></summary>
        /// <param name="vec">The <see cref="Vector2"/> to copy from</param>
        public Vector2(Vector3 vec) {
            x = vec.x;
            y = vec.y;
        }
        #endregion
        #region Operators
        /// <summary>Adds two <see cref="Vector2"/>s together</summary>
        /// <param name="a">The left side <see cref="Vector2"/></param>
        /// <param name="b">The right side <see cref="Vector2"/></param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        /// <summary>Subtracts two <see cref="Vector2"/>s from another</summary>
        /// <param name="a">The left side <see cref="Vector2"/></param>
        /// <param name="b">The right side <see cref="Vector2"/></param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        /// <summary>Inverses this <see cref="Vector2"/></summary>
        /// <param name="a">The <see cref="Vector2"/> to inverse</param>
        /// <returns>The inversed <see cref="Vector2"/></returns>
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);
        /// <summary>Scales a <see cref="Vector2"/> by a value</summary>
        /// <param name="a">The left side <see cref="Vector2"/></param>
        /// <param name="scalar">The value to scale by</param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator *(Vector2 a, float scalar) => new Vector2(a.x * scalar, a.y * scalar);
        /// <summary>Scales a <see cref="Vector2"/> by a value</summary>
        /// <param name="scalar">The value to scale by</param>
        /// <param name="a">The right side <see cref="Vector2"/></param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator *(float scalar, Vector2 a) => new Vector2(a.x * scalar, a.y * scalar);
        /// <summary>Divides a <see cref="Vector2"/> by a value</summary>
        /// <param name="a">The left side <see cref="Vector2"/></param>
        /// <param name="scalar">The value to divide by</param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator /(Vector2 a, float scalar) => new Vector2(a.x / scalar, a.y / scalar);
        /// <summary>Creates a <see cref="Vector2"/> with num divided by the <see cref="Vector2"/></summary>
        /// <param name="num">The numerator of the division</param>
        /// <param name="a">The <see cref="Vector2"/> to divide by</param>
        /// <returns>The resulting <see cref="Vector2"/></returns>
        public static Vector2 operator /(float num, Vector2 a) => new Vector2(num / a.x, num / a.y);
        /// <summary>Checks to see if two <see cref="Vector2"/>s are equal</summary>
        /// <param name="a">The left hand <see cref="Vector2"/></param>
        /// <param name="b">The right hand <see cref="Vector2"/></param>
        /// <returns>True if the <see cref="Vector2"/> are equal, false if not</returns>
        public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
        /// <summary>Checks to see if two <see cref="Vector2"/>s are not equal</summary>
        /// <param name="a">The left hand <see cref="Vector2"/></param>
        /// <param name="b">The right hand <see cref="Vector2"/></param>
        /// <returns>True if the <see cref="Vector2"/> are not equal, flase if they are</returns>
        public static bool operator !=(Vector2 a, Vector2 b) => a.x != b.x || a.y != b.y;
        #endregion
        #region Conversions
        /// <summary>Converts from a <see cref="ValueTuple"/> to a <see cref="Vector2"/></summary>
        /// <param name="t">The tuple value</param>
        public static implicit operator Vector2(ValueTuple<float, float> t) => new Vector2(t.Item1, t.Item2);
        /// <summary>Converts from a <see cref="Vector2"/> to a <see cref="ValueTuple"/></summary>
        /// <param name="v">The <see cref="Vector2"/></param>
        public static implicit operator ValueTuple<float, float>(Vector2 v) => (v.x, v.y);
        /// <summary>Converts from a <see cref="Vector3"/> to a <see cref="Vector2"/></summary>
        /// <param name="vec">The <see cref="Vector2"/></param>
        public static implicit operator Vector2(Vector3 vec) => new Vector2(vec);
        #endregion
        #region Functions
        /// <summary>Sets the <see cref="x"/> and <see cref="y"/> values to 0.0f</summary>
        public void SetZero() => x = y = 0.0f;
        /// <summary>Checks whether the <see cref="x"/> and <see cref="y"/> values are 0.0f</summary>
        /// <returns>True if both values are 0.0f, false if one or more are not</returns>
        public bool IsZero() => x == 0.0f && y == 0.0f;
        /// <summary>Gets the length of the <see cref="Vector2"/></summary>
        /// <returns>The length of the <see cref="Vector2"/></returns>
        public float Length() => MathF.Sqrt(x * x + y * y);
        /// <summary>Returns the square of this <see cref="Vector2"/>'s length<para>This is faster than <see cref="Length"/> as this doesn't have to take the square root after</para></summary>
        /// <returns>The square of this <see cref="Vector2"/>'s length</returns>
        public float LengthSq() => x * x + y * y;
        /// <summary>Calculates the Dot of this <see cref="Vector2"/> and another <see cref="Vector2"/></summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>The Dot product of the <see cref="Vector2"/></returns>
        public float Dot(Vector2 other) => x * other.x + y * other.y;
        /// <summary>Calculates the Dot of this <see cref="Vector2"/> and another <see cref="Vector2"/>, but uses the normalized version of both <see cref="Vector2"/>s</summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>The Dot product of the <see cref="Vector2"/>s</returns>
        public float DotNormalized(Vector2 other) {
            other = other.Normalized;
            var self = Normalized;
            return self.x * other.x + self.y * other.y;
        }
        /// <summary>Normalizes this <see cref="Vector2"/> to have a length of 1</summary>
        public void Normalize() {
            var length = MathF.Sqrt(x * x + y * y);
            this /= length;
        }
        /// <summary>Calculates on which side the other <see cref="Vector2"/> is<para>1 means the other <see cref="Vector2"/> is clockwise from this <see cref="Vector2"/>, -1 means anti-clockwise</para></summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>1 if the other <see cref="Vector2"/> is clockwise from this <see cref="Vector2"/>, -1 if anti-clockwise</returns>
        public int Sign(Vector2 other) => y * other.x > x * other.y ? -1 : 1;
        /// <summary>Calculates the distance to the other <see cref="Vector2"/></summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>The distance between the two <see cref="Vector2"/></returns>
        public float Distance(Vector2 other) {
            var dx = other.x - x;
            var dy = other.y - y;

            return MathF.Sqrt(dx * dx + dy * dy);
        }
        /// <summary>Calculates the squared distance to the other <see cref="Vector2"/></summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>The squared distance between the two <see cref="Vector2"/></returns>
        public float DistanceSq(Vector2 other) {
            var dx = other.x - x;
            var dy = other.y - y;

            return dx * dx + dy * dy;
        }
        /// <summary>Calculates the manhattan distance to the other <see cref="Vector2"/></summary>
        /// <param name="other">The other <see cref="Vector2"/></param>
        /// <returns>The manhattan distance to the other <see cref="Vector2"/></returns>
        public float ManhattanDistance(Vector2 other) {
            var dx = other.x - x;
            var dy = other.y - y;

            return MathF.Abs(dx) + MathF.Abs(dy);
        }
        /// <summary>Truncates this <see cref="Vector2"/>'s length if it is longer than the max value</summary>
        /// <param name="max">The max value this <see cref="Vector2"/> can be</param>
        public void Truncate(float max) {
            if ((x * x + y * y) <= max * max)
                return;

            var length = MathF.Sqrt(x * x + y * y);
            var factor = max / length;
            this *= factor;
        }
        /// <summary>Reflects this <see cref="Vector2"/> based on a normal</summary>
        /// <param name="norm">The normal to reflect around</param>
        public void Reflect(Vector2 norm) {
            Vector2 res = new Vector2(this);
            res += 2 * Dot(norm) * -norm;
            this = res;
        }
        /// <summary>Wraps this <see cref="Vector2"/> around 0.0f and the max value</summary>
        /// <param name="maxX">The max value the <see cref="x"/> can be</param>
        /// <param name="maxY">The max value the <see cref="y"/> can be</param>
        public void Wrap(float maxX, float maxY) {
            if (x > maxX)
                x = 0.0f;
            else if (x < 0.0f)
                x = maxX;

            if (y > maxY)
                y = 0.0f;
            else if (y < 0.0f)
                y = maxY;
        }
        /// <summary>Wraps this <see cref="Vector2"/> around the min and max value</summary>
        /// <param name="minX">The min value the <see cref="x"/> can be</param>
        /// <param name="maxX">The max value the <see cref="x"/> can be</param>
        /// <param name="minY">The min value the <see cref="y"/> can be</param>
        /// <param name="maxY">The max value the <see cref="y"/> can be</param>
        public void Wrap(float minX, float maxX, float minY, float maxY) {
            if (x > maxX)
                x = minX;
            else if (x < minX)
                x = maxX;

            if (y > maxY)
                y = minY;
            else if (y < minY)
                y = maxY;
        }
        /// <summary>Checks whether this <see cref="Vector2"/> is within a region</summary>
        /// <param name="tl">The top-left corner of the region</param>
        /// <param name="br">The bottom-right corner of the region</param>
        /// <returns>True if this <see cref="Vector2"/> is within the region</returns>
        public bool InsideRegion(Vector2 tl, Vector2 br) => (x > tl.x) && (x < br.x) && (y > tl.y) && (y < br.y);
        /// <summary>Checks whether this <see cref="Vector2"/> is not within a region</summary>
        /// <param name="tl">The top-left corner of the region</param>
        /// <param name="br">The bottom-right corner of the region</param>
        /// <returns>True if this <see cref="Vector2"/> is within the region</returns>
        public bool NotInsideRegion(Vector2 tl, Vector2 br) => (x < tl.x) || (x > br.x) || (y < tl.y) || (y > br.y);
        /// <summary>Checks whether this <see cref="Vector2"/> is equal to another object</summary>
        /// <param name="obj">The object to check with</param>
        /// <returns>True if the objects are equal to eachother</returns>
        public override bool Equals(object obj) => obj is Vector2 vector && Equals(vector);
        /// <summary>Checks if this <see cref="Vector2"/> is equal to another vector</summary>
        /// <param name="other">The other vector to check with</param>
        /// <returns>True if the <see cref="Vector2"/> are equal to eachother</returns>
        public bool Equals(Vector2 other) => x == other.x && y == other.y;
        /// <summary>Gets the hashcode of this <see cref="Vector2"/></summary>
        /// <returns>the hashcode of this <see cref="Vector2"/></returns>
        public override int GetHashCode() => HashCode.Combine(x, y);
        #region Static Functions
        /// <summary>Checks whether a <see cref="Vector2"/> is within FOV of another <see cref="Vector2"/></summary>
        /// <param name="first">The position of the looking <see cref="Vector2"/></param>
        /// <param name="firstLookDir">The look direction of the first <see cref="Vector2"/> (this should be normalized)</param>
        /// <param name="second">The position of the target <see cref="Vector2"/></param>
        /// <param name="fov">The FOV of the first <see cref="Vector2"/></param>
        /// <returns>True if the first <see cref="Vector2"/> can see the second <see cref="Vector2"/></returns>
        public static bool IsSecondInFOVOfFirst(Vector2 first, Vector2 firstLookDir, Vector2 second, float fov) {
            var toTarget = (second - first).Normalized;
            return firstLookDir.Dot(toTarget) >= MathF.Cos(fov / 2);
        }
        /// <summary>Lerps between two values</summary>
        /// <param name="start">The start value</param>
        /// <param name="end">The end value</param>
        /// <param name="delta">How much to lerp with</param>
        /// <returns>A value between start and end</returns>
        public static Vector2 Lerp(Vector2 start, Vector2 end, float delta) {
            delta = Math.Clamp(delta, 0.0f, 1.0f);
            var v = new Vector2 {
                x = start.x * (1.0f - delta) + end.x * delta,
                y = start.y * (1.0f - delta) + end.y * delta
            };
            return v;
        }
        /// <summary>Lerps between two values, without clamping the delta between 0 and 1</summary>
        /// <param name="start">The start value</param>
        /// <param name="end">The end value</param>
        /// <param name="delta">How much to lerp with</param>
        /// <returns>A value between start and end</returns>
        public static Vector2 LerpUnclamped(Vector2 start, Vector2 end, float delta) {
            var v = new Vector2 {
                x = start.x * (1.0f - delta) + end.x * delta,
                y = start.y * (1.0f - delta) + end.y * delta
            };
            return v;
        }
        /// <summary>Creates a normalized <see cref="Vector2"/> based on two values</summary>
        /// <param name="x">The x-value of the <see cref="Vector2"/></param>
        /// <param name="y">The y-value of the <see cref="Vector2"/></param>
        /// <returns>A normalized <see cref="Vector2"/> based on the given x and y</returns>
        public static Vector2 CreateNormalized(float x, float y) {
            var length = MathF.Sqrt(x * x + y * y);
            return new Vector2(x / length, y / length);
        }
        #endregion
        #endregion
    }
}
