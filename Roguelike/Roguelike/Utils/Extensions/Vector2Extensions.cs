
using Microsoft.Xna.Framework;

namespace Roguelike.Utils.Vector2Extensions {
    public static class Vector2Extensions {
        public static Vector2 Truncate(this Vector2 vector, float max) {
            if (vector.Length() <= max)
                return vector;

            vector.Normalize();

            return vector * max;
        }
    }
}
