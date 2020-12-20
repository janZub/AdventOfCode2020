using FluentAssertions;
using Moq;
using Puzzles.Day14;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day14
{
    public class MaskDay14bTests
    {
        [Theory]
        [MemberData(nameof(ApllyMaskData))]
        public void Should_ApplyMask(string maskCode, char[] number, char[] expected)
        {
            var mask = new MaskDay14b(maskCode);
            var result = mask.ApplyMask(number);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> ApllyMaskData()
        {
            yield return new object[]
            {
                "000000000000000000000000000000X1001X",
                "000000000000000000000000000000101010".ToCharArray(),
                "000000000000000000000000000000X1101X".ToCharArray()
            };
            yield return new object[]
            {
                "00000000000000000000000000000000X0XX",
                "000000000000000000000000000000011010".ToCharArray(),
                "00000000000000000000000000000001X0XX".ToCharArray()
            };
        }
    }
}