using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day12
{
    public abstract class PuzzleDay12 : Puzzle
    {
        protected List<CommandDay12> inputData = new List<CommandDay12>();
        protected long solution;

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
                inputData.Add(CommandDay12.CreateCommand(line));
        }
    }
}