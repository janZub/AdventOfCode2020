using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Puzzles.Day7
{
    public class InputHandlerServiceDay7
    {
        public Dictionary<string, GraphNodeDay7> AddNode(Dictionary<string, GraphNodeDay7> nodes, GraphNodeDay7 newNode)
        {
            var newNodes = new Dictionary<string, GraphNodeDay7>(nodes);

            var key = newNode.Name;
            if (newNodes.ContainsKey(key))
            {
                var existingNode = newNodes[key];
                newNode.ConnectedNodesBelow.UnionWith(existingNode.ConnectedNodesBelow);
                newNode.ConnectedNodesUp.UnionWith(existingNode.ConnectedNodesUp);
            }
            else
                newNodes.Add(key, newNode);

            return newNodes;
        }
        public GraphNodeDay7 CreateNode(string input)
        {
            var node = new  GraphNodeDay7();
            var matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
                throw new ArgumentException("Input string not correct, no match with pattern.","input");

            node.Name = matches[0].Groups[1].Value.Trim();
            var nodesBelow = matches[0].Groups[3].Captures.Select(v => v.Value.Trim());
            
            foreach (var nb in nodesBelow)
            {
                if (nb == "no other")
                    continue;

                node.AddNodeBellow(nb);
            }


            return node;
        }

        private string pattern = @"([a-z\s]*)\sbags\scontain([\s\d]*\s([a-z\s]*)bags?[,|\.])*";

    }
}