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
        #region Constants
        /// <summary>
        /// The width of a tile
        /// </summary>
        public const int TILE_WIDTH = 25;
        /// <summary>
        /// The height of a tile
        /// </summary>
        public const int TILE_HEIGHT = 25;
        #endregion
        #region Variables
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
        /// <summary>
        /// Indicates whether this tile can be walked over
        /// </summary>
        public bool isWalkable;
        #endregion
        #region Properties
        /// <summary>
        /// Gets a rectangle representing this tile
        /// </summary>
        public Rectangle tileRectangle => new Rectangle(position, new Vector2D(TILE_WIDTH, TILE_HEIGHT));
        #endregion
        #region Constructors
        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        protected BaseTile(Vector2D position) : this(position, Color.Black) { }

        protected BaseTile(Vector2D position, Bitmap sprite) : this(position, Color.Black, sprite) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color of the tile</param>
        protected BaseTile(Vector2D position, Color tileColor) : this(position, tileColor, false) { }

        protected BaseTile(Vector2D position, Color tileColor, Bitmap sprite) : this(position, tileColor, false, sprite) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="isWalkable">Whether the tile can be walked over</param>
        protected BaseTile(Vector2D position, bool isWalkable) : this(position, Color.Black, isWalkable) { }

        protected BaseTile(Vector2D position, bool isWalkable, Bitmap sprite) : this(position, Color.Black, isWalkable, sprite) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color of the tile</param>
        /// <param name="isWalkable">Whether the tile can be walked over</param>
        protected BaseTile(Vector2D position, Color tileColor, bool isWalkable) : this(position, tileColor, isWalkable, null) { }

        protected BaseTile(Vector2D position, Color tileColor, bool isWalkable, Bitmap sprite) {
            this.position = position;
            this.tileColor = tileColor;
            this.isWalkable = isWalkable;
            this.sprite = sprite;
        }
        #endregion
    }
}
