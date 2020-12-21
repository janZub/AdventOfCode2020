using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day16
{
    public abstract class PuzzleDay16 : Puzzle
    {
        protected ulong solution;
        protected List<List<int>> tickets = new List<List<int>>();
        protected List<RuleDay16> rules = new List<RuleDay16>();
        protected PuzzleSolverDay16 solver = new PuzzleSolverDay16();
        protected InputHandlerServiceDay16 inputHandler = new InputHandlerServiceDay16();
        protected string inputFileileName = "Day16Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        protected List<string> ReadFile()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            return input;
        }
        protected void ReadRules(List<string> input)
        {
            var indexForEndOfRulesRules = input.FindIndex(s => string.IsNullOrWhiteSpace(s));

            foreach (var rule in input.Take(indexForEndOfRulesRules))
            {
                var newRule = inputHandler.GetNewRule(rule);
                rules.Add(newRule);
            }
        }
        protected void ReadTickets(List<string> input)
        {
            var indexForTickets = input.FindIndex(s => s.StartsWith("nearby tickets"));

            foreach (var ticket in input.Skip(indexForTickets + 1))
            {
                var newTicket = inputHandler.GetNewTicketValues(ticket);
                tickets.Add(newTicket);
            }
        }

    }
}