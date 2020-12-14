using FluentAssertions;
using Moq;
using Puzzles.Day6;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Puzzles.Tests.Day6
{
    public class GroupDay6bTests
    {
        [Theory]
        [InlineData("aabbaacc", 7, 0)]
        [InlineData("abcde", 1, 5)]
        [InlineData("aaaaaaaa", 8, 1)]
        [InlineData("", 0, 0)]
        public void Should_CountDistinctQuestions(string data, int groupSize, int expected)
        {
            var group = new GroupDay6b(data, groupSize);
            var nrAnswers = group.CountDifferentAnswers();

            Assert.Equal(expected, nrAnswers);
        }

    }
}