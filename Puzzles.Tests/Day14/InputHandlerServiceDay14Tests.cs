using FluentAssertions;
using Moq;
using Puzzles.Day14;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day14
{
    public class InputHandlerServiceDay14Tests
    {
        [Theory]
        [InlineData("mask = X10X010101101011X011X0X1010XX0001101", true)]
        [InlineData("mem[65231] = 6306247", false)]
        public void Should_IsMask(string input, bool expected)
        {
            var isMask = InputHandlerServiceDay14.IsMask(input);

            Assert.Equal(expected, isMask);
        }

        [Theory]
        [InlineData("mask = X10X010101101011X011X0X1010XX0001101", "X10X010101101011X011X0X1010XX0001101")]
        [InlineData("mask = 00X010010XX01001011011111010010X10X0", "00X010010XX01001011011111010010X10X0")]
        public void Should_ExtractMask(string input, string expected)
        {
            var maskCode = InputHandlerServiceDay14.ExtractMask(input);

            Assert.Equal(expected, maskCode);
        }


        [Theory]
        [ClassData(typeof(CreateMemoryInputData))]
        public void Should_CreateMemoryInput(int order, string input, IMask mask, MemoryInputDay14 expected)
        {
            var memoryData = InputHandlerServiceDay14.CreateMemoryInput(order, input, mask);

            memoryData.Should().BeEquivalentTo(expected);
        }
    }
    public class CreateMemoryInputData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var mask = new Mock<IMask>().Object;
            var order = 1;

            var expected = new Mock<MemoryInputDay14>(null ,null, null, null);
            expected.SetupGet(s => s.Mask).Returns(mask);
            expected.SetupGet(s => s.Order).Returns(order);
            expected.SetupGet(s => s.MemoryIndex).Returns(15228);
            expected.SetupGet(s => s.Number).Returns(58105116);

            yield return new object[] {
                order,"mem[15228] = 58105116", mask, expected.Object
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}