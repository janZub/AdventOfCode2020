using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day7
{
    public class GraphNodeDay7
    {
        public virtual string Name { get; set; }
        public virtual Dictionary<string, int> ConnectedNodesBelow { get; private set; }
        public GraphNodeDay7()
        {
            ConnectedNodesBelow = new Dictionary<string, int>();
        }
        public void AddNodeBellow(string node, int wieght = 1)
        {
            ConnectedNodesBelow.Add(node, wieght);
        }
    }
}