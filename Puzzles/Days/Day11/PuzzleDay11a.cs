﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day11
{
    public class PuzzleDay11a : PuzzleDay11
    {
        public override void ReadInput()
        {
            var seats = ProcessInputToArray();
            inputData = new AirportSeatsDay11(new CloseNeighboursStrategy(), seats);
        }
    }
}