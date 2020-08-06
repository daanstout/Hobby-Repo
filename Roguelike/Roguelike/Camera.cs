
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Roguelike.ECS.Entities;
using Roguelike.Utils;

namespace Roguelike {
    public class Camera {
        public static Vector2 ScreenOffset { get; private set; } = Vector2.Zero;

        private GraphicsDeviceManager Graphics { get; }

        private RectangleF viewPort;
        private RectangleF trackingBounds;
        private Vector2 targetPosition;
        private Vector2 currentPosition;

        public RectangleF View => viewPort;

        private const float BOUNDS_PERCENT = 0.25f;

        public Camera(GraphicsDeviceManager graphics) {
            Graphics = graphics;
            viewPort = new RectangleF(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            CalculateTrackingBounds();
        }

        public void SetResolution(Vector2 resolution) {
            Graphics.PreferredBackBufferWidth = (int)resolution.X;
            Graphics.PreferredBackBufferHeight = (int)resolution.Y;
            Graphics.ApplyChanges();
            viewPort.width = resolution.X;
            viewPort.height = resolution.Y;
            CalculateTrackingBounds();
        }

        public void SetFullScreen(bool fullScreen) {
            if (Graphics.IsFullScreen == fullScreen)
                return;

            Graphics.IsFullScreen = fullScreen;
            Graphics.ApplyChanges();
        }

        public void Initialize() {
            CenterCamera();
            CalculateTrackingBounds();
        }

        public void Update(GameTime gameTime) {
            CalculateCameraLocation(gameTime);
        }

        private void CalculateTrackingBounds() {
            trackingBounds = new RectangleF() {
                x = viewPort.x + (viewPort.width * BOUNDS_PERCENT),
                y = viewPort.y + (viewPort.height * BOUNDS_PERCENT),
                width = viewPort.width * (1 - (2 * BOUNDS_PERCENT)),
                height = viewPort.height * (1 - (2 * BOUNDS_PERCENT))
            };
        }

        private void CenterCamera() {
            var player = Player.Instance;

            currentPosition.X = player.location.X - ((viewPort.width - player.spriteSize.X) / 2);
            currentPosition.Y = player.location.Y - ((viewPort.height - player.spriteSize.Y) / 2);

            viewPort.x = currentPosition.X;
            viewPort.y = currentPosition.Y;

            targetPosition.X = currentPosition.X;
            targetPosition.Y = currentPosition.Y;

            ScreenOffset = currentPosition;

            //var offset = new Vector2() {
            //    X = (viewPort.width - player.spriteSize.X) / 2,
            //    Y = (viewPort.height - player.spriteSize.Y) / 2
            //};

            //CenterCamera(player.location - offset);
        }

        private void CenterCamera(Vector2 center) {
            currentPosition = center - (viewPort.Size / 2);

            viewPort.Location = currentPosition;

            targetPosition = currentPosition;

            ScreenOffset = viewPort.Location;
        }

        private void CalculateCameraLocationOld(GameTime gameTime) {
            var player = Player.Instance;

            var offset = new Vector2() {
                X = (viewPort.width - player.spriteSize.X) / 2,
                Y = (viewPort.height - player.spriteSize.Y) / 2
            };

            var centeredPlayer = player.location;

            var mouseLocation = Mouse.GetState().Position.ToVector2();

            var mouseLocalized = mouseLocation - viewPort.Location;

            var average = (centeredPlayer + mouseLocalized) / 2;

            var newLoc = average;

            CenterCamera(newLoc);

            Console.WriteLine(ScreenOffset);
        }

        private void CalculateCameraLocation(GameTime gameTime) {
            var playerLocation = Player.Instance.location;

            if (playerLocation.X < trackingBounds.Left)
                targetPosition.X = playerLocation.X - viewPort.width * BOUNDS_PERCENT;
            if (playerLocation.X > trackingBounds.Right)
                targetPosition.X = viewPort.x + (playerLocation.X - trackingBounds.Right);
            if (playerLocation.Y < trackingBounds.Top)
                targetPosition.Y = playerLocation.Y - viewPort.height * BOUNDS_PERCENT;
            if (playerLocation.Y > trackingBounds.Bottom)
                targetPosition.Y = viewPort.y + (playerLocation.Y - trackingBounds.Bottom);

            currentPosition = Vector2.Lerp(currentPosition, targetPosition, 5.0f * (float)gameTime.ElapsedGameTime.TotalSeconds);

            viewPort.x = (int)currentPosition.X;
            viewPort.y = (int)currentPosition.Y;

            ScreenOffset = currentPosition;

            CalculateTrackingBounds();
        }
    }
}
