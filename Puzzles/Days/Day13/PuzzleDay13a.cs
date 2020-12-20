using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day13
{
    public class PuzzleDay13a : PuzzleDay13
    {
        protected List<ulong> inputData = new List<ulong>();
        protected ulong departureTime;
        
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            departureTime = ulong.Parse(input[0]);
            foreach (var bus in input[1].Split(','))
                if (ulong.TryParse(bus, out ulong busId))
                    inputData.Add(busId);
        }
        public override void Solve()
        {
            var busesAndWaitingTime = inputData.Select(t => new Tuple<ulong, ulong>(t, t - departureTime % t));
            var busAndWaitingTime = busesAndWaitingTime.Where(t => t.Item1 != t.Item2).OrderBy(t => t.Item2).First();
            solution = busAndWaitingTime.Item1 * busAndWaitingTime.Item2;
        }
        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("Bus * time to wait is {0}.", solution));
        }
    }
}