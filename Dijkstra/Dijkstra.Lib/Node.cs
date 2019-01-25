using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Lib
{
    /// <summary>
    ///  This class is for individual Node it have name , weight and connected to another node list
    ///  Add IComparable for make a priority queue (dequeue by get lowest weight)
    /// </summary>
    public class Node : IComparable<Node>
    {
        internal List<Node> connectedNode { get; private set; }
        public string name;
        public int weight;

        public int CompareTo(Node other)
        {
            // Alphabetic sort if weight is equal from A to Z
            if (this.weight == other.weight)
            {
                return this.name.CompareTo(other.name);
            }
            // Weight sort from low to high
            return this.weight.CompareTo(other.weight);
        }

        public Node Dequeue()
        {
            // Get lowest weight value of connectedNode then return and remove
            Node result = connectedNode.First();
            connectedNode.Remove(result);
            return result;
        }
        public List<Node> GetMinOrderConnectedNode()
        {
            return this.connectedNode.OrderBy(c => c.weight).ToList();
        }

        public Node(string name)
        {
            // when create new Node object then assign node name
            connectedNode = new List<Node>();
            this.name = name;
        }
        public void AddConnection(Node node, int weight)
        {
            //Enqueue
            // New Node object to prevent reference value
            var obj = new Node(node.name);
            obj.weight = weight;
            connectedNode.Add(obj);
            // After add new connectedNode need to re sort again it will trigger CompareTo function
            connectedNode.Sort();

        }
    }
}
