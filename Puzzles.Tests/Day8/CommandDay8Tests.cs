using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Xunit;
using Puzzles.Day8;
using System;

namespace Puzzles.Tests.Day8
{
    public class CommandDay8Tests
    {
        [Theory]
        [ClassData(typeof(ChangeCommandData))]
        public void Should_ChangeCommand(CommandDay8b command, CommandDay8b expected)
        {
            command.ChangeCommand();
            command.Should().BeEquivalentTo(expected);
        }
        [Theory]
        [ClassData(typeof(ChangeCommandInValidData))]
        public void ShouldNot_ChangeCommand(CommandDay8b command)
        {
            Assert.Throws<Exception>(() => command.ChangeCommand());
        }
    }
    public class ChangeCommandData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new CommandDay8b(CommandDay8Enum.nop, 5),
                new CommandDay8b(CommandDay8Enum.jmp, 5),
            };
            yield return new object[] {
                new CommandDay8b(CommandDay8Enum.jmp, 5),
                new CommandDay8b(CommandDay8Enum.nop, 5),
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class ChangeCommandInValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new CommandDay8b(CommandDay8Enum.acc, 5)
            };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}