using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Puzzles.Tests.Day4
{
    public class InputHandlerDay4aTests
    {
        [Theory]
        [ClassData(typeof(InputHandlerDay4aData))]
        public void Should_CreatePassporsFromInput(List<string> lines, List<Passport> expectedPassports)
        {
            var inputHandler = new InputHandlerDay4a();
            var passports = inputHandler.CreatePassporsFromInput(lines);

            passports.Should().BeEquivalentTo(expectedPassports);
        }
    }

    public class InputHandlerDay4aData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var lines1 = new List<string>()
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm",
                ""
            };
            var lines2 = new List<string>()
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929",
                ""
            };
            var lines3 = new List<string>()
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm",
                "",
            };
            var lines4 = new List<string>()
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in",
            };

            var passports = new List<Passport>()
            {
                new Passport(lines1),
                new Passport(lines2),
                new Passport(lines3),
                new Passport(lines4),
            };

            var lines = lines1.Concat(lines2).Concat(lines3).Concat(lines4).ToList();
            yield return new object[] {
                lines, passports
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}