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

        [Theory]
        [ClassData(typeof(FindWeightInNodeData))]
        public void Should_FindWeight(Dictionary<string, GraphNodeDay7> graph, string searchedNode, int expectedWeight)
        {
            var solver = new PuzzleSolverDay7();
            var result = solver.FindWeightInNode(graph, searchedNode);

            Assert.Equal(expectedWeight, result);
        }
    }
    public class FindNumberConnectedNodesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nodes1 = new Dictionary<string, int>() { ["node2"] = 1, ["node3"] = 3 };
            var nodes2 = new Dictionary<string, int>() { ["node4"] = 2 };

            var graph1 = PuzzleDay7GraphMock.SetUpGraphMock(nodes1, "node1").Object;
            var graph2 = PuzzleDay7GraphMock.SetUpGraphMock(nodes2, "node2").Object;

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
    }

    public class FindWeightInNodeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nodes1 = new Dictionary<string, int>() { ["node2"] = 2, ["node4"] = 2 };
            var nodes2 = new Dictionary<string, int>() { ["node3"] = 5 };
            var nodes3 = new Dictionary<string, int>() { ["node4"] = 3 };
            var nodes4 = new Dictionary<string, int>() { };

            var graph1 = PuzzleDay7GraphMock.SetUpGraphMock(nodes1, "searchedNode").Object;
            var graph2 = PuzzleDay7GraphMock.SetUpGraphMock(nodes2, "node2").Object;
            var graph3 = PuzzleDay7GraphMock.SetUpGraphMock(nodes3, "node3").Object;
            var graph4 = PuzzleDay7GraphMock.SetUpGraphMock(nodes4, "node4").Object;

            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1,
                  [graph2.Name] = graph2,
                  [graph3.Name] = graph3,
                  [graph4.Name] = graph4
                },
                graph1.Name, 1 + 2 + 2 * ( 1 + 5 * (1 + 3 * (1)))
            };
            yield return new object[] {
                new Dictionary<string, GraphNodeDay7>()
                {
                  [graph1.Name] = graph1
                },
                graph1.Name, 1
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}