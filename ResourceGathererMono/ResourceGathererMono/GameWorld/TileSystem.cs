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

        private BaseTile[] tiles;

        private int tileCount;
        private int tilesPerRow;

        private static Random rand = new Random();

        private void GenerateTiles() {
            BaseTile[] temp = new BaseTile[tileCount];


            float curX = 0, curY = 0;


            for (int i = 0; i < tileCount; i++) {
                //var test = curX;
                //Vector2 test2 = new Vector2(curX, curY);
                BaseTile tile = new BaseTile(new Vector2(curX + 0, curY + 0), Color.White);
                tile.isPlains = true;
                temp[i] = tile;
                //tiles[i] = tile;
                //tiles[i].isPlains = true;

                curX += BaseTile.TILE_WIDTH;

                if (curX >= World.instance.gameWidth) {
                    curX = 0;
                    curY += BaseTile.TILE_HEIGHT;
                }
            }

            tiles = temp;
        }

        public void RenderTiles(SpriteBatch spriteBatch) {
            foreach (BaseTile tile in tiles)
                BaseTile.renderer.RenderTile(tile, spriteBatch);
        }
    }
}
