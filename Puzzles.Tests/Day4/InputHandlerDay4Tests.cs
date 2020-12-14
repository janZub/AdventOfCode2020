using FluentAssertions;
using Moq;
using Puzzles.Day4;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Puzzles.Tests.Day4
{
    public class InputHandlerDay4Tests
    {
        [Theory]
        [ClassData(typeof(InputHandlerDay4aData))]
        public void Should_CreatePassporsDay4aFromInput(List<string> lines, List<PassportDay4a> expectedPassports)
        {
            var inputHandler = new InputHandlerServiceDay4();
            var passports = inputHandler.CreatePassports4aFromInput(lines);

            passports.Should().AllBeOfType(typeof(PassportDay4a));
            passports.Should().BeEquivalentTo(expectedPassports);
        }

        [Theory]
        [ClassData(typeof(InputHandlerDay4bData))]
        public void Should_CreatePassporsDay4bFromInput(List<string> lines, List<PassportDay4b> expectedPassports)
        {
            var inputHandler = new InputHandlerServiceDay4();
            var passports = inputHandler.CreatePassports4bFromInput(lines);

            passports.Should().AllBeOfType(typeof(PassportDay4b));
            passports.Should().BeEquivalentTo(expectedPassports);
        }

        [Theory]
        [ClassData(typeof(InputHandlerDay4PassportDataInLines))]
        public void Should_ConvertListToPassportDataList(List<string> lines, List<string> expectedPassportsData)
        {
            var inputHandler = new InputHandlerServiceDay4();
            var passportsData = inputHandler.ConvertListToPassportDataList(lines);

            expectedPassportsData.Should().BeEquivalentTo(passportsData);
        }
    }

    public class InputHandlerDay4aData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var passportData1 = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd";
            var passportData2 = "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884";
            var passports = new List<PassportDay4a>()
            {
                new PassportDay4a(passportData1),
                new PassportDay4a(passportData2),
            };

            var listOfPassportData = new List<string>()
            {
                passportData1,
                passportData2
            };
            yield return new object[] {
                listOfPassportData, passports
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class InputHandlerDay4bData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var passportData1 = "ecl:   gry pid:860033327 eyr:2020 hcl:#fffffd";
            var passportData2 = "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884";

            var mock = new Mock<PasswordValidationService>();
            var passports = new List<PassportDay4b>()
            {
                new PassportDay4b(passportData1, mock.Object),
                new PassportDay4b(passportData2, mock.Object),
            };

            var listOfPassportData = new List<string>()
            {
                passportData1,
                passportData2
            };
            yield return new object[] {
                listOfPassportData, passports
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InputHandlerDay4PassportDataInLines : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<string>()
                {
                    "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                    "byr:1937 iyr:2017 cid:147 hgt:183cm",
                    ""
                },
                new List<string>()
                {
                string.Format("{0} {1}",
                    "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                    "byr:1937 iyr:2017 cid:147 hgt:183cm")
                 }
            };
            yield return new object[] {
                new List<string>()
                {
                    "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                    "hcl:#cfa07d byr:1929"
                },
                new List<string>()
                {
                string.Format("{0} {1}",
                    "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                    "hcl:#cfa07d byr:1929")
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}