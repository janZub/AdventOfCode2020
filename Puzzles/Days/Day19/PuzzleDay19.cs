using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day19
{
    public abstract class PuzzleDay19 : Puzzle
    {
        protected ulong solution;
        protected List<string> messages = new List<string>();
        protected List<RuleDay19> rules = new List<RuleDay19>();
        protected string pattern;
        protected string inputFileileName = "Day19Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected InputHandlerServiceDay19 inputHandler = new InputHandlerServiceDay19();
        protected PuzzleSolverDay19 solver = new PuzzleSolverDay19();

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var rulesData = input.TakeWhile(s => !string.IsNullOrWhiteSpace(s)).ToList();

            foreach (var rule in rulesData)
                rules.Add(inputHandler.CreateRule(rule));

            messages = input.SkipWhile(s => !string.IsNullOrWhiteSpace(s)).Skip(1).ToList();
        }
        public override void Solve()
        {
            var rule0 = rules.First(r => r.Id == 0);

            while (rule0.CanBeSimplified())
               rule0 = solver.CreateSimplifiedRule(rule0, rules);

            rule0.CleanWhiteSpaces();
            rule0.MakeRuleToMatchWhole();

            foreach (var msg in messages)
                if (solver.IsMessageValid(rule0, msg))
                    solution++;
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid messages is {0}.", solution));
        }

    }
}