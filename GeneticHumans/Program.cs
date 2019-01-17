using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    class Program {
        public static IParser parser = new BaseParser();

        static void Main(string[] args) {
            World world = new World();
            Colony colony = new Colony();

            Console.WindowWidth = (int)(Console.LargestWindowWidth * 0.95);

            Console.WriteLine("Starting simulation");

            while (true) {
                Console.WriteLine("\nEnter a command");

                string line = Console.ReadLine();

                parser.Parse(line, world);
            }
        }
    }
}
