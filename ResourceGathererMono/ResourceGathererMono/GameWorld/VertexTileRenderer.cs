using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ResourceGathererMono.GameWorld {
    public class VertexTileRenderer : ITileRenderer {
        private static SimpleTileRenderer simpleRenderer = new SimpleTileRenderer();
        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch) {
            simpleRenderer.RenderTile(tile, spriteBatch);
        }

        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch, Color color) {
            simpleRenderer.RenderTile(tile, spriteBatch, color);
        }

        public void RenderTile(BaseTile tile, SpriteBatch spriteBatch, Color color, float layerDepth) {
            simpleRenderer.RenderTile(tile, spriteBatch, color, layerDepth);
        }
    }
}
