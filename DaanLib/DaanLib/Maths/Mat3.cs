using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    public sealed class Mat3 {
        #region Static Variables
        public static Mat3 Identity {
            get {
                var mat = new Mat3();

                mat[0, 0] = 1.0f;
                mat[1, 1] = 1.0f;
                mat[2, 2] = 1.0f;

                return mat;
            }
        }
        #endregion

        private float[,] matrix;

        public float this[int row, int column] {
            get {
                if (column < 0 || column >= 3 || row < 0 || row >= 3)
                    throw new ArgumentOutOfRangeException();

                return matrix[row, column];
            }
            set {
                if (column < 0 || column >= 3 || row < 0 || row >= 3)
                    throw new ArgumentOutOfRangeException();

                matrix[row, column] = value;
            }
        }

        #region Constructors
        public Mat3() {
            matrix = new float[3, 3];
        }

        public Mat3(Vector2f v) {
            matrix = new float[3, 3];

            matrix[0, 0] = v.x;
            matrix[1, 0] = v.y;
            matrix[1, 1] = 1.0f;
            matrix[2, 2] = 1.0f;
        }

        public Mat3(Vector3f v) {
            matrix = new float[3, 3];

            matrix[0, 0] = v.x;
            matrix[1, 0] = v.y;
            matrix[2, 0] = v.z;
            matrix[1, 1] = 1.0f;
            matrix[2, 2] = 1.0f;
        }

        public Mat3(float a, float b, float c, float d, float e, float f) {
            matrix = new float[3, 3];

            matrix[0, 0] = a;
            matrix[0, 1] = b;
        }
        #endregion

        #region Operators
        public static Mat3 operator +(Mat3 a, Mat3 b) {
            var mat = new Mat3();

            mat.matrix[0, 0] = a.matrix[0, 0] + b.matrix[0, 0];
            mat.matrix[1, 0] = a.matrix[1, 0] + b.matrix[1, 0];
            mat.matrix[2, 0] = a.matrix[2, 0] + b.matrix[2, 0];

            mat.matrix[0, 1] = a.matrix[0, 1] + b.matrix[0, 1];
            mat.matrix[1, 1] = a.matrix[1, 1] + b.matrix[1, 1];
            mat.matrix[2, 1] = a.matrix[2, 1] + b.matrix[2, 1];

            mat.matrix[0, 2] = a.matrix[0, 2] + b.matrix[0, 2];
            mat.matrix[1, 2] = a.matrix[1, 2] + b.matrix[1, 2];
            mat.matrix[2, 2] = a.matrix[2, 2] + b.matrix[2, 2];

            return mat;
        }

        public static Mat3 operator -(Mat3 a, Mat3 b) {
            var mat = new Mat3();

            mat.matrix[0, 0] = a.matrix[0, 0] - b.matrix[0, 0];
            mat.matrix[1, 0] = a.matrix[1, 0] - b.matrix[1, 0];
            mat.matrix[2, 0] = a.matrix[2, 0] - b.matrix[2, 0];

            mat.matrix[0, 1] = a.matrix[0, 1] - b.matrix[0, 1];
            mat.matrix[1, 1] = a.matrix[1, 1] - b.matrix[1, 1];
            mat.matrix[2, 1] = a.matrix[2, 1] - b.matrix[2, 1];

            mat.matrix[0, 2] = a.matrix[0, 2] - b.matrix[0, 2];
            mat.matrix[1, 2] = a.matrix[1, 2] - b.matrix[1, 2];
            mat.matrix[2, 2] = a.matrix[2, 2] - b.matrix[2, 2];

            return mat;
        }

        public static Mat3 operator *(Mat3 a, float f) {
            var mat = new Mat3();

            mat.matrix[0, 0] = a.matrix[0, 0] * f;
            mat.matrix[1, 0] = a.matrix[1, 0] * f;
            mat.matrix[2, 0] = a.matrix[2, 0] * f;

            mat.matrix[0, 1] = a.matrix[0, 1] * f;
            mat.matrix[1, 1] = a.matrix[1, 1] * f;
            mat.matrix[2, 1] = a.matrix[2, 1] * f;

            mat.matrix[0, 2] = a.matrix[0, 2] * f;
            mat.matrix[1, 2] = a.matrix[1, 2] * f;
            mat.matrix[2, 2] = a.matrix[2, 2] * f;

            return mat;
        }

        public static Mat3 operator *(float f, Mat3 a) {
            var mat = new Mat3();

            mat.matrix[0, 0] = a.matrix[0, 0] * f;
            mat.matrix[1, 0] = a.matrix[1, 0] * f;
            mat.matrix[2, 0] = a.matrix[2, 0] * f;

            mat.matrix[0, 1] = a.matrix[0, 1] * f;
            mat.matrix[1, 1] = a.matrix[1, 1] * f;
            mat.matrix[2, 1] = a.matrix[2, 1] * f;

            mat.matrix[0, 2] = a.matrix[0, 2] * f;
            mat.matrix[1, 2] = a.matrix[1, 2] * f;
            mat.matrix[2, 2] = a.matrix[2, 2] * f;

            return mat;
        }

        public static Vector2f operator *(Mat3 a, Vector2f v) {
            Vector2f vec;

            vec.x = (a.matrix[0, 0] * v.x) + (a.matrix[0, 1] * v.y);
            vec.y = (a.matrix[1, 0] * v.x) + (a.matrix[1, 1] * v.y);

            return vec;
        }

        public static Vector3f operator *(Mat3 a, Vector3f v) {
            Vector3f vec;

            vec.x = (a.matrix[0, 0] * v.x) + (a.matrix[0, 1] * v.y) + (a.matrix[0, 2] * v.z);
            vec.y = (a.matrix[1, 0] * v.x) + (a.matrix[1, 1] * v.y) + (a.matrix[1, 2] * v.z);
            vec.z = (a.matrix[2, 0] * v.x) + (a.matrix[2, 1] * v.y) + (a.matrix[2, 2] * v.z);

            return vec;
        }

        public static Mat3 operator *(Mat3 a, Mat3 b) {
            var mat = new Mat3();

            mat.matrix[0, 0] = a.matrix[0, 0] * b.matrix[0, 0] + a.matrix[0, 1] * b.matrix[1, 0] + a.matrix[0, 2] * b.matrix[2, 0];
            mat.matrix[0, 1] = a.matrix[1, 0] * b.matrix[0, 0] + a.matrix[1, 1] * b.matrix[1, 0] + a.matrix[1, 2] * b.matrix[2, 0];
            mat.matrix[0, 2] = a.matrix[2, 0] * b.matrix[0, 0] + a.matrix[2, 1] * b.matrix[1, 0] + a.matrix[2, 2] * b.matrix[2, 0];

            mat.matrix[1, 0] = a.matrix[0, 0] * b.matrix[0, 1] + a.matrix[0, 1] * b.matrix[1, 1] + a.matrix[0, 2] * b.matrix[2, 1];
            mat.matrix[1, 1] = a.matrix[1, 0] * b.matrix[0, 1] + a.matrix[1, 1] * b.matrix[1, 1] + a.matrix[1, 2] * b.matrix[2, 1];
            mat.matrix[1, 2] = a.matrix[2, 0] * b.matrix[0, 1] + a.matrix[2, 1] * b.matrix[1, 1] + a.matrix[2, 2] * b.matrix[2, 1];

            mat.matrix[2, 0] = a.matrix[0, 0] * b.matrix[0, 2] + a.matrix[0, 1] * b.matrix[1, 2] + a.matrix[0, 2] * b.matrix[2, 2];
            mat.matrix[2, 1] = a.matrix[1, 0] * b.matrix[0, 2] + a.matrix[1, 1] * b.matrix[1, 2] + a.matrix[1, 2] * b.matrix[2, 2];
            mat.matrix[2, 2] = a.matrix[2, 0] * b.matrix[0, 2] + a.matrix[2, 1] * b.matrix[1, 2] + a.matrix[2, 2] * b.matrix[2, 2];

            return mat;
        }
        #endregion

        public void SetIdentity() {
            matrix = new float[3, 3];

            matrix[0, 0] = 1.0f;
            matrix[1, 1] = 1.0f;
            matrix[2, 2] = 1.0f;
        }

        public Vector2f TransformVector(Vector2f point) => this * point;
        public Vector3f TransformVector(Vector3f point) => this * point;
        public void Translate(Vector2f vec) {
            var mat = Identity;

            mat.matrix[2, 0] = vec.x;
            mat.matrix[2, 1] = vec.y;

            matrix = (this * mat).matrix;
        }

        public void Scale(Vector2f vec) {
            var mat = Identity;

            mat.matrix[0, 0] = vec.x;
            mat.matrix[1, 1] = vec.y;

            matrix = (this * mat).matrix;
        }

        public void Rotate(float rotation) {
            var mat = Identity;

            var sin = (float)Math.Sin(rotation);
            var cos = (float)Math.Cos(rotation);

            mat.matrix[0, 0] = cos;
            mat.matrix[0, 1] = sin;
            mat.matrix[1, 0] = -sin;
            mat.matrix[1, 1] = cos;

            matrix = (this * mat).matrix;
        }

        public void ScaleTranslate(Vector2f scale, Vector2f translation) {
            Scale(scale);
            Translate(translation);
        }

        public void ScaleRotate(Vector2f scale, float rotation) {
            Scale(scale);
            Rotate(rotation);
        }

        public void RotateTranslate(float rotation, Vector2f translation) {
            Rotate(rotation);
            Translate(translation);
        }

        public void ScaleRotateTranslate(Vector2f scale, float rotation, Vector2f translation) {
            Scale(scale);
            Rotate(rotation);
            Translate(translation);
        }

        public override string ToString() {
            var res = $"[[{matrix[0, 0]}, {matrix[1, 0]}, {matrix[2, 0]}]\n";
            res += $" [{matrix[0, 1]}, {matrix[1, 1]}, {matrix[2, 1]}]\n";
            res += $" [{matrix[0, 2]}, {matrix[1, 2]}, {matrix[2, 2]}]]";

            return res;
        }
    }
}
