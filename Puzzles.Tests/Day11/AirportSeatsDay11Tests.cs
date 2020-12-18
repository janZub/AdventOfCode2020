using Moq;
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
            var strategyMock = new Mock<ISittingStrategy>();
            var seats1 = new SeatDay11[2, 2]
            {
                {new SeatDay11('.'), new SeatDay11('L') },
                { new SeatDay11('.'), new SeatDay11('#') }
            };

            var seats2 = new SeatDay11[3, 2]
            {
                {new SeatDay11('.'), new SeatDay11('L') },
                { new SeatDay11('.'), new SeatDay11('#') },
                { new SeatDay11('#'), new SeatDay11('#') }
            };

            var airportSeat1 = new AirportSeatsDay11(strategyMock.Object, seats1);
            var airportSeat2 = new AirportSeatsDay11(strategyMock.Object, seats2);

            yield return new object[] {
                airportSeat1, 1
            };
            yield return new object[] {
                airportSeat2, 3
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ChangeStateData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var strategyMock1 = new Mock<ISittingStrategy>();
            var strategyMock2 = new Mock<ISittingStrategy>();
            var strategyMock3 = new Mock<ISittingStrategy>();

            var seats1 = new SeatDay11[2, 2]
            {
                {new SeatDay11('#'), new SeatDay11('L') },
                { new SeatDay11('L'), new SeatDay11('#') }
            };

            var seats2 = new SeatDay11[2, 2]
            {
                {new SeatDay11('.'), new SeatDay11('.') },
                { new SeatDay11('.'), new SeatDay11('.') }
            };

            strategyMock1.Setup(s => s.ShouldChangeState(It.IsAny<SeatDay11>(), It.IsAny<int>()))
                .Returns(true);

            strategyMock2.Setup(s => s.ShouldChangeState(It.IsAny<SeatDay11>(), It.IsAny<int>()))
                .Returns(false);


            strategyMock3.Setup(s => s.CountOccupiedNeighbours(It.IsAny<SeatDay11[,]>(), 1, 1)).Returns(10);
            strategyMock3.SetReturnsDefault(false);
            strategyMock3.Setup(s => s.ShouldChangeState(It.IsAny<SeatDay11>(), 10))
                .Returns(true);


            var airportSeats1 = new AirportSeatsDay11(strategyMock1.Object, seats1);
            var airportSeats2 = new AirportSeatsDay11(strategyMock2.Object, seats1);
            var airportSeats3 = new AirportSeatsDay11(strategyMock3.Object, seats1);
            var airportSeats4 = new AirportSeatsDay11(strategyMock1.Object, seats2);

            yield return new object[] {
                airportSeats1, true
            };
            yield return new object[] {
                airportSeats2, false
            };
            yield return new object[] {
                airportSeats3, true
            };
            yield return new object[] {
                airportSeats4, false
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}