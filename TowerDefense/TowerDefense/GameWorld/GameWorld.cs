using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DaanLib.StateMachine;
using TowerDefense.GameWorld.Tiles;

namespace TowerDefense.GameWorld {
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
    }
}
