using Puzzles.Day2;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests
{
    public class PuzzleDaySolver2aTests
    {

        [Theory]
        [ClassData(typeof(PasswordPolicySolverValidData))]
        public void Should_GetNumberOfValidPasswords(List<PasswordPolicy> passwordPolicies, int expected)
        {
            var solver = new PuzzleDay2aSolver();
            var result = solver.GetNumberOfValidPasswords(passwordPolicies);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> KNumbersThatSumToN()
        {
            yield return new object[] {
                new List<int>() { 1, 2, 3, 5, 6, 2017 },
                7, 2020
            };
        }
    }
    public class PasswordPolicySolverValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<PasswordPolicy>(){
               new PasswordPolicy
                {
                    Password = "aaaa",
                    MinOccurances = 2,
                    MaxOccurances = 4,
                    Letter = "a"
                },
               new PasswordPolicy
                {
                    Password = "wwakdokda",
                    MinOccurances = 2,
                    MaxOccurances = 4,
                    Letter = "d"
                },
               new PasswordPolicy
                {
                    Password = "aaaaa",
                    MinOccurances = 2,
                    MaxOccurances = 4,
                    Letter = "m"
                },
                },
                2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}