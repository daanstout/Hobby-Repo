using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Graphs;
using TowerDefense.World.Tiles;

namespace TowerDefense.World {
    /// <summary>
    /// The graph that holds the verteces
    /// </summary>
    public class Graph : Graph<BaseTile>{
        /// <summary>
        /// The instance of the current graph
        /// </summary>
        public static Graph instance;

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        public Graph() : this(true) { }

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        /// <param name="hasUniqueVerteces">Whether the verteces are always unique (default = true)</param>
        public Graph(bool hasUniqueVerteces = true) : base(hasUniqueVerteces) => instance = this;

        /// <summary>
        /// Creates a new Vertex based on a tile
        /// </summary>
        /// <param name="tile"></param>
        public void CreateVertex(BaseTile tile) {
            if (!RegisterVertex(tile))
                Console.WriteLine(string.Format("Tile [{0}] already has a Vertex", tile.tileId));
        }

        /// <summary>
        /// Creates verteces for all the tiles
        /// </summary>
        /// <param name="tiles">The tiles to create verteces for</param>
        public void CreateVerteces(BaseTile[] tiles) {
            if (tiles == null || tiles.Length <= 0)
                return;

            foreach(BaseTile tile in tiles) {
                if (tile == null)
                    continue;

                if (!tile.isWalkable)
                    continue;

                CreateVertex(tile);
            }

            LinkVerteces(tiles);
        }

        private void LinkVerteces(BaseTile[] tiles) {
            if (tiles == null || tiles.Length <= 0)
                return;

            foreach(BaseTile tile in tiles) {
                if (tile == null)
                    continue;

                if (!ContainsKey(tile))
                    continue;

                List<BaseTile> neighbours = TileSystem.instance.GetNeighbours(tile);

                if (neighbours == null || neighbours.Count <= 0)
                    continue;

                foreach (BaseTile neighbour in neighbours)
                    RegisterEdge(tile, neighbour);
            }
        }
    }
}
