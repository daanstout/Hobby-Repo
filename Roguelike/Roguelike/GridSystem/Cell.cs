
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.Graphics;
using Roguelike.Utils;
using Roguelike.Utils.SpriteBatchExtensions;

namespace Roguelike.GridSystem {
    public class Cell {
        public static Vector2 CellSize { get; private set; } = new Vector2(40, 40);
        public static Vector2 HalfSize => CellSize / 2;
        public static float HalfWidth => CellSize.X / 2;
        public static float HalfHeight => CellSize.Y / 2;

        public string tileName;
        public bool traversable;
        public bool isWall;
        public Vector2 Location { get; private set; }
        public RectangleF ViewRectangle => new RectangleF(Location - HalfSize, CellSize);
        public Texture2D Texture { get; private set; }

        public Cell(Vector2 location) {
            Location = location;
        }

        public virtual void Draw(DrawData drawData) {
            if (drawData.ScreenBounds.Intersects(ViewRectangle))
                drawData.SpriteBatch.Draw(Texture, GetCellRectangle(drawData.ScreenBounds.Location), Color.White);
        }

        public virtual void Load() {
            Texture = ContentLibrary.CaveContentManager.Load<Texture2D>(tileName);
        }

        private RectangleF GetCellRectangle(Vector2 offset) {
            return new RectangleF(Location - HalfSize - offset, CellSize);
        }
    }
}
