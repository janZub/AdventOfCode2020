using Puzzles.Day3;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace Puzzles.Tests.Day3
{
    public class MapDay3Tests
    {
        [Theory]
        [ClassData(typeof(MapDay3ValidDataTreeMove))]
        public void Should_Move(MapDay3 map, int expectedX, int expectedY)
        {
            map.Move();
            var x = map.CurrentPositionX;
            var y = map.CurrentPositionY;

            Assert.Equal(expectedX, x);
            Assert.Equal(expectedY, y);
        }

        [Theory]
        [ClassData(typeof(MapDay3ValidDataIsAtTree))]
        public void Should_IsAtTree(MapDay3 map, bool expectedIsOnTree)
        {
            var isOnTree = map.IsAtTree();
            Assert.Equal(expectedIsOnTree, isOnTree);
        }

        [Theory]
        [ClassData(typeof(MapDay3InValidDataIsAtTree))]
        public void ShouldNot_IsAtTree(MapDay3 map)
        {
            map.Move();
            Assert.Throws<ArgumentOutOfRangeException>(() => map.IsAtTree()); ;
        }
        [Theory]
        [ClassData(typeof(MapDay3ValidDataLeftTree))]
        public void Should_DidLeftMap(MapDay3 map, bool expectedLeftMap)
        {
            map.Move();
            map.Move();

            var left = map.DidLeftMap();
            Assert.Equal(expectedLeftMap, left);
        }
    }

    public class MapDay3ValidDataLeftTree : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines = new List<string>()
            {
                {"#####" },
                {"#####" },
                {"#####" },
                {"#####" }
            };
            yield return new object[] {
               new MapDay3(lines,1,9),
               false
            };

            yield return new object[] {
               new MapDay3(lines,5,1),
               true
            };
            yield return new object[] {
               new MapDay3(lines,2,2),
               true
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MapDay3InValidDataIsAtTree : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines = new List<string>()
            {
                {"#" }
            };
            var lines2 = new List<string>()
            {
                {"." }
            };
            yield return new object[] {
               new MapDay3(lines,1,1)
            };

            yield return new object[] {
               new MapDay3(lines2,1,1)
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MapDay3ValidDataIsAtTree : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines = new List<string>()
            {
                {"#" }
            };
            var lines2 = new List<string>()
            {
                {"." }
            };
            yield return new object[] {
               new MapDay3(lines,1,1), true
            };

            yield return new object[] {
               new MapDay3(lines2,1,1), false
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class MapDay3ValidDataTreeMove : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines = new List<string>()
            {
                { ".##.#"},
                { "#..##" },
                { "#..##" },
                { "#..#." },
                { "#..#." }
            };
            yield return new object[] {
               new MapDay3(lines,2,1), 1, 2
            };

            yield return new object[] {
               new MapDay3(lines,1,5), 0, 1
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}