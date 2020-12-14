using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using Puzzles.Day6;

namespace Puzzles.Tests.Day6
{
    public class PuzzleSolverDay6Tests
    {
        [Theory]
        [ClassData(typeof(PuzzleSolverDay6TestData))]
        public void Should_CountAnswersInGroups(List<IGroupDay6> groups, int expectedCount)
        {
            var solver = new PuzzleSolverDay6();
            var result = solver.CountAnswersInGroups(groups);

            Assert.Equal(expectedCount, result);
        }
    }

    public class PuzzleSolverDay6TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            Mock<IGroupDay6> group1 = new Mock<IGroupDay6>();
            group1.Setup(s => s.CountDifferentAnswers()).Returns(2);

            Mock<IGroupDay6> group2 = new Mock<IGroupDay6>();
            group2.Setup(s => s.CountDifferentAnswers()).Returns(7);

            yield return new object[] {
                new List<IGroupDay6>(){ group1.Object, group2.Object },
                9
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}