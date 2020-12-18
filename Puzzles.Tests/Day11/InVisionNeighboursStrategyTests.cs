using Moq;
using Puzzles.Day11;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day11
{
    public class InVisionNeighboursStrategyTests
    {
        [Theory]
        [ClassData(typeof(InVisionNeighbours.CountOccupiedNeighboursData))]
        public void Should_CountOccupiedNeighbours(SeatDay11[,] seats, int i, int j, int expected)
        {
            var strategy = new InVisionNeighbourStrategy();
            var result = strategy.CountOccupiedNeighbours(seats, i, j);

            Assert.Equal(expected, result);
        }
        [Theory]
        [ClassData(typeof(InVisionNeighbours.ShouldChangeStateData))]
        public void Should_ShouldChangeState(SeatDay11 seat, int neighbours, bool expected)
        {
            var strategy = new InVisionNeighbourStrategy();
            var result = strategy.ShouldChangeState(seat, neighbours);

            Assert.Equal(expected, result);
        }

    }
    namespace InVisionNeighbours
    {
        public class CountOccupiedNeighboursData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var seatsInput = new List<string>()
                {
                    "L.LL",
                    "LL#L",
                    "L.#.",
                    "LL##",
                };

                //such big object should not be created in unit testes?
                //for x for ? ^ ^"
                var seats1 = new SeatDay11[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        seats1[i, j] = new SeatDay11(seatsInput[i][j]);
                }

                yield return new object[] {
                seats1, 0,0,0
                };
                yield return new object[] {
                seats1, 1,0,1
                };
                yield return new object[] {
                seats1, 2,2,3
                };
                yield return new object[] {
                seats1, 1,2,1
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class ShouldChangeStateData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                new SeatDay11('.'), 6, false
            };
                yield return new object[] {
                new SeatDay11('#'), 10, true
            };
                yield return new object[] {
                new SeatDay11('#'), true, false
            };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}