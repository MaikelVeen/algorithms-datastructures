using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures
{
    /// <summary>
    /// Data structure implementation for a weighted simple graph
    /// </summary>
    public class Graph<T> where T : IComparable
    {
        /// <summary>
        /// Creates an empty graph
        /// </summary>
        public Graph()
        {
        }

        /// <summary>
        /// Creates an graph with vertices based on vertex data
        /// but with no edges
        /// </summary>
        /// <param name="value"></param>
        public Graph(T value)
        {
            AddVertex(value, Count);
        }

        /// <summary>
        /// Creates an graph with vertices based on vertex data
        /// but with no edges
        /// </summary>
        /// <param name="values"></param>
        public Graph(IEnumerable<T> values)
        {
            InitValues(values);
        }

        /// <summary>
        /// Creates a graph with vertices and edges based on given
        /// vertex data and edges
        /// Tuple must contain valid indexes for vertices
        /// </summary>
        /// <param name="values"></param>
        /// <param name="edges"></param>
        public Graph(IEnumerable<T> values, IEnumerable<Tuple<int, int>> edges)
        {
            InitValues(values);
            foreach (Tuple<int, int> edge in edges)
            {
                SetEdge(edge);
            }
        }

        // Extracted helper function because it is used in multiple constructors
        private void InitValues(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                AddVertex(value, Count, false);
            }

            ResizeAdjacencyMatrix();
        }
        
        /// <summary>
        /// All the vertices currently part of this graph
        /// </summary>
        private List<Vertex<T>> Vertices { get; set; } = new List<Vertex<T>>();
        
        /// <summary>
        /// Adjacency matrix that describes the edges of the graph
        /// </summary>
        public int[,] AdjacencyMatrix { get; private set; }
        
        /// <summary>
        /// The number of vertices in the graph
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds a new vertex to the graph, returns the index of the added vertex
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int AddVertex(T data)
        {
            int index = Count;
            AddVertex(data, index);
            return index;
        }

        private void AddVertex(T data, int index, bool automaticResize = true)
        {
            Count++;
            Vertex<T> vertex = new Vertex<T>(index, data);
            Vertices.Add(vertex);
            if (automaticResize)
            {
                ResizeAdjacencyMatrix();
            }
        }

        /// <summary>
        /// Adds an edge between two indexed vertices with a given weight to the graph.
        /// Indexes must exist.
        /// Default weight is 1.
        /// </summary>
        /// <param name="edge">Tuple that describes from which index to which index</param>
        /// <param name="weight"></param>
        public void SetEdge(Tuple<int, int> edge, int weight = 1)
        {
            if (edge.Item1 > Count - 1 || edge.Item2 > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            AdjacencyMatrix[edge.Item1, edge.Item2] = weight;
            AdjacencyMatrix[edge.Item2, edge.Item1] = weight;
        }

        /// <summary>
        /// Returns the weight of edge between two vertexes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int GetEdgeWeight(int from, int to)
        {
            if (from > Count - 1 || to > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return AdjacencyMatrix[from, to];
        }

        /// <summary>
        /// Resizes the adjacency matrix after an vertex is added
        /// </summary>
        private void ResizeAdjacencyMatrix()
        {
            if (AdjacencyMatrix != null && AdjacencyMatrix.GetLength(0) != Count)
            {
                int[,] newMatrix = new int[Count, Count];

                for (int x = 0; x < AdjacencyMatrix.GetLength(0); x++)
                {
                    for (int y = 0; y < AdjacencyMatrix.GetLength(0); y++)
                    {
                        newMatrix[x, y] = AdjacencyMatrix[x, y];
                    }
                }

                AdjacencyMatrix = newMatrix;
            }
            else
            {
                AdjacencyMatrix = new int[Count, Count];
            }
        }
        
        /// <summary>
        /// Returns a list with indexes of vertices that are connected to
        /// the vertex with given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<int> GetAdjacentVertex(int index)
        {
            List<int> adjacentIndexes = new List<int>();
            for (int i = 0; i < Count; i++)
            {
                int weight = AdjacencyMatrix[index, i];
                if (weight > 0)
                {
                    adjacentIndexes.Add(i);
                }
            }

            return adjacentIndexes;
        }

        /// <summary>
        /// Returns sequence string of data in graph when visiting all vertices
        /// using Breadth-First-Traversal
        /// </summary>
        /// <returns></returns>
        public string BreadthFirstTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(0);
            while (queue.Count != 0)
            {
                int currentIndex = queue.Dequeue();
                visited.Add(currentIndex);

                stringBuilder.Append(AtIndex(currentIndex).Data.ToString());

                List<int> neighbours = GetAdjacentVertex(currentIndex);
                foreach (int neighbourIndex in neighbours)
                {
                    if (!visited.Contains(neighbourIndex) && queue.Contains(neighbourIndex) == false)
                    {
                        queue.Enqueue(neighbourIndex);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns sequence string of data in graph when visiting all vertices
        /// using Depth-First-Traversal
        /// </summary>
        /// <returns></returns>
        public string DepthFirstTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(0);
            while (stack.Count != 0)
            {
                int currentVertex = stack.Pop();
                if (visited.Contains(currentVertex)) continue;

                visited.Add(currentVertex);
                stringBuilder.Append(AtIndex(currentVertex).Data.ToString());

                List<int> neighbours = GetAdjacentVertex(currentVertex);
                neighbours.Reverse();
                foreach (int neighbourIndex in neighbours)
                {
                    if (!visited.Contains(neighbourIndex) && stack.Contains(neighbourIndex) == false)
                    {
                        stack.Push(neighbourIndex);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the Vertex at a specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vertex<T> AtIndex(int index)
        {
            return Vertices.Find(x => x.Index.Equals(index));
        }
        
        // TODO Implement Dijkstra Algorithm 
        
        // TODO Implement Floyd-Warschall Algorithm
    }

    /// <summary>
    /// Encapsulation class for a vertex in a graph
    /// </summary>
    /// <typeparam name="T">Generic type for satellite data</typeparam>
    public class Vertex<T>
    {
        public Vertex(int index, T data)
        {
            Index = index;
            Data = data;
        }

        public int Index { get; set; }
        public T Data { get; set; }
    }
}