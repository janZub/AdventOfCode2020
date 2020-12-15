using FluentAssertions;
using Moq;
using Puzzles.Day6;
using System;
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
        public void Should_ConvertListToGroupDataList(List<string> lines, List<Tuple<string, int>> expectedGroups)
        {
            var inputHandler = new InputHandlerServiceDay6();
            var groups = inputHandler.ConvertListToGroupDataList(lines);

            Assert.Equal(expectedGroups, groups);
        }
        [Theory]
        [ClassData(typeof(CreateGroupsDataDay6a))]
        public void Should_CreateGroupsDay6aFromInput(List<string> lines, List<GroupDay6a> expectedGroups)
        {
            var inputHandler = new InputHandlerServiceDay6();
            var groups = inputHandler.CreateGroup6aFromInput(lines);

            groups.Should().AllBeOfType(typeof(GroupDay6a));
            groups.Should().BeEquivalentTo(expectedGroups);
        }
        [Theory]
        [ClassData(typeof(CreateGroupsDataDay6b))]
        public void Should_CreateGroupsDay6bFromInput(List<Tuple<string, int>> input, List<GroupDay6b> expectedGroups)
        {
            var inputHandler = new InputHandlerServiceDay6();
            var groups = inputHandler.CreateGroup6bFromInput(input);

            groups.Should().AllBeOfType(typeof(GroupDay6b));
            groups.Should().BeEquivalentTo(expectedGroups);
        }
        public static IEnumerable<object[]> GroupData()
        {
            yield return new object[] {
                new List<string>() {"abc","","a","b","c","","ab","ac","","a","a","a","a","","b"},
                new List<Tuple<string,int>>() {
                    new Tuple<string, int>("abc",1),
                    new Tuple<string, int>("abc",3),
                    new Tuple<string, int>("abac",2),
                    new Tuple<string, int>("aaaa",4),
                    new Tuple<string, int>("b",1),
                }
            };
        }
    }

    public class CreateGroupsDataDay6b : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] {
                new List<Tuple<string,int>>()
                {
                    new Tuple<string, int>("abcd", 5),
                    new Tuple<string, int>("aa", 3)
                },
                new List<GroupDay6b>() {new GroupDay6b("abcd",5), new GroupDay6b("aa",3)}
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CreateGroupsDataDay6a : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] {
                new List<string>(){"abcd", "aa"},
                new List<GroupDay6a>() {new GroupDay6a("abcd"), new GroupDay6a("aa")}
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}