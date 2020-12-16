using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day7
{
    public class RegexMatcherServiceDay7
    {
        private string pattern = @"([a-z\s]*)\sbags\scontain(?:\s([\d])*\s([a-z\s]*)bags?[,|\.])*";

        public GroupCollection GetMatches(string input)
        {
            var matches = Regex.Matches(input, pattern);

            ValidateMatch(matches);
            ValidateGroups(matches[0].Groups);

            return matches[0].Groups;
        }

        private void ValidateMatch(MatchCollection matches)
        {
            if (!matches.Any() || matches[0].Groups.Count == 0)
                throw new ArgumentException("Input string not correct, no match with pattern.", "input");
        }
        private void ValidateGroups(GroupCollection groups)
        {
            if (groups.Count == 4 && (groups[2].Captures.Count != groups[3].Captures.Count))
                throw new Exception("Input do not have matching number of bags names and weights");
        }
    }
}
