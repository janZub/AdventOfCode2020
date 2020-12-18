using Moq;
using Puzzles.Day11;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day11
{
    public class SeatDay11Tests
    {
        [Theory]
        [InlineData('.', true)]
        [InlineData('#', false)]
        public void Should_IsFloor(char state, bool expected)
        {
            var seat = new SeatDay11(state);
            Assert.Equal(expected, seat.IsFloor());
        }
        [Theory]
        [InlineData('.', false)]
        [InlineData('#', true)]
        public void Should_IsOccupied(char state, bool expected)
        {
            var seat = new SeatDay11(state);
            Assert.Equal(expected, seat.IsOccupied());
        }
        [Theory]
        [InlineData('L', true)]
        [InlineData('#', false)]
        public void Should_IsEmpty(char state, bool expected)
        {
            var seat = new SeatDay11(state);
            Assert.Equal(expected, seat.IsEmpty());
        }
        [Theory]
        [InlineData('L', '#', true)]
        [InlineData('#', 'L', true)]
        [InlineData('.', '.', false)]
        public void Should_ChangeState(char state, char expected, bool expectedChange)
        {
            var seat = new SeatDay11(state);
            var stateChange = seat.ChangeState();

            Assert.Equal(expectedChange, stateChange);
            Assert.Equal(expected, seat.SeatState);
        }
    }
}