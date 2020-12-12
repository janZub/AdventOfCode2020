using Puzzles.Day2;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System;

namespace Puzzles.Tests
{
    public class PasswordPolicyTests
    {
        [Theory]
        [ClassData(typeof(PasswordPolicyValidData))]
        public void Should_CreatePolicy(string policy, PasswordPolicy expected)
        {
            var newPolicy = new PasswordPolicy(policy);
            newPolicy.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(PasswordPolicyInValidData))]
        public void ShouldNot_CreatePolicy(string policy)
        {
            Assert.Throws<ArgumentException>(() => new PasswordPolicy(policy));
        }
    }
    public class PasswordPolicyValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                "2-4 m: aaaaa",
                new PasswordPolicy
                {
                    Password = "aaaaa",
                    MinOccurances = 2,
                    MaxOccurances = 4,
                    Letter = "m"
                }
            };

            yield return new object[] {
                "0-31 c: aaswaoikoaaaa",
                new PasswordPolicy
                {
                    Password = "aaswaoikoaaaa",
                    MinOccurances = 0,
                    MaxOccurances = 31,
                    Letter = "c"
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PasswordPolicyInValidData : IEnumerable<object[]>
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