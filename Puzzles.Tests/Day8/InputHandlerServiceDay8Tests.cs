using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections;
using Xunit;
using Puzzles.Day8;
using System;

namespace Puzzles.Tests.Day8
{
    public class InputHandlerServiceDay7Tests
    {
        [Theory]
        [ClassData(typeof(CreateCommandData))]
        public void Should_CreateCommand(string command, CommandDay8 expected)
        {
            var inputHandler = new InputHandlerServiceDay8();
            var result = inputHandler.CreateCommand(command);

            result.Should().BeOfType(expected.GetType());
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("nop +0 nop +0")]
        [InlineData("djiw -99")]
        [InlineData("jmp +5ab")]
        public void ShouldNot_CreateCommand(string command)
        {
            var inputHandler = new InputHandlerServiceDay8();

            Assert.Throws<Exception>(() => inputHandler.CreateCommand(command));
        }
    }
    public class CreateCommandData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               "nop +0", new CommandDay8b(CommandDay8Enum.nop, 0)
            };
            yield return new object[] {
               "acc -99", new CommandDay8(CommandDay8Enum.acc, -99)
            };

            yield return new object[] {
               "jmp -2", new CommandDay8b(CommandDay8Enum.jmp, -2)
            };

            yield return new object[] {
               "jmp +5", new CommandDay8b(CommandDay8Enum.jmp, 5)
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}