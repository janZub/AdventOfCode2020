
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
                    if (node.Value.ConnectedNodesBelow.Keys.Any(n => nodesConnectedToSearchedNode.Contains(n)))
                    {
                        if (nodesConnectedToSearchedNode.Add(node.Key))
                            keepSearching = true;
                    }
                }
            }
            nodesConnectedToSearchedNode.Remove(searchedNode);

            return nodesConnectedToSearchedNode.Count;
        }

        public long FindWeightInNode(Dictionary<string, GraphNodeDay7> graph, string searchedNode, HashSet<string> visitedNodes)
        {
            long weight = 1;

            if (!graph.ContainsKey(searchedNode))
                return 0;

            if (!visitedNodes.Add(searchedNode))
                return 1;

            if (graph[searchedNode].ConnectedNodesBelow.Count == 0)
                return 1;

            else
            {
                foreach (var nodeBelow in graph[searchedNode].ConnectedNodesBelow)
                {
                    weight += nodeBelow.Value * FindWeightInNode(graph, nodeBelow.Key, new HashSet<string>(visitedNodes));
                }
                return weight;
            }
        }
    }
}