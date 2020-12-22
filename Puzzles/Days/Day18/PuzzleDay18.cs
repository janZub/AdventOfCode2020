using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day18
{
    public abstract class PuzzleDay18 : Puzzle
    {
        protected ulong solution;
        protected List<string> inputData = new List<string>();
        protected string inputFileileName = "Day18Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected IExpressionSolver solver;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The sum is {0}.", solution));

        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input;
        }
    }
}