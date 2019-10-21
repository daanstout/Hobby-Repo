using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGathererMono.GameWorld {
    public static class Global {
        public static int randomSeed = 0;

        private static Random _randomGenerator;

        public static Random randomGenerator {
            get {
                if (randomSeed == 0)
                    randomSeed = DateTime.Now.GetHashCode();

                if (_randomGenerator == null)
                    _randomGenerator = new Random(randomSeed);

                return _randomGenerator;
            }
        }
    }
}
