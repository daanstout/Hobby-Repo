using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public static class Fight {
        public enum result {
            first,
            second,
            tie
        }

        public static Func<Human, Human, result> fightingMethod { private get; set; }

        public static result StrengthToStrength(Human a, Human b) => a.strength > b.strength ? result.first : a.strength == b.strength ? result.tie : result.second;

        public static void War(Colony a, Colony b) {
            int minPop = Math.Min(a.population, b.population);

            for (int i = 0; i < minPop; i++) {
                if (fightingMethod(a.GetHuman(i), b.GetHuman(i)) == result.first) {

                }
            }
        }
    }
}
