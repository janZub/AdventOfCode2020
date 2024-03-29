﻿using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using Puzzles.Day5;

namespace Puzzles.Tests.Day5
{
    public class PuzzleSolverDay5Tests
    {
        [Theory]
        [ClassData(typeof(PuzzleSolverDay5TestData))]
        public void Should_GetMaxSeatId(List<SeatDay5> seats, int expectedMaxId)
        {
            var solver = new PuzzleSolverDay5();
            var result = solver.GetMaxSeatId(seats);

            Assert.Equal(expectedMaxId, result);
        }
        [Theory]
        [ClassData(typeof(PuzzleSolverDay5TestDataListOfIds))]
        public void Should_GetListOfSeatIds(List<SeatDay5> seats, List<int> expectedIds)
        {
            var solver = new PuzzleSolverDay5();
            var result = solver.GetListOfSeatIds(seats);

            Assert.Equal(result, expectedIds);
        }


        [Theory]
        [ClassData(typeof(PuzzleSolverDay5TestDataMissingId))]
        public void Should_FindMissingId(List<SeatDay5> seats, int missingId)
        {
            var solver = new PuzzleSolverDay5();
            var result = solver.GetMissingId(seats);

            Assert.Equal(result, missingId);
        }

        [Theory]
        [ClassData(typeof(PuzzleSolverDay5TestDataMissingIdFail))]
        public void ShouldNot_FindMissingId(List<SeatDay5> seats)
        {
            var solver = new PuzzleSolverDay5();

            Assert.Throws<Exception>(() => solver.GetMissingId(seats));
        }
    }

    public class PuzzleSolverDay5TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            Mock<SeatDay5> seat1 = new Mock<SeatDay5>(null);
            seat1.Setup(s => s.GetSeatId()).Returns(2);

            Mock<SeatDay5> seat2 = new Mock<SeatDay5>(null);
            seat2.Setup(s => s.GetSeatId()).Returns(5);

            yield return new object[] {
                new List<SeatDay5>(){ seat1.Object, seat2.Object }, 5
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PuzzleSolverDay5TestDataListOfIds : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            Mock<SeatDay5> seat1 = new Mock<SeatDay5>(null);
            seat1.Setup(s => s.GetSeatId()).Returns(2);

            Mock<SeatDay5> seat2 = new Mock<SeatDay5>(null);
            seat2.Setup(s => s.GetSeatId()).Returns(5);

            yield return new object[] {
                new List<SeatDay5>(){ seat1.Object, seat2.Object },
                new List<int>(){2,5}
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PuzzleSolverDay5TestDataMissingId : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            Mock<SeatDay5> seat1 = new Mock<SeatDay5>(null);
            seat1.Setup(s => s.GetSeatId()).Returns(2);

            Mock<SeatDay5> seat2 = new Mock<SeatDay5>(null);
            seat2.Setup(s => s.GetSeatId()).Returns(4);

            yield return new object[] {
                new List<SeatDay5>(){ seat1.Object, seat2.Object }, 3
            };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PuzzleSolverDay5TestDataMissingIdFail : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            Mock<SeatDay5> seat1 = new Mock<SeatDay5>(null);
            seat1.Setup(s => s.GetSeatId()).Returns(2);

            Mock<SeatDay5> seat2 = new Mock<SeatDay5>(null);
            seat2.Setup(s => s.GetSeatId()).Returns(5);
            
            yield return new object[] {
                new List<SeatDay5>(){ seat1.Object, seat2.Object }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}