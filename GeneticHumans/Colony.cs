using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class Colony {
        private List<Human> humans;
        private int population;
        private float _modifier = 0.25f;

        public float modifier { set => _modifier = value; get => _modifier; }

        public Colony() { }

        public void Populate(int str, int inte, int con, int geneCount, int population) {
            this.population = Math.Abs(population);

            humans = new List<Human>();

            for (int i = 0; i < population; i++)
                humans.Add(new Human(str, inte, con, geneCount));
        }

        public void Print() {
            humans.Sort();

            foreach (Human human in humans)
                Console.WriteLine(human);
        }

        public void NextGeneration() {
            if (humans.Count == 0)
                return;

            humans.RemoveRange(humans.Count / 2, humans.Count / 2);

            Random rand = new Random(humans[0].Fitness());

            while (humans.Count() < population)
                humans.Add(humans[rand.Next(0, humans.Count())].CreateOffSpring(humans[rand.Next(0, humans.Count())], _modifier));
        }
    }
}
