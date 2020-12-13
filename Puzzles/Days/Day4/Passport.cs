using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day4
{
    public class Passport
    {
        public List<string> Lines { get; }
        public Passport(List<string> lines)
        {
            this.Lines = lines;
        }
        public static List<string> RequiredProperties
        {
            get => new List<string>()
            { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        }
        public bool IsValid()
        {
            var match = GetMatch();
            var isValid = ValidateMatch(match);

            return isValid;
        }

        private static string Patterns
        {
            get =>
               string.Format(@"(({0})):", string.Join(")|(", RequiredProperties));
        }
        private MatchCollection GetMatch()
        {
            var allData = string.Join(' ', Lines);
            var match = Regex.Matches(allData, Patterns);

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