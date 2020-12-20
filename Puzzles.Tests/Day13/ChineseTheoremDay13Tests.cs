using FluentAssertions;
using Moq;
using Puzzles.Day13;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day13
{
    public class ChineseTheoremDay13Tests
    {
        [Theory]
        [MemberData(nameof(ComputeProductNData))]
        public void Should_ComputeProductN(List<ulong> numbers, ulong expected)
        {
            var result = ChineseTheoremDay13.ComputeProductN(numbers);
            Assert.Equal(expected, result);
        }
        [Theory]
        [MemberData(nameof(SolveForNPrimesData))]
        public void Should_SolveForNPrimes(List<Tuple<ulong, ulong>> numbers, ulong expected)
        {
            var result = ChineseTheoremDay13.SolveForNPrimes(numbers);
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> ComputeProductNData()
        {
            yield return new object[] { new List<ulong>() { 2, 5, 10 }, 100 };
            yield return new object[] { new List<ulong>() { 0, 31, 50, 11, 231, 2308, 32123 }, 0 };
        }
        public static IEnumerable<object[]> SolveForNPrimesData()
        {
            yield return new object[] { new List<Tuple<ulong,ulong>>()
            {
                new Tuple<ulong, ulong>(0,7),
                new Tuple<ulong, ulong>(12,13),
                new Tuple<ulong, ulong>(55,59),
                new Tuple<ulong, ulong>(25,31),
                new Tuple<ulong, ulong>(12,19),
            }, 1068781 };

            yield return new object[] { new List<Tuple<ulong,ulong>>()
            {
                new Tuple<ulong, ulong>(0,1789),
                new Tuple<ulong, ulong>(36,37),
                new Tuple<ulong, ulong>(45,47),
                new Tuple<ulong, ulong>(1886,1889)
            }, 1202161486 };


        }
    }
}