using System;

namespace NeuralNetwork {
    class Program {
        static void Main(string[] args) {
            //Matrix a = new Matrix(2, 3);
            //a[0] = new float[] { 2, 1, 4 };
            //a[1] = new float[] { 0, 1, 1 };

            //Matrix b = new Matrix(3, 4);
            //b[0] = new float[] { 6, 3, -1, 0 };
            //b[1] = new float[] { 1, 1, 0, 4 };
            //b[2] = new float[] { -2, 5, 0, 2 };

            //Matrix c = a * b;

            //Console.WriteLine(a);
            //Console.WriteLine();
            //Console.WriteLine(b);
            //Console.WriteLine();
            //Console.WriteLine(c);

            //NeuralNetwork network = new NeuralNetwork(3, new int[] { 3 }, 4, new float[] { 0.35f }, 0.60f);
            Matrix hiddenWeights = new Matrix(2, 2);
            // The weights in one row are TO a node, not FROM a previous node 
            hiddenWeights[0] = new float[] { 0.15f, 0.25f };
            hiddenWeights[1] = new float[] { 0.20f, 0.30f };

            Matrix outputWeights = new Matrix(2, 2);
            outputWeights[0] = new float[] { 0.40f, 0.50f };
            outputWeights[1] = new float[] { 0.45f, 0.55f };

            NeuralNetwork network = new NeuralNetwork(2, new int[] { 2 }, 2, 0.5f, new float[] { 0.35f }, 0.60f, new Matrix[] { hiddenWeights }, outputWeights);

            Matrix result = network.Calculate(new float[] { 0.05f, 0.10f});

            Console.WriteLine(result);

            float error = network.GetTotalError(new float[] { 0.01f, 0.99f });

            Console.WriteLine(error);

            network.BackPropogation(new float[] { 0.01f, 0.99f });
        }

        static void MatrixTest() {
            Random random = new Random();

            Matrix a = new Matrix(3, 3);
            FillRandom(ref a, ref random);

            Matrix b = new Matrix(3, 3);
            FillRandom(ref b, ref random);


            Matrix ab = a * b;
            Matrix ba = b * a;

            Console.WriteLine(ab);
            Console.WriteLine();
            Console.WriteLine(ba);
        }

        private static void FillRandom(ref Matrix mat, ref Random random) {
            for (int row = 0; row < mat.rows; row++)
                for (int column = 0; column < mat.columns; column++)
                    mat[row, column] = random.Next(0, 100);
        }
    }
}
