using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Puzzles.Day7
{
    public class InputHandlerServiceDay7
    {
        //should be dependency injection and mocked in tests?
        //or such small classes that are product of privet methods should not be injected?
        //IMO shouldn't, maybe when the class grows
        private NodeCreatorServiceDay7 nodeCreator = new NodeCreatorServiceDay7();
        private RegexMatcherServiceDay7 regexMatcher = new RegexMatcherServiceDay7();

        public Dictionary<string, GraphNodeDay7> AddNode(Dictionary<string, GraphNodeDay7> nodes, GraphNodeDay7 newNode)
        {
            var newNodes = new Dictionary<string, GraphNodeDay7>(nodes);

            var key = newNode.Name;
            if (newNodes.ContainsKey(key))
            {
                var existingNode = newNodes[key];

                foreach (var nodebelow in existingNode.ConnectedNodesBelow)
                    newNode.ConnectedNodesBelow.TryAdd(nodebelow.Key, nodebelow.Value);

                newNodes[key] = newNode;
            }
            else
                newNodes.Add(key, newNode);

            return newNodes;
        }

        public GraphNodeDay7 CreateNodeWithNodesBelow(string input)
        {
            var matches = regexMatcher.GetMatches(input);
            var node = nodeCreator.CreateNode(matches);

            return node;
        }
    }
}