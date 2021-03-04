using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A Graph that allows you to create a network of Verteces connected through Edges
    /// </summary>
    public class Graph {
        /// <summary>
        /// The list of Verteces
        /// </summary>
        protected List<Vertex> verteces = new List<Vertex>();

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        public Graph() { }

        /// <summary>
        /// Gets an array of all Verteces
        /// </summary>
        /// <returns>A copy of all Verteces</returns>
        public Vertex[] GetVertexArray() => verteces.ToArray();

        /// <summary>
        /// Registers a new Vertex to the Graph
        /// </summary>
        /// <param name="vertexName">The name of the Vertex</param>
        /// <exception cref="ArgumentException">Thrown if the name is either null or empty</exception>
        /// <returns>True if nothing went wrong</returns>
        public virtual bool RegisterVertex(string vertexName) {
            if (string.IsNullOrEmpty(vertexName))
                throw new ArgumentException("Vertex name cannot be null or empty");

            if (verteces.Any(vertex => vertex.name == vertexName))
                return false;

            verteces.Add(new Vertex(vertexName));

            return true;
        }

        /// <summary>
        /// Removes a Vertex from the graph, and all Edges that lead to that Vertex
        /// </summary>
        /// <param name="vertexName">The name of the Vertex to remove</param>
        /// <exception cref="ArgumentException">Thrown if the name is either null or empty</exception>
        /// <returns>True if a Vertex was succesfully removed</returns>
        public virtual bool RemoveVertex(string vertexName) {
            if (string.IsNullOrEmpty(vertexName))
                throw new ArgumentException("Vertex name cannot be null or empty");

            var vertex = verteces.FirstOrDefault(vertex => vertex.name == vertexName);

            if (vertex == null)
                return false;

            foreach (var vert in verteces) {
                var edgesToRemove = new List<Edge>();
                foreach (var edge in vert.edgeList) {
                    if (edge.destination == vertex)
                        edgesToRemove.Add(edge);
                }

                foreach (var edge in edgesToRemove)
                    vert.edgeList.Remove(edge);
            }

            verteces.Remove(vertex);

            return true;
        }

        /// <summary>
        /// Replaces an existing Vertex with a new "clean" Vertex, removing all Edges to it
        /// <para>If there is no Vertex with the given name present, nothing will happen</para>
        /// <para>If the Vertex should be added in the above case, consider using ReplaceOrAddVertex() instead</para>
        /// </summary>
        /// <param name="vertexName">The name of the Vertex to replace</param>
        /// <exception cref="ArgumentException">Thrown if the vertexName is either null or empty</exception>
        /// <returns>True if a Vertex was succesfully replaced</returns>
        public virtual bool ReplaceVertex(string vertexName) {
            try {
                if (!RemoveVertex(vertexName))
                    return false;

                return RegisterVertex(vertexName);
            }catch(ArgumentException ae) {
                throw ae;
            }
        }

        /// <summary>
        /// Replaces an existing Vertex, or simply adds it if it doesn't yet exist
        /// </summary>
        /// <param name="vertexName">The name of the Vertex</param>
        /// <exception cref="ArgumentException">Thrown if the vertexName is either null or empty</exception>
        /// <returns>True if the Vertex was succesfully replaced/added</returns>
        public virtual bool ReplaceOrAddVertex(string vertexName) {
            try {
                RemoveVertex(vertexName);

                return RegisterVertex(vertexName);
            }catch(ArgumentException ae) {
                throw ae;
            }
        }

        /// <summary>
        /// Gets the Vertex with the given name, or null if it doesn't exist
        /// </summary>
        /// <param name="vertexName">The name of the Vertex</param>
        /// <returns>The Vertex with the corresponding name</returns>
        public virtual Vertex GetVertex(string vertexName) => verteces.FirstOrDefault(vertex => vertex.name == vertexName);

        /// <summary>
        /// Indicates whether there exists a Vertex with a given name
        /// </summary>
        /// <param name="vertexName">The name to check against</param>
        /// <returns>True if there exists a Vertex with the given name</returns>
        public virtual bool ContainsVertex(string vertexName) => verteces.Any(vertex => vertex.name == vertexName);

        /// <summary>
        /// Registers an Edge between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The destination Vertex</param>
        /// <returns>True if an Edge has been added succesfully</returns>
        public virtual bool RegisterEdge(string from, string to) {
            var vertexFrom = GetVertex(from);
            var vertexTo = GetVertex(to);

            if (vertexFrom == null || vertexTo == null)
                return false;

            vertexFrom.AddEdge(vertexTo);

            return true;
        }

        /// <summary>
        /// Registers an Edge with a cost between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The destination Vertex</param>
        /// <param name="cost">The cost to travel over this Edge</param>
        /// <returns>True if an Edge has been added succesfully</returns>
        public virtual bool RegisterEdge(string from, string to, float cost) {
            var vertexFrom = GetVertex(from);
            var vertexTo = GetVertex(to);

            if (vertexFrom == null || vertexTo == null)
                return false;

            vertexFrom.AddEdge(vertexTo, cost);

            return true;
        }

        /// <summary>
        /// Gets the Edge cost between two Verteces, or -1 if said edge does not exist between the Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The destination Vertex</param>
        /// <exception cref="ArgumentException">Thrown if either one of the Verteces does not exist</exception>
        /// <returns>The cost to travel from start to destination</returns>
        public virtual float GetEdgeCost(string from, string to) {
            var vertexFrom = GetVertex(from);
            var vertexTo = GetVertex(to);

            if (vertexFrom == null || vertexTo == null)
                throw new ArgumentException($"Verteces do not exist: VertexFrom: {vertexFrom == null} - VertexTo: {vertexTo == null}");

            var edge = vertexFrom.edgeList.FirstOrDefault(edge => edge.destination == vertexTo);

            if (edge == null)
                return -1.0f;

            return edge.cost;
        }

        /// <summary>
        /// Updates the Edge cost between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The destination Vertex</param>
        /// <param name="cost">The new cost to travel over the Edge</param>
        /// <returns>True if the cost has been updated succesfully</returns>
        public virtual bool UpdateEdgeCost(string from, string to, float cost) {
            var vertexFrom = GetVertex(from);
            var vertexTo = GetVertex(to);

            if (vertexFrom == null || vertexTo == null)
                return false;

            var edge = vertexFrom.edgeList.FirstOrDefault(edge => edge.destination == vertexTo);

            if (edge == null)
                return false;

            edge.cost = cost;

            return true;
        }

        /// <summary>
        /// Registers Edges between two Verteces, both ways
        /// </summary>
        /// <param name="first">The first Vertex</param>
        /// <param name="second">The second Vertex</param>
        /// <returns>True if an Edge has been added succesfully</returns>
        public virtual bool RegisterEdges(string first, string second) {
            var vertexFrom = GetVertex(first);
            var vertexTo = GetVertex(second);

            if (vertexFrom == null || vertexTo == null)
                return false;

            vertexFrom.AddEdge(vertexTo);
            vertexTo.AddEdge(vertexFrom);

            return true;
        }

        /// <summary>
        /// Registers Edges between two Verteces, both ways
        /// </summary>
        /// <param name="first">The first Edge</param>
        /// <param name="second">The second Edge</param>
        /// <param name="cost">The cost to travel over this Edge</param>
        /// <returns>True if an Edge has been added succesfully</returns>
        public virtual bool RegisterEdges(string first, string second, float cost) {
            var vertexFrom = GetVertex(first);
            var vertexTo = GetVertex(second);

            if (vertexFrom == null || vertexTo == null)
                return false;

            vertexFrom.AddEdge(vertexTo, cost);
            vertexTo.AddEdge(vertexFrom, cost);

            return true;
        }

        /// <summary>
        /// Updates the Edge cost between two Verteces, both ways
        /// </summary>
        /// <param name="first">The first Vertex</param>
        /// <param name="second">The second Vertex</param>
        /// <param name="cost">The new Edge cost</param>
        /// <returns>True if both Edges has been updated succesfully, if only 1 has been updated, it will return false</returns>
        public virtual bool UpdateEdgesCost(string first, string second, float cost) {
            var vertexFirst = GetVertex(first);
            var vertexSecond = GetVertex(second);

            if (vertexFirst == null || vertexSecond == null)
                return false;

            var edge = vertexFirst.edgeList.FirstOrDefault(edge => edge.destination == vertexSecond);

            if (edge == null)
                return false;

            edge.cost = cost;

            edge = vertexSecond.edgeList.FirstOrDefault(edge => edge.destination == vertexFirst);

            if (edge == null)
                return false;

            edge.cost = cost;

            return true;
        }
    }
}
