using FluentAssertions;
using Moq;
using Puzzles.Day15;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day15
{
    public class PuzzleSolverDay15Tests
    {
        [Theory]
        [MemberData(nameof(SolveMemoryGameData))]
        public void Should_SolveMemoryGame(List<int> inputData, ulong numberOfSpokenWord, ulong expected)
        {
            var solver = new PuzzleSolverDay15();
            var result = solver.SolveMemoryGame(inputData, numberOfSpokenWord);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> SolveMemoryGameData()
        {
            yield return new object[]
            {
                new List<int>(){ 1, 3, 2 }, 2020, 1
            };

            yield return new object[]
            {
                new List<int>(){ 3,1,2 }, 2020, 1836
            };

        }
    }
}