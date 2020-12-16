using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Utils;

namespace Puzzles.Day9
{
    public class PuzzleDay9a : Puzzle
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
        public override void Solve()
        {
            solution = solver.FindNumberThatIsNotSumOfKPreviousNumbers(new Day1.PuzzleSolverDay1(), inputData, 25);
        }
    }
}