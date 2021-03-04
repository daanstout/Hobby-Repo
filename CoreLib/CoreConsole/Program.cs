using System;

using CoreLib.Maths;

namespace CoreConsole {
    class Program {
        static void Main(string[] args) {
            Complex c = new Complex(0, 1);

            Console.WriteLine(c.Normalized);

            Console.ReadKey();
        }
    }
}
