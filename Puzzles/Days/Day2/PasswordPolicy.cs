using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PasswordPolicy
    {
        public string Password { get; set; }
        public int MinOccurances { get; set; }
        public int MaxOccurances { get; set; }
        public string Letter { get; set; }

        private static string pattern = @"(\d+)-(\d+)\s([a-z]):\s([a-z]+)";

        public PasswordPolicy(string s)
        {
            var match = GetMatch(s);
            Validate(match);
            AssignMatchToProperties(match);
        }
        public PasswordPolicy() { }

        private Match GetMatch(string s)
        {
            return Regex.Match(s, pattern, RegexOptions.IgnoreCase);
        }
        private void AssignMatchToProperties(Match match)
        {
            MinOccurances = int.Parse(match.Groups[1].Value);
            MaxOccurances = int.Parse(match.Groups[2].Value);
            Letter = match.Groups[3].Value;
            Password = match.Groups[4].Value;
        }
        private void Validate(Match match)
        {
            if (!match.Success || match.Groups.Count != 5)
                throw new ArgumentException();
        }
    }
}