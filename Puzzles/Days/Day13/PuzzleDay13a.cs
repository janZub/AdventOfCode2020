using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day13
{
    public class PuzzleDay13a : Puzzle
    {
        protected List<int> inputData = new List<int>();
        protected int departureTime;
        protected long solution;

        protected string inputFileileName = "Day13Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Bus * time to wait is {0}.", solution));
        }
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            departureTime = int.Parse(input[0]);
            foreach (var bus in input[1].Split(','))
                if (int.TryParse(bus, out int busId))
                    inputData.Add(busId);
        }
        public override void Solve()
        {
            var busesAndWaitingTime = inputData.Select(t => new Tuple<int, int>(t,t - departureTime % t));
            var busAndWaitingTime = busesAndWaitingTime.Where(t=>t.Item1 != t.Item2).OrderBy(t => t.Item2).First();
            solution = busAndWaitingTime.Item1 * busAndWaitingTime.Item2;
        }
    }
}