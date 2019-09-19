using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ResourceGathererMono.GameWorld {
    public interface ITileRenderer {
        void RenderTile(BaseTile tile, SpriteBatch spriteBatch);
    }
}
