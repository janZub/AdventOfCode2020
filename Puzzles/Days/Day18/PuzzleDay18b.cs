using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day18
{
    public class PuzzleDay18b : PuzzleDay18
    {
        public PuzzleDay18b()
        {
            solver = new ExpressionPlusFirst();
        }
        public override void Solve()
        {
            foreach (var input in inputData)
            {
                solution += solver.Solve(input);
            }
        }
    }
}