using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roguelike.Utils.SpriteBatchExtensions {
    public static class SpriteBatchExtensions {
        private static Texture2D texture;
        private static Texture2D GetTexture(SpriteBatch spriteBatch) {
            if (texture == null) {
                texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                texture.SetData(new[] { Color.White });
            }

            return texture;
        }

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1.0f) {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1.0f) {
            var origin = new Vector2(0.0f, 0.5f);
            var scale = new Vector2(length, thickness);
            spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, RectangleF destinationRectangle, Color color) {
            spriteBatch.Draw(texture, (Rectangle)destinationRectangle, color);
        }

        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, RectangleF destinationRectangle, RectangleF sourceRectangle, Color color) {
            spriteBatch.Draw(texture, (Rectangle)destinationRectangle, (Rectangle)sourceRectangle, color);
        }
    }
}
