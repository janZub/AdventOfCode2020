using Puzzles.Day11;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day11
{
    public class AirportSeatsDay11Tests
    {
        [Theory]
        [ClassData(typeof(GetNumberOfOccupiedSeatsData))]
        public void Should_GetNumberOfOccupiedSeats(AirportSeatsDay11 seats, int expected)
        {
            var result = seats.GetNumberOfOccupiedSeats();

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(ChangeStateData))]
        public void Should_ChangeState(AirportSeatsDay11 seats, bool expected)
        {
            var result = seats.ChangeState();

            Assert.Equal(expected, result);
        }
    }
    public class GetNumberOfOccupiedSeatsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var chairs1 = new char[2, 2]
            {
                { '.','L' },
                { '.','#' }
            };

            var chairs2 = new char[3, 3]
            {
                { '.','L','L' },
                { '.','L', '#' },
                { '#','#', '#' },
            };
            var airportSeat1 = new AirportSeatsDay11(chairs1);
            var airportSeat2 = new AirportSeatsDay11(chairs2);
            yield return new object[] {
                airportSeat1, 1
            };
            yield return new object[] {
                airportSeat2, 4
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ChangeStateData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var chairs1 = new char[2, 2]
            {
                { '.','L' },
                { '.','L' }
            };

            var chairs2 = new char[3, 3]
            {
                { '#','#', '#' },
                { '.','L', '.' },
                { '#','#', '#' },
            };
            var airportSeat1 = new AirportSeatsDay11(chairs1);
            var airportSeat2 = new AirportSeatsDay11(chairs2);
           
            yield return new object[] {
                airportSeat1, true
            };
            yield return new object[] {
                airportSeat2, false
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}