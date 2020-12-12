using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PasswordPolicyDay2b : PasswordPolicyDay2
    {
        public List<int> Occurrences { get; set; }
        protected override string Pattern { get => @"(\d+-)+(\d+)\s([a-z]):\s([a-z]+)"; }

        public PasswordPolicyDay2b(string s) : base(s) { }
        public PasswordPolicyDay2b() { }
        protected override void AssignMatchToProperties(Match match)
        {
            Occurrences = GetOccurances(match);
            Letter = match.Groups[3].Value;
            Password = match.Groups[4].Value;
        }
        protected override void Validate(Match match)
        {
            if (!match.Success || match.Groups.Count != 5)
                throw new ArgumentException();
        }

        private List<int> GetOccurances(Match match)
        {
            var occurreneces = new List<int>();
            var matchesWithFromGroup1 = match.Groups[1].Captures;
            for (int i = 0; i < matchesWithFromGroup1.Count; i++)
                occurreneces.Add(GetPosition(matchesWithFromGroup1[i].Value));

            occurreneces.Add(GetPosition(match.Groups[2].Value));
            return occurreneces;

        }
        private int GetPosition(string s)
        {
            return int.Parse(s.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}