using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day19
{
    public class PuzzleDay19a : Puzzle
    {
        protected ulong solution;
        protected List<string> messages = new List<string>();
        protected List<RuleDay19> rules = new List<RuleDay19>();
        protected string pattern;
        protected string inputFileileName = "Day19Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected string ruleCreationPattern = @"([\d]+):(.*)";

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var rulesData = input.TakeWhile(s => !string.IsNullOrWhiteSpace(s)).ToList();

            foreach (var rule in rulesData)
            {
                var ruleData = Regex.Match(rule, ruleCreationPattern);
                var id = int.Parse(ruleData.Groups[1].Value);
                var ruleValue = ruleData.Groups[2].Value.Replace("\"", "");
                var newRule = new RuleDay19(id, ruleValue);

                if(newRule.Id == 11)
                {
                    //shameless solution for 19b
                    for (int i = 2; i < 10; i++)
                    {
                        var duplicate42 = string.Concat(Enumerable.Repeat("42 ", i));
                        var duplicate31 = string.Concat(Enumerable.Repeat("31 ", i));
                        string result = duplicate42 + duplicate31;
                        newRule.Rule +=" | " + result;
}
                }

                rules.Add(newRule);
            }


            var msgs = input.SkipWhile(s => !string.IsNullOrWhiteSpace(s)).Skip(1).ToList();
            foreach (var msg in msgs)
            {
                messages.Add(msg);
            }
        }
        public override void Solve()
        {
            var rule0 = rules.First(r => r.Id == 0);

            while (true)
            {

                var rulesToReplace = rule0.GetRulesToReplace();

                if (rulesToReplace.Count == 0)
                    break;

                var aStringBuilder = new StringBuilder(rule0.Rule);
                foreach (var rule in rulesToReplace.OrderByDescending(i => i.Index))
                { 
                    var ruleReplacement = rules.First(r => r.Id == rule.Id);

                    aStringBuilder.Remove(rule.Index, rule.Id.ToString().Length);
                    aStringBuilder.Insert(rule.Index, "(" + ruleReplacement.Rule + ")");
                }
                rule0.Rule = aStringBuilder.ToString();
            }
            rule0.Rule = "^"+ Regex.Replace(rule0.Rule, @"\s+", "")+"$";

            foreach (var input in messages)
            {
                if (Regex.Match(input, rule0.Rule).Success)
                    solution++;
            }
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid messages is {0}.", solution));

        }

    }
}