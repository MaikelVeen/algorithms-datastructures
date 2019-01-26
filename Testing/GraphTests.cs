using System;
using System.Collections.Generic;
using System.Text;
using Data_Structures;
using Xunit;

namespace Testing
{
    public class GraphTests
    {
        private Graph<string> graph;

        private readonly string[] graphData = new[] {"A", "B", "C", "D", "E", "F", "G"};

        private readonly Tuple<int, int>[] edges = new[]
        {
            new Tuple<int, int>(0,1),
            new Tuple<int, int>(1,2),
            new Tuple<int, int>(2,3),
            new Tuple<int, int>(0,4),
            new Tuple<int, int>(4,1),
            new Tuple<int, int>(1,5),
            new Tuple<int, int>(5,2),
            new Tuple<int, int>(2,6),
            new Tuple<int, int>(6,3)

        };
        
        private readonly string[] graphDijkstra = new[] {"A", "B", "C", "D", "E", "F"};
        
        private const string BreadthTraversal = "ABECFDG";
        private const string DepthTraversal = "ABCDGFE";

        public GraphTests()
        {
            graph = new Graph<string>();
        }

        #region Initialization Tests

        [Fact]
        public void InitialSizeZero()
        {
            Assert.Equal(0, graph.Count);
        }

        [Fact]
        public void InitWithSingleVertex()
        {
            graph = new Graph<string>("A");
            Assert.Equal(1, graph.Count);
            Assert.Equal("A", graph.AtIndex(0).Data);
        }

        [Fact]
        public void InitWithVertices()
        {
            graph = new Graph<string>(new []{"A","B","C"});
            Assert.Equal(3, graph.Count);
            Assert.Equal("A", graph.AtIndex(0).Data);
            Assert.Equal("B", graph.AtIndex(1).Data);
            Assert.Equal("C", graph.AtIndex(2).Data);
            
            Assert.Equal(3, graph.AdjancencyMatrix.GetLength(0));
            Assert.Equal(3, graph.AdjancencyMatrix.GetLength(1));
        }
        
        [Fact]
        public void InitWithVerticesAndEdges()
        {
            graph = new Graph<string>(graphData,edges);
            Assert.Equal(7, graph.Count);
            Assert.Equal("A", graph.AtIndex(0).Data);
            Assert.Equal("G", graph.AtIndex(6).Data);
            
            Assert.Equal(1,graph.GetEdgeWeight(0,1));
            // Should be only one direction, so value should be same
            Assert.Equal(1,graph.GetEdgeWeight(1,0));
            
            Assert.Equal(1,graph.GetEdgeWeight(1,2));
            Assert.Equal(1,graph.GetEdgeWeight(2,3));
            
            Assert.Equal(1,graph.GetEdgeWeight(0,4));
            Assert.Equal(1,graph.GetEdgeWeight(4,1));
            Assert.Equal(1,graph.GetEdgeWeight(1,5));
            
            Assert.Equal(1,graph.GetEdgeWeight(5,2));
            Assert.Equal(1,graph.GetEdgeWeight(2,6));
            Assert.Equal(1,graph.GetEdgeWeight(6,3));
        }

        #endregion

        #region Adding Tests

        // TODO add vertex and edge adding tests

        #endregion

        #region Traversal Tests


        [Fact]
        public void TestAdjacentFetching()
        {
            graph = new Graph<string>(graphData, edges);

            List<int> adjacentToA = graph.GetAdjacentVertex(0);
            Assert.Contains(4, adjacentToA);
            Assert.Contains(1, adjacentToA);
            Assert.DoesNotContain(3, adjacentToA);
            
            
            List<int> adjacentToC = graph.GetAdjacentVertex(2);
            Assert.Contains(1, adjacentToC);
            Assert.Contains(3, adjacentToC);
            Assert.Contains(5, adjacentToC);
            Assert.Contains(6, adjacentToC);
            Assert.DoesNotContain(0, adjacentToA);
        }

        #endregion

        #region Dijkstra Tests

        

        #endregion

        #region Floyd Warschall Tests

        

        #endregion
    }
}