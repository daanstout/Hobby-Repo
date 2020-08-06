using System;

using Microsoft.Xna.Framework;

namespace Roguelike.Utils {
    /// <summary>
    /// Describes a 2D floating-point rectangle
    /// </summary>
    public struct RectangleF : IEquatable<RectangleF>{
        private static RectangleF emptyRectangle = new RectangleF();

        /// <summary>
        /// The x coordinate of the top-left corner of this <see cref="RectangleF"/>
        /// </summary>
        public float x;
        /// <summary>
        /// The y coordinate of the top-left corner of this <see cref="RectangleF"/>
        /// </summary>
        public float y;
        /// <summary>
        /// The width of this <see cref="RectangleF"/>
        /// </summary>
        public float width;
        /// <summary>
        /// The height of this <see cref="RectangleF"/>
        /// </summary>
        public float height;

        /// <summary>
        /// Returns a <see cref="RectangleF"/> with X=0, Y=0, Width=0, Height=0
        /// </summary>
        public static RectangleF Empty => emptyRectangle;
        /// <summary>
        /// Returns the x coordinate of the left edge of this <see cref="RectangleF"/>
        /// </summary>
        public float Left => x;
        /// <summary>
        /// Returns the x coordinate of the right edge of this <see cref="RectangleF"/>
        /// </summary>
        public float Right => x + width;
        /// <summary>
        /// Returns the y coordinate of the top edge of this <see cref="RectangleF"/>
        /// </summary>
        public float Top => y;
        /// <summary>
        /// Returns the y coordinate of the bottom edge of this <see cref="RectangleF"/>
        /// </summary>
        public float Bottom => y + height;

        /// <summary>
        /// Whether or not this Rectangle has a <see cref="width"/> and <see cref="height"/> of 0, and a <see cref="Location"/> of (0, 0)
        /// </summary>
        public bool IsEmpty => width == 0 && height == 0 && x == 0 && y == 0;

        /// <summary>
        /// The top-left coordinates of this <see cref="RectangleF"/>
        /// </summary>
        public Vector2 Location {
            get => new Vector2(x, y);
            set {
                x = value.X;
                y = value.Y;
            }
        }

        /// <summary>
        /// The width-height coordinates of this <see cref="RectangleF"/>
        /// </summary>
        public Vector2 Size {
            get => new Vector2(width, height);
            set {
                width = value.X;
                height = value.Y;
            }
        }

        /// <summary>
        /// A <see cref="Vector2"/> located in the center of this <see cref="RectangleF"/>
        /// </summary>
        public Vector2 Center => new Vector2(x + (width / 2), y + (height / 2));

        internal string DebugDisplayString => string.Format("({0}, {1}) - ({2}, {3})", x, y, width, height);

        /// <summary>
        /// Creates a new instance of <see cref="RectangleF"/> struct, with the specified position, width, and height
        /// </summary>
        /// <param name="x">The x coordinate and the top-left corner of the created <see cref="RectangleF"/></param>
        /// <param name="y">The y coordinate and the top-left corner of the created <see cref="RectangleF"/></param>
        /// <param name="width">The width of the created <see cref="RectangleF"/></param>
        /// <param name="height">The height of the created <see cref="RectangleF"/></param>
        public RectangleF(float x, float y, float width, float height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a new insance of <see cref="RectangleF"/> struct, with the specified position and size
        /// </summary>
        /// <param name="location">The x and y coordinates of the top-left corner of the created <see cref="RectangleF"/></param>
        /// <param name="size">The width and height of the created <see cref="RectangleF"/></param>
        public RectangleF(Vector2 location, Vector2 size) {
            x = location.X;
            y = location.Y;
            width = size.X;
            height = size.Y;
        }

        /// <summary>
        /// Compares whether two <see cref="RectangleF"/> instances are equal
        /// </summary>
        /// <param name="a"><see cref="RectangleF"/> instance on the left of the equal sign</param>
        /// <param name="b"><see cref="RectangleF"/> instance on the right of the equal sign</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise</returns>
        public static bool operator ==(RectangleF a, RectangleF b) => a.x == b.x && a.y == b.y && a.width == b.width && a.height == b.height;
        /// <summary>
        /// Compares whether two <see cref="RectangleF"/> instances are not equal
        /// </summary>
        /// <param name="a"><see cref="RectangleF"/> instance on the left of the not equal sign</param>
        /// <param name="b"><see cref="RectangleF"/> instance on the right of the not equal sign</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise</returns>
        public static bool operator !=(RectangleF a, RectangleF b) => !(a == b);

        public bool Contains(int x, int y) => (this.x <= x) && (this.x + width >= x) && (this.y <= y) && (this.y + height >= y);

        public bool Contains(float x, float y) => (this.x <= x) && (this.x + width >= x) && (this.y <= y) && (this.y + height >= y);

        public bool Contains(Point value) => (x <= value.X) && (x + width >= value.X) && (y <= value.Y) && (y + height >= value.Y);

        public void Contains(ref Point value, out bool result) => result = (x <= value.X) && (x + width >= value.X) && (y <= value.Y) && (y + height >= value.Y);

        public bool Contains(Vector2 value) => (x <= value.X) && (x + width >= value.X) && (y <= value.Y) && (y + height >= value.Y);

        public void Contains(ref Vector2 value, out bool result) => result = (x <= value.X) && (x + width >= value.X) && (y <= value.Y) && (y + height >= value.Y);

        public bool Contains(Rectangle value) => (x <= value.X) && (value.X + value.Width <= x + width) && (y <= value.Y) && (value.Y + value.Height <= y + height);

        public void Contains(ref Rectangle value, out bool result) => result = (x <= value.X) && (value.X + value.Width <= x + width) && (y <= value.Y) && (value.Y + value.Height <= y + height);

        public bool Contains(RectangleF value) => (x <= value.x) && (value.x + value.width <= x + width) && (y <= value.y) && (value.y + value.height <= y + height);

        public void Contains(ref RectangleF value, out bool result) => result = (x <= value.x) && (value.x + value.width <= x + width) && (y <= value.y) && (value.y + value.height <= y + height);

        public override bool Equals(object obj) => (obj is RectangleF rect) && this == rect;

        public bool Equals(RectangleF other) => this == other;

        public override int GetHashCode() {
            unchecked {
                var hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                hash = hash * 23 + width.GetHashCode();
                hash = hash * 23 + height.GetHashCode();
                return hash;
            }
        }

        public void Inflate(float horizontalAmount, float verticalAmount) {
            x -= horizontalAmount;
            y -= verticalAmount;
            width += horizontalAmount * 2;
            height += verticalAmount * 2;
        }

        public bool Intersects(RectangleF value) => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

        public bool Intersects(Rectangle value) => value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

        public void Intersects(ref RectangleF value, out bool result) => result = value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

        public void Intersects(ref Rectangle value, out bool result) => result = value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

        public static RectangleF Intersect(RectangleF value1, RectangleF value2) {
            Intersect(ref value1, ref value2, out RectangleF result);
            return result;
        }

        public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result) {
            if (value1.Intersects(value2)) {
                var right = Math.Min(value1.x + value1.width, value2.x + value2.width);
                var left = Math.Max(value1.x, value2.x);
                var top = Math.Max(value1.x, value2.x);
                var bottom = Math.Min(value1.y + value1.height, value2.y + value2.height);
                result = new RectangleF(left, top, right - left, bottom - top);
            } else {
                result = new RectangleF(0, 0, 0, 0);
            }
        }

        public void Offset(int offsetX, int offsetY) {
            x += offsetX;
            y += offsetY;
        }

        public void Offset(float offsetX, float offsetY) {
            x += offsetX;
            y += offsetY;
        }

        public void Offset(Point amount) {
            x += amount.X;
            y += amount.Y;
        }

        public void Offset(Vector2 amount) {
            x += amount.X;
            y += amount.Y;
        }

        public override string ToString() => $"{{X:{x} Y:{y} Width:{width} Height:{height}}}";

        public static RectangleF Union(RectangleF value1, RectangleF value2) {
            var x = Math.Min(value1.x, value2.x);
            var y = Math.Min(value1.y, value2.y);
            return new RectangleF(x, y, Math.Max(value1.Right, value2.Right) - x, Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        public static void Union(ref RectangleF value1, ref RectangleF value2, out RectangleF result) {
            result = new RectangleF(0, 0, 0, 0) {
                x = Math.Min(value1.x, value2.x),
                y = Math.Min(value1.y, value2.y)
            };
            result.width = Math.Max(value1.Right, value2.Right) - result.x;
            result.height = Math.Max(value1.Bottom, value2.Bottom) - result.y;
        }

        public void Deconstruct(out float x, out float y, out float width, out float height) {
            x = this.x;
            y = this.y;
            width = this.width;
            height = this.height;
        }

        public static explicit operator Rectangle(RectangleF rect) => new Rectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        
        public static explicit operator RectangleF(Rectangle rect) => new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
    }
}
