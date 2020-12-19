using FluentAssertions;
using Moq;
using Puzzles.Day12;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day12
{
    public class CommandDay12Tests
    {
        [Theory]
        [ClassData(typeof(CreateCommandData))]
        public void Should_CreateCommand(string command, CommandDay12 expected)
        {
            var result = CommandDay12.CreateCommand(command);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("Ws10")]
        [InlineData("Q10")]
        [InlineData("")]
        public void ShouldNot_CreateCommand(string command)
        {
            Assert.Throws<Exception>(() => CommandDay12.CreateCommand(command));
        }
    }
    public class CreateCommandData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var command1 = new Mock<CommandDay12>();
            command1.SetupGet(t => t.CommandType).Returns(CommandTypeDay12Enum.Forward);
            command1.SetupGet(t => t.ActionValue).Returns(10);

            var command2 = new Mock<CommandDay12>();
            command2.SetupGet(t => t.CommandType).Returns(CommandTypeDay12Enum.IntoDirection);
            command2.SetupGet(t => t.Direction).Returns(DirectionDay12Enum.North);
            command2.SetupGet(t => t.ActionValue).Returns(3);

            var command3 = new Mock<CommandDay12>();
            command3.SetupGet(t => t.CommandType).Returns(CommandTypeDay12Enum.RotateRight);
            command3.SetupGet(t => t.ActionValue).Returns(270);

            var command4 = new Mock<CommandDay12>();
            command4.SetupGet(t => t.CommandType).Returns(CommandTypeDay12Enum.RotateRight);
            command4.SetupGet(t => t.ActionValue).Returns(90);

            yield return new object[] {
               "F10", command1.Object,
            };
            yield return new object[] {
                "N3", command2.Object,
            };
            yield return new object[] {
               "R270", command3.Object,
            };

            yield return new object[] {
               "L270",  command4.Object,
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}