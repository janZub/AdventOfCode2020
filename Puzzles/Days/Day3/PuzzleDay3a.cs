using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day3
{
    public class PuzzleDay3a : Puzzle
    {
        protected MapDay3a inputData;
        protected int solution;

        protected string inputFileileName = "Day3Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected virtual int numberOfComponents { get; }
        protected virtual int sumTo { get; }

        private PuzzleSolverDay3a solver = new PuzzleSolverDay3a();

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = new MapDay3a(input, 1, 3);
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of trees in the way: is {0}.",solution));
        }

        public override void Solve()
        {
            solution = solver.GetNumberOfTreesInAway(inputData);
        }
    }
}