using System;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Utils
{
    public class PuzzleFactoryTests
    {
        [Theory]
        [InlineData(1, "a")]
        [InlineData(25, "suf")]
        public void Should_ValidateArguments(int dayNumber, string daySuffix)
        {
            PuzzleFactory.ValidateArguments(dayNumber, daySuffix);
        }

        [Theory]
        [InlineData(-4, "a")]
        [InlineData(32, "suff")]
        public void ShouldNot_ValidateArguments_dayNumber(int dayNumber, string daySuffix)
        {
            Assert.Throws<ArgumentException>("dayNumber", () => PuzzleFactory.ValidateArguments(dayNumber, daySuffix));
        }

        [Theory]
        [InlineData(2, "")]
        [InlineData(4, "looongSuffix")]
        [InlineData(8, "s w")]
        public void ShouldNot_ValidateArguments_daySuffix(int dayNumber, string daySuffix)
        {
            Assert.Throws<ArgumentException>("daySuffix", () => PuzzleFactory.ValidateArguments(dayNumber, daySuffix));
        }

        [Theory]
        [InlineData(1, "a", "PuzzleDay1a")]
        [InlineData(201, "wws", "PuzzleDay201wws")]
        public void Should_CreatePuzzleDayClassName(int dayNumber, string daySuffix, string expected)
        {
            var name = PuzzleFactory.CreatePuzzleDayClassName(dayNumber, daySuffix);
            Assert.Equal(name, expected);
        }
        [Theory]
        [InlineData(1, "a", "")]
        [InlineData(201, "wws", "PuzzleDay2d1owws")]
        public void ShouldNot_CreatePuzzleDayClassName(int dayNumber, string daySuffix, string expected)
        {
            var name = PuzzleFactory.CreatePuzzleDayClassName(dayNumber, daySuffix);
            Assert.NotEqual(name, expected);
        }
    }
}