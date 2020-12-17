using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day10
{
    public abstract class PuzzleDay10 : Puzzle
    {
        protected private PuzzleSolverDay10 solver = new PuzzleSolverDay10();
        protected List<int> inputData = new List<int>();
        protected ulong solution;

        protected string inputFileileName = "Day10Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input.Select(i => int.Parse(i)).ToList();
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("1-jolt differences * 3-jolt differencees is {0}", solution));
        }
    }
}