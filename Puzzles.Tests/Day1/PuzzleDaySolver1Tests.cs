using Puzzles.Day1;
using System;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day1
{
    public class PuzzleDaySolver1Tests
    {

        [Theory]
        [MemberData(nameof(KNumbersThatSumToN))]
        public void Should_GetKNumbersThatSumToN(List<int> numbers, int k, int n, List<int> expected)
        {
            var solver = new PuzzleSolverDay1();
            var result = solver.GetKNumbersThatSumToN(numbers, k, n);
        
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(KNumbersThatNotSumToN))]
        public void ShouldNot_GetKNumbersThatSumToN(List<int> numbers, int k, int n)
        {
            var solver = new PuzzleSolverDay1();
            var result =  solver.GetKNumbersThatSumToN(numbers, k, n);

            Assert.Empty(result);
        }

        [Theory]
        [MemberData(nameof(TooFewNumbers))]
        public void ShouldNot_GetKNumbersThatSumToN_TooFewNumbers(List<int> numbers, int k, int n)
        {
            var solver = new PuzzleSolverDay1();
            Assert.Throws<ArgumentException>("k", () => solver.GetKNumbersThatSumToN(numbers, k, n));
        }

        [Theory]
        [MemberData(nameof(NumbersThatSumToN))]
        public void Should_GetNumbersThatSumToN(List<int> numbers, int n)
        {
            var solver = new PuzzleSolverDay1();
            var result = solver.GetNumbersThatSumToN(numbers, n);

            Assert.Equal(n, result[0] + result[1]);
            Assert.Equal(2, result.Count);
        }

        [Theory]
        [MemberData(nameof(NumbersThatNotSumToN))]
        public void ShouldNot_GetNumbersThatSumToN(List<int> numbers, int n)
        {
            var solver = new PuzzleSolverDay1();
            var result = solver.GetNumbersThatSumToN(numbers, n);

            Assert.Empty(result);
        }

        public static IEnumerable<object[]> NumbersThatSumToN()
        {
            yield return new object[] { new List<int>() { 1, 2, 3, 4, 2017 }, 2020 };
            yield return new object[] { new List<int>() { 2011, 300, 3, 4, 200, 1720 }, 2020 };
            yield return new object[] { new List<int>() { 2011, 300, 3, 4, 200, 1720 }, 2311 };
        }
        public static IEnumerable<object[]> NumbersThatNotSumToN()
        {
            yield return new object[] { new List<int>() { 3000 }, 2020 };
            yield return new object[] { new List<int>() { 10, 31, 50, 11, 231, 2308, 32123 }, 2020 };
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