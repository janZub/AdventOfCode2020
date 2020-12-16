using FluentAssertions;
using Moq;
using Puzzles.Day7;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day7
{
    public class GraphNodeDay7Tests
    {
        [Theory]
        [ClassData(typeof(AddDefaultNodeBellowData))]
        public void Should_AddDefaultNodeBellow(string node, Dictionary<string, int> expectedNodes)
        {
            var graph = new GraphNodeDay7();

            graph.AddNodeBellow(node);
            Assert.Equal(expectedNodes, graph.ConnectedNodesBelow);
        }
        [Theory]
        [ClassData(typeof(AddNodeBellowData))]
        public void Should_AddNodeBellow(string node, int weight,  Dictionary<string, int> expectedNodes)
        {
            var graph = new GraphNodeDay7();

            graph.AddNodeBellow(node, weight);
            Assert.Equal(expectedNodes, graph.ConnectedNodesBelow);
        }
    }
    public class AddDefaultNodeBellowData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                "node", new Dictionary<string,int>() {["node"] = 1 },
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class AddNodeBellowData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
        yield return new object[] {
                "node", 2, new Dictionary<string,int>() {["node"] = 2 }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}