using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Graphs;
using DaanLib.Maths;

namespace ConsoleTest {
    class Program {
        private static void Main(string[] args) {
            var matA = new Mat3();
            var matB = new Mat3();

            matA[0, 0] = 1;
            matA[0, 1] = 2;
            matA[0, 2] = 3;
            matA[1, 0] = 4;
            matA[1, 1] = 5;
            matA[1, 2] = 6;
            matA[2, 0] = 7;
            matA[2, 1] = 8;
            matA[2, 2] = 9;

            matB[0, 0] = 1;
            matB[0, 1] = 2;
            matB[0, 2] = 1;
            matB[1, 0] = 2;
            matB[1, 1] = 4;
            matB[1, 2] = 6;
            matB[2, 0] = 7;
            matB[2, 1] = 2;
            matB[2, 2] = 5;

            var res = matA * matB;

            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
