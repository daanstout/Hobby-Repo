using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;
using DaanLib.StateMachine;
using TowerDefense.World.Tiles;

namespace TowerDefense.World {
    public class GameWorld {
        public static GameWorld instance;

        private TileSystem tileSystem;

        public readonly int gameWidth;
        public readonly int gameHeight;

        public GameWorld(int width, int height) {
            instance = this;

            gameWidth = width;
            gameHeight = height;

            tileSystem = new TileSystem();

            tileSystem.InitTileSystem();
        }

        public void RenderBackground(Graphics g) {
            tileSystem.RenderTiles(g);

            using (Pen pen = new Pen(Color.Gray)) {
                for (int x = BaseTile.TILE_WIDTH; x < gameWidth; x += BaseTile.TILE_WIDTH)
                    g.DrawLine(pen, new Vector2D(x, 0), new Vector2D(x, gameWidth));

                for (int y = BaseTile.TILE_HEIGHT; y < gameHeight; y += BaseTile.TILE_HEIGHT)
                    g.DrawLine(pen, new Vector2D(0, y), new Vector2D(gameHeight, y));
            }
        }
    }
}
