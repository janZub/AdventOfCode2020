using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day3
{
    public abstract class PuzzleDay3 : Puzzle
    {
        protected long solution;
        protected PuzzleSolverDay3 solver = new PuzzleSolverDay3();

        protected string inputFileileName = "Day3Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
    }
}