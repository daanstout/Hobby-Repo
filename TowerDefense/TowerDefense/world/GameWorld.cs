using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;
using DaanLib.StateMachine;
using TowerDefense.Entities;
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
        /// <summary>
        /// The time instance that keeps track of time
        /// </summary>
        private Time time;
        /// <summary>
        /// The graph system for the verteces
        /// </summary>
        private Graph graph;

        /// <summary>
        /// The list of entities in the world
        /// </summary>
        private List<ITickable> entities;

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

            entities = new List<ITickable>();

            entities.Add(new MovingEntity(new Vector2D(50, 50), new Vector2D(10, 10), Color.Red, Vector2D.Left, 1, 1, 1, 1));
            entities.Add(new MovingEntity(new Vector2D(100, 100), new Vector2D(20, 20), Color.Black, Vector2D.Left, 1, 1, 1, 1));

            Initialize();
        }

        /// <summary>
        /// Initializes the world and its components
        /// </summary>
        private void Initialize() {
            TileInfo tileInfo = tileSystem.getTileInfo;

            tileInfo.AddState(tileSystem.GetIndexFromXY(0, 0), TileInfo.tileStates.enemy_spawn);
            tileInfo.AddState(tileSystem.GetIndexFromXY(0, 0), TileInfo.tileStates.non_walkable);

            tileInfo.AddState(tileSystem.GetIndexFromXY(1, 0), TileInfo.tileStates.enemy_spawn);
            tileInfo.AddState(tileSystem.GetIndexFromXY(1, 0), TileInfo.tileStates.non_walkable);

            tileInfo.AddState(tileSystem.GetIndexFromXY(0, 1), TileInfo.tileStates.enemy_spawn);
            tileInfo.AddState(tileSystem.GetIndexFromXY(0, 1), TileInfo.tileStates.non_walkable);

            tileInfo.AddState(tileSystem.GetIndexFromXY(1, 1), TileInfo.tileStates.enemy_spawn);
            tileInfo.AddState(tileSystem.GetIndexFromXY(1, 1), TileInfo.tileStates.non_walkable);

            tileInfo.SetAllTypes(TileInfo.tileTypes.plains);

            // Initialize the tiles
            tileSystem.InitTileSystem(tileInfo);

            graph.CreateVerteces(tileSystem.GetTiles(), tileInfo);

            foreach (ITickable entity in entities)
                entity.Initialize();
        }

        /// <summary>
        /// Updates all the pieces in the world
        /// </summary>
        public void Update() {
            time.Update();

            foreach (ITickable entity in entities)
                entity.Update(Time.deltaTimeSeconds);
        }

        /// <summary>
        /// Renders all the pieces in the world
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public void Render(Graphics g) {
            foreach (ITickable entity in entities)
                entity.Render(g);
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
