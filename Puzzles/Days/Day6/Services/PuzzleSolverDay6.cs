
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day6
{
    public class PuzzleSolverDay6
    {
        public int CountAnswersInGroups(List<IGroupDay6> groups)
        {
            int groupsAnswers = 0;
            foreach (var group in groups)
                groupsAnswers += group.CountDifferentAnswers();

            return groupsAnswers;
        }
    }
}