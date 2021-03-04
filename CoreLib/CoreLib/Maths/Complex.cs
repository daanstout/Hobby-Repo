using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Maths {
    /// <summary>A <see cref="Complex"/> number that has 1 real number and 1 imaginary number</summary>
    public struct Complex {
        /// <summary>A <see cref="Complex"/> that is equal to i (0 + 1i)</summary>
        public static Complex I => new Complex(0.0f, 1.0f);
        /// <summary>A <see cref="Complex"/> that is equal to i^2 (1 + 0i)</summary>
        public static Complex IPow2 => new Complex(-1.0f, 0.0f);
        /// <summary>A <see cref="Complex"/> that is equal to i^3 (0 - 1i)</summary>
        public static Complex IPow3 => new Complex(0.0f, -1.0f);
        /// <summary>A <see cref="Complex"/> that is equal to i^4 (-1 + 0i)</summary>
        public static Complex IPow4 => new Complex(1.0f, 0.0f);
        /// <summary>A <see cref="Complex"/> with a real and imaginary value of 0</summary>
        public static Complex Zero => new Complex(0.0f, 0.0f);

        /// <summary>The real portion of the <see cref="Complex"/></summary>
        public float r;
        /// <summary>The imaginary portion of the <see cref="Complex"/></summary>
        public float i;

        /// <summary>Returns a new <see cref="Complex"/> that is a normalized version of this <see cref="Complex"/></summary>
        public Complex Normalized {
            get {
                var length = MathF.Sqrt(r * r + i * i);
                return this / length;
            }
        }

        /// <summary>Returns a new <see cref="Complex"/> that has the same real value, but an inversed imaginary value</summary>
        public Complex Conjugate => new Complex(r, -i);

        /// <summary>Returns a new <see cref="Complex"/> that is the Reciprocal of this <see cref="Complex"/></summary>
        public Complex Reciprocal {
            get {
                var complex = new Complex(r, -i);
                var div = r * r + i * i;
                complex.r /= div;
                return complex;
            }
        }

        /// <summary>Instantiates a new <see cref="Complex"/></summary>
        /// <param name="r">The real part</param>
        /// <param name="i">The imaginary part</param>
        public Complex(float r, float i) {
            this.r = r;
            this.i = i;
        }

        /// <summary>Copies a <see cref="Complex"/> to a new <see cref="Complex"/></summary>
        /// <param name="c">The <see cref="Complex"/> to copy from</param>
        public Complex(Complex c) {
            r = c.r;
            i = c.i;
        }

        /// <summary>Adds to <see cref="Complex"/> values together</summary>
        /// <param name="a">The left hand <see cref="Complex"/></param>
        /// <param name="b">The right hand <see cref="Complex"/></param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator +(Complex a, Complex b) => new Complex(a.r + b.r, a.i + b.i);
        /// <summary>Negates a <see cref="Complex"/> value</summary>
        /// <param name="a">The <see cref="Complex"/> to negate</param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator -(Complex a) => new Complex(-a.r, -a.i);
        /// <summary>Subtracts a <see cref="Complex"/> from another <see cref="Complex"/></summary>
        /// <param name="a">The <see cref="Complex"/> to subtract from</param>
        /// <param name="b">The <see cref="Complex"/> to subtract</param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator -(Complex a, Complex b) => new Complex(a.r - b.r, a.i - b.i);
        /// <summary>Multiplies two <see cref="Complex"/> with eachother
        /// <para>Note: The resulting magnitude is equal to the magnitudes of the two <see cref="Complex"/> multiplied with eachother</para></summary>
        /// <param name="a">The left hand <see cref="Complex"/></param>
        /// <param name="b">The right hand <see cref="Complex"/></param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator *(Complex a, Complex b) => new Complex(a.r * b.r - a.i * b.i, a.r * b.i + a.i * b.r);
        /// <summary>Multiplies a <see cref="Complex"/> with a <see cref="float"/> value
        /// <para>This assumes the <see cref="float"/> is REAL, to multiply with an imaginary value, multiply: <see cref="float"/> * <see cref="Complex"/></para></summary>
        /// <param name="a">The left hand <see cref="Complex"/></param>
        /// <param name="b">The real <see cref="float"/> to multiply with</param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator *(Complex a, float b) => new Complex(a.r * b, a.i * b);
        /// <summary>Multiplies a <see cref="Complex"/> with an imaginary <see cref="float"/> value
        /// <para>This assumes the <see cref="float"/> is IMAGINARY, to multiply with a real value, multiply: <see cref="float"/> * <see cref="Complex"/></para></summary>
        /// <param name="b">The imaginary <see cref="float"/> to multiply with</param>
        /// <param name="a">The right hand <see cref="Complex"/></param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator *(float b, Complex a) => new Complex(-(a.i * b), a.r * b);
        /// <summary>Divides two <see cref="Complex"/> with eachother</summary>
        /// <param name="a">The left hand <see cref="Complex"/></param>
        /// <param name="b">The right hand <see cref="Complex"/></param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator /(Complex a, Complex b) {
            var div = b.r * b.r + b.i * b.i;
            var complex = new Complex {
                r = a.r * b.r + a.i * b.i,
                i = a.i * b.r - a.r * b.i
            };
            return complex / div;
        }
        /// <summary>Divides a <see cref="Complex"/> by a <see cref="float"/></summary>
        /// <param name="a">The <see cref="Complex"/> to divide</param>
        /// <param name="b">The <see cref="float"/> to divide by</param>
        /// <returns>The resulting <see cref="Complex"/></returns>
        public static Complex operator /(Complex a, float b) => new Complex(a.r / b, a.i / b);

        /// <summary>Explicitly converts from a <see cref="Complex"/> to a <see cref="Vector2"/></summary>
        /// <param name="a">The <see cref="Complex"/> to convert</param>
        public static explicit operator Vector2(Complex a) => new Vector2(a.r, a.i);
        /// <summary>Explicitly converts from a <see cref="Vector2"/> to a <see cref="Complex"/></summary>
        /// <param name="a">The <see cref="Vector2"/> to convert</param>
        public static explicit operator Complex(Vector2 a) => new Complex(a.x, a.y);

        /// <summary>Normalizes the <see cref="Complex"/> to a magnitude of 1</summary>
        public void Normalize() {
            var length = MathF.Sqrt(r * r + i * i);
            this /= length;
        }

        /// <summary>Gets the squared magnitude of this <see cref="Complex"/></summary>
        /// <returns>The squared magnitude</returns>
        public float Magnitude() => MathF.Sqrt(r * r + i * i);
        /// <summary>Gets the unsquared magnitude of this <see cref="Complex"/></summary>
        /// <returns>The unsquared magnitude</returns>
        public float MagnitudeSQ() => r * r + i * i;

        /// <summary>Creates a <see cref="string"/> representation of this <see cref="Complex"/></summary>
        /// <returns>This <see cref="Complex"/> as a <see cref="string"/></returns>
        public override string ToString() {
            if (r == 0 && i == 0)
                return "(0)";

            string res = "(";

            if (r != 0)
                res += r.ToString();

            if (r != 0 && i != 0)
                res += " + ";

            if (i != 0)
                res += i.ToString() + "i";

            return res + ")";
        }
    }
}
