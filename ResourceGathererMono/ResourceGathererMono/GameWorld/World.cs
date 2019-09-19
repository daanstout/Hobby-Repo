using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ResourceGathererMono.GameWorld {
    public sealed class World {
        public static World instance;

        public int gameWidth;
        public int gameHeight;

        public string levelData;

        public World(int gameWidth, int gameHeight) {
            instance = this;

            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;

            TileSystem.Create((gameWidth / BaseTile.TILE_WIDTH) * (gameHeight / BaseTile.TILE_HEIGHT), gameHeight / BaseTile.TILE_HEIGHT);
        }

        public void Render(SpriteBatch spriteBatch) => TileSystem.instance.RenderTiles(spriteBatch);

        public bool LoadLevel(string data) {
            levelData = data;
            // TODO load from the data

            return true;
        }
    }
}
