using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PasswordPolicyDay2a : PasswordPolicyDay2
    {
        public int MinOccurences { get; set; }
        public int MaxOccurences { get; set; }
        protected override string Pattern { get => @"(\d+)-(\d+)\s([a-z]):\s([a-z]+)"; }

        public PasswordPolicyDay2a(string s) : base(s) { }
        public PasswordPolicyDay2a() { }
        protected override void AssignMatchToProperties(Match match)
        {
            MinOccurences = int.Parse(match.Groups[1].Value);
            MaxOccurences = int.Parse(match.Groups[2].Value);
            Letter = match.Groups[3].Value;
            Password = match.Groups[4].Value;
        }
        protected override void Validate(Match match)
        {
            if (!match.Success || match.Groups.Count != 5)
                throw new ArgumentException();
        }
    }
}