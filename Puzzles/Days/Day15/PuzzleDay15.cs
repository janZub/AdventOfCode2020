using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day15
{
    public abstract class PuzzleDay15 : Puzzle
    {
        protected ulong solution;
        protected List<int> inputData = new List<int>();
        protected PuzzleSolverDay15 solver = new PuzzleSolverDay15();
        protected string inputFileileName = "Day15Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected abstract ulong numberOfSearchedWord { get; }

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = input[0].Split(',').Select(n => int.Parse(n)).ToList();
        }

        public override void Solve()
        {
            solution = solver.SolveMemoryGame(inputData, numberOfSearchedWord);
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("The 2020th number is {0}.", solution));
        }
    }
}