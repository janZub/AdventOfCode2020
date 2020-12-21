using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day16
{
    public class PuzzleDay16a : PuzzleDay16
    {
        public override void ReadInput()
        {
            var input = ReadFile();
            ReadRules(input);
            ReadTickets(input);
        }

        public override void Solve()
        {
            solution = solver.GetInvalidNumbers(rules, tickets);
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Sum of the invalid numbers is: {0}.", solution));
        }
    }
}