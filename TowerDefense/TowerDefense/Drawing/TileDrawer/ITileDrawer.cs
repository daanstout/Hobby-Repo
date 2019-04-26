using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.GameWorld.Tiles;

namespace TowerDefense.Drawing.TileDrawer {
    public interface ITileDrawer {
        void Render(Graphics g, BaseTile tile);
    }
}
