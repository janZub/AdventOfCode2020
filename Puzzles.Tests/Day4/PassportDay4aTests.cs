using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace Puzzles.Tests.Day4
{
    public class PassportDay4aTests
    {
        [Theory]
        [MemberData(nameof(PassportLines))]
        public void Should_IsValid(PassportDay4a passport, bool expected)
        {
            var isValid = passport.IsValid();

            Assert.Equal(expected, isValid);
        }
        public static IEnumerable<object[]> PassportLines()
        {
            yield return new object[] {
                 new PassportDay4a("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd " +
                "byr:1937 iyr:2017 cid:147 hgt:183cm"),
                true
            };
            yield return new object[]  {
                new PassportDay4a("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 " +
                "hcl:#cfa07d byr:1929"),
                false
            };
            yield return new object[] {
                new PassportDay4a("hcl:#ae17e1 iyr:2013 eyr:2024" +
                "ecl:brn pid:760753108 byr:1931" +
                "hgt:179cm"),
                true
            };
            yield return new object[]{
                new PassportDay4a("hcl:#cfa07d eyr:2025 pid:166559648" +
                "iyr:2011 ecl:brn hgt:59in"),
                false
            };
        }
    }
}