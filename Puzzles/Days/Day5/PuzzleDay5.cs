using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day5
{
    public abstract class PuzzleDay5 : Puzzle
    {
        protected List<SeatDay5> inputData = new List<SeatDay5>();
        protected int solution;
        protected PuzzleSolverDay5 solver = new PuzzleSolverDay5();
        protected InputHandlerDay5Service inputHandler = new InputHandlerDay5Service();

        protected string inputFileileName = "Day5Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = inputHandler.CreateSeatsFromInput(input);
        }
    }
}