using FluentAssertions;
using Moq;
using Puzzles.Day7;
using System.Collections.Generic;
using System.Collections;
using Xunit;

namespace Puzzles.Tests.Day7
{
    public class PuzzleSolverDay7Tests
    {
        [Theory]
        [ClassData(typeof(FindNumberConnectedNodesData))]
        public void Should_FindNumberConnectedNodes(Dictionary<string, GraphNodeDay7> graph, string searchedNode, int expectedConnectedNodes)
        {
            var solver = new PuzzleSolverDay7();
            var result = solver.FindNumberConnectedNodes(graph, searchedNode);

            Assert.Equal(expectedConnectedNodes, result);
        }
    }
    public class FindNumberConnectedNodesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nodes1 = new HashSet<string>() { "node2", "node3" };
            var nodes2 = new HashSet<string>() { "node4" };

            var graph1 = SetUpGraphMock(nodes1,null, "node1").Object;
            var graph2 = SetUpGraphMock(nodes2, null, "node2").Object;

            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1,
                  [graph2.Name] = graph2
                },
                "node2", 1
            };
            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1,
                  [graph2.Name] = graph2
                },
                "node4", 2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private Mock<GraphNodeDay7> SetUpGraphMock(HashSet<string> below, HashSet<string> up, string name)
        {
            var moqGraph = new Mock<GraphNodeDay7>();
            moqGraph
               .SetupGet(g => g.ConnectedNodesBelow)
               .Returns(below);

            moqGraph
                .SetupGet(g => g.ConnectedNodesUp)
                .Returns(up);

            moqGraph
              .SetupGet(g => g.Name)
              .Returns(name);

            return moqGraph;
        }
    }

}