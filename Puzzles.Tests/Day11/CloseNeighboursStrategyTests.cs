using Moq;
using Puzzles.Day11;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day11
{
    public class CloseNeighboursStrategyTests
    {
        [Theory]
        [ClassData(typeof(CloseNeighbours.CountOccupiedNeighboursData))]
        public void Should_CountOccupiedNeighbours(SeatDay11[,] seats, int i, int j, int expected)
        {
            var strategy = new CloseNeighboursStrategy();
            var result = strategy.CountOccupiedNeighbours(seats, i, j);

            Assert.Equal(expected, result);
        }
        [Theory]
        [ClassData(typeof(CloseNeighbours.ShouldChangeStateData))]
        public void Should_ShouldChangeState(SeatDay11 seat, int neighbours, bool expected)
        {
            var strategy = new CloseNeighboursStrategy();
            var result = strategy.ShouldChangeState(seat, neighbours);

            Assert.Equal(expected, result);
        }

    }
    namespace CloseNeighbours
    {
        public class CountOccupiedNeighboursData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var seats1 = new SeatDay11[2, 2]
                {
                {new SeatDay11('.'), new SeatDay11('.') },
                { new SeatDay11('.'), new SeatDay11('#') }
                };

                var seats2 = new SeatDay11[3, 2]
                {
                {new SeatDay11('.'), new SeatDay11('L') },
                { new SeatDay11('.'), new SeatDay11('#') },
                { new SeatDay11('#'), new SeatDay11('#') }
                };

                yield return new object[] {
                seats1, 0, 0, 1
            };
                yield return new object[] {
                seats2, 1,0,3
            };
                yield return new object[] {
                seats2, 1,1,2
            };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class ShouldChangeStateData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                new SeatDay11('.'), 1, false
                };

                yield return new object[] {
                new SeatDay11('#'), 4, true
                };
                yield return new object[] {
                new SeatDay11('#'), 3, false
                };
                yield return new object[] {
                new SeatDay11('L'), 1, false
                };
                yield return new object[] {
                new SeatDay11('L'), 0, true
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}