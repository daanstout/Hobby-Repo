using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class World {
        public Colony civA;
        public Colony civB;

        private int population;

        public float modifier {
            get => civA.modifier;
            set => civA.modifier = civB.modifier = value;
        }

        public bool debug {
            get => civA.debug;
            set => civA.debug = civB.debug = value;
        }

        public float mutationChance { get; set; } = 0.05f;

        public World() {
            civA = new Colony();
            civB = new Colony();
        }

        public void NextGeneration() {
            civA.NextGeneration(mutationChance);
            civB.NextGeneration(mutationChance);
        }

        public void Populate(int str, int inte, int con, int geneCount, int pop) {
            population = pop;

            civA.Populate(str, inte, con, geneCount, pop);
            civB.Populate(str, inte, con, geneCount, pop);
        }

        public void Print() {
            Console.WriteLine("Civilization one:");
            civA.Print();

            Console.WriteLine("\nCivilization two:");
            civB.Print();
        }

        public void Sort() {
            if (population == 0)
                return;
            civA.Sort();
            civB.Sort();
        }

        public void PrintCompare() {
            Console.WriteLine($"Generation: {civA.generation}");
            Console.WriteLine("Civilizations:");
            Console.WriteLine($"\tCivilization One:\t\t\t\t\tCivilization Two:");

            for(int i = 0; i < population; i++) {
                Console.WriteLine($"{i + 1}\t{civA.GetHuman(i)}\t{civB.GetHuman(i)}");
            }
        }
    }
}
