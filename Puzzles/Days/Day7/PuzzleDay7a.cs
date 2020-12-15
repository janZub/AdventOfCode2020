using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day7
{
    public class PuzzleDay7a : Puzzle
    {
        protected int solution;

        protected string inputFileileName = "Day7Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected Dictionary<string, GraphNodeDay7> inputData = new Dictionary<string, GraphNodeDay7>();
        protected InputHandlerServiceDay7 inputHandler = new InputHandlerServiceDay7();
        protected PuzzleSolverDay7 solver = new PuzzleSolverDay7();

        public override void Solve()
        {
            solution = solver.FindNumberConnectedNodes(inputData, "shiny gold");
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("You can bring in shiny gold bag in {0} other colors!", solution));
        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
            {
                var node = inputHandler.CreateNode(line);
                inputData = inputHandler.AddNode(inputData, node);
            }
        }
    }
}