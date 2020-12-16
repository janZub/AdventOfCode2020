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
            var result = inputHandler.CreateNodeWithNodesBelow(input);

            result.Should().BeEquivalentTo(expectedNode);
        }
    }

    public class AddNodeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nodes1 = new Dictionary<string, int>()
            {
                ["node1"] = 1,
                ["node2"] = 1,
                ["node3"] = 1
            };
            var nodes1a = new Dictionary<string, int>()
            {
                ["node3"] = 1,
                ["node4"] = 1,
                ["node4"] = 1
            };

            var nodes1b = new Dictionary<string, int>()
            {
                ["node1"] = 1,
                ["node2"] = 1,
                ["node3"] = 1,
                ["node4"] = 1
            };
            var graph1 = PuzzleDay7GraphMock.SetUpGraphMock(nodes1, "node1").Object;
            var graph2 = PuzzleDay7GraphMock.SetUpGraphMock(nodes1, "node2").Object;

            var graph1a = PuzzleDay7GraphMock.SetUpGraphMock(nodes1a, "node1").Object;
            var graph1b = PuzzleDay7GraphMock.SetUpGraphMock(nodes1b, "node1").Object;


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
    }

    public class CreateNodeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var input = "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.";
            var graph = PuzzleDay7GraphMock.SetUpGraphMock(new Dictionary<string, int>() { ["faded blue"] = 5, ["dotted black"] = 6 }, "vibrant plum").Object;

            var input2 = "dotted black bags contain no other bags.";
            var graph2 = PuzzleDay7GraphMock.SetUpGraphMock(new Dictionary<string, int>(), "dotted black").Object;


            yield return new object[] { input, graph };
            yield return new object[] { input2, graph2 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}