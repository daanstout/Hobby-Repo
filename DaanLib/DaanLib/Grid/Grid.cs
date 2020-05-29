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
    public class Grid<T> where T : ICell {
        public readonly T[] grid;

        public Size dimensions;

        public int width => dimensions.Width;
        public int height => dimensions.Height;
        public int size => width * height;

        public T this[int x, int y] => grid[y * width + x];
        public T this[int index] => grid[index];

        public Grid(int width, int height) : this(new Size(width, height)) { }

        public Grid(Size dimensions) {
            this.dimensions = dimensions;

            grid = new T[dimensions.Width * dimensions.Height];
        }

        public int CoordToIndex(Point coord) => (coord.Y * width) + coord.X;

        public Point IndexToCoord(int index) => new Point(index % width, index / width);

        public List<T> GetHorizontalNeighbours(int index) => GetHorizontalNeighbours(IndexToCoord(index));

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

        public List<T> GetVerticalNeighbours(int index) => GetVerticalNeighbours(IndexToCoord(index));

        public List<T> GetVerticalNeighbours(Point coord) {
            var neighbours = new List<T>();

            if (!IsCoordValid(coord))
                return neighbours;

            if (coord.Y > 0)
                neighbours.Add(this[coord.X, coord.Y - 1]);

            if (coord.Y < height - 1)
                neighbours.Add(this[coord.X, coord.Y - 1]);

            return neighbours;
        }

        public List<T> GetOrthogonalNeighbours(int index) {
            var neighbours = GetHorizontalNeighbours(index);

            neighbours.AddRange(GetVerticalNeighbours(index));

            return neighbours;
        }

        public List<T> GetOrthogonalNeighbours(Point coord) {
            var neighbours = GetHorizontalNeighbours(coord);

            neighbours.AddRange(GetVerticalNeighbours(coord));

            return neighbours;
        }

        public List<T> GetDiagonalNeighbours(int index) => GetDiagonalNeighbours(IndexToCoord(index));

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

        public List<T> GetAllNeighbours(int index) {
            var neighbours = GetOrthogonalNeighbours(index);

            neighbours.AddRange(GetDiagonalNeighbours(index));

            return neighbours;
        }

        public List<T> GetAllNeighbours(Point coord) {
            var neighbours = GetOrthogonalNeighbours(coord);

            neighbours.AddRange(GetDiagonalNeighbours(coord));

            return neighbours;
        }


        public bool IsCoordValid(Point coord) => coord.X > 0 || coord.X < width || coord.Y > 0 || coord.Y < height;

        public bool IsIndexValid(int index) => index > 0 && index < size;
    }
}
