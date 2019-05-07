using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAncestor.Ancestors {
    public struct Person {
        public int father { get; set; }
        public int mother { get; set; }

        public Person(int father = -1, int mother = -1) {
            this.father = father;
            this.mother = mother;
        }
    }
}
