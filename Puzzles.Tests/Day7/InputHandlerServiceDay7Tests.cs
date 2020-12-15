using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Xunit;
using Puzzles.Day7;

namespace Puzzles.Tests.Day7
{
    public class InputHandlerServiceDay7Tests
    {
        [Theory]
        [ClassData(typeof(AddNodeData))]
        public void Should_AddNode(Dictionary<string, GraphNodeDay7> nodes, GraphNodeDay7 newNode, Dictionary<string, GraphNodeDay7> expectedNodes)
        {
            var inputHandler = new InputHandlerServiceDay7();
            var result = inputHandler.AddNode(nodes, newNode);

            result.Should().BeEquivalentTo(expectedNodes);
        }
        [Theory]
        [ClassData(typeof(CreateNodeData))]
        public void Should_CreateNode(string input, GraphNodeDay7 expectedNode)
        {
            var inputHandler = new InputHandlerServiceDay7();
            var result = inputHandler.CreateNode(input);

            result.Should().BeEquivalentTo(expectedNode);
        }
    }

    public class AddNodeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nodes1 = new HashSet<string>() { "node1", "node2", "node3" };
            var nodes2 = new HashSet<string>() { "node3", "node4", "node4" };
            var nodes1a = new HashSet<string>() { "node4" };

   
            var graph1 = SetUpGraphMock(nodes1, nodes2, "node1").Object;
            var graph2 = SetUpGraphMock(nodes1, nodes2, "node2").Object;

            var graph1a = SetUpGraphMock(nodes1a, nodes2, "node1").Object;
            var graph1b = SetUpGraphMock(nodes1, nodes2, "node1").Object;


            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1
                },
                graph2,
                new Dictionary<string, GraphNodeDay7>()
                {
                    [graph1.Name] = graph1,
                    [graph2.Name] = graph2
                },
            };

            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1
                },
                graph1a,
                new Dictionary<string, GraphNodeDay7>()
                {
                    [graph1b.Name] = graph1b
                },
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

    public class CreateNodeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var input = "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.";
            var graph = SetUpGraphMock(new HashSet<string>() { "faded blue", "dotted black", }, new HashSet<string>(), "vibrant plum").Object;

            var input2 = "dotted black bags contain no other bags.";
            var graph2 = SetUpGraphMock(new HashSet<string>(), new HashSet<string>(), "dotted black").Object;


            yield return new object[] { input, graph };
            yield return new object[] { input2, graph2 };
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