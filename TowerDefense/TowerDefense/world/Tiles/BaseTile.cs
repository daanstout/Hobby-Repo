using DaanLib.Maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Rendering.TileRenderer;
using DaanLib;

namespace TowerDefense.World.Tiles {
    /// <summary>
    /// A base tile that occupies the world
    /// </summary>
    public abstract class BaseTile : IEquatable<BaseTile> {
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
        #region Statics
        /// <summary>
        /// The renderer used for drawing the tiles
        /// </summary>
        private static ITileRenderer renderer = new SimpleTileRenderer();
        private static IDSetter idSetter = new IDSetter();
        #endregion
        #region Variables
        /// <summary>
        /// The id of the tile
        /// </summary>
        private int tileID;
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
        ///// <summary>
        ///// Indicates whether this tile can be walked over
        ///// </summary>
        //public bool isWalkable;
        #endregion
        #region Properties
        /// <summary>
        /// Gets a rectangle representing this tile
        /// </summary>
        public Rectangle tileRectangle => new Rectangle(position, new Vector2D(TILE_WIDTH, TILE_HEIGHT));
        /// <summary>
        /// The id of the tile
        /// </summary>
        public int tileId => tileID;

        public bool isWalkable => !TileSystem.instance.getTileInfo.ContainsState(TileSystem.instance.GetIndexFromPos(position), TileInfo.tileStates.non_walkable);
        #endregion
        #region Constructors
        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        protected BaseTile(Vector2D position) : this(position, Color.Black) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="sprite">The sprite for the tile</param>
        protected BaseTile(Vector2D position, Bitmap sprite) : this(position, Color.Black, sprite) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color of the tile</param>
        protected BaseTile(Vector2D position, Color tileColor) : this(position, tileColor, null) { }

        /// <summary>
        /// Instantiates a new BaseTile
        /// </summary>
        /// <param name="position">The position of the tile</param>
        /// <param name="tileColor">The color for the tile</param>
        /// <param name="sprite">The sprite for this tile</param>
        protected BaseTile(Vector2D position, Color tileColor, Bitmap sprite) {
            this.position = position;
            this.tileColor = tileColor;
            this.sprite = sprite;
            tileID = idSetter.getNextValidId;
        }
        #endregion
        /// <summary>
        /// Renders the tile
        /// </summary>
        /// <param name="g"></param>
        public virtual void Render(Graphics g) => renderer.Render(g, this);

        /// <summary>
        /// Changes the renderer for the tiles
        /// </summary>
        /// <param name="renderer"></param>
        public static void SetRenderer(ITileRenderer renderer) => BaseTile.renderer = renderer;

        /// <summary>
        /// Compares two Tiles to see if they are the same Tile
        /// </summary>
        /// <param name="obj">The other tile</param>
        /// <returns>True if they are the same tiels</returns>
        public override bool Equals(object obj) => Equals(obj as BaseTile);
        /// <summary>
        /// Compares two Tiles to see if they are the same Tile
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BaseTile other) => other != null && tileID == other.tileID && position.Equals(other.position);

        public override int GetHashCode() {
            var hashCode = -185539890;
            hashCode = hashCode * -1521134295 + tileID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector2D>.Default.GetHashCode(position);
            return hashCode;
        }

        public static bool operator ==(BaseTile left, BaseTile right) => EqualityComparer<BaseTile>.Default.Equals(left, right);
        public static bool operator !=(BaseTile left, BaseTile right) => !(left == right);
    }
}
