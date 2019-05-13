using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;
using DaanLib.StateMachine;

namespace TowerDefense.World.Tiles {
    public class TileSystem {
        private BaseTile[] tiles;

        private int tileCount;

        private int tilesPerRow;

        private static Random rand;
        public TileSystem() => rand = new Random();

        public void InitTileSystem() {
            tilesPerRow = GameWorld.instance.gameWidth / BaseTile.TILE_WIDTH;
            tileCount = tilesPerRow * (GameWorld.instance.gameHeight / BaseTile.TILE_HEIGHT);

            tiles = new BaseTile[tileCount];

            float curX = 0, curY = 0;

            for (int i = 0; i < tileCount; i++) {
                tiles[i] = new PlainsTile(new Vector2D(curX, curY), Color.Green, true);
                curX += BaseTile.TILE_WIDTH;

                if (curX >= GameWorld.instance.gameWidth) {
                    curX = 0;
                    curY += BaseTile.TILE_HEIGHT;
                }
            }
        }

        public void RenderTiles(Graphics g) {
            foreach (BaseTile tile in tiles)
                tile.Render(g);
        }
    }
}
