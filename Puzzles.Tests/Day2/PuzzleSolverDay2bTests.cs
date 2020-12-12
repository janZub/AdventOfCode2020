using Puzzles.Day2;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Puzzles.Tests.Day2
{
    public class PuzzleSolverDay2bTests
    {
        [Theory]
        [ClassData(typeof(PasswordPolicySolverValidDataDay2b))]
        public void Should_GetNumberOfValidPasswords(List<PasswordPolicyDay2b> passwordPolicies, int expected)
        {
            var solver = new PuzzleSolverDay2b();
            var result = solver.GetNumberOfValidPasswords(passwordPolicies);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(PasswordPolicySolverInValidDataDay2b))]
        public void ShouldNot_GetNumberOfValidPasswords_IndexOutO(List<PasswordPolicyDay2b> passwordPolicies)
        {
            var solver = new PuzzleSolverDay2b();

            Assert.Throws<ArgumentOutOfRangeException>(() => solver.GetNumberOfValidPasswords(passwordPolicies));
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
    public class PasswordPolicySolverInValidDataDay2b : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
               new List<PasswordPolicyDay2b>(){
               new PasswordPolicyDay2b
                {
                    Password = "aaaa",
                    Occurrences = new List<int>(){2,34},
                    Letter = "a"
                },
               },
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}