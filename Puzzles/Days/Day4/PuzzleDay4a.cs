﻿using System.Collections.Generic;

namespace Puzzles.Day4
{
    public class PuzzleDay4a : PuzzleDay4
    {
        protected override void AssignConcretPassportsToInput(List<string> passportData)
        {
            inputData = inputHandler.CreatePassports4aFromInput(passportData);
        }
    }
}