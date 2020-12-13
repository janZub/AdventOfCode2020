using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day4
{
    public class PuzzleDay4a : Puzzle
    {
        private List<Passport> inputData;
        protected int solution;

        private PuzzleSolverDay4a solver = new PuzzleSolverDay4a();
        private InputHandlerDay4a inputHandler = new InputHandlerDay4a();

        protected string inputFileileName = "Day4Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = inputHandler.CreatePassporsFromInput(input);
        }

        public override void Solve()
        {
            solution = solver.CountValidPassports(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid passports is {0}.", solution));
        }
    }
}