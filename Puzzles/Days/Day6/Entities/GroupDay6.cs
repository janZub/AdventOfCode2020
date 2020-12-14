using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day6
{
    public class GroupDay6
    {
        public string Data { get; private set; }

        public GroupDay6(string data)
        {
            Data = data;
        }

        public virtual int CountDifferentAnswers()
        {
            var matches = Regex.Matches(Data, pattern);
            if (matches.Count == 0)
                return 0;

            var foundUniqueAnswers = matches.Select(e => e.Value)
                .Distinct().Count();

            return foundUniqueAnswers;
        }
        private static string pattern = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
    }
}