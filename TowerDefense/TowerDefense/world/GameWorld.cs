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
    /// <summary>
    /// The game world
    /// </summary>
    public class GameWorld {
        /// <summary>
        /// The public instance of the game world
        /// </summary>
        public static GameWorld instance;

        /// <summary>
        /// The tiles in the world
        /// </summary>
        private TileSystem tileSystem;
        private Time time;
        private Graph graph;

        /// <summary>
        /// The width of the world
        /// </summary>
        public readonly int gameWidth;
        /// <summary>
        /// The height of the world
        /// </summary>
        public readonly int gameHeight;

        /// <summary>
        /// Creates a new game world
        /// </summary>
        /// <param name="width">The width of the game</param>
        /// <param name="height">The height of the game</param>
        public GameWorld(int width, int height) {
            // Set the instance
            instance = this;

            gameWidth = width;
            gameHeight = height;

            // Create a new tile system
            tileSystem = new TileSystem();
            time = Time.Create();
            graph = new Graph();

            // Initialize the tiles
            tileSystem.InitTileSystem();

            graph.CreateVerteces(tileSystem.GetTiles());
        }

        /// <summary>
        /// Updates all the pieces in the world
        /// </summary>
        public void Update() {
            time.Update();
        }

        /// <summary>
        /// Renders all the pieces in the world
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void Render(Graphics g) {

        }

        /// <summary>
        /// Renders the background of the world
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void RenderBackground(Graphics g) {
            // Renders all the tiles
            tileSystem.RenderTiles(g);

            // Draws a grid over the field
            using (Pen pen = new Pen(Color.Gray)) {
                for (int x = BaseTile.TILE_WIDTH; x < gameWidth; x += BaseTile.TILE_WIDTH)
                    g.DrawLine(pen, new Vector2D(x, 0), new Vector2D(x, gameWidth));

                for (int y = BaseTile.TILE_HEIGHT; y < gameHeight; y += BaseTile.TILE_HEIGHT)
                    g.DrawLine(pen, new Vector2D(0, y), new Vector2D(gameHeight, y));
            }
        }
    }
}
