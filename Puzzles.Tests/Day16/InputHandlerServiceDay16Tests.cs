using FluentAssertions;
using Moq;
using Puzzles.Day16;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day16
{
    public class InputHandlerServiceDay16Tests
    {
        [Theory]
        [ClassData(typeof(GetNewRuleData))]
        public void Should_GetNewRule(string rule, RuleDay16 expectation)
        {
            var inputHandler = new InputHandlerServiceDay16();
            var result = inputHandler.GetNewRule(rule);

            result.Should().BeEquivalentTo(expectation);
        }
        [Theory]
        [MemberData(nameof(GetNewTicketValuesData))]
        public void Should_GetNewTicketValues(string ticket, List<int> expectation)
        {
            var inputHandler = new InputHandlerServiceDay16();
            var result = inputHandler.GetNewTicketValues(ticket);

            result.Should().BeEquivalentTo(expectation);
        }
        public static IEnumerable<object[]> GetNewTicketValuesData()
        {
            yield return new object[] { "7,3,47", new List<int>() { 7, 3, 47 } };
            yield return new object[] { "55,2,20", new List<int>() { 55, 2, 20 } };
        }

    }
    public class GetNewRuleData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var expected = new Mock<RuleDay16>("class");
            var inputRule = "class: 1-3 or 5-7";

            expected.SetupGet(s => s.Name).Returns("class");
            expected.SetupGet(s => s.Ranges).Returns(
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,3),
                    new Tuple<int, int>(5,7),
                });

            var expected2 = new Mock<RuleDay16>(null);
            var inputRule2 = "seat: 13-40 or 45-50";

            expected2.SetupGet(s => s.Name).Returns("seat");
            expected2.SetupGet(s => s.Ranges).Returns(
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(13,40),
                    new Tuple<int, int>(45, 50),
                });

            yield return new object[] {
                inputRule, expected.Object
            };
            yield return new object[] {
                inputRule2, expected2.Object
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}