using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day6
{
    public class PuzzleDay6a : Puzzle
    {
        protected int solution;

        protected string inputFileileName = "Day6Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected List<GroupDay6> inputData;
        private InputHandlerServiceDay6 inputHandler = new InputHandlerServiceDay6();
        private PuzzleSolverDay6 solver = new PuzzleSolverDay6();
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var groupsData = inputHandler.ConvertListToGroupDataList(input);
            inputData = inputHandler.CreateGroupsFromInput(groupsData);
        }
        public override void Solve()
        {
            solution = solver.CountAnswersInGroups(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number ansers 'yes' in groups is : {0}.", solution));
        }
    }
}