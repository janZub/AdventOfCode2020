using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day10
{
    public class PuzzleDay10b : PuzzleDay10
    {
        public override void Solve()
        {
            solution = solver.GetNumberOfPossibleCombinations(inputData);
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("There is {0} possible combinations", solution));
        }
    }
}