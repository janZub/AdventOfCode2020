using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day2
{
    public abstract class PuzzleDay2 : Puzzle
    {
        protected int solution = 0;

        protected string inputFileileName = "Day2Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The number of valid password is: {0}.", solution));
        }
    }
}