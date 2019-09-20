using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ResourceGathererMono.GameWorld {
    public class SimpleTileRenderer : ITileRenderer{
        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch) {
            if (tile == null)
                return;

            spriteBatch.Draw(tile.GetTexture(),
                tile.tileRectangle,
                null,
                tile.tileColor,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0f);
        }

        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch, Color color) {
            if (tile == null)
                return;

            spriteBatch.Draw(tile.GetTexture(),
                tile.tileRectangle,
                null,
                color,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0f);
        }

        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch, Color color, float layerDepth) {
            if (tile == null)
                return;

            spriteBatch.Draw(tile.GetTexture(),
                tile.tileRectangle,
                null,
                color,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                layerDepth);
        }
    }
}
