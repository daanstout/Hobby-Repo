using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Roguelike.ECS.Entities;
using Roguelike.Graphics;

namespace Roguelike.ECS.Components {
    public class Animation : IDrawComponent{
        private SpriteSheet spriteSheet;
        private int numFrames;
        private int currentFrame;
        private TimeSpan frameTime;
        private TimeSpan frameRunningTime;

        public Entity Entity { get; set; }

        private Animation() { }

        public Animation(string sheetName, int numFrames, TimeSpan frameTime) {
            //spriteSheet = new SpriteSheet(sheetName);
            spriteSheet = ContentLibrary.GetSpriteSheet(sheetName);
            this.numFrames = numFrames;
            currentFrame = 0;
            this.frameTime = frameTime;
            frameRunningTime = TimeSpan.Zero;
        }

        public void Execute(GameTime gameTime) {
            frameRunningTime += gameTime.ElapsedGameTime;

            if(frameRunningTime >= frameTime) {
                frameRunningTime = TimeSpan.Zero;
                currentFrame++;
                currentFrame %= numFrames;
            }
        }

        public void Draw(DrawData drawData) {
            spriteSheet.DrawSprite(drawData, currentFrame, Entity.GetEntityRectangle(drawData.ScreenBounds.Location));
        }

        public IComponent Copy() {
            return new Animation() {
                spriteSheet = spriteSheet,
                numFrames = numFrames,
                currentFrame = currentFrame,
                frameTime = frameTime,
                frameRunningTime = frameRunningTime,
                Entity = Entity
            };
        }
    }
}
