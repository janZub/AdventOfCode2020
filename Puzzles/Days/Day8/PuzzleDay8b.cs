using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day8
{
    public class PuzzleDay8b : PuzzleDay8
    {
        public override void Solve()
        {
            var nodeCausingMalfunction = solver.FindCommandThatCauseInfiniteLoopData(inputData);
            nodeCausingMalfunction.ChangeCommand();            
            solution = solver.CountAccumulator(inputData);
        }
    }
}