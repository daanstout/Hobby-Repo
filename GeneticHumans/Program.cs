using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    class Program {
        static void Main(string[] args) {
            List<Human> humans = new List<Human>();

            for (int i = 0; i < 100; i++)
                humans.Add(new Human(10, 10, 10, 20));

            humans.Sort();

            foreach (Human human in humans)
                Console.WriteLine(human);

            Console.ReadKey();

            humans.RemoveRange(humans.Count / 2, humans.Count / 2);

            Random rand = new Random(humans[0].Fitness());

            while (humans.Count < 100)
                humans.Add(humans[rand.Next(0, humans.Count)].CreateOffSpring(humans[rand.Next(0, humans.Count)]));

            humans.Sort();

            foreach (Human human in humans)
                Console.WriteLine(human);

            Console.ReadKey();
        }
    }
}
