using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles
{
    public class PuzzleDay1a : PuzzleDay1
    {
        private PuzzleDay1aSolver solver = new PuzzleDay1aSolver();
        protected override int numberOfComponents { get => 2; }
        protected override int sumTo { get => 2020; }

        //Should change PuzzleDay1aSolver to PuzzleDay1bSolver
        //Should abstract to PuzzleDay1
        public override void Solve()
        {
            solution = solver.GetNumbersThatSumToN(inputData, sumTo);
        }
    }
}