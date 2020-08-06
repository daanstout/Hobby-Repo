using System.Collections.Generic;
using System.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Roguelike.ECS.Components;
using Roguelike.Graphics;
using Roguelike.Utils;

namespace Roguelike.GridSystem {
    /// <summary>
    /// Represents a 2D Grid system where every cell has the same dimensions
    /// </summary>
    /// <typeparam name="Cell">The type of Cell this Grid is made up of</typeparam>
    public class Grid {
        /// <summary>
        /// The cells in the Grid
        /// </summary>
        public readonly Cell[] grid;

        /// <summary>
        /// The dimensions of the Grid
        /// </summary>
        public readonly Vector2 dimensions;

        /// <summary>
        /// The width of the Grid
        /// </summary>
        public int Width => (int)dimensions.X;
        /// <summary>
        /// The height of the Grid
        /// </summary>
        public int Height => (int)dimensions.Y;
        /// <summary>
        /// The total size of the Grid
        /// </summary>
        public int Size => Width * Height;

        /// <summary>
        /// Gets the element at the specified position
        /// </summary>
        /// <param name="x">The x-location of the element</param>
        /// <param name="y">The y-location of the element</param>
        /// <returns>The element at the requested position</returns>
        public Cell this[int x, int y] {
            get => grid[y * Width + x];
            set => grid[y * Width + x] = value;
        }
        /// <summary>
        /// Gets the elemet at the specified index
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <returns>The element at the requested index</returns>
        public Cell this[int index] {
            get => grid[index];
            set => grid[index] = value;
        }

        public Cell this[float x, float y] {
            get => grid[(int)y * Width + (int)x];
            set => grid[(int)y * Width + (int)x] = value;
        }

        /// <summary>
        /// Instantiates a new Grid
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        public Grid(int width, int height) : this(new Vector2(width, height)) { }

        /// <summary>
        /// Instantiates a new Grid
        /// </summary>
        /// <param name="dimensions">The dimensions of the Grid</param>
        public Grid(Vector2 dimensions) {
            this.dimensions = dimensions;

            grid = new Cell[Size];
        }

        public void Initialize() {
            for (int i = 0; i < Size; i++) {
                int x = (i % Width);
                int y = (i / Width);

                var sprite = "Floor";
                if (x == 0)
                    sprite = "WallLeft";
                if (y == 0)
                    sprite = "WallTop";
                if (x == Width - 1)
                    sprite = "WallRight";
                if (y == Height - 1)
                    sprite = "WallBot";

                grid[i] = new Cell(new Vector2(x * (int)Cell.CellSize.X, y * (int)Cell.CellSize.Y)) {
                    tileName = sprite,
                    traversable = sprite == "Floor",
                    isWall = sprite != "Floor"
                };
            }
        }

        public MapHitboxComponent GenerateMapHitbox() {
            return new MapHitboxComponent(this);
        }

        public Cell[] GetCellsInRectangle(RectangleF rectangle) {
            var xStart = (int)(rectangle.x / Cell.CellSize.X);
            var yStart = (int)(rectangle.y / Cell.CellSize.Y);
            var xStop = (int)(rectangle.width / Cell.CellSize.X);
            var yStop = (int)(rectangle.height / Cell.CellSize.Y);

            int count = (xStop - xStart + 1) * (yStop - yStart + 1);

            Cell[] cells = new Cell[count];

            int cellIndex = 0;

            for(int x = xStart; x <= xStop; x++) {
                for(int y = yStart; y <= yStop; y++) {
                    cells[cellIndex] = grid[y * Width + x];
                    cellIndex++;
                }
            }

            return cells;
        }

        /// <summary>
        /// Translates a coordinate to its corresponding index
        /// </summary>
        /// <param name="coord">The coordinate to translate</param>
        /// <returns>The index of the specified coordinate</returns>
        public int CoordToIndex(Vector2 coord) => ((int)coord.Y * Width) + (int)coord.X;

        /// <summary>
        /// Translates an index to its corresponding coordinate
        /// </summary>
        /// <param name="index">The index to translate</param>
        /// <returns>The coordinates of the index</returns>
        public Vector2 IndexToCoord(int index) => new Vector2(index % Width, index / Width);

        /// <summary>
        /// Gets all horizontal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetHorizontalNeighbours(int index) => GetHorizontalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all horizontal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetHorizontalNeighbours(Vector2 coord) {
            var neighbours = new List<Cell>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.X > 0)
                neighbours.Add(this[coord.X - 1, coord.Y]);

            if (coord.X < Width - 1)
                neighbours.Add(this[coord.X + 1, coord.Y]);

            return neighbours;
        }

        /// <summary>
        /// Gets all vertical neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetVerticalNeighbours(int index) => GetVerticalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all vertical neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetVerticalNeighbours(Vector2 coord) {
            var neighbours = new List<Cell>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.Y > 0)
                neighbours.Add(this[coord.X, coord.Y - 1]);

            if (coord.Y < Height - 1)
                neighbours.Add(this[coord.X, coord.Y + 1]);

            return neighbours;
        }

        /// <summary>
        /// Gets all orthogonal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetOrthogonalNeighbours(int index) {
            var neighbours = GetHorizontalNeighbours(index);

            neighbours.AddRange(GetVerticalNeighbours(index));

            return neighbours;
        }

        /// <summary>
        /// Gets all orthogonal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetOrthogonalNeighbours(Vector2 coord) {
            var neighbours = GetHorizontalNeighbours(coord);

            neighbours.AddRange(GetVerticalNeighbours(coord));

            return neighbours;
        }

        /// <summary>
        /// Gets all diagonal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetDiagonalNeighbours(int index) => GetDiagonalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all diagonal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the element</returns>
        public List<Cell> GetDiagonalNeighbours(Vector2 coord) {
            var neighbours = new List<Cell>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.X > 0 && coord.Y > 0)
                neighbours.Add(this[coord.X - 1, coord.Y - 1]);

            if (coord.X > 0 && coord.Y < Height - 1)
                neighbours.Add(this[coord.X - 1, coord.Y + 1]);

            if (coord.X < Width - 1 && coord.Y > 0)
                neighbours.Add(this[coord.X + 1, coord.Y - 1]);

            if (coord.X < Width - 1 && coord.Y < Height - 1)
                neighbours.Add(this[coord.X + 1, coord.Y + 1]);

            return neighbours;
        }

        /// <summary>
        /// Gets all neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetAllNeighbours(int index) {
            var neighbours = GetOrthogonalNeighbours(index);

            neighbours.AddRange(GetDiagonalNeighbours(index));

            return neighbours;
        }

        /// <summary>
        /// Gets all neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coorindates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<Cell> GetAllNeighbours(Vector2 coord) {
            var neighbours = GetOrthogonalNeighbours(coord);

            neighbours.AddRange(GetDiagonalNeighbours(coord));

            return neighbours;
        }

        /// <summary>
        /// Checks to see if the coordinate is valid for this Grid
        /// </summary>
        /// <param name="coord">The coordinate to validate</param>
        /// <returns>True if the coordinate falls within the Grid</returns>
        public bool IsCoordValid(Vector2 coord) => coord.X >= 0 || coord.X < Width || coord.Y >= 0 || coord.Y < Height;

        /// <summary>
        /// Checks to see if the index is valid for this Grid
        /// </summary>
        /// <param name="index">The index to validate</param>
        /// <returns>True if the index falls within the Grid</returns>
        public bool IsIndexValid(int index) => index > 0 && index < Size;

        public void DrawGrid(DrawData drawData) {
            foreach (var cell in grid)
                cell.Draw(drawData);
        }

        public void LoadContent() {
            foreach (var cell in grid)
                cell.Load();
        }
    }
}
