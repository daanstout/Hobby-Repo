using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.XPath;

using Microsoft.Xna.Framework;

using Roguelike.ECS.Entities;
using Roguelike.GridSystem;
using Roguelike.Utils;

namespace Roguelike.ECS.Components {
    /// <summary>
    /// Checks an entity against the map's walls for collision
    /// </summary>
    public class MapHitboxComponent : HitboxComponent {
        /// <summary>
        /// The grid that makes up the map
        /// </summary>
        private readonly Grid grid;

        /// <summary>
        /// Instantiates a new MapHitboxComponent
        /// </summary>
        /// <param name="grid">The map this component checks against</param>
        public MapHitboxComponent(Grid grid) {
            this.grid = grid;
        }

        public override IComponent Copy() {
            return new MapHitboxComponent(grid);
        }

        /// <summary>
        /// Executes the component and checks for collisions with the map wall
        /// </summary>
        /// <param name="gameTime">The gametime since the last call</param>
        public override void Execute(GameTime gameTime) {
            if (!Entity.HasMoved)
                return;

            // Calculate the bounds of the rectangle based on the current and previous rectangle
            // This provides a rectangle where the player rectangle based on both current and previous location become the edges of the rectangle
            var left = Math.Min(Entity.location.X, Entity.previousLocation.X) - (Entity.spriteSize.X / 2);
            var top = Math.Min(Entity.location.Y, Entity.previousLocation.Y) - (Entity.spriteSize.Y / 2);
            var right = Math.Max(Entity.location.X, Entity.previousLocation.X) + (Entity.spriteSize.X / 2);
            var bottom = Math.Max(Entity.location.Y, Entity.previousLocation.Y) + (Entity.spriteSize.Y / 2);

            // The width becomes the right coorindate, and not he width of the rectangle, so that the division after does not lose precision
            // The same with the height
            var rect = new RectangleF() {
                x = left + (Cell.CellSize.X * 0.4f),
                y = top + (Cell.CellSize.Y * 0.4f),
                width = right + (Cell.CellSize.X * 0.6f),
                height = bottom + (Cell.CellSize.Y * 0.6f)
            };

            var cells = grid.GetCellsInRectangle(rect);

            ApplyCollision(cells);
        }
    }
}
