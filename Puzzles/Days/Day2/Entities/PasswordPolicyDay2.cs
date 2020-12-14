using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public abstract class PasswordPolicyDay2
    {
        public string Password { get; set; }
        public string Letter { get; set; }
        protected virtual string Pattern { get; }
        public PasswordPolicyDay2(string s)
        {
            var match = GetMatch(s);
            Validate(match);
            AssignMatchToProperties(match);
        }
        public PasswordPolicyDay2() { }

        private Match GetMatch(string s)
        {
            return Regex.Match(s, Pattern, RegexOptions.IgnoreCase);
        }
        protected abstract void Validate(Match match);
        protected abstract void AssignMatchToProperties(Match match);
    }
}