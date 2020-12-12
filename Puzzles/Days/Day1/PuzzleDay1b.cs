using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles
{
    public class PuzzleDay1b : PuzzleDay1
    {
        private PuzzleDay1bSolver solver = new PuzzleDay1bSolver();
        protected override int numberOfComponents { get => 3; }
        protected override int sumTo { get => 2020; }

        //Should abstract to PuzzleDay1
        public override void Solve()
        {
            solution = solver.GetKNumbersThatSumToN(inputData, numberOfComponents, sumTo);
        }
    }
}