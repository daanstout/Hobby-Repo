using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class Human : IComparable{
        private int baseStrength;
        private int baseIntelligence;
        private int baseConstitution;

        public int strength;
        public int intelligence;
        public int constitution;

        private Gene[] genes;

        public Human(int str, int inte, int con, int geneCount) {
            baseStrength = str;
            baseIntelligence = inte;
            baseConstitution = con;

            genes = new Gene[geneCount];

            for (int i = 0; i < geneCount; i++)
                genes[i] = new Gene();

            InitHuman();
        }

        private Human(int str, int inte, int con, Gene[] genes) {
            baseStrength = str;
            baseIntelligence = inte;
            baseConstitution = con;

            this.genes = genes;

            InitHuman();
        }

        private void InitHuman() {
            strength = baseStrength;
            intelligence = baseIntelligence;
            constitution = baseConstitution;

            foreach (Gene gene in genes)
                gene.Activate(this);
        }

        public int Fitness() {
            return strength + intelligence + constitution;
        }

        public Human CreateOffSpring(Human other, float mod) {
            int avgStr = (int)((strength + other.strength) * mod);
            int avgInt = (int)((intelligence + other.intelligence) * mod);
            int avgCon = (int)((constitution + other.constitution) * mod);

            Gene[] genes = new Gene[this.genes.Count()];

            Random rand = new Random(avgStr + avgInt + avgCon);

            for(int i = 0; i < genes.Count(); i++) {
                genes[i] = rand.Next() % 2 == 0 ? this.genes[i] : other.genes[i];

                if (rand.Next(0, 10) == 0)
                    genes[i] = new Gene();
            }

            return new Human(avgStr, avgInt, avgCon, genes);
        }

        public override string ToString() {
            return $"Str: {strength} - Int: {intelligence} - Con: {constitution}\t\t\tFitness:{Fitness()}";
        }

        public int CompareTo(object obj) {
            if (obj == null)
                return -1;
            else if (obj is Human h) {
                int own = Fitness();
                int other = h.Fitness();

                return other - own;
            } else
                return -1;
        }
    }
}
