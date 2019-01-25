using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Lib
{
    /// <summary>
    ///  This class for keep record shortest path while calculation
    /// </summary>
    public class NodeRecord
    {
        public Node previousNode;
        public int lowestWeight;
        public Node node;
    }
}
