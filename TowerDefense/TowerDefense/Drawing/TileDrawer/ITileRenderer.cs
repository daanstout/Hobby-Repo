using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.World.Tiles;

namespace TowerDefense.Rendering.TileRenderer {
    /// <summary>
    /// Renders a tile
    /// </summary>
    public interface ITileRenderer {
        /// <summary>
        /// Renders a tile
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tile">The tile to render</param>
        void Render(Graphics g, BaseTile tile);
    }
}
