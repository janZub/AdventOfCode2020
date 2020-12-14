using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace Puzzles.Tests.Day4
{
    public class PassportDay4Tests
    {
        [Fact]
        public void Should_RequiredProperties()
        {
            var reqProperties = new List<string>() {
                "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
            };
            Assert.Equal(reqProperties, PassportDay4.RequiredProperties);
        }
    }
}