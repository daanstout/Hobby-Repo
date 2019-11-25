using System;
using System.Drawing;

namespace CirclePractice {
    /// <summary>
    /// A Circle that has a blob moving over it
    /// </summary>
    class Circle {
        /// <summary>
        /// The position of the circle in the world
        /// </summary>
        Point position;
        /// <summary>
        /// The radius of the circle, from center to edge
        /// </summary>
        float radius;
        /// <summary>
        /// How many degrees the blob has moved over the current circle
        /// </summary>
        float rotation;
        /// <summary>
        /// the speed of the blob
        /// </summary>
        float speed;
        /// <summary>
        /// The radius of the blob
        /// </summary>
        float blobRadius;

        /// <summary>
        /// Creates a rectangle in which the circle sits
        /// </summary>
        RectangleF circleRectangle => new RectangleF(position.X - radius, position.Y - radius, radius * 2, radius * 2);

        /// <summary>
        /// Instantiates a new Circle
        /// </summary>
        /// <param name="position">The position of the circle</param>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="rotation">Where the blob starts on the circle in degrees</param>
        /// <param name="speed">The speed of the circle</param>
        /// <param name="blobRadius">The radius of the blob</param>
        public Circle(Point position, float radius, float rotation, float speed, float blobRadius) {
            this.position = position;
            this.radius = radius;
            this.rotation = rotation;
            this.speed = speed;
            this.blobRadius = blobRadius;
        }

        /// <summary>
        /// Updates the blob's position
        /// </summary>
        /// <param name="elapsedTime">The time elapsed since the previous tick</param>
        public void Update(float elapsedTime) => rotation += (speed * elapsedTime);

        /// <summary>
        /// Draws the circle to a canvas
        /// </summary>
        /// <param name="g">The graphics instance of the canvas</param>
        public void DrawCircle(Graphics g) => g.DrawEllipse(Pens.Black, circleRectangle);

        /// <summary>
        /// Draws the blob to a canvas
        /// </summary>
        /// <param name="g">The graphics instance of the canvas</param>
        public void DrawBlob(Graphics g) {
            // This calculates the position of the blob.
            // First we change the degrees to radians, since Math.Cos and Math.Sin use radians
            // Then we multiply by the circle's radius to get the correct distance from the centre so it sits on the edge
            // We take the minus of the Math.Sin because WinForm's Y goes from top to bottom (so the top is 0)
            float blobX = (float)Math.Cos((Math.PI * rotation) / 180.0f) * radius;
            float blobY = -(float)Math.Sin((Math.PI * rotation) / 180.0f) * radius;

            g.FillEllipse(Brushes.Red, new RectangleF(blobX - blobRadius + position.X, blobY - blobRadius + position.Y, blobRadius * 2, blobRadius * 2));
        }
    }
}
