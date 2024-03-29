﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day10
{
    public class PuzzleDay10a : PuzzleDay10
    {
        public override void Solve()
        {
            solution = solver.GetProductOfJoltDifferences(inputData);
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("1-jolt differences * 3-jolt differencees is {0}", solution));
        }
    }
}