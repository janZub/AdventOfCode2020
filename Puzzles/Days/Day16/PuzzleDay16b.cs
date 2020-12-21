using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day16
{
    public class PuzzleDay16b : PuzzleDay16
    {
        protected List<int> myTicket = new List<int>();
        public override void ReadInput()
        {
            var input = ReadFile();
            ReadRules(input);
            ReadMyticket(input);
            ReadTickets(input);
        }

        public override void Solve()
        {
            var validTickets = tickets.Where(t => solver.IsTicketValid(rules, t)).ToList();
            validTickets = validTickets.Prepend(myTicket).ToList();

            var rulesPerField = solver.GetValidRulesPerField(rules, validTickets);

            var rulesInOrder = solver.GetRulesOrder(rulesPerField);
            var departureRules = rules.Where(r => r.Name.StartsWith("departure")).ToList();

            solution = 1;
            foreach (var departureRule in departureRules)
            {
                var isAtIndex = rulesInOrder.IndexOf(departureRule.Name);

                Console.WriteLine(departureRule.Name + " " + isAtIndex + " " + myTicket[isAtIndex]);
                solution *= (ulong)myTicket[isAtIndex];
            }
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Sum of departure fields is {0}.", solution));
        }
        private void ReadMyticket(List<string> input)
        {
            var indexForYourTickets = input.FindIndex(s => s.StartsWith("your ticket"));

            myTicket = inputHandler.GetNewTicketValues(input[indexForYourTickets+1]);
        }
    }
}