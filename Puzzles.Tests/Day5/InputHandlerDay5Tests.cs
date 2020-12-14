using FluentAssertions;
using Moq;
using Puzzles.Day5;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Puzzles.Tests.Day5
{
    public class InputHandlerDay5Tests
    {
        [Theory]
        [ClassData(typeof(InputHandlerDay5Data))]
        public void Should_CreateSeatsDay5FromInput(List<string> input, List<Seat> expectedSeats)
        {
            var inputHandler = new InputHandlerDay5Service();
            var seats = inputHandler.CreateSeatsFromInput(input);

            seats.Should().AllBeOfType(typeof(Seat));
            seats.Should().BeEquivalentTo(expectedSeats);
        }
    }

    public class InputHandlerDay5Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<string>(){ "BBFFBBFRLL" },
                new List<Seat>(){ new Seat("BBFFBBFRLL") }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}