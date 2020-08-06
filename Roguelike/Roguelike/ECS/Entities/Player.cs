using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.Graphics;
using Roguelike.Utils.SpriteBatchExtensions;

namespace Roguelike.ECS.Entities {
    public class Player : Entity {
        public static Player Instance { get; private set; }
        private Texture2D sprite;

        public Player(Vector2 location, float speed = 150.0f) : base() {
            Instance = this;
            this.location = location;
            base.speed = speed;
            spriteSize = new Vector2(40, 40);
        }

        public override void Load() {
            sprite = ContentLibrary.CaveContentManager.Load<Texture2D>("Player");
        }

        public override void Draw(DrawData drawData) {
            drawData.SpriteBatch.Draw(sprite, GetEntityRectangle(drawData.ScreenBounds.Location), Color.White);
            drawData.SpriteBatch.Draw(ContentLibrary.CaveContentManager.Load<Texture2D>("BorderBlack"), GetEntityRectangle(drawData.ScreenBounds.Location), Color.White);
        }

        public override Entity Copy() {
            var copy = new Player(location, speed) {
                previousLocation = previousLocation,
                sprite = sprite,
                spriteSize = spriteSize,
                velocity = velocity
            };

            foreach (var component in components)
                copy.AddComponent(component.Copy());

            return copy;
        }
    }
}
