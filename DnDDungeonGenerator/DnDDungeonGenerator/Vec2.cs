using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDungeonGenerator {
    public struct Vec2 : IEquatable<Vec2> {
        public int x;
        public int y;

        public Vec2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj) => obj is Vec2 vec && Equals(vec);
        public bool Equals(Vec2 other) => x == other.x && y == other.y;
        public override int GetHashCode() => HashCode.Combine(x, y);
        public override string ToString() => $"[{x}, {y}]";

        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.x + b.x, a.y + b.y);
    }
}
