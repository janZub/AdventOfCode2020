using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day7
{
    public class NodeCreatorServiceDay7
    {
        public GraphNodeDay7 CreateNode(GroupCollection matches)
        {
            var node = new GraphNodeDay7();

            node.Name = GetNameOfNode(matches);

            if (matches.Count == 4)
                AddNodesBelow(node, matches);

            return node;
        }
        
        private void AddNodesBelow(GraphNodeDay7 node, GroupCollection groups)
        {
            for (int i = 0; i < groups[3].Captures.Count; i++)
            {
                var name = GetNameOfNodeBelow(groups, i);
                var weight = GetWeightOfNodeBelow(groups, i);

                node.AddNodeBellow(name, weight);
            }
        }
        private string GetNameOfNode(GroupCollection groups)
        {
            var name = groups[1].Value.Trim();
            return name;
        }
        private string GetNameOfNodeBelow(GroupCollection groups, int position)
        {
            var name = groups[3].Captures[position].Value.Trim();
            return name;
        }
        private int GetWeightOfNodeBelow(GroupCollection groups, int position)
        {
            var weightCapture = groups[2].Captures[position].Value.Trim();

            if (!int.TryParse(weightCapture, out int weight))
                throw new Exception("Couldn't cast weight to int," +
                    " probably provided matches did not have matching number of bags names and weights");

            return weight;
        }

    }
}
