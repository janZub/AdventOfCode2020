using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Xunit;
using Puzzles.Day1;
using System;
using Puzzles.Day9;

namespace Puzzles.Tests.Day9
{
    public class PuzzleSolverDay9Tests
    {
        [Theory]
        [ClassData(typeof(FindNumberThatIsNotSumOfKPreviousNumbersData))]
        public void Should_FindNumberThatIsNotSumOfKPreviousNumbers(List<ulong> numbers, int k, IPuzzleSolverDay1 mock, ulong expected)
        {
            var solver = new PuzzleSolverDay9();
            var result = solver.FindNumberThatIsNotSumOfKPreviousNumbers(mock, numbers, k);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(FindNumberThatIsNotSumOfKPreviousNumbersInValidData))]
        public void ShouldNot_FindNumberThatIsNotSumOfKPreviousNumbers(List<ulong> numbers, int k, IPuzzleSolverDay1 mock)
        {
            var solver = new PuzzleSolverDay9();

            Assert.Throws<Exception>(() => solver.FindNumberThatIsNotSumOfKPreviousNumbers(mock, numbers, k));
        }

        [Theory]
        [MemberData(nameof(ContiguousSetThatSumToNData))]
        public void Should_FindContiguousSetThatSumToN(List<ulong> numbers, ulong n, ulong expected)
        {
            var solver = new PuzzleSolverDay9();
            var result = solver.FindContiguousSetThatSumToN(numbers, n);

            Assert.Equal(expected, result);
        }
        [Theory]
        [MemberData(nameof(ContiguousSetThatSumToNInValidData))]
        public void ShouldNot_FindContiguousSetThatSumToN(List<ulong> numbers, ulong n)
        {
            var solver = new PuzzleSolverDay9();
            Assert.Throws<Exception>(() => solver.FindContiguousSetThatSumToN(numbers, n));
        }
        public static IEnumerable<object[]> ContiguousSetThatSumToNData()
        {
            yield return new object[] { new List<ulong>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 },
                127, 62
            };
        }
        public static IEnumerable<object[]> ContiguousSetThatSumToNInValidData()
        {
            yield return new object[] { new List<ulong>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 },
                2000
            };
        }
        public class FindNumberThatIsNotSumOfKPreviousNumbersData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var moq = new Mock<IPuzzleSolverDay1>();
                moq.SetReturnsDefault(new List<ulong>() { 0, 0 });
                moq.Setup(s => s.GetNumbersThatSumToN(It.IsAny<List<ulong>>(), 8)).Returns(new List<ulong>());

                yield return new object[] {
                new List<ulong>() { 1,2,3,4,5,6,7,8,9},
                3,
                moq.Object,
                8
            };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class FindNumberThatIsNotSumOfKPreviousNumbersInValidData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var moq = new Mock<IPuzzleSolverDay1>();
                moq.SetReturnsDefault(new List<ulong>() { 0, 0 });

                yield return new object[] {
                new List<ulong>() { 1,2,3,4,5,6,7,8,9},
                3,
                moq.Object,
            };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}