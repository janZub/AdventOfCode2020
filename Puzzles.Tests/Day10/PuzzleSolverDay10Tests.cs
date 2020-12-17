using Puzzles.Day10;
using System;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day10
{
    public class PuzzleSolverDay10Tests
    {
        [Theory]
        [MemberData(nameof(GetProductOfJoltDifferencesData))]
        public void Should_GetProductOfJoltDifferences(List<int> numbers, ulong expected)
        {
            var solver = new PuzzleSolverDay10();
            var result = solver.GetProductOfJoltDifferences(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetNumberOfPossibleCombinationsData))]
        public void Should_GetNumberOfPossibleCombinations(List<int> numbers, ulong expected)
        {
            var solver = new PuzzleSolverDay10();
            var result = solver.GetNumberOfPossibleCombinations(numbers);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetProductOfJoltDifferencesData()
        {
            yield return new object[] {
                new List<int>() { 28,33,18,42,31,14,46,20,48,47,24,23,49,45,19,38,39,11,1,32,25,35,8,17,7,9,4,2,34,10,3 }, 220 };
            yield return new object[] {
                new List<int>() { 16,10,15,5,1,11,7,19,6,12,4 }, 35 };
        }
        public static IEnumerable<object[]> GetNumberOfPossibleCombinationsData()
        {
            yield return new object[] {
                new List<int>() { 28,33,18,42,31,14,46,20,48,47,24,23,49,45,19,38,39,11,1,32,25,35,8,17,7,9,4,2,34,10,3 }, 19208 };
            yield return new object[] {
                new List<int>() { 16,10,15,5,1,11,7,19,6,12,4 }, 8 };
        }
    }
}
