using System;
using System.Collections.Generic;
using System.Linq;
namespace Dijkstra.Lib
{
    public class Graph
    {
        // This variable for keep node list in Graph 
        public IDictionary<string, Node> nodeList { get; private set; }
        public Graph()
        {
            // Inital list when new Graph object 
            nodeList = new Dictionary<string, Node>();
        }

        public void AddNode(string name)
        {
            if (nodeList.FirstOrDefault(c => c.Key == name).Key != null)
            {
                throw new ArgumentException("duplicate node");
            }
            else
            {
                var node = new Node(name);
                nodeList.Add(name, node);
            }

        }

        public void AddConnection(string fromNode, string toNode, int weight)
        {
            // Make sure weight is not negative number
            if (weight < 0)
            {
                throw new ArgumentException("weight cannot negative number");
            }

            // When add connection between two node then need to do two way binding
            // Check connected node must not duplicate 
            if (nodeList[fromNode].connectedNode.FirstOrDefault(c => c.name == toNode) == null)
            {
                nodeList[fromNode].AddConnection(nodeList[toNode], weight);
            }
            if (nodeList[toNode].connectedNode.FirstOrDefault(c => c.name == fromNode) == null)
            {
                nodeList[toNode].AddConnection(nodeList[fromNode], weight);
            }
        }

    }
}
