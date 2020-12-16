﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Utils;

namespace Puzzles.Day9
{
    public class PuzzleDay9a : PuzzleDay9
    { 
        public override void Solve()
        {
            solution = solver.FindNumberThatIsNotSumOfKPreviousNumbers(new Day1.PuzzleSolverDay1(), inputData, 25);
        }
    }
}