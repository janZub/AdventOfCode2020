using FluentAssertions;
using Moq;
using Puzzles.Day7;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day7
{
    public class GraphNodeDay7Tests
    {
        [Theory]
        [MemberData(nameof(AddNodeData))]
        public void Should_AddNodeBellow(string node, HashSet<string> expectedNodes)
        {
            var graph = new GraphNodeDay7();

            graph.AddNodeBellow(node);
            Assert.Equal(expectedNodes, graph.ConnectedNodesBelow);
        }
        [Theory]
        [MemberData(nameof(AddNodeData))]
        public void Should_AddNodeUp(string node, HashSet<string> expectedNodes)
        {
            var graph = new GraphNodeDay7();

            graph.AddNodeUp(node);
            Assert.Equal(expectedNodes, graph.ConnectedNodesUp);
        }
        public static IEnumerable<object[]> AddNodeData()
        {
            yield return new object[] {
                "node", new HashSet<string>() {"node" }
            };
        }

    }
}