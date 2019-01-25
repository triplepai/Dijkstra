using System;
using System.Collections.Generic;
using Dijkstra.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra.Test
{

    [TestClass]
    public class DijkstraUnitTest
    {
        [TestMethod]
        public void Test_Initial_Node_In_Graph()
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            Assert.AreEqual(5, graph.nodeList.Count);
        }

        [TestMethod]
        public void Test_Binding_Path_In_Graph()
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            graph.AddConnection("A", "B", 6);
            graph.AddConnection("A", "D", 1);
            graph.AddConnection("B", "D", 2);
            graph.AddConnection("B", "E", 2);
            graph.AddConnection("B", "C", 5);
            graph.AddConnection("D", "E", 1);
            graph.AddConnection("E", "C", 5);

            Assert.AreEqual(2, graph.nodeList["A"].GetMinOrderConnectedNode().Count);
        }

        [TestMethod]
        public void Test_Binding_Path_Duplicate_Node_In_Graph()
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");

            graph.AddConnection("A", "B", 6);
            graph.AddConnection("A", "B", 6);
            graph.AddConnection("B", "A", 6);
            graph.AddConnection("B", "A", 6);

            Assert.AreEqual(1, graph.nodeList["A"].GetMinOrderConnectedNode().Count);
        }
        [TestMethod]
        public void Test_Exception_Node_No_Connection()
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddConnection("A", "B", 6);

            DijkstraAlgo algo = new DijkstraAlgo();
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() => algo.CalculateDistances(graph, "A"));
            Assert.AreEqual("all node must have connection", ex.Message);
        }

        [TestMethod]
        public void Test_Calculation_Shortest_Path()
        {

            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            graph.AddConnection("A", "B", 6);
            graph.AddConnection("A", "D", 1);
            graph.AddConnection("B", "D", 2);
            graph.AddConnection("B", "E", 2);
            graph.AddConnection("B", "C", 5);
            graph.AddConnection("D", "E", 1);
            graph.AddConnection("E", "C", 5);

            DijkstraAlgo algo = new DijkstraAlgo();
            IDictionary<string, NodeRecord> result = algo.CalculateDistances(graph, "A");
            Assert.AreEqual(7, result["C"].lowestWeight);
        }
        [TestMethod]
        public void Test_Exception_DuplicateNode()
        {
            Graph graph = new Graph();
            graph.AddNode("A");

            DijkstraAlgo algo = new DijkstraAlgo();
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() => graph.AddNode("A"));
            Assert.AreEqual("duplicate node", ex.Message);
        }
        [TestMethod]
        public void Test_Exception_Negative_Weight()
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");

            DijkstraAlgo algo = new DijkstraAlgo();
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() => graph.AddConnection("A", "B", -1));
            Assert.AreEqual("weight cannot negative number", ex.Message);
        }

    }
}
