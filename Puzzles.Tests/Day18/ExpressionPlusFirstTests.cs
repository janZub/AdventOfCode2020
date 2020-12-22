using FluentAssertions;
using Moq;
using Puzzles.Day18;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day18
{
    public class ExpressionPlusFirstTests
    {
        [Theory]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void Should_Solve(string expression, ulong expectation)
        {
            var solver = new ExpressionPlusFirst();
            var result = solver.Solve(expression);

            Assert.Equal(expectation, result);
        }
    }
}