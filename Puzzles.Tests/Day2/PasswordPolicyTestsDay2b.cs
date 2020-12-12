using Puzzles.Day2;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System;

namespace Puzzles.Tests
{
    public class PasswordPolicyTestsDay2b
    {
        [Theory]
        [ClassData(typeof(PasswordPolicyValidDataDay2b))]
        public void Should_CreatePolicy(string policy, PasswordPolicyDay2b expected)
        {
            var newPolicy = new PasswordPolicyDay2b(policy);
            newPolicy.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(PasswordPolicyInValidDataDay2b))]
        public void ShouldNot_CreatePolicy(string policy)
        {
            Assert.Throws<ArgumentException>(() => new PasswordPolicyDay2b(policy));
        }
    }
    public class PasswordPolicyValidDataDay2b : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                "2-4 m: aaaaa",
                new PasswordPolicyDay2b
                {
                    Password = "aaaaa",
                    Occurrences = new List<int>(){2,4},
                    Letter = "m"
                }
            };

            yield return new object[] {
                "1-3-7 c: aaswaoikoaaaa",
                new PasswordPolicyDay2b
                {
                    Password = "aaswaoikoaaaa",
                    Occurrences = new List<int>(){1,3,7},
                    Letter = "c"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PasswordPolicyInValidDataDay2b : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                "-10 m: aaaaa"
            };

            yield return new object[] {
                "0- c: aaswaoikoaaaa"
            };
            yield return new object[] {
                "0-31 : aaswaoikoaaaa"
            };
            yield return new object[] {
                "0-31 c: "
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}