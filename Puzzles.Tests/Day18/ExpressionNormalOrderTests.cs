using FluentAssertions;
using Moq;
using Puzzles.Day18;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day18
{
    public class ExpressionNormalOrderTests
    {
        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void ShouldSolve(string expression, ulong expectation)
        {
            var solver = new ExpressionNormalOrder();
            var result = solver.Solve(expression);

            Assert.Equal(expectation, result);
        }
    }
}