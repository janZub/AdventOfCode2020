﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day12
{
    public class PuzzleDay12a : PuzzleDay12
    {
        public override void Solve()
        {
            var ship = new ShipDay12a();
            foreach (var cmd in inputData)
                ship.ExecuteCommand(cmd);

            solution = ship.GetManhattanDistance();
        }
    }
}