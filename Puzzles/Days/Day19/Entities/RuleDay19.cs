using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day19
{
    public class RuleDay19
    {
        public string Rule { get; set; }
        public int Id { get; private set; }

        public RuleDay19(int id, string rule)
        {
            Id = id;
            Rule = rule;
        }

        public bool CanBeSimplified()
        {
            return Rule.Any(c=>char.IsDigit(c));
        }
        public void CleanWhiteSpaces()
        {
            Rule = Regex.Replace(Rule, @"\s+", "");
        }
        public void MakeRuleToMatchWhole()
        {
            Rule = "^" + Rule + "$";
        }
    }
}