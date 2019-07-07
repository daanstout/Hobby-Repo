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
        public void CreateVerteces(BaseTile[] tiles, TileInfo info) {
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

        /// <summary>
        /// Links all verteces in the world with its neighbours
        /// </summary>
        /// <param name="tiles">The tiles that contain the verteces</param>
        private void LinkVerteces(BaseTile[] tiles) {
            // Do a null check to make sure there are tiles to link
            if (tiles == null || tiles.Length <= 0)
                return;

            foreach(BaseTile tile in tiles) {
                // Do a null check to make sure there is a tile
                if (tile == null)
                    continue;

                // Check if the tile is a registered key
                if (!ContainsKey(tile))
                    continue;

                // Get the neighbours of the tile
                List<BaseTile> neighbours = TileSystem.instance.GetNeighbours(tile);

                // Make sure the list isn't empty
                if (neighbours == null || neighbours.Count <= 0)
                    continue;

                // Link this node to every neighbour
                // The RegisterEdge() function will not link if the neighbour doesn't have a vertex, so we don't have to do that check
                foreach (BaseTile neighbour in neighbours)
                    RegisterEdge(tile, neighbour);
            }
        }
    }
}
