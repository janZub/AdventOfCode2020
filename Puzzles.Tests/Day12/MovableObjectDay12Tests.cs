using FluentAssertions;
using Moq;
using Puzzles.Day12;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day12
{
    public class MovableObjectDay12Tests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, -1, 2)]
        [InlineData(0, 2, 2)]
        public void Should_GetManhattanDistance(int x, int y, int expected)
        {
            var movable = new Mock<MovableObjectDay12>()
            {
                CallBase = true
            };
            movable.Setup(x => x.PositionX).Returns(x);
            movable.Setup(y => y.PositionY).Returns(y);

            var result = movable.Object.GetManhattanDistance();

            Assert.Equal(expected, result);

        }
        [Theory]
        [InlineData(DirectionDay12Enum.East, 3, 0, 3)]
        [InlineData(DirectionDay12Enum.West, 3, 0, -3)]
        [InlineData(DirectionDay12Enum.North, 3, 3, 0)]
        [InlineData(DirectionDay12Enum.South, 3, -3, 0)]
        public void Should_MoveIntoDirection(DirectionDay12Enum direction, int value, int expectedX, int expectedY)
        {
            var movable = new MovableObjectDay12();

            movable.MoveIntoDirection(direction, value);
            Assert.Equal(expectedX, movable.PositionX);
            Assert.Equal(expectedY, movable.PositionY);
        }
    }
}