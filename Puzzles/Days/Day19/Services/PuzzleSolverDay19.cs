using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day19
{
    public class PuzzleSolverDay19
    {
        private static string rulePattern = @"(:?([\da-z]+)\s?)+";

        //Not very effective
        public RuleDay19 CreateSimplifiedRule(RuleDay19 rule, List<RuleDay19> rules)
        {
            var rulesToReplace = GetRulesToReplace(rule);
            var aStringBuilder = new StringBuilder(rule.Rule);

            foreach (var ruleToReplace in rulesToReplace.OrderByDescending(i => i.Index))
                ReplaceSubRule(ruleToReplace, aStringBuilder, rules);

            var newRule = aStringBuilder.ToString();
            var newRuleObject = new RuleDay19(rule.Id, newRule);

            return newRuleObject;
        }

        private StringBuilder ReplaceSubRule(RuleToReplaceDay19 ruleToReplace, StringBuilder aStringBuilder, List<RuleDay19> rules)
        {
            var ruleReplacement = rules.First(r => r.Id == ruleToReplace.Id);

            aStringBuilder.Remove(ruleToReplace.Index, ruleToReplace.Id.ToString().Length);
            aStringBuilder.Insert(ruleToReplace.Index, "(" + ruleReplacement.Rule + ")");

            return aStringBuilder;
        }
        private List<RuleToReplaceDay19> GetRulesToReplace(RuleDay19 rule)
        {
            var nestedRules = Regex.Matches(rule.Rule, rulePattern);
            return CreateNestedRules(nestedRules);
        }
        private List<RuleToReplaceDay19> CreateNestedRules(MatchCollection nestedRules)
        {
            var rulesToReplace = new List<RuleToReplaceDay19>();
            for (int i = 0; i < nestedRules.Count; i++)
            {
                var nestedRuleCaptures = nestedRules[i].Groups[1].Captures;

                for (int j = 0; j < nestedRuleCaptures.Count; j++)
                    if (nestedRuleCaptures[j].Value.Trim().All(c => char.IsDigit(c)))
                        rulesToReplace.Add(CreateRuleToReplace(nestedRuleCaptures[j]));
            }
            return rulesToReplace;
        }
        private RuleToReplaceDay19 CreateRuleToReplace(Capture capture)
        {
            var ruleToReplaceId = int.Parse(capture.Value);
            return new RuleToReplaceDay19(ruleToReplaceId, capture.Index, capture.Length);
        }

        public bool IsMessageValid(RuleDay19 rule, string message)
        {
            return Regex.Match(message, rule.Rule).Success;
        }
    }
}