using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day7
{
    public abstract class PuzzleDay7 : Puzzle
    {
        protected Dictionary<string, GraphNodeDay7> inputData = new Dictionary<string, GraphNodeDay7>();

        protected InputHandlerServiceDay7 inputHandler = new InputHandlerServiceDay7();
        protected PuzzleSolverDay7 solver = new PuzzleSolverDay7();
        protected string inputFileileName = "Day7Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected long solution;

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
            {
                var node = inputHandler.CreateNodeWithNodesBelow(line);
                inputData = inputHandler.AddNode(inputData, node);
            }
        }
    }
}