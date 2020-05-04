using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// Represents an Edge between two Verteces
    /// </summary>
    public class Edge : IEquatable<Edge> {
        /// <summary>
        /// The source Vertex of this Edge
        /// </summary>
        public readonly Vertex source;
        /// <summary>
        /// The destination Vertex of this Edge
        /// </summary>
        public readonly Vertex destination;
        /// <summary>
        /// The cost to travel over this Edge
        /// </summary>
        public float cost;

        /// <summary>
        /// Instantiates a new Edge with a default travel cost
        /// </summary>
        /// <param name="source">The source Vertex</param>
        /// <param name="destination">The destination Vertex</param>
        public Edge(Vertex source, Vertex destination) : this(source, destination, 1.0f) { }

        /// <summary>
        /// Instantiates a new Edge with a certain travel cost
        /// </summary>
        /// <param name="source">The source Vertex</param>
        /// <param name="destination">The destination Vertex</param>
        /// <param name="cost">The cost to travel over this Edge</param>
        public Edge(Vertex source, Vertex destination, float cost) {
            this.source = source;
            this.destination = destination;
            this.cost = cost;
        }

        /// <summary>
        /// Checks whether this Edge and another object are equal to eachother
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True if this Edge and the other Edge are the same</returns>
        public override bool Equals(object obj) => Equals(obj as Edge);
        /// <summary>
        /// Checks whether this Edge and another Edge are equal to eachother
        /// </summary>
        /// <param name="other">The other Edge to compare to</param>
        /// <returns>True if this Edge and the other Edge are the same</returns>
        public bool Equals(Edge other) => other != null && EqualityComparer<Vertex>.Default.Equals(source, other.source) && EqualityComparer<Vertex>.Default.Equals(destination, other.destination) && cost == other.cost;

        /// <summary>
        /// Gets the HashCode for this Edge
        /// </summary>
        /// <returns>The calculated HashCode</returns>
        public override int GetHashCode() {
            int hashCode = 1014330407;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(source);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(destination);
            hashCode = hashCode * -1521134295 + cost.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares two Edges against eachother for equality
        /// </summary>
        /// <param name="left">The left Edge to compare against</param>
        /// <param name="right">The right Edge to compare with</param>
        /// <returns>True if the Edges are equal to eachother</returns>
        public static bool operator ==(Edge left, Edge right) => EqualityComparer<Edge>.Default.Equals(left, right);
        /// <summary>
        /// Compares two Edges against eachoter for inequality
        /// </summary>
        /// <param name="left">The left Edge to compare against</param>
        /// <param name="right">The right Edge to compare with</param>
        /// <returns>True if the Edges are not equal to eachother</returns>
        public static bool operator !=(Edge left, Edge right) => !(left == right);
    }
}
