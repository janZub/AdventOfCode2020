using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day19
{
    public class RuleDay19
    {
        private static string rulePattern = @"(:?([\da-z]+)\s?)+";

        public string Rule { get; set; }
        public int Id { get; private set; }



        public RuleDay19(int id, string rule)
        {
            Id = id;
            Rule = rule;
        }

        public List<RuleToReplaceDay19> GetRulesToReplace()
        {
            var rulesToReplace = new List<RuleToReplaceDay19>();

            var nestedRules = Regex.Matches(Rule, rulePattern);
            for (int i=0;i < nestedRules.Count;i++)
            {
                var nestedRuleCaptures = nestedRules[i].Groups[1].Captures;
                for (int j=0; j < nestedRuleCaptures.Count; j++) 
                {
                    var capture = nestedRuleCaptures[j];
                   
                    if (int.TryParse(capture.Value, out int ruleToReplaceId))
                    {
                        var ruleToReplace = new RuleToReplaceDay19(ruleToReplaceId, capture.Index, capture.Length);
                        rulesToReplace.Add(ruleToReplace);
                    }
                       
                }
            }

            return rulesToReplace;
        }
    }
}