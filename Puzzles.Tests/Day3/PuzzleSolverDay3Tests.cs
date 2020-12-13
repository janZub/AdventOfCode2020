using Puzzles.Day3;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
namespace Puzzles.Tests.Day3
{
    public class PuzzleSolverDay3Tests
    {
        [Theory]
        [ClassData(typeof(PuzzleSolverDay3Data))]
        public void Should_GetNumberOfTreesInAway(MapDay3 map, int expected)
        {
            var solver = new PuzzleSolverDay3();
            var result = solver.GetNumberOfTreesInAway(map);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(PuzzleSolverDay3DataList))]
        public void Should_GetNumberOfTreesInAway_InList(List<MapDay3> map, long expected)
        {
            var solver = new PuzzleSolverDay3();
            var result = solver.GetNumberOfTreesInAway(map);

            Assert.Equal(expected, result);
        }
    }
    public class PuzzleSolverDay3Data : IEnumerable<object[]>
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
               new MapDay3(lines,2,1), 0
            };

            yield return new object[] {
               new MapDay3(lines,1,1), 2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PuzzleSolverDay3DataList : IEnumerable<object[]>
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

            var maps = new List<MapDay3>()
            {
                new MapDay3(lines,1,1),
                new MapDay3(lines,4,0),
            };

            var maps2 = new List<MapDay3>()
            {
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
                new MapDay3(lines,1,0),
            };

            yield return new object[] {
               maps,
               2
            };
            yield return new object[] {
               maps2,
               17179869184
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}