using Puzzles.Day4;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;

namespace Puzzles.Tests.Day4
{
    public class PuzzleSolverDay4aTests
    {
        [Theory]
        [ClassData(typeof(PuzzleSolverDay4aTestData))]
        public void Should_CountValidPassports(List<IPassportDay4> passports, int expectedValidPasswords)
        {
            var solver = new PuzzleSolverDay4();
            var result = solver.CountValidPassports(passports);

            Assert.Equal(expectedValidPasswords, result);
        }
    }

    public class PuzzleSolverDay4aTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var mocqValid = new Mock<IPassportDay4>();
            mocqValid.Setup(s => s.IsValid()).Returns(true);

            var mocqInvalid = new Mock<IPassportDay4>();
            mocqInvalid.Setup(s => s.IsValid()).Returns(false);

            var passports = new List<IPassportDay4>()
            {
                mocqValid.Object,
                mocqInvalid.Object,
                mocqValid.Object,
                mocqInvalid.Object,
            };

            yield return new object[] {
               passports, 2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}