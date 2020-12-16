using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Puzzles.Day7
{
    public class InputHandlerServiceDay7
    {
        private string pattern = @"([a-z\s]*)\sbags\scontain(?:\s([\d])*\s([a-z\s]*)bags?[,|\.])*";

        public Dictionary<string, GraphNodeDay7> AddNode(Dictionary<string, GraphNodeDay7> nodes, GraphNodeDay7 newNode)
        {
            var newNodes = new Dictionary<string, GraphNodeDay7>(nodes);

            var key = newNode.Name;
            if (newNodes.ContainsKey(key))
            {
                var existingNode = newNodes[key];
                foreach (var nodebelow in existingNode.ConnectedNodesBelow)
                    newNode.ConnectedNodesBelow.TryAdd(nodebelow.Key, nodebelow.Value);
            }
            else
                newNodes.Add(key, newNode);

            return newNodes;
        }

        public GraphNodeDay7 CreateNodeWithNodesBelow(string input)
        {
            var matches = GetMatches(input);
            var node = SetUpNode(matches);

            return node;
        }

        private GraphNodeDay7 SetUpNode(GroupCollection matches)
        {
            var node = new GraphNodeDay7();

            node.Name = matches[1].Value.Trim();

            if (matches.Count == 4)
            {
                for (int i = 0; i < matches[3].Captures.Count; i++)
                {
                    var values = GetNodeNameAndWeight(matches, i);
                    node.AddNodeBellow(values.Item1, values.Item2);
                }
            }
            return node;
        }

        private Tuple<string, int> GetNodeNameAndWeight(GroupCollection groups, int position)
        {
            var name = groups[3].Captures[position].Value.Trim();
            var weightCapture = groups[2].Captures[position].Value.Trim();

            if (!int.TryParse(weightCapture, out int weight))
                throw new Exception("Couldn't cast weight to int," +
                    " probably provided matches did not have matching number of bags names and weights");

            return new Tuple<string, int>(name, weight);
        }

        private GroupCollection GetMatches(string input)
        {
            var matches = Regex.Matches(input, pattern);

            if (!matches.Any() || matches[0].Groups.Count == 0)
                throw new ArgumentException("Input string not correct, no match with pattern.", "input");

            var matchedGroups = matches[0].Groups;

            if (matchedGroups.Count == 4 && (matchedGroups[2].Captures.Count != matchedGroups[3].Captures.Count))
                throw new Exception("Input do not have matching number of bags names and weights");

            return matchedGroups;
        }
    }
}