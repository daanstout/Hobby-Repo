using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAncestor.Ancestors {
    public class Person {
        /// <summary>
        /// The index of the father in the previous gen
        /// </summary>
        public int father { get; set; } = -1;
        /// <summary>
        /// The index of the mother in the previous gen
        /// </summary>
        public int mother { get; set; } = -1;

        /// <summary>
        /// A dictionary where each index represents an index of a person in the initial generation and a corresponding bool representing if that person descents to this person
        /// </summary>
        public Dictionary<int, bool> descentsTo { get; private set; } = new Dictionary<int, bool>();

        /// <summary>
        /// Checks whether this person descents into all of the initial persons or to none at all
        /// </summary>
        public bool descentsToAllOrNone {
            get {
                bool all = descentsTo.Values.All(x => x);
                bool none = descentsTo.Values.All(x => !x);

                return all | none;
            }
        }

        /// <summary>
        /// Instantiates a Person
        /// </summary>
        /// <param name="initialPopulationSize">The initial population size, used for the dictionary</param>
        public Person(int initialPopulationSize) {
            for (int i = 0; i < initialPopulationSize; i++)
                descentsTo.Add(i, false);
        }
        
        /// <summary>
        /// Sets a descendant's value
        /// <para>Useful to set a person to itself in the initial generation</para>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDescendant(int key, bool value) => descentsTo[key] = value;

        /// <summary>
        /// Taking in a child, it sets all of its owns descendants equal to this child or what it already had
        /// </summary>
        /// <param name="child"></param>
        /// <param name="initialPopulationSize"></param>
        public void CheckDescendants(Person child, int initialPopulationSize) {
            for (int key = 0; key < initialPopulationSize; key++)
                descentsTo[key] |= child.descentsTo[key];
        }

        /// <summary>
        /// Checks whether this person descents to a Person
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DescentsTo(int key) => descentsTo[key];
    }
}
