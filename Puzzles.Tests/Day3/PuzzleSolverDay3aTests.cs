using Puzzles.Day3;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
namespace Puzzles.Tests.Day3
{
    public class PuzzleSolverDay3aTests
    {
        [Theory]
        [ClassData(typeof(PuzzleSolverDay3aData))]
        public void Should_GetNumberOfTreesInAway(MapDay3a map, int expected)
        {
            var solver = new PuzzleSolverDay3a();
            var result = solver.GetNumberOfTreesInAway(map);

            Assert.Equal(expected, result);
        }
    }
    public class PuzzleSolverDay3aData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines = new List<string>()
            {
                { ".##.#"},
                { "#..##" },
                { "#..##" },
                { "#..#." },
                { "#..##" }
            };
            yield return new object[] {
               new MapDay3a(lines,2,1), 0
            };

            yield return new object[] {
               new MapDay3a(lines,1,1), 2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}