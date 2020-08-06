using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;

using Roguelike.Utils;
using Roguelike.Utils.SpriteBatchExtensions;

namespace Roguelike.Graphics {
    public class SpriteSheet {
        private readonly Texture2D sheet;
        private readonly Dictionary<string, RectangleF> sprites;
        public string Sprite { get; }

        public SpriteSheet(string sheetName) {
            Sprite = sheetName;
            sheet = ContentLibrary.CaveContentManager.Load<Texture2D>($"{sheetName}SpriteSheet");
            sprites = JsonConvert.DeserializeObject<Dictionary<string, RectangleF>>(File.ReadAllText($"Graphics/Data/{sheetName}SpriteSheet.json"));
        }

        public bool ContainsSprite(string sprite) {
            return sprites.ContainsKey(sprite);
        }

        public void DrawSprite(DrawData drawData, string sprite, Vector2 location) {
            var sourceRect = sprites[sprite];

            var destinationRect = new RectangleF(location - drawData.ScreenBounds.Location, sourceRect.Size);

            if (drawData.ScreenBounds.Intersects(destinationRect))
                drawData.SpriteBatch.Draw(sheet, destinationRect, sourceRect, Color.White);
        }

        public void DrawSprite(DrawData drawData, string sprite, int spriteIndex, Vector2 location) {
            sprite += "_" + spriteIndex;

            DrawSprite(drawData, sprite, location);
        }

        public void DrawSprite(DrawData drawData, int spriteIndex, Vector2 location) {
            var sprite = Sprite + "_" + spriteIndex;

            DrawSprite(drawData, sprite, location);
        }

        public void DrawSprite(DrawData drawData, string sprite, RectangleF destinationRect) {
            var sourceRect = sprites[sprite];

            if (drawData.ScreenBounds.Intersects(destinationRect))
                drawData.SpriteBatch.Draw(sheet, destinationRect, sourceRect, Color.White);
        }

        public void DrawSprite(DrawData drawData, string sprite, int spriteIndex, RectangleF destinationRect) {
            sprite += "_" + spriteIndex;

            DrawSprite(drawData, sprite, destinationRect);
        }

        public void DrawSprite(DrawData drawData, int spriteIndex, RectangleF destinationRect) {
            DrawSprite(drawData, Sprite + "_" + spriteIndex, destinationRect);
        }
    }
}
