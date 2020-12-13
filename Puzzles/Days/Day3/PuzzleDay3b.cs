using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day3
{
    public class PuzzleDay3b : PuzzleDay3
    {
        protected List<MapDay3> inputData = new List<MapDay3>();

        private List<Tuple<int, int>> moves = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(1,1),
            new Tuple<int, int>(1,3),
            new Tuple<int, int>(1,5),
            new Tuple<int, int>(1,7),
            new Tuple<int, int>(2,1)
        };

        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var m in moves)
                inputData.Add(new MapDay3(input, m.Item1, m.Item2));

        }

        public override void Solve()
        {
            solution = solver.GetNumberOfTreesInAway(inputData);
        }

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Product of trees in the way: is {0}.", solution));
        }
    }
}