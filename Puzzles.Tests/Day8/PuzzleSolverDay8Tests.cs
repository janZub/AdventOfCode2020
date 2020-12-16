using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Xunit;
using Puzzles.Day8;
using System;

namespace Puzzles.Tests.Day8
{
    public class PuzzleSolverDay8Tests
    {
        [Theory]
        [ClassData(typeof(CountAccumulatorUntilInfiniteLoopData))]
        public void Should_CountAccumulatorUntilInfiniteLoop(List<CommandDay8> commands, int expected)
        {
            var solver = new PuzzleSolverDay8();
            var result = solver.CountAccumulatorUntilInfiniteLoop(commands);

            Assert.Equal(expected, result);
        }
    }
    public class CountAccumulatorUntilInfiniteLoopData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               new List<CommandDay8>(){
                new CommandDay8(CommandDay8Enum.nop, 0),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8(CommandDay8Enum.jmp, 4),
                new CommandDay8(CommandDay8Enum.acc, 3),
                new CommandDay8(CommandDay8Enum.jmp, -3),
                new CommandDay8(CommandDay8Enum.acc, -99),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8(CommandDay8Enum.jmp, -4),
                new CommandDay8(CommandDay8Enum.acc, 6),
               },
               5
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}