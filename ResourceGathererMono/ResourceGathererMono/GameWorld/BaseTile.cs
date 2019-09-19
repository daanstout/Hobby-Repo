using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ResourceGathererMono.GameWorld {
    public class BaseTile {
        public const int TILE_WIDTH = 40;
        public const int TILE_HEIGHT = 40;

        private static Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();

        public static void RegisterTexture(Texture2D texture, int mask) {
            if (texture == null)
                return;

            if (textures.ContainsKey(mask))
                return;

            textures.Add(mask, texture);
        }

        public static ITileRenderer renderer { get; private set; } = new SimpleTileRenderer();

        public Vector2 position;
        public Color tileColor;

        public Rectangle tileRectangle => new Rectangle(position.ToPoint(), new Point(TILE_WIDTH, TILE_HEIGHT));

        public BaseTile(Vector2 position, Color tileColor) {
            this.position = position;
            this.tileColor = tileColor;
        }

        public virtual void Render(SpriteBatch spriteBatch) => renderer.RenderTile(this, spriteBatch);

        public virtual Texture2D GetTexture() => textures[mask];

        public static void SetRenderer(ITileRenderer renderer) => BaseTile.renderer = renderer;

        #region Masks
        private int mask = 0;

        public const int plainsMask = 0x1;
        public const int WaterMask = 0x2;

        public bool isPlains {
            get => (mask & plainsMask) > 0;
            set => mask |= plainsMask;
        }
        #endregion
    }
}
