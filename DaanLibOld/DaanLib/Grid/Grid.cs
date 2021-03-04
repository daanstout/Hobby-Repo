using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Grid {
    /// <summary>
    /// Represents a 2D Grid system where every cell has the same dimensions
    /// </summary>
    /// <typeparam name="T">The type of Cell this Grid is made up of</typeparam>
    public class Grid<T> where T : ICell {
        /// <summary>
        /// The cells in the Grid
        /// </summary>
        public readonly T[] grid;

        /// <summary>
        /// The dimensions of the Grid
        /// </summary>
        public readonly Size dimensions;

        /// <summary>
        /// The width of the Grid
        /// </summary>
        public int width => dimensions.Width;
        /// <summary>
        /// The height of the Grid
        /// </summary>
        public int height => dimensions.Height;
        /// <summary>
        /// The total size of the Grid
        /// </summary>
        public int size => width * height;

        /// <summary>
        /// Gets the element at the specified position
        /// </summary>
        /// <param name="x">The x-location of the element</param>
        /// <param name="y">The y-location of the element</param>
        /// <returns>The element at the requested position</returns>
        public T this[int x, int y] { 
            get => grid[y * width + x];
            set => grid[y * width + x] = value;
        }
        /// <summary>
        /// Gets the elemet at the specified index
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <returns>The element at the requested index</returns>
        public T this[int index] {
            get => grid[index];
            set => grid[index] = value;
        }

        /// <summary>
        /// Instantiates a new Grid
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        public Grid(int width, int height) : this(new Size(width, height)) { }

        /// <summary>
        /// Instantiates a new Grid
        /// </summary>
        /// <param name="dimensions">The dimensions of the Grid</param>
        public Grid(Size dimensions) {
            this.dimensions = dimensions;

            grid = new T[dimensions.Width * dimensions.Height];
        }

        /// <summary>
        /// Translates a coordinate to its corresponding index
        /// </summary>
        /// <param name="coord">The coordinate to translate</param>
        /// <returns>The index of the specified coordinate</returns>
        public int CoordToIndex(Point coord) => (coord.Y * width) + coord.X;

        /// <summary>
        /// Translates an index to its corresponding coordinate
        /// </summary>
        /// <param name="index">The index to translate</param>
        /// <returns>The coordinates of the index</returns>
        public Point IndexToCoord(int index) => new Point(index % width, index / width);

        /// <summary>
        /// Gets all horizontal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetHorizontalNeighbours(int index) => GetHorizontalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all horizontal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetHorizontalNeighbours(Point coord) {
            var neighbours = new List<T>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.X > 0)
                neighbours.Add(this[coord.X - 1, coord.Y]);

            if (coord.X < width - 1)
                neighbours.Add(this[coord.X + 1, coord.Y]);

            return neighbours;
        }

        /// <summary>
        /// Gets all vertical neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetVerticalNeighbours(int index) => GetVerticalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all vertical neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetVerticalNeighbours(Point coord) {
            var neighbours = new List<T>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.Y > 0)
                neighbours.Add(this[coord.X, coord.Y - 1]);

            if (coord.Y < height - 1)
                neighbours.Add(this[coord.X, coord.Y + 1]);

            return neighbours;
        }

        /// <summary>
        /// Gets all orthogonal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetOrthogonalNeighbours(int index) {
            var neighbours = GetHorizontalNeighbours(index);

            neighbours.AddRange(GetVerticalNeighbours(index));

            return neighbours;
        }

        /// <summary>
        /// Gets all orthogonal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetOrthogonalNeighbours(Point coord) {
            var neighbours = GetHorizontalNeighbours(coord);

            neighbours.AddRange(GetVerticalNeighbours(coord));

            return neighbours;
        }

        /// <summary>
        /// Gets all diagonal neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetDiagonalNeighbours(int index) => GetDiagonalNeighbours(IndexToCoord(index));

        /// <summary>
        /// Gets all diagonal neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coordinates of the central element</param>
        /// <returns>The neighbours of the element</returns>
        public List<T> GetDiagonalNeighbours(Point coord) {
            var neighbours = new List<T>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.X > 0 && coord.Y > 0)
                neighbours.Add(this[coord.X - 1, coord.Y - 1]);

            if (coord.X > 0 && coord.Y < height - 1)
                neighbours.Add(this[coord.X - 1, coord.Y + 1]);

            if (coord.X < width - 1 && coord.Y > 0)
                neighbours.Add(this[coord.X + 1, coord.Y - 1]);

            if (coord.X < width - 1 && coord.Y < height - 1)
                neighbours.Add(this[coord.X + 1, coord.Y + 1]);

            return neighbours;
        }

        /// <summary>
        /// Gets all neighbours of the element at the specified index
        /// </summary>
        /// <param name="index">The index of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetAllNeighbours(int index) {
            var neighbours = GetOrthogonalNeighbours(index);

            neighbours.AddRange(GetDiagonalNeighbours(index));

            return neighbours;
        }

        /// <summary>
        /// Gets all neighbours of the element at the specified coordinates
        /// </summary>
        /// <param name="coord">The coorindates of the central element</param>
        /// <returns>The neighbours of the cell</returns>
        public List<T> GetAllNeighbours(Point coord) {
            var neighbours = GetOrthogonalNeighbours(coord);

            neighbours.AddRange(GetDiagonalNeighbours(coord));

            return neighbours;
        }

        /// <summary>
        /// Checks to see if the coordinate is valid for this Grid
        /// </summary>
        /// <param name="coord">The coordinate to validate</param>
        /// <returns>True if the coordinate falls within the Grid</returns>
        public bool IsCoordValid(Point coord) => coord.X > 0 || coord.X < width || coord.Y > 0 || coord.Y < height;

        /// <summary>
        /// Checks to see if the index is valid for this Grid
        /// </summary>
        /// <param name="index">The index to validate</param>
        /// <returns>True if the index falls within the Grid</returns>
        public bool IsIndexValid(int index) => index > 0 && index < size;
    }
}
