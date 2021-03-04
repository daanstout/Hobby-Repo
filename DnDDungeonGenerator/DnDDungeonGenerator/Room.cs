using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDungeonGenerator {
    public class Room {
        public static readonly Size roomSizeOuter = new Size(60, 30);
        public static readonly Size roomSizeInner = new Size(50, 20);
        public static readonly int pathWidth = 10;

        public readonly Room[] neighbours;

        public Vec2 RoomPosition { get; }
        public Color RoomColor { get; set; }

        public Room GetTop => neighbours[0];
        public Room GetRight => neighbours[1];
        public Room GetBottom => neighbours[2];
        public Room GetLeft => neighbours[3];

        public Room() {
            neighbours = new Room[4];

            neighbours[0] = null;
            neighbours[1] = null;
            neighbours[2] = null;
            neighbours[3] = null;
        }

        public Room(Vec2 roomPosition) : this() {
            RoomPosition = roomPosition;
        }

        public void Draw(Graphics g, int lowestX, int lowestY, Font font) {
            int offsetX = RoomPosition.x - lowestX;
            int offsetY = RoomPosition.y - lowestY;

            var drawLoc = new Point() {
                X = offsetX * roomSizeOuter.Width,
                Y = offsetY * roomSizeOuter.Height
            };

            drawLoc += roomSizeOuter / 2;

            using var brush = new SolidBrush(RoomColor);

            g.FillRectangle(brush, new Rectangle(drawLoc - roomSizeInner / 2, roomSizeInner));

            var stringSize = g.MeasureString(RoomPosition.ToString(), font);

            g.DrawString(RoomPosition.ToString(), font, Brushes.Black, (PointF)drawLoc - stringSize / 2);

            if (GetTop != null) {
                int xPos = drawLoc.X - pathWidth / 2;
                int yPos = drawLoc.Y - roomSizeOuter.Height / 2;

                g.FillRectangle(Brushes.Green, new Rectangle(xPos, yPos, pathWidth, (roomSizeOuter.Height - roomSizeInner.Height) / 2));
            }
            if(GetRight != null) {
                int xPos = drawLoc.X + roomSizeInner.Width / 2;
                int yPos = drawLoc.Y - pathWidth / 2;

                g.FillRectangle(Brushes.Green, new Rectangle(xPos, yPos, (roomSizeOuter.Width - roomSizeInner.Width) / 2, pathWidth));
            }
            if (GetBottom != null) {
                int xPos = drawLoc.X - pathWidth / 2;
                int yPos = drawLoc.Y + roomSizeInner.Height / 2;

                g.FillRectangle(Brushes.Green, new Rectangle(xPos, yPos, pathWidth, (roomSizeOuter.Height - roomSizeInner.Height) / 2));
            }
            if(GetLeft != null) {
                int xPos = drawLoc.X - roomSizeOuter.Width / 2;
                int yPos = drawLoc.Y - pathWidth / 2;

                g.FillRectangle(Brushes.Green, new Rectangle(xPos, yPos, (roomSizeOuter.Width - roomSizeInner.Width) / 2, pathWidth));
            }
        }
    }
}
