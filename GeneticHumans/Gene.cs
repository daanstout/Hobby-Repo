using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticHumans {
    public class Gene {
        private Effect effect;

        public Gene() {
            effect = Effect.GetRandomEffect();
        }

        public Gene(Effect effect) {
            this.effect = effect;
        }

        public void Activate(Human human) => effect.Activate(human);
    }
}
