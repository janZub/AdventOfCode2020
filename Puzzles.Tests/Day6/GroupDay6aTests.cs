using FluentAssertions;
using Moq;
using Puzzles.Day6;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Puzzles.Tests.Day6
{
    public class GroupDay6aTests
    {
        [Theory]
        [InlineData("aa a aaabbb aa", 2)]
        [InlineData("abcde", 5)]
        [InlineData("aaaaaaaa", 1)]
        [InlineData("", 0)]
        public void Should_CountDistinctQuestions(string data, int expected)
        {
            var group = new GroupDay6a(data);
            var nrAnswers = group.CountDifferentAnswers();

            Assert.Equal(expected, nrAnswers);
        }

    }
}