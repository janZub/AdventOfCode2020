using System;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests
{
    public class PuzzleDaySolver1aTests
    {
        [Theory]
        [MemberData(nameof(SolvableData))]
        public void Should_GetNumbersThatSumToN(List<int> numbers, int n)
        {
            var solver = new PuzzleDay1aSolver();
            var result = solver.GetNumbersThatSumToN(numbers, n);

            Assert.Equal(n, result[0] + result[1]);
            Assert.Equal(2, result.Count);
        }

        [Theory]
        [MemberData(nameof(NotSolvableData))]
        public void ShouldNot_GetNumbersThatSumToN(List<int> numbers, int n)
        {
            var solver = new PuzzleDay1aSolver();
            var result = solver.GetNumbersThatSumToN(numbers, n);

            Assert.Empty(result);
        }

        public static IEnumerable<object[]> SolvableData()
        {
            yield return new object[] { new List<int>() { 1, 2, 3, 4, 2017 }, 2020 };
            yield return new object[] { new List<int>() { 2011, 300, 3, 4, 200, 1720 }, 2020 };
            yield return new object[] { new List<int>() { 2011, 300, 3, 4, 200, 1720 }, 2311 };
        }
        public static IEnumerable<object[]> NotSolvableData()
        {
            yield return new object[] { new List<int>() { 3000 }, 2020 };
            yield return new object[] { new List<int>() { 10, 31, 50, 11, 231, 2308, 32123 }, 2020 };
        }
    }
}