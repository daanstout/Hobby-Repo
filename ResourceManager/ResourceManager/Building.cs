using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResourceManager {
    public class Building {
        private static readonly Dictionary<string, Building> buildings = new Dictionary<string, Building>();

        public Building this[string identifier] {
            get => buildings.ContainsKey(identifier) ? buildings[identifier] : null;
            set {
                if (!buildings.ContainsKey(identifier))
                    buildings.Add(identifier, value);
            }
        }

        public int id;
        public string name;
        public string description;
        public List<Materials> materials;
        public Bitmap sprite;

        [JsonConstructor]
        private Building(int id, string name, string description, List<Materials> materials) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.materials = materials;
        }

        public override string ToString() {
            string returnString = string.Format("id: {0}\nname: {1}\ndescription: {2}", id, name, description);

            foreach (Materials mat in materials)
                returnString += $"\n{mat.ToString()}";

            return returnString;
        }
    }

    public struct Materials {
        public int id;
        public int amount;

        public Materials(int id, int amount) {
            this.id = id;
            this.amount = amount;
        }

        public override string ToString() => string.Format("id: {0}; amount: {1}", id, amount);
    }
}
