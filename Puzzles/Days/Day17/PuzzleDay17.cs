using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day17
{
    public abstract class PuzzleDay17 : Puzzle
    {
        protected IDimension inputData;

        protected int solution;
        protected int cycles = 6;

        protected string inputFileileName = "Day17Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("There are {0} seats occupied.", solution));
        }
    }
}