using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork {
    /// <summary>
    /// A Matrix to keep the neurons and weights in a handy value
    /// </summary>
    public class Matrix {
        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        public readonly int rows;
        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        public readonly int columns;

        /// <summary>
        /// The elements in the matrix
        /// </summary>
        private readonly float[,] elements;

        /// <summary>
        /// Gets or sets a certain row from the matrix
        /// </summary>
        /// <param name="row">The row to get or set</param>
        /// <returns>The row in the matrix</returns>
        public float[] this[int row] {
            get {
                if (row < 0 || row >= rows)
                    throw new IndexOutOfRangeException();

                float[] result = new float[columns];

                for (int column = 0; column < columns; column++)
                    result[column] = elements[row, column];

                return result;
            }
            set {
                if (row < 0 || row >= rows)
                    throw new IndexOutOfRangeException();

                for (int column = 0; column < columns; column++)
                    elements[row, column] = value[column];
            }
        }

        /// <summary>
        /// Gets or sets a certain element in the matrix
        /// </summary>
        /// <param name="row">The row the element is located at</param>
        /// <param name="column">The column the element is located in</param>
        /// <returns>The element at the specified position</returns>
        public float this[int row, int column] {
            get => elements[row, column];
            set => elements[row, column] = value;
        }

        /// <summary>
        /// Instantiates a new Matrix
        /// </summary>
        /// <param name="rows">The number of rows in the matrix</param>
        /// <param name="columns">The number of columns in the matrix</param>
        public Matrix(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;

            elements = new float[rows, columns];
        }

        /// <summary>
        /// Multiplies two matrices with eachother
        /// <para>The order of the two matrices are very important, and the result differs greatly</para>
        /// <para>Switching the order may even stop allowing two matrices to multiply, when they otherwhise would be able to</para>
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <returns>The result of the multiplication</returns>
        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.columns != b.rows)
                throw new ArgumentException();

            Matrix result = new Matrix(a.rows, b.columns);

            for (int row = 0; row < result.rows; row++) {
                for (int column = 0; column < result.columns; column++) {
                    float res = 0.0f;
                    for (int i = 0; i < a.columns; i++) {
                        res += (a[row, i] * b[i, column]);
                    }
                    result[row, column] = res;
                }
            }

            return result;
        }

        /// <summary>
        /// Explicitally converts an array of floats to a 1x(length of array) Matrix
        /// </summary>
        /// <param name="input">The array of floats to turn into a matrix</param>
        public static explicit operator Matrix(float[] input) {
            Matrix result = new Matrix(1, input.Length);
            result[0] = input;
            return result;
        }

        /// <summary>
        /// Explicitally converts the first row of a matrix to an array of floats
        /// <para>This does not convert the whole matrix to a 1-dimensional array, it is purely to get the first row of the matrix</para>
        /// </summary>
        /// <param name="input">The matrix to turn into an array of floats</param>
        public static explicit operator float[](Matrix input) => input[0];


        /// <summary>
        /// Converts the matrix to a string
        /// </summary>
        /// <returns>The string version of this array</returns>
        public override string ToString() {
            string result = "[";

            for (int row = 0; row < rows; row++) {
                result += "(";
                for (int column = 0; column < columns; column++) {
                    result += elements[row, column] + (column + 1 != columns ? ", " : "");
                }
                result += ")" + (row + 1 != rows ? "\n " : "");
            }

            return result + "]";
        }

        /// <summary>
        /// Checks to see if this matrix can validly multiply with the other matrix
        /// <para>Remember to call this function from the same matrix you put in front</para>
        /// <para>a.CanMultiply(b) == a * b, but a.CanMultiply(b) != b * a</para>
        /// </summary>
        /// <param name="other">The other matrix to multiply this with</param>
        /// <returns></returns>
        public bool CanMultiply(Matrix other) {
            return columns == other.rows;
        }

        /// <summary>
        /// Checks to see if this matrix can multiply with an array of floats
        /// </summary>
        /// <param name="other">The array of floats this matrix wants to multiply with</param>
        /// <returns>True if the matrix and array are compatible in size</returns>
        public bool CanMultiply(float[] other) {
            return other.Length == rows;
        }
    }
}
