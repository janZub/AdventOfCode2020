using System;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests
{
    public class PuzzleDaySolver1bTests
    {

        [Theory]
        [MemberData(nameof(KNumbersThatSumToN))]
        public void Should_GetKNumbersThatSumToN(List<int> numbers, int k, int n, List<int> expected)
        {
            var solver = new PuzzleDay1bSolver();
            var nextSmallesSubset = solver.GetKNumbersThatSumToN(numbers, k, n);
            Assert.Equal(expected, nextSmallesSubset);
        }

        [Theory]
        [MemberData(nameof(KNumbersThatNotSumToN))]
        public void ShouldNot_GetKNumbersThatSumToN(List<int> numbers, int k, int n)
        {
            var solver = new PuzzleDay1bSolver();
            var result =  solver.GetKNumbersThatSumToN(numbers, k, n);

            Assert.Empty(result);
        }

        [Theory]
        [MemberData(nameof(TooFewNumbers))]
        public void ShouldNot_GetKNumbersThatSumToN_TooFewNumbers(List<int> numbers, int k, int n)
        {
            var solver = new PuzzleDay1bSolver();
            Assert.Throws<ArgumentException>("k", () => solver.GetKNumbersThatSumToN(numbers, k, n));
        }

        public static IEnumerable<object[]> KNumbersThatSumToN()
        {
            yield return new object[] {
                new List<int>() { 1, 2, 3, 5, 6, 2017 },
                2, 2020,
                new List<int>() {3,2017 }
            };

            yield return new object[] {
                new List<int>() { 20, 33, 44, 57, 199, 200 ,1800},
                3, 2020,
                new List<int>() { 200, 1800, 20 } };

            yield return new object[] {
                new List<int>() { 20, 33, 44, 57, 199, 200 ,1800},
                3 ,97,
                new List<int>(){ 33, 44, 20 } };
        }
        public static IEnumerable<object[]> KNumbersThatNotSumToN()
        {
            yield return new object[] {
                new List<int>() { 1, 2, 3, 5, 6, 2017 },
                2, 2050
            };

            yield return new object[] {
                new List<int>() { 20, 33, 44, 57, 199, 200 ,1800},
                7, 2020
            };

            yield return new object[] {
                new List<int>() { 20, 33, 44, 57, 199, 200 ,1800},
                2 ,97
            };
        }
        public static IEnumerable<object[]> TooFewNumbers()
        {
            yield return new object[] {
                new List<int>() { 1, 2, 3, 5, 6, 2017 },
                7, 2020
            };
        }

    }
}