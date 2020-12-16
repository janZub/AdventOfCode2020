using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Utils;

namespace Puzzles.Day9
{
    public abstract class PuzzleDay9 : Puzzle
    {
        protected List<ulong> inputData = new List<ulong>();

        protected PuzzleSolverDay9 solver = new PuzzleSolverDay9();
        protected string inputFileileName = "Day9Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected ulong solution;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            foreach (var line in input)
            {
                inputData.Add(ulong.Parse(line));
            }
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The number is: {0}", solution));
        }
    }
}