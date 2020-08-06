using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;

using Roguelike.Graphics;

namespace Roguelike {
    public static class ContentLibrary {
        public const string CONTENT_ROOT_DIRECTORY = "Content";
        public static ContentManager CaveContentManager { get; private set; }

        private static readonly Dictionary<string, SpriteSheet> spriteSheets = new Dictionary<string, SpriteSheet>();

        public static void Initialize(IServiceProvider serviceProvider) {
            CaveContentManager = new ContentManager(serviceProvider, CONTENT_ROOT_DIRECTORY);
        }

        public static void Unload() {
            CaveContentManager.Unload();
        }

        public static SpriteSheet GetSpriteSheet(string sheetName) {
            if (!spriteSheets.ContainsKey(sheetName))
                spriteSheets.Add(sheetName, new SpriteSheet(sheetName));

            return spriteSheets[sheetName];
        }
    }
}
