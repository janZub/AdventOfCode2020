using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day6
{
    public class GroupDay6b : GroupDay6
    {
        private int groupSize;
        public GroupDay6b(string data, int groupSize) : base(data)
        {
            this.groupSize = groupSize;
        }

        public override int CountDifferentAnswers()
        {
            var matches = Regex.Matches(Data, pattern);
            if (matches.Count == 0)
                return 0;

            var foundUniqueAnswers = matches.Select(e => e.Value)
                .GroupBy(m => m, (key, g) => g.Count())
                .Where(answersCount => answersCount == groupSize)
                .Count();

            return foundUniqueAnswers;
        }
    }
}