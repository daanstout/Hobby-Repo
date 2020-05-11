using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Graphs;

namespace ConsoleTest {
    class Program {
        private static void Main(string[] args) {
            Graph graph = new Graph();

            graph.RegisterVertex("V1");
            graph.RegisterVertex("V2");

            graph.RegisterEdge("V1", "V2" , 2.5f);
            Console.WriteLine(graph.GetEdgeCost("V1", "V2"));

            graph.UpdateEdgeCost("V1", "V2", 3.5f);
            Console.WriteLine(graph.GetEdgeCost("V1", "V2"));

            Console.ReadKey();
        }
    }
}
