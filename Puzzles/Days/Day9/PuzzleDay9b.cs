using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Utils;

namespace Puzzles.Day9
{
    public class PuzzleDay9b : PuzzleDay9
    {
        public override void Solve()
        {
            solution = solver.FindContiguousSetThatSumToN(inputData, 144381670);
        }
    }
}