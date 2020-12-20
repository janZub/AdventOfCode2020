using FluentAssertions;
using Moq;
using Puzzles.Day13;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day13
{
    public class EuclidForCoPrimeDay13Tests
    {
        [Theory]
        [InlineData(247,17,218)]
        [InlineData(43, 17, 38)]
        public void Should_GetGetCofficentBForNi(ulong ni, ulong Ni, ulong expected)
        {
            var result = EuclidForCoPrimeDay13.GetCofficentBForNi(ni, Ni);
            Assert.Equal(expected, result);

        }
    }
}