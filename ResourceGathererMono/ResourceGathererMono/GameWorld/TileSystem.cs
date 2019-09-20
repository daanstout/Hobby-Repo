using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ResourceGathererMono.GameWorld {
    /// <summary>
    /// The Tile System of the game
    /// <para>This class is a Singleton</para>
    /// </summary>
    public class TileSystem {
        #region Instantiating
        /// <summary>
        /// The instance of the TileSystem, Only one can exist at a time
        /// </summary>
        public static TileSystem instance;

        /// <summary>
        /// Instantiates a new TileSystem
        /// </summary>
        private TileSystem(int numTiles, int numRows) {
            instance = this;

            tileCount = numTiles;
            tilesPerRow = numRows;

            GenerateTiles();
        }

        /// <summary>
        /// Creates a new TileSystem
        /// </summary>
        public static void Create(int numTiles, int numRows) => instance = new TileSystem(numTiles, numRows);
        #endregion

        //private BaseTile[] tiles;
        private Dictionary<Vector2, BaseTile> tiles;

        private int tileCount;
        private int tilesPerRow;

        private static Random rand = new Random();

        private void GenerateTiles() {
            tiles = new Dictionary<Vector2, BaseTile>();

            float curX = 0, curY = 0;


            for (int i = 0; i < tileCount; i++) {
                BaseTile tile = new BaseTile(new Vector2(curX + 0, curY + 0), Color.White);
                tile.isPlains = true;
                tiles.Add(tile.position, tile);

                curX += BaseTile.TILE_WIDTH;

                if (curX >= World.instance.gameWidth) {
                    curX = 0;
                    curY += BaseTile.TILE_HEIGHT;
                }
            }
        }

        public void RenderTiles(SpriteBatch spriteBatch) {
            foreach (BaseTile tile in tiles.Values)
                BaseTile.renderer.RenderTile(tile, spriteBatch);
        }

        public BaseTile[] GetNeighboursAll(BaseTile tile) {
            List<BaseTile> neighbours = new List<BaseTile>();

            if (tile == null)
                return neighbours.ToArray();

            if (!tiles.ContainsKey(tile.position))
                return neighbours.ToArray();

            // Check North-West
            if (tiles.ContainsKey(tile.position + new Vector2(-BaseTile.TILE_WIDTH, -BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(-BaseTile.TILE_WIDTH, -BaseTile.TILE_HEIGHT)]);

            // Check North
            if (tiles.ContainsKey(tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)]);

            // Check North-East
            if (tiles.ContainsKey(tile.position + new Vector2(BaseTile.TILE_WIDTH, -BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(BaseTile.TILE_WIDTH, -BaseTile.TILE_HEIGHT)]);

            // Check West
            if (tiles.ContainsKey(tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)]);

            // Check East
            if (tiles.ContainsKey(tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)]);

            // Check South-West
            if (tiles.ContainsKey(tile.position + new Vector2(-BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(-BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT)]);

            // Check South
            if (tiles.ContainsKey(tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)]);

            // Check South-East
            if (tiles.ContainsKey(tile.position + new Vector2(BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT)]);

            return neighbours.ToArray();
        }

        public BaseTile[] GetNeighboursCardinal(BaseTile tile) {
            List<BaseTile> neighbours = new List<BaseTile>();

            if (tile == null)
                return neighbours.ToArray();

            if (!tiles.ContainsKey(tile.position))
                return neighbours.ToArray();

            // Check North
            if (tiles.ContainsKey(tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)]);

            // Check West
            if (tiles.ContainsKey(tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)]);

            // Check East
            if (tiles.ContainsKey(tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)]);

            // Check South
            if (tiles.ContainsKey(tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)]);

            return neighbours.ToArray();
        }

        public BaseTile[] GetNeighboursCardinal(Vector2 position) {
            List<BaseTile> neighbours = new List<BaseTile>();

            BaseTile tile = GetTileFromPos(position);

            if (tile == null)
                return neighbours.ToArray();

            if (!tiles.ContainsKey(tile.position))
                return neighbours.ToArray();

            // Check North
            if (tiles.ContainsKey(tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, -BaseTile.TILE_HEIGHT)]);

            // Check West
            if (tiles.ContainsKey(tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(-BaseTile.TILE_WIDTH, 0)]);

            // Check East
            if (tiles.ContainsKey(tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)))
                neighbours.Add(tiles[tile.position + new Vector2(BaseTile.TILE_WIDTH, 0)]);

            // Check South
            if (tiles.ContainsKey(tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)))
                neighbours.Add(tiles[tile.position + new Vector2(0, BaseTile.TILE_HEIGHT)]);

            return neighbours.ToArray();
        }

        public BaseTile GetTileFromPos(Vector2 pos) {
            if (!tiles.ContainsKey(pos))
                return null;

            return tiles[pos];
        }

        public int GetIndexFromPos(Vector2 position) => (int)(position.X / BaseTile.TILE_WIDTH) + (int)(position.Y / BaseTile.TILE_HEIGHT * tilesPerRow);
    }
}
