using FluentAssertions;
using Moq;
using Puzzles.Day14;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day14
{
    public class MaskDay14Tests
    {
        [Theory]
        [MemberData(nameof(ApllyMaskData))]
        public void Should_ApplyMask(string maskCode, char[] number, char[] expected)
        {
            var mask = new MaskDay14(maskCode);
            var result = mask.ApplyMask(number);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> ApllyMaskData()
        {
            yield return new object[]
            {
                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "000000000000000000000000000000001011".ToCharArray(),
                "000000000000000000000000000001001001".ToCharArray()
            };
            yield return new object[]
            {
                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "000000000000000000000000000001100101".ToCharArray(),
                "000000000000000000000000000001100101".ToCharArray()
            };
            yield return new object[]
            {
                "1XXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "000000000000000000000000000001100101".ToCharArray(),
                "100000000000000000000000000001100101".ToCharArray()
            };
        }
    }
}