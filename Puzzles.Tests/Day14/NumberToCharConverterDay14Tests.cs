using FluentAssertions;
using Moq;
using Puzzles.Day14;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day14
{
    public class NumberToCharConverterDay14Tests
    {
        [Theory]
        [InlineData(11, "000000000000000000000000000000001011")]
        [InlineData(0, "000000000000000000000000000000000000")]
        [InlineData(64, "000000000000000000000000000001000000")]
        [InlineData(73, "000000000000000000000000000001001001")]
        [InlineData(101, "000000000000000000000000000001100101")]
        public void Should_ConvertNumberToCharArray(ulong number, string expected)
        {
            var result = NumberToCharConverterDay14.ConvertNumberToCharArray(number);

            Assert.Equal(expected.ToCharArray(), result);
        }

        [Theory]
        [InlineData("000000000000000000000000000000001011", 11)]
        [InlineData("000000000000000000000000000000000000", 0)]
        [InlineData("000000000000000000000000000001000000", 64)]
        [InlineData("000000000000000000000000000001001001", 73)]
        [InlineData("000000000000000000000000000001100101", 101)]
        public void Should_ConvertCharArrayToNumber(string numberChars, ulong expected)
        {
            var result = NumberToCharConverterDay14.ConvertCharArrayToNumber(numberChars.ToCharArray());

            Assert.Equal(expected, result);
        }
        [Theory]
        [ClassData(typeof(ApplyMaskToNumberData))]
        public void Should_ApplyMaskToNumber(ulong number, IMask mask, ulong expected)
        {
            var result = NumberToCharConverterDay14.ApplyMaskToNumber(number, mask);

            Assert.Equal(expected, result);
        }
    }
    public class ApplyMaskToNumberData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var nr1 = "000000000000000000000000000001100101".ToCharArray();//101
            var nr2 = "000000000000000000000000000000001011".ToCharArray();//11
            var nr3 = "000000000000000000000000000001001001".ToCharArray();//73


            var mask = new Mock<IMask>();
            mask.Setup(m => m.ApplyMask(nr1)).Returns(nr1);
            mask.Setup(m => m.ApplyMask(nr2)).Returns(nr3);
            mask.Setup(m => m.ApplyMask(nr3)).Returns(nr2);

            yield return new object[] {
               101, mask.Object, 101
            };
            yield return new object[] {
               11, mask.Object, 73
            };
            yield return new object[] {
               73, mask.Object, 11
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}