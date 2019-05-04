using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Maths;

namespace TowerDefense.World.Tiles {
    public class PlainsTile : BaseTile {
        public PlainsTile(Vector2D position) : this(position, Color.Green) { }

        public PlainsTile(Vector2D position, Bitmap sprite) : this(position, Color.Green, sprite) { }

        public PlainsTile(Vector2D position, Color tileColor) : base(position, tileColor) { }

        public PlainsTile(Vector2D position, bool isWalkable) : this(position, Color.Green, isWalkable) { }

        public PlainsTile(Vector2D position, Color tileColor, Bitmap sprite) : base(position, tileColor, sprite) { }

        public PlainsTile(Vector2D position, bool isWalkable, Bitmap sprite) : base(position, Color.Green, isWalkable, sprite) { }

        public PlainsTile(Vector2D position, Color tileColor, bool isWalkable) : base(position, tileColor, isWalkable) { }

        public PlainsTile(Vector2D position, Color tileColor, bool isWalkable, Bitmap sprite) : base(position, tileColor, isWalkable, sprite) { }
    }
}
