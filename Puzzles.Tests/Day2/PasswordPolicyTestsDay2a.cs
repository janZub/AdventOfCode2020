using Puzzles.Day2;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System;

namespace Puzzles.Tests.Day2
{
    public class PasswordPolicyTestsDay2a
    {
        [Theory]
        [ClassData(typeof(PasswordPolicyValidDataDay2a))]
        public void Should_CreatePolicy(string policy, PasswordPolicyDay2a expected)
        {
            var newPolicy = new PasswordPolicyDay2a(policy);
            newPolicy.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(PasswordPolicyInValidDataDay2a))]
        public void ShouldNot_CreatePolicy(string policy)
        {
            Assert.Throws<ArgumentException>(() => new PasswordPolicyDay2a(policy));
        }
    }
    public class PasswordPolicyValidDataDay2a : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                "2-4 m: aaaaa",
                new PasswordPolicyDay2a
                {
                    Password = "aaaaa",
                    MinOccurences = 2,
                    MaxOccurences = 4,
                    Letter = "m"
                }
            };

            yield return new object[] {
                "0-31 c: aaswaoikoaaaa",
                new PasswordPolicyDay2a
                {
                    Password = "aaswaoikoaaaa",
                    MinOccurences = 0,
                    MaxOccurences = 31,
                    Letter = "c"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PasswordPolicyInValidDataDay2a : IEnumerable<object[]>
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