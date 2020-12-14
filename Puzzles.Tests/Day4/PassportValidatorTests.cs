using FluentAssertions;
using Moq;
using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Puzzles.Tests.Day4
{
    public class PassportValidatorTests
    {
        [Theory]
        [MemberData(nameof(PassportValidatorData))]
        public void Should_IsPropertyValid(string[] match, string property, bool expectedIsValid)
        {
            var validator = new PassportPropertyValidator();
            var isValid = validator.IsPropertyValid(match, property);

            Assert.Equal(expectedIsValid, isValid);
        }

        [Theory]
        [InlineData(new string[] { "nonExistingParam", "" }, "nonExistingParam")]
        public void ShouldNot_IsPropertyValid(string[] match, string nonExistingProperty)
        {
            var validator = new PassportPropertyValidator();
            Assert.Throws<ArgumentException>("property", () => validator.IsPropertyValid(match, nonExistingProperty));
        }

        public static IEnumerable<object[]> PassportValidatorData()
        {
            yield return new object[] { new string[] { "byr", "1921" }, "byr", true };
            yield return new object[] { new string[] { "byr", "2001" }, "byr", true };
            yield return new object[] { new string[] { "byr", "1919" }, "byr", false };
            yield return new object[] { new string[] { "byr", "3000" }, "byr", false };
            yield return new object[] { new string[] { "byr", "jdai" }, "byr", false };

            yield return new object[] { new string[] { "iyr", "2020" }, "iyr", true };
            yield return new object[] { new string[] { "iyr", "djio" }, "iyr", false };
            yield return new object[] { new string[] { "iyr", "2000" }, "iyr", false };
            yield return new object[] { new string[] { "iyr", "2021" }, "iyr", false };

            yield return new object[] { new string[] { "eyr", "2020" }, "eyr", true };
            yield return new object[] { new string[] { "eyr", "2030" }, "eyr", true };
            yield return new object[] { new string[] { "eyr", "djio" }, "eyr", false };
            yield return new object[] { new string[] { "eyr", "2000" }, "eyr", false };
            yield return new object[] { new string[] { "eyr", "2031" }, "eyr", false };

            yield return new object[] { new string[] { "hcl", "#abc123" }, "hcl", true };
            yield return new object[] { new string[] { "hcl", "abc123" }, "hcl", false };
            yield return new object[] { new string[] { "hcl", "#abc12" }, "hcl", false };
            yield return new object[] { new string[] { "hcl", "#abc1234" }, "hcl", false };
            yield return new object[] { new string[] { "hcl", "#abc12g" }, "hcl", false };

            yield return new object[] { new string[] { "ecl", "amb" }, "ecl", true };
            yield return new object[] { new string[] { "ecl", "blue" }, "ecl", false };
            yield return new object[] { new string[] { "ecl", "brn" }, "ecl", true };
            yield return new object[] { new string[] { "ecl", "gry" }, "ecl", true };
            yield return new object[] { new string[] { "ecl", "grn" }, "ecl", true };
            yield return new object[] { new string[] { "ecl", "hzl" }, "ecl", true };
            yield return new object[] { new string[] { "ecl", "oth" }, "ecl", true };

            yield return new object[] { new string[] { "pid", "123456789" }, "pid", true };
            yield return new object[] { new string[] { "pid", "001234567" }, "pid", true };
            yield return new object[] { new string[] { "pid", "12345678" }, "pid", false };
            yield return new object[] { new string[] { "pid", "1234567890" }, "pid", false };
            yield return new object[] { new string[] { "pid", "12345678a" }, "pid", false };

            yield return new object[] { new string[] { "hgt", "150cm" }, "hgt", true };
            yield return new object[] { new string[] { "hgt", "149cm" }, "hgt", false };
            yield return new object[] { new string[] { "hgt", "193cm" }, "hgt", true };
            yield return new object[] { new string[] { "hgt", "194cm" }, "hgt", false };
            yield return new object[] { new string[] { "hgt", "cm180" }, "hgt", false };

            yield return new object[] { new string[] { "hgt", "59in" }, "hgt", true };
            yield return new object[] { new string[] { "hgt", "9in" }, "hgt", false };
            yield return new object[] { new string[] { "hgt", "76in" }, "hgt", true };
            yield return new object[] { new string[] { "hgt", "1000in" }, "hgt", false };
            yield return new object[] { new string[] { "hgt", "in70" }, "hgt", false };
        }
    }
}