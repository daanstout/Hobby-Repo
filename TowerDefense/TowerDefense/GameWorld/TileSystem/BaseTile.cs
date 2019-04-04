using DaanLib.Maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.GameWorld.TileSystem {
    /// <summary>
    /// A base tile that occupies the world
    /// </summary>
    public abstract class BaseTile {
        /// <summary>
        /// The width of a tile
        /// </summary>
        public const int TILE_WIDTH = 25;
        /// <summary>
        /// The height of a tile
        /// </summary>
        public const int TILE_HEIGHT = 25;

        /// <summary>
        /// The sprite of the tile
        /// </summary>
        public Bitmap sprite;
        /// <summary>
        /// The color of the tile in case the sprite is not set
        /// </summary>
        public Color tileColor;
        /// <summary>
        /// The position of the tile
        /// </summary>
        public Vector2D position;
        
    }
}
