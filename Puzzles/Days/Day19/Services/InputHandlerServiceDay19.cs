using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day19
{
    public class InputHandlerServiceDay19
    {
        private static string ruleCreationPattern = @"([\d]+):(.*)";
        public RuleDay19 CreateRule(string input)
        {
            var ruleData = Regex.Match(input, ruleCreationPattern);
            var id = int.Parse(ruleData.Groups[1].Value);
            var ruleValue = ruleData.Groups[2].Value.Replace("\"", "");
            var newRule = new RuleDay19(id, ruleValue);
            return newRule;
        }
        public void UpgradeRule8(RuleDay19 rule8)
        {
            rule8.Rule = "(" + rule8.Rule + ")+";
        }
        public void UpgradeRule11(RuleDay19 rule8)
        {
            for (int i = 2; i < 10; i++)
            {
                var duplicate42 = string.Concat(Enumerable.Repeat("42 ", i));
                var duplicate31 = string.Concat(Enumerable.Repeat("31 ", i));
                string result = duplicate42 + duplicate31;
                rule8.Rule += " | " + result;
            }
        }
    }
}
