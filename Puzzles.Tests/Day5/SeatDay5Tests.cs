using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using Puzzles.Day5;

namespace Puzzles.Tests.Day5
{
    public class SeatDay5Tests
    {
        [Theory]
        [InlineData("BFFFBBFRRR", 70)]
        [InlineData("FFFBBBFRRR", 14)]
        [InlineData("BBFFBBFRLL", 102)]
        [InlineData("FFFFFFFRLL", 0)]
        [InlineData("BBBBBBBRLL", 127)]
        public void Should_GetRowId(string code, int expectedRowId)
        {
            var seat = new Seat(code);
            var result = seat.GetRowId();

            Assert.Equal(expectedRowId, result);
        }
        
        [Theory]
        [InlineData("BFFFBBFRRR", 7)]
        [InlineData("FFFBBBFRRR", 7)]
        [InlineData("BBFFBBFRLL", 4)]
        [InlineData("FFFFFFFLLL", 0)]
        public void Should_GetColumnId(string code, int expectedRowId)
        {
            var seat = new Seat(code);
            var result = seat.GetColumnId();

            Assert.Equal(expectedRowId, result);
        }

        [Theory]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        [InlineData("FFFFFFFLLL", 0)]
        public void Should_SeatId(string code, int expectedRowId)
        {
            var seat = new Seat(code);
            var result = seat.GetSeatId();

            Assert.Equal(expectedRowId, result);
        }

    }
}