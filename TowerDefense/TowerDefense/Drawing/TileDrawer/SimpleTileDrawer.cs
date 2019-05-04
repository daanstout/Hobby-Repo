using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.World.Tiles;

namespace TowerDefense.Drawing.TileDrawer {
    public class SimpleTileDrawer : ITileDrawer {
        public void Render(Graphics g, BaseTile tile) {
            if(tile.sprite == null) {
                g.FillRectangle(new SolidBrush(tile.tileColor), tile.tileRectangle);
            } else {
                g.DrawImage(tile.sprite, tile.tileRectangle);
            }
        }
    }
}
