using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class Colony {
        private List<Human> humans = new List<Human>();
        private int population;

        public int generation;
        public float modifier { set; get; } = 0.25f;
        public bool debug { set; get; } = false;

        public Colony() { }

        public void Populate(int str, int inte, int con, int geneCount, int population) {
            this.population = Math.Abs(population);

            humans = new List<Human>();

            for (int i = 0; i < population; i++) {
                humans.Add(new Human(str, inte, con, geneCount));
            }

            if (debug)
                Console.WriteLine($"Created {population} humans with {geneCount} genes each.");

            generation = 1;
        }

        public void Print() {
            humans.Sort();

            Console.WriteLine($"Printing:\nGeneration: {generation}");

            for (int i = 0; i < humans.Count; i++)
                Console.WriteLine($"{i + 1}\t{humans[i]}");
        }

        public void Sort() => humans.Sort();

        public Human GetHuman(int index) => humans[index];

        public void NextGeneration(float mutationChance) {
            if (humans.Count == 0)
                return;

            generation++;

            if (debug)
                Console.WriteLine("Sorting population based on fitness");
            humans.Sort();

            if (debug)
                Console.WriteLine("Removing the lowest 50% of the population");

            int totalFitness = 0;
            foreach (Human h in humans)
                totalFitness += h.Fitness();

            Random rand = new Random(humans[0].Fitness());

            if (debug)
                Console.WriteLine("Saving the best of the population");
            //List<Human> temp = new List<Human>() {
            //    humans[0],
            //};
            List<Human> temp = new List<Human>();

            Human hum = humans[0];
            foreach (Human h in humans)
                if (hum.Fitness() < h.Fitness())
                    hum = h;

            temp.Add(hum);

            if (debug)
                Console.WriteLine("Creating new Humans");
            while (temp.Count() < population) {
                // The two humans that will create an offspring together
                Human one = Human.dummy;
                Human two = Human.dummy;

                // The fitness at which we choose the humans
                int select1 = rand.Next(0, totalFitness);
                int select2 = rand.Next(0, totalFitness);
                // Go through all the humans
                for (int i = 0; i < humans.Count; i++) {
                    // Lower the select value
                    select1 -= humans[i].Fitness();
                    select2 -= humans[i].Fitness();
                    // If it reaches 0, we found a sacrifice (i mean parent)
                    if (select1 <= 0) {
                        one = humans[i];
                        select1 = int.MaxValue;
                    }
                    if (select2 <= 0) {
                        two = humans[i];
                        select2 = int.MaxValue;
                    }
                }

                // Create an offspring together
                temp.Add(one.CreateOffSpring(two, modifier, debug, mutationChance));
            }

            humans = temp;
        }
    }
}
