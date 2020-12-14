using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Text.RegularExpressions;
using Moq;

namespace Puzzles.Tests.Day4
{
    public class PassportDay4bTests
    {
        [Theory]
        [MemberData(nameof(PassportLines))]
        public void Should_IsValid(PassportDay4b passport, bool expected)
        {
            var isValid = passport.IsValid();
            Assert.Equal(expected, isValid);
        }
        public static IEnumerable<object[]> PassportLines()
        {
            var mocqValidatorTrue = new Mock<IPassportValidator>();
            mocqValidatorTrue
                .Setup(p => p.IsPropertyValid(It.IsAny<string[]>(), It.IsAny<string>()))
                .Returns(true);

            yield return new object[] {
                new PassportDay4b("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 " +
                "byr:1980 hcl:#623a2f",
                mocqValidatorTrue.Object),
                true
            };

            var mocqValidatorFalse = new Mock<IPassportValidator>();
            mocqValidatorFalse
                .Setup(p => p.IsPropertyValid(It.IsAny<string[]>(), It.IsAny<string>()))
                .Returns(false);

            yield return new object[] {
                new PassportDay4b("dh", mocqValidatorFalse.Object),
                false
            };
        }
    }
}