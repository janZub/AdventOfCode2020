using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day8
{
    public abstract class PuzzleDay8 : Puzzle
    {
        protected List<CommandDay8> inputData = new List<CommandDay8>();

        protected InputHandlerServiceDay8 inputHandler = new InputHandlerServiceDay8();
        protected PuzzleSolverDay8 solver = new PuzzleSolverDay8();
        protected string inputFileileName = "Day8Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected int solution;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
            {
                inputData.Add(inputHandler.CreateCommand(line));
            }
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Value in accumulator is {0}", solution));
        }
    }
}