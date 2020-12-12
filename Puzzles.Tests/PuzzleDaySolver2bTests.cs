using Puzzles.Day2;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests
{
    public class PuzzleDaySolver2bTests
    {

        [Theory]
        [ClassData(typeof(PasswordPolicySolverValidDataDay2b))]
        public void Should_GetNumberOfValidPasswords(List<PasswordPolicyDay2b> passwordPolicies, int expected)
        {
            var solver = new PuzzleDay2bSolver();
            var result = solver.GetNumberOfValidPasswords(passwordPolicies);

            Assert.Equal(expected, result);
        }
    }
    public class PasswordPolicySolverValidDataDay2b : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               new List<PasswordPolicyDay2b>(){
               new PasswordPolicyDay2b
                {
                    Password = "aaaa",
                    Occurrences = new List<int>(){2,4},
                    Letter = "a"
                },
               new PasswordPolicyDay2b
                {
                    Password = "wwakdokda",
                    Occurrences = new List<int>(){5,8},
                    Letter = "d"
                },
               new PasswordPolicyDay2b
                {
                    Password = "adkioajio",
                    Occurrences = new List<int>(){1,2,3},
                    Letter = "a"
                },
                new PasswordPolicyDay2b
                {
                    Password = "admioajio",
                    Occurrences = new List<int>(){1,2,3},
                    Letter = "m"
                },
                },
                2
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}