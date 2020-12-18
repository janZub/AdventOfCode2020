using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day12
{
    public class PuzzleDay12a : Puzzle
    {
        protected List<CommandDay12> inputData = new List<CommandDay12>();
        protected int solution;

        protected string inputFileileName = "Day12Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Manhattan distance is {0}.", solution));
        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            foreach (var line in input)
                inputData.Add(new CommandDay12(line));
        }
        public override void Solve()
        {
            var ship = new ShipDay12();
            foreach (var cmd in inputData)
                ship.ExecuteCommand(cmd);

            solution = ship.GetManhattanDistance();
        }
    }
}