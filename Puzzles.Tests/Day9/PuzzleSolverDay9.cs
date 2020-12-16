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