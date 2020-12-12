using Puzzles.Day2;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day2
{
    public class PuzzleSolverDay2aTests
    {
        [Theory]
        [ClassData(typeof(PasswordPolicySolverValidData))]
        public void Should_GetNumberOfValidPasswords(List<PasswordPolicyDay2a> passwordPolicies, int expected)
        {
            var solver = new PuzzleSolverDay2a();
            var result = solver.GetNumberOfValidPasswords(passwordPolicies);

            Assert.Equal(expected, result);
        }
    }
    public class PasswordPolicySolverValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<PasswordPolicyDay2a>(){
               new PasswordPolicyDay2a
                {
                    Password = "aaaa",
                    MinOccurences = 2,
                    MaxOccurences = 4,
                    Letter = "a"
                },
               new PasswordPolicyDay2a
                {
                    Password = "wwakdokda",
                    MinOccurences = 2,
                    MaxOccurences = 4,
                    Letter = "d"
                },
               new PasswordPolicyDay2a
                {
                    Password = "aaaaa",
                    MinOccurences = 2,
                    MaxOccurences = 4,
                    Letter = "m"
                },
                },
                2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}