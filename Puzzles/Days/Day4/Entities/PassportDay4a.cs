using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public class PassportDay4a : PassportDay4
    {
        public PassportDay4a(string lines) : base(lines) { }
        private string pattern
        {
            get =>
               string.Format(@"(({0})):", string.Join(")|(", RequiredProperties));
        }
        public override bool IsValid()
        {
            var match = GetMatch();
            var isValid = ValidateMatch(match);

            return isValid;
        }
        private MatchCollection GetMatch()
        {
            var match = Regex.Matches(Data, pattern);

            return match;
        }
        private bool ValidateMatch(MatchCollection match)
        {
            if (match.Count != RequiredProperties.Count)
                return false;

            for (int i = 0; i < RequiredProperties.Count; i++)
            {
                if (match[i].Captures.Count > 1)
                    return false;
            }

            return true;
        }
    }
}