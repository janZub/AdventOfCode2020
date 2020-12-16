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
        [ClassData(typeof(CountAccumulatorData))]
        public void Should_CountAccumulator(List<CommandDay8> commands, int expected)
        {
            var solver = new PuzzleSolverDay8();
            var result = solver.CountAccumulator(commands);

            Assert.Equal(expected, result);
        }
        [Theory]
        [ClassData(typeof(FindCommandThatCauseInfiniteLoopData))]
        public void Should_FindCommandThatCauseInfiniteLoopData(List<CommandDay8> commands, CommandDay8b expected)
        {
            var solver = new PuzzleSolverDay8();
            var result = solver.FindCommandThatCauseInfiniteLoopData(commands);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(FindCommandThatCauseInfiniteLoopInValidData))]
        public void ShouldNot_FindCommandThatCauseInfiniteLoopData(List<CommandDay8> commands)
        {
            var solver = new PuzzleSolverDay8();
            Assert.Throws<Exception>(() => solver.FindCommandThatCauseInfiniteLoopData(commands));

        }
    }
    public class CountAccumulatorData : IEnumerable<object[]>
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
    public class FindCommandThatCauseInfiniteLoopData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               new List<CommandDay8>(){
                new CommandDay8b(CommandDay8Enum.nop, 0),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8b(CommandDay8Enum.jmp, 4),
                new CommandDay8(CommandDay8Enum.acc, 3),
                new CommandDay8b(CommandDay8Enum.jmp, -3),
                new CommandDay8(CommandDay8Enum.acc, -99),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8b(CommandDay8Enum.jmp, -4),
                new CommandDay8(CommandDay8Enum.acc, 6),
               },
               new CommandDay8b(CommandDay8Enum.jmp, -4)
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class FindCommandThatCauseInfiniteLoopInValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               new List<CommandDay8>(){
                new CommandDay8b(CommandDay8Enum.jmp, 0),
                new CommandDay8b(CommandDay8Enum.jmp, 0),
                new CommandDay8(CommandDay8Enum.acc, 1),
               },
            };
            yield return new object[] {
               new List<CommandDay8>(){
                new CommandDay8b(CommandDay8Enum.jmp, 0),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8b(CommandDay8Enum.jmp, 4),
                new CommandDay8(CommandDay8Enum.acc, 3),
                new CommandDay8b(CommandDay8Enum.jmp, -3),
                new CommandDay8(CommandDay8Enum.acc, -99),
                new CommandDay8(CommandDay8Enum.acc, 1),
                new CommandDay8b(CommandDay8Enum.jmp, -4),
                new CommandDay8(CommandDay8Enum.acc, 6),
               },
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}