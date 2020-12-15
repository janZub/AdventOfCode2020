
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day7
{
    public class PuzzleSolverDay7
    {
        public int FindNumberConnectedNodes(Dictionary<string, GraphNodeDay7> graph, string searchedNode)
        {
            var nodesConnectedToSearchedNode = new HashSet<string>() { searchedNode };
            var keepSearching = true;

            while (keepSearching)
            {
                keepSearching = false;
                foreach (var node in graph)
                {
                    if (node.Value.ConnectedNodesBelow.Any(n => nodesConnectedToSearchedNode.Contains(n)))
                    {
                        if (nodesConnectedToSearchedNode.Add(node.Key))
                            keepSearching = true;
                    }
                }
            }
            return nodesConnectedToSearchedNode.Count - 1;
        }
    }
}