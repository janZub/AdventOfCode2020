﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day8
{
    public class PuzzleDay8a : PuzzleDay8
    {
        public override void Solve()
        {
            solution = solver.CountAccumulator(inputData);
        }
    }
}