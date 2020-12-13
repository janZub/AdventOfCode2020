using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day3
{
    public class PuzzleDay3a : PuzzleDay3
    {
        private MapDay3 inputData;
       
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            inputData = new MapDay3(input, 1, 3);
        }

        public override void Solve()
        {
            solution = solver.GetNumberOfTreesInAway(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Number of trees in the way: is {0}.", solution));
        }
    }
}