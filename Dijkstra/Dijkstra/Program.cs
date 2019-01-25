using Dijkstra.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intial Graph and add all node
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            // Bind path weight between node
            graph.AddConnection("A", "B", 6);
            graph.AddConnection("A", "D", 1);
            graph.AddConnection("B", "D", 2);
            graph.AddConnection("B", "E", 2);
            graph.AddConnection("B", "C", 5);
            graph.AddConnection("D", "E", 1);
            graph.AddConnection("E", "C", 5);

            DijkstraAlgo algo = new DijkstraAlgo();
            // Let A is start node
            IDictionary<string, NodeRecord> result = algo.CalculateDistances(graph, "A");

            // print all shortest path of each node
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " shortest path:" + item.Value.lowestWeight + " previous node:" + item.Value.previousNode?.name);
            }



            Console.ReadLine();
        }
    }
}
