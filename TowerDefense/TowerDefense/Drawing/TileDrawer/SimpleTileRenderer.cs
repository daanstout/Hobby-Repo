using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.World.Tiles;

namespace TowerDefense.Rendering.TileRenderer {
    /// <summary>
    /// Renders a tile in the simplest way
    /// </summary>
    public class SimpleTileRenderer : ITileRenderer {
        /// <summary>
        /// Renders a tile
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tile">The tile to render</param>
        public void Render(Graphics g, BaseTile tile) {
            // If the tile has no sprite, use its tile color, else use its sprite
            if(tile.sprite == null) {
                g.FillRectangle(new SolidBrush(tile.tileColor), tile.tileRectangle);
            } else {
                g.DrawImage(tile.sprite, tile.tileRectangle);
            }
        }
    }
}
