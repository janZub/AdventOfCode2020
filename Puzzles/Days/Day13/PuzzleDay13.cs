﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day13
{
    public abstract class PuzzleDay13 : Puzzle
    {
        protected ulong solution;

        protected string inputFileileName = "Day13Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Bus * time to wait is {0}.", solution));
        }
    }
}