using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Graphs;

namespace ResourceGathererMono.GameWorld {
    public class Graph : Graph<BaseTile>{
        public static Graph instance;

        private Graph(bool hasUniqueVerteces = true) : base(hasUniqueVerteces) { }

        public static void CreateGraph(bool hasUniqueVerteces) => instance = new Graph(hasUniqueVerteces);


        public bool CreateVertex(BaseTile tile) {
            bool result = RegisterVertex(tile);

            if (!result)
                Console.WriteLine(string.Format("Tile {0} already has a vertex", tile.position));

            return result;
        }

        public bool CreateVerteces(BaseTile[] tiles) {
            if (tiles == null || tiles.Length <= 0)
                return false;

            bool result = true;

            foreach (BaseTile tile in tiles) {
                if (tile == null) {
                    result = false;
                    continue;
                }

                result &= CreateVertex(tile);
            }

            return result;
        }

        public void LinkVerteces(BaseTile[] tiles) {
            if (tiles == null || tiles.Length <= 0)
                return;

            foreach(BaseTile tile in tiles) {
                if (tile == null)
                    continue;

                if (!ContainsKey(tile))
                    continue;

                
            }
        }
    }
}
