using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day6
{
    public abstract class PuzzleDay6 : Puzzle
    {
        protected int solution;

        protected string inputFileileName = "Day6Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected List<IGroupDay6> inputData;
        protected InputHandlerServiceDay6 inputHandler = new InputHandlerServiceDay6();
        protected PuzzleSolverDay6 solver = new PuzzleSolverDay6();

        public override void Solve()
        {
            solution = solver.CountAnswersInGroups(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number answers 'yes' in groups is : {0}.", solution));
        }
    }
}