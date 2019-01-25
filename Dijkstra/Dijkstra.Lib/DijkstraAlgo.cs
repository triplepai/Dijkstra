using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.Lib
{

    /// <summary>
    ///  This class for add node in graph and binding path between node
    /// </summary>

    public class DijkstraAlgo
    {
        // This variable for store visited node and unvisited node in type of boolean flag
        IDictionary<string, bool> isVisitedNodeList;
        // This variable for keep node record about lowest weight , previousNode
        IDictionary<string, NodeRecord> nodeTableRecord;
        public IDictionary<string, NodeRecord> CalculateDistances(Graph graph, string startNode)
        {
            // Validate all node must have connection
            if (graph.nodeList.FirstOrDefault(c => c.Value.connectedNode.Count == 0).Key != null)
            {  
                throw new ArgumentException("all node must have connection");
            }


            nodeTableRecord = new Dictionary<string, NodeRecord>();
            isVisitedNodeList = new Dictionary<string, bool>();

            // 1. Initial node table record and add node in unvisited list
            foreach (var item in graph.nodeList)
            {
                // Add node and set shortest path to infinite
                nodeTableRecord.Add(item.Key, new NodeRecord { node = item.Value, previousNode = null, lowestWeight = int.MaxValue });
                // Add node to unvisited list by set isVisited flag = false
                isVisitedNodeList.Add(item.Key, false);
            }

            bool isProcessing = true;
            string currentNode = startNode;
            string nextNode = "";

            // 2. For start node set lowest weight = 0
            nodeTableRecord[currentNode].lowestWeight = 0;

            while (isProcessing)
            {
                // 3. Set current node to be visited node
                isVisitedNodeList[currentNode] = true;

                //  4. Set the next node by get lowest weight connected node of current node and connected node must not be visited node
                nextNode = graph.nodeList[currentNode].GetMinOrderConnectedNode().
                   FirstOrDefault(c => isVisitedNodeList.FirstOrDefault(p => p.Key == c.name).Value == false)?.name;

                // 5. Loop until connected node of current node is empty
                while (graph.nodeList[currentNode].connectedNode.Count > 0)
                {
                    // 5.1 Dequeue (get lowest weight) connected node
                    Node connectedNode = graph.nodeList[currentNode].Dequeue();

                    // 5.2 If this node still not visited
                    if (isVisitedNodeList[connectedNode.name] == false)
                    {
                        // 5.3 Update lowest weight if in node table record have lowest weight more than current lowest weight node + connected node weight
                        if (nodeTableRecord[connectedNode.name].lowestWeight > connectedNode.weight + nodeTableRecord[currentNode].lowestWeight)
                        {
                            // Set lowest weight
                            nodeTableRecord[connectedNode.name].lowestWeight = connectedNode.weight + nodeTableRecord[currentNode].lowestWeight;
                            // Set previous node for track back propose
                            nodeTableRecord[connectedNode.name].previousNode = graph.nodeList[currentNode];
                        }
                    }
                }

                // 6. If no unvisited node then end this loop
                if (isVisitedNodeList.FirstOrDefault(c => c.Value == false).Key == null)
                {
                    isProcessing = false;
                    break;
                }

                // 7. Set next current node and back to No 3.
                currentNode = nextNode;
            }
            // After end of loop (no unvisited node) then return the result
            return nodeTableRecord;
        }
    }

}
