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
        /// The tile info of the system
        /// </summary>
        private TileInfo info;

        /// <summary>
        /// Gets the tile info
        /// </summary>
        public TileInfo getTileInfo {
            get {
                if (info == null)
                    info = new TileInfo(tileCount);
                return info;
            }
        }

        /// <summary>
        /// Instantiates a new Tile System
        /// </summary>
        public TileSystem() {
            instance = this;
            rand = new Random();

            // Calculate the number of tiles per row
            tilesPerRow = GameWorld.instance.gameWidth / BaseTile.TILE_WIDTH;
            // Calculate the number of tiles in total
            tileCount = tilesPerRow * (GameWorld.instance.gameHeight / BaseTile.TILE_HEIGHT);
        }

        /// <summary>
        /// Initiates the Tile System
        /// </summary>
        public void InitTileSystem(TileInfo info) {
            // Instantiate the tiles array
            tiles = new BaseTile[tileCount];

            // Set the current X and Y coordinates
            float curX = 0, curY = 0;
            // Go through every tile and create it
            for (int i = 0; i < tileCount; i++) {
                // Check the type to see what type of tile needs to be initiated
                if (info.ContainsType(i, TileInfo.tileTypes.plains))
                    tiles[i] = new PlainsTile(new Vector2D(curX, curY), Color.Green);
                else
                    tiles[i] = new PlainsTile(new Vector2D(curX, curY), Color.Green);


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

        /// <summary>
        /// Gets the index in the array from a vector2D
        /// </summary>
        /// <param name="position">The position of the tile in the system</param>
        /// <returns>The index of that tile</returns>
        public int GetIndexFromPos(Vector2D position) => (int)(position.x / BaseTile.TILE_WIDTH) + (int)(position.y / BaseTile.TILE_HEIGHT * tilesPerRow);

        /// <summary>
        /// Gets the index in the array from an x-y position
        /// </summary>
        /// <param name="x">The xth tile horizontally</param>
        /// <param name="y">the yth tile vertically</param>
        /// <returns>The index of the tile</returns>
        public int GetIndexFromXY(int x, int y) => y * tilesPerRow + x;
    }

    /// <summary>
    /// A class for keeping the tile info
    /// </summary>
    public class TileInfo {
        /// <summary>
        /// The states applicable for a tile
        /// </summary>
        public enum tileStates {
            /// <summary>
            /// The tile is empty
            /// </summary>
            empty = 0x0,
            /// <summary>
            /// The tile contains the enemy spawn location
            /// </summary>
            enemy_spawn = 0x1,
            /// <summary>
            /// The tile contains the allied base
            /// </summary>
            allied_base = 0x2,
            /// <summary>
            /// The tile contains a building
            /// </summary>
            building = 0x4,
            /// <summary>
            /// The tile cannot be walked on (tiles can be walked on by default)
            /// </summary>
            non_walkable = 0x8,
        }

        /// <summary>
        /// The types of tiles there are
        /// </summary>
        public enum tileTypes {
            /// <summary>
            /// The tile is a plain (the default setting)
            /// </summary>
            plains = 0x0
        }

        /// <summary>
        /// The tile info
        /// </summary>
        int[] info;
        /// <summary>
        /// The tile types
        /// </summary>
        int[] types;

        /// <summary>
        /// Instantiates a new TileInfo
        /// </summary>
        /// <param name="tileCount">The number of tiles in the system</param>
        public TileInfo(int tileCount) {
            info = new int[tileCount];
            types = new int[tileCount];
        }

        /// <summary>
        /// Adds a state to a tile
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="state">The state of the tile</param>
        public void AddState(int index, tileStates state) => info[index] |= (int)state;

        /// <summary>
        /// Removes a state from a tile
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="state">The state of the tile to remove</param>
        public void RemoveState(int index, tileStates state) => info[index] &= ~(int)state;

        /// <summary>
        /// Checks whether the tile contains a specified state
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="state">The state to check for</param>
        /// <returns>True if the tile contains the state</returns>
        public bool ContainsState(int index, tileStates state) => (info[index] & (int)state) == (int)state;

        /// <summary>
        /// Sets the state for all tiles to a certain type
        /// </summary>
        /// <param name="state">The state to set</param>
        public void SetAllStates(tileStates state) {
            for (int i = 0; i < info.Length; i++)
                info[i] |= (int)state;
        }

        /// <summary>
        /// Removes a type from all tiles
        /// </summary>
        /// <param name="state">The state to remove</param>
        public void RemoveAllStates(tileStates state) {
            for (int i = 0; i < info.Length; i++)
                info[i] &= ~(int)state;
        }

        /// <summary>
        /// Adds a type to a tile
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="type">The type of tile</param>
        public void AddType(int index, tileTypes type) => types[index] |= (int)type;

        /// <summary>
        /// Removes a type from a tile
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="type">The type of the tile to remove</param>
        public void RemoveType(int index, tileTypes type) => types[index] &= ~(int)type;

        /// <summary>
        /// Checks whether the tile contains the specified type
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <param name="type">The type to check for</param>
        /// <returns>True if the tile contains the type</returns>
        public bool ContainsType(int index, tileTypes type) => (types[index] & (int)type) == (int)type;

        /// <summary>
        /// Sets a type for all tiles
        /// </summary>
        /// <param name="type">The type to set the tile to</param>
        public void SetAllTypes(tileTypes type) {
            for (int i = 0; i < types.Length; i++)
                types[i] |= (int)type;
        }

        /// <summary>
        /// Removes a type from all tiles
        /// </summary>
        /// <param name="type">The type to remove</param>
        public void RemoveAllTypes(tileTypes type) {
            for (int i = 0; i < types.Length; i++)
                types[i] &= ~(int)type;
        }
    }
}
