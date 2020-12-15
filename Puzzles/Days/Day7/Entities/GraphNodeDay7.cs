using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day7
{
    public class GraphNodeDay7
    {
        public virtual string Name { get; set; }
        public virtual HashSet<string> ConnectedNodesBelow { get; private set; }
        public virtual HashSet<string> ConnectedNodesUp { get; private set; }
        public GraphNodeDay7()
        {
            ConnectedNodesBelow = new HashSet<string>();
            ConnectedNodesUp = new HashSet<string>();
        }
        public void AddNodeBellow(string node)
        {
            ConnectedNodesBelow.Add(node);
        }
        public void AddNodeUp(string node)
        {
            ConnectedNodesUp.Add(node);
        }
    }
}