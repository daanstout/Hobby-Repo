using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.World.Tiles;

using DaanLib.Graphs;
using TowerDefense.World;
using DaanLib.Maths;

namespace TowerDefense.Rendering.TileRenderer {
    public class VertexTileRenderer : ITileRenderer {
        static Color vertexColor = Color.Red;

        private SimpleTileRenderer simpleRenderer = new SimpleTileRenderer();

        public void Render(Graphics g, BaseTile tile) {
            simpleRenderer.Render(g, tile);

            Vertex vertex = Graph.instance.GetVertex(tile);

            if (vertex == null)
                return;

            Vector2D vertexPos = tile.position + (new Vector2D(BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT) / 2);

            const int vertexRecSize = 5;

            vertexPos -= new Vector2D(vertexRecSize, vertexRecSize);
            Vector2D vertexSize = new Vector2D(vertexRecSize * 2, vertexRecSize * 2);

            g.FillRectangle(new SolidBrush(vertexColor), new Rectangle(vertexPos, vertexSize));

            foreach(Edge e in vertex.edgeList) {
                BaseTile other = Graph.instance.GetKey(e.destination);
                vertexPos = tile.position + (new Vector2D(BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT) / 2);

                Vector2D otherPos = other.position + (new Vector2D(BaseTile.TILE_WIDTH, BaseTile.TILE_HEIGHT) / 2);

                g.DrawLine(new Pen(vertexColor), vertexPos, otherPos);
            }
        }
    }
}
