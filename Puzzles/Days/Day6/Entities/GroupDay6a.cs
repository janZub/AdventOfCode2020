using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day6
{
    public class GroupDay6a : GroupDay6
    {
        public GroupDay6a(string data) : base(data) { }

        public override int CountDifferentAnswers()
        {
            var matches = Regex.Matches(Data, pattern);
            if (matches.Count == 0)
                return 0;

            var foundUniqueAnswers = matches.Select(e => e.Value)
                .Distinct().Count();

            return foundUniqueAnswers;
        }
    }
}