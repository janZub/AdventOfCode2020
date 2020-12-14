using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day4
{
    public abstract class PuzzleDay4 : Puzzle
    {
        protected List<IPassportDay4> inputData;
        protected int solution;

        protected PuzzleSolverDay4 solver = new PuzzleSolverDay4();
        protected InputHandlerDay4 inputHandler = new InputHandlerDay4();

        protected string inputFileileName = "Day4Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void Solve()
        {
            solution = solver.CountValidPassports(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of valid passports is {0}.", solution));
        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var passportData = inputHandler.ConvertListToPassportDataList(input);
            AssignConcretPassportsToInput(passportData);
        }
        protected abstract void AssignConcretPassportsToInput(List<string> passportData);
    }
}