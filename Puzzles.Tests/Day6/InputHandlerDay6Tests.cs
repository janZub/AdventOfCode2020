using FluentAssertions;
using Moq;
using Puzzles.Day6;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Puzzles.Tests.Day6
{
    public class InputHandlerDay6Tests
    {
        [Theory]
        [MemberData(nameof(GroupData))]
        public void Should_ConvertListToGroupDataList(List<string> lines, List<string> expectedGroups)
        {
            var inputHandler = new InputHandlerServiceDay6();
            var groups = inputHandler.ConvertListToGroupDataList(lines);

            Assert.Equal(expectedGroups, groups);
        }
        [Theory]
        [ClassData(typeof(CreateGroupsData))]
        public void Should_CreateGroupsFromInput(List<string> lines, List<GroupDay6> expectedGroups)
        {
            var inputHandler = new InputHandlerServiceDay6();
            var groups = inputHandler.CreateGroupsFromInput(lines);

            groups.Should().BeEquivalentTo(expectedGroups);
        }
        public static IEnumerable<object[]> GroupData()
        {
            yield return new object[] {
                new List<string>() {"abc","","a","b","c","","ab","ac","","a","a","a","a","","b"},
                new List<string>() {"abc", "abc", "abac","aaaa","b"}
            };
        }
    }
    public class CreateGroupsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] {
                new List<string>(){"abcd", "aa"},
                new List<GroupDay6>() {new GroupDay6("abcd"), new GroupDay6("aa")}
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}