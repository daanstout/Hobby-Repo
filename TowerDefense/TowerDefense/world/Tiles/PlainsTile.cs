using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;

namespace TowerDefense.World.Tiles {
    /// <summary>
    /// A plains tile
    /// </summary>
    public class PlainsTile : BaseTile {
        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        public PlainsTile(Vector2D position) : this(position, Color.Green) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="sprite">The sprite used for this tile</param>
        public PlainsTile(Vector2D position, Bitmap sprite) : this(position, Color.Green, sprite) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color used for this tile</param>
        public PlainsTile(Vector2D position, Color tileColor) : base(position, tileColor) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="isWalkable">Indicates whether this tile can be walked upon</param>
        public PlainsTile(Vector2D position, bool isWalkable) : this(position, Color.Green, isWalkable) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color used for this tile</param>
        /// <param name="sprite">The sprite used for this tile</param>
        public PlainsTile(Vector2D position, Color tileColor, Bitmap sprite) : base(position, tileColor, sprite) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="isWalkable">Indicates whether this tile can be walked upon</param>
        /// <param name="sprite">The sprite used for this tile</param>
        public PlainsTile(Vector2D position, bool isWalkable, Bitmap sprite) : base(position, Color.Green, isWalkable, sprite) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color used for this tile</param>
        /// <param name="isWalkable">Indicates whether this tile can be walked upon</param>
        public PlainsTile(Vector2D position, Color tileColor, bool isWalkable) : base(position, tileColor, isWalkable) { }

        /// <summary>
        /// Instantiates a new Plains Tile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color used for this tile</param>
        /// <param name="isWalkable">Indicates whether this tile can be walked upon</param>
        /// <param name="sprite">The sprite used for this tile</param>
        public PlainsTile(Vector2D position, Color tileColor, bool isWalkable, Bitmap sprite) : base(position, tileColor, isWalkable, sprite) { }
    }
}
