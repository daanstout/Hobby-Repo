using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;
using DaanLib.StateMachine;

namespace TowerDefense.World.Tiles {
    /// <summary>
    /// The Tile System that keeps track of all the tiles
    /// </summary>
    public class TileSystem {
        /// <summary>
        /// The public instance
        /// </summary>
        public static TileSystem instance;

        /// <summary>
        /// The list of tiles
        /// </summary>
        private BaseTile[] tiles;

        /// <summary>
        /// The number of tiles in the system
        /// </summary>
        private int tileCount;
        /// <summary>
        /// The number of tiles per row
        /// </summary>
        private int tilesPerRow;

        /// <summary>
        /// The random number generator
        /// </summary>
        private static Random rand;

        /// <summary>
        /// Instantiates a new Tile System
        /// </summary>
        public TileSystem() {
            instance = this;
            rand = new Random();
        }

        /// <summary>
        /// Initiates the Tile System
        /// </summary>
        public void InitTileSystem() {
            // Calculate the number of tiles per row
            tilesPerRow = GameWorld.instance.gameWidth / BaseTile.TILE_WIDTH;
            // Calculate the number of tiles in total
            tileCount = tilesPerRow * (GameWorld.instance.gameHeight / BaseTile.TILE_HEIGHT);

            // Instantiate the tiles array
            tiles = new BaseTile[tileCount];

            // Set the current X and Y coordinates
            float curX = 0, curY = 0;
            // Go through every tile and create it
            for (int i = 0; i < tileCount; i++) {
                tiles[i] = new PlainsTile(new Vector2D(curX, curY), Color.Green, true);
                curX += BaseTile.TILE_WIDTH; // Update the current X coordinate

                if (curX >= GameWorld.instance.gameWidth) { // If the X coordinate gets larger than the game width, increase the Y coordinate and set the X coordinate to zero
                    curX = 0;
                    curY += BaseTile.TILE_HEIGHT;
                }
            }
        }

        /// <summary>
        /// Draws all the tiles
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderTiles(Graphics g) {
            foreach (BaseTile tile in tiles)
                tile.Render(g);
        }

        /// <summary>
        /// Gets a list of all the tiles
        /// </summary>
        /// <returns>The list of tiles</returns>
        public BaseTile[] GetTiles() => (BaseTile[])tiles.Clone();

        public List<BaseTile> GetNeighbours(BaseTile tile) {
            // Create the list
            List<BaseTile> neighbours = new List<BaseTile>();

            // Null check, just return the empty list
            if (tile == null)
                return neighbours;

            // Get the index based on the position
            int index = GetIndexFromPos(tile.position);

            // Make sure the index is within bounds
            if (index < 0 || index > tileCount)
                return neighbours;

            // If the index is not a multiple of the number of rows, that means there is a tile to the left
            if (index % tilesPerRow != 0)
                neighbours.Add(tiles[index - 1]);

            // If the index is larger than the number of tiles in a row, that means there is a tile above
            if (index >= tilesPerRow)
                neighbours.Add(tiles[index - tilesPerRow]);

            // If the index is not a multiple of the number of tiles per row + the num
            if (index % tilesPerRow != tilesPerRow - 1)
                neighbours.Add(tiles[index + 1]);

            if (index < tileCount - tilesPerRow)
                neighbours.Add(tiles[index + tilesPerRow]);

            return neighbours;
        }

        public int GetIndexFromPos(Vector2D position) => (int)(position.x / BaseTile.TILE_WIDTH) + (int)(position.y / BaseTile.TILE_HEIGHT * tilesPerRow);
    }
}
